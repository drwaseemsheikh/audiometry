using System;
using System.Collections.Generic;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Documents;
using System.Windows.Markup;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Threading;
using Audiometry.Image;
using Audiometry.ViewModel.BithermalCaloricVM;
using Audiometry.ViewModel.PureToneVM.Audiogram;
using OxyPlot;
using HorizontalAlignment = System.Windows.HorizontalAlignment;
using VerticalAlignment = System.Windows.VerticalAlignment;

namespace Audiometry.Print
{
    public static class PrintUtility
    {
        public static childItem FindVisualChild<childItem>(DependencyObject obj) where childItem : DependencyObject
        {
            for (int i = 0; i <= VisualTreeHelper.GetChildrenCount(obj) - 1; i++)
            {
                DependencyObject child = VisualTreeHelper.GetChild(obj, i);

                if (child != null && child is childItem)
                    return (childItem)child;
                else
                {
                    childItem childOfChild = FindVisualChild<childItem>(child);

                    if (childOfChild != null)
                        return childOfChild;
                }
            }

            return null;
        }

        public static T FindFirstChild<T>(FrameworkElement element) where T : FrameworkElement
        {
            int childrenCount = VisualTreeHelper.GetChildrenCount(element);
            var children = new FrameworkElement[childrenCount];

            for (int i = 0; i < childrenCount; i++)
            {
                var child = VisualTreeHelper.GetChild(element, i) as FrameworkElement;
                children[i] = child;
                if (child is T)
                    return (T)child;
            }

            for (int i = 0; i < childrenCount; i++)
                if (children[i] != null)
                {
                    var subChild = FindFirstChild<T>(children[i]);
                    if (subChild != null)
                        return subChild;
                }

            return null;
        }

        public static IEnumerable<T> FindVisualChildren<T>(DependencyObject depObj)
       where T : DependencyObject
        {
            if (depObj != null)
            {
                for (int i = 0; i < VisualTreeHelper.GetChildrenCount(depObj); i++)
                {
                    DependencyObject child = VisualTreeHelper.GetChild(depObj, i);
                    if (child != null && child is T)
                    {
                        yield return (T)child;
                    }

                    foreach (T childOfChild in FindVisualChildren<T>(child))
                    {
                        yield return childOfChild;
                    }
                }
            }
        }

        public static childItem FindVisualChild2<childItem>(DependencyObject obj)
            where childItem : DependencyObject
        {
            foreach (childItem child in FindVisualChildren<childItem>(obj))
            {
                return child;
            }

            return null;
        }

        private static System.Windows.Controls.Image ConvertControlToImage(FrameworkElement control, Size newSize)
        {
            Size origSize = new Size(control.ActualWidth, control.ActualHeight);
            //Size newSize = new Size(8.26 * 96, 11.69 * 96);
            System.Windows.VerticalAlignment origVerAlign = control.VerticalAlignment;
            System.Windows.HorizontalAlignment origHorAlign = control.HorizontalAlignment;
            control.VerticalAlignment = VerticalAlignment.Top;
            control.HorizontalAlignment = HorizontalAlignment.Left;
            control.Measure(newSize);
            control.Arrange(new Rect(newSize));
            control.UpdateLayout();
            RenderTargetBitmap rtbmp = new RenderTargetBitmap((int)newSize.Width, (int)newSize.Height, 96, 96, PixelFormats.Pbgra32);
            rtbmp.Render(control);
            var bitmapImage = new BitmapImage();
            var bitmapEncoder = new PngBitmapEncoder();
            bitmapEncoder.Frames.Add(BitmapFrame.Create(rtbmp));

            using (var stream = new System.IO.MemoryStream())
            {
                bitmapEncoder.Save(stream);
                stream.Seek(0, System.IO.SeekOrigin.Begin);
                bitmapImage.BeginInit();
                bitmapImage.CacheOption = BitmapCacheOption.OnLoad;
                bitmapImage.StreamSource = stream;
                bitmapImage.EndInit();
            }

            System.Windows.Controls.Image img = new System.Windows.Controls.Image();
            img.Source = bitmapImage;

            //restore original control layout
            control.VerticalAlignment = origVerAlign;
            control.HorizontalAlignment = origHorAlign;
            control.Measure(origSize);
            control.Arrange(new Rect(origSize));
            control.UpdateLayout();

            return img;
        }

        public static PageContent CreatePrintPageContent(Size pageSize, List<PrintVisual> specialTestsCtrls, string heading)
        {
            var page = new FixedPage { Width = pageSize.Width, Height = pageSize.Height };
            StackPanel stack = new StackPanel();

            foreach (PrintVisual pv in specialTestsCtrls)
            {
                System.Windows.Controls.Image img = ConvertControlToImage(pv.Control, pv.Size);
                GroupBox panelGrpBox = new GroupBox();
                panelGrpBox.Header = pv.Heading;
                panelGrpBox.Content = img;
                stack.Children.Add(panelGrpBox);
            }

            GroupBox grpBox = new GroupBox();
            grpBox.Header = heading;
            grpBox.Content = stack;
            page.Children.Add(grpBox);
            page.Measure(pageSize);
            page.Arrange(new Rect(new Point(), pageSize));
            page.UpdateLayout();
            var pageContent = new PageContent();
            ((IAddChild)pageContent).AddChild(page);
            return pageContent;            
        }

        public static PageContent CreatePrintPageContent(Size pageSize, FrameworkElement tabCtrlCanvas, 
            TabControl tabCtrl, int startIndex, int endIndex, string header)
        {
            var page = new FixedPage { Width = pageSize.Width, Height = pageSize.Height };
            Size panelSize = new Size {Width = pageSize.Width, Height = pageSize.Height/(endIndex - startIndex + 1)};
            StackPanel stack = new StackPanel();

            for (int i = startIndex; i <= endIndex; i++)
            {
                tabCtrl.SelectedIndex = i;
                tabCtrl.SelectedItem = tabCtrl.Items[i];
                tabCtrl.Measure(tabCtrl.RenderSize);
                tabCtrl.Arrange(new Rect(tabCtrl.RenderSize));
                tabCtrl.UpdateLayout();
                System.Windows.Controls.Image img = ConvertControlToImage(tabCtrlCanvas, panelSize);
                stack.Children.Add(img);
            }

            GroupBox grpBox = new GroupBox();
            grpBox.Header = header;
            grpBox.Content = stack;
            page.Children.Add(grpBox);
            page.Measure(pageSize);
            page.Arrange(new Rect(new Point(), pageSize));
            page.UpdateLayout();
            var pageContent = new PageContent();
            ((IAddChild)pageContent).AddChild(page);
            return pageContent;
        }

        public static PageContent CreatePrintPageContent(Size pageSize, FrameworkElement ctrl, string header)
        {
            var page = new FixedPage { Width = pageSize.Width, Height = pageSize.Height };
            System.Windows.Controls.Image img = ConvertControlToImage(ctrl, pageSize);
            GroupBox grpBox = new GroupBox();
            grpBox.Header = header;
            grpBox.Content = img;
            page.Children.Add(grpBox);
            page.Measure(pageSize);
            page.Arrange(new Rect(new Point(), pageSize));
            page.UpdateLayout();
            var firstPageContent = new PageContent();
            ((IAddChild)firstPageContent).AddChild(page);
            return firstPageContent;
        }

        public static PageContent CreatePrintPageContentOxyPlot(Size pageSize, PlotModel plot, int width, int height, string header)
        {
            var page = new FixedPage { Width = pageSize.Width, Height = pageSize.Height };
            BitmapSource plotBitmapSrc = ImageUtility.ExportToBitmap(plot, width, height, OxyColors.Transparent, 96);
            System.Windows.Controls.Image img = new System.Windows.Controls.Image();
            img.Source = plotBitmapSrc;
            GroupBox grpBox = new GroupBox();
            grpBox.Header = header;
            grpBox.Content = img;
            page.Children.Add(grpBox);
            page.Measure(pageSize);
            page.Arrange(new Rect(new Point(), pageSize));
            page.UpdateLayout();
            var firstPageContent = new PageContent();
            ((IAddChild)firstPageContent).AddChild(page);
            return firstPageContent;
        }

        public static PageContent CreatePrintPageContentOxyPlot(Size pageSize, AudiogramPlot audiogramPlot, 
            int width, int height, string header)
        {
            return CreatePrintPageContentOxyPlot(pageSize, AudiogramPlot.PlotModel, width, height, header);
        }

        public static PageContent CreatePrintPageContentOxyPlot(Size pageSize, BithermalCaloricTabVM caloricVM, int width, int height, string header)
        {
            var page = new FixedPage { Width = pageSize.Width, Height = pageSize.Height };
            BitmapSource plotBmp30 = ImageUtility.ExportToBitmap(caloricVM.Calorigram30, width, height, OxyColors.Transparent, 96);

            StackPanel caloricPanel = new StackPanel();
            System.Windows.Controls.Image img30 = new System.Windows.Controls.Image();
            img30.Source = plotBmp30;
            caloricPanel.Children.Add(img30);
            BitmapSource plotBmp44 = ImageUtility.ExportToBitmap(caloricVM.Calorigram44, width, height, OxyColors.Transparent, 96);
            System.Windows.Controls.Image img44 = new System.Windows.Controls.Image();
            img44.Source = plotBmp44;
            caloricPanel.Children.Add(img44);
            GroupBox grpBox = new GroupBox();
            grpBox.Header = header;
            grpBox.Content = caloricPanel;
            page.Children.Add(grpBox);
            page.Measure(pageSize);
            page.Arrange(new Rect(new Point(), pageSize));
            page.UpdateLayout();
            var firstPageContent = new PageContent();
            ((IAddChild)firstPageContent).AddChild(page);
            return firstPageContent;
        }

        public static void RestoreTab(TabControl tabCtrl, int tabIndex)
        {
            if (tabIndex < tabCtrl.Items.Count)
            {
                DispatcherTimer switchTabTimer = new DispatcherTimer();
                switchTabTimer.Interval = new TimeSpan(0);
                switchTabTimer.Tick += (object timerSender, EventArgs timerE) =>
                {
                    tabCtrl.SelectedIndex = tabIndex;
                    switchTabTimer.Stop();
                };

                switchTabTimer.Start();
            }
        }
        public static void CycleThroughTabs(TabControl tabCtrl)
        {
            int selIndex = tabCtrl.SelectedIndex;
            int numTabs = tabCtrl.Items.Count;

            int count = 0;
            int newSelIndex = (selIndex + 1) % numTabs;

            while (count < numTabs)
            {
                SelectTab(tabCtrl, newSelIndex);
                newSelIndex = (newSelIndex + 1) % numTabs;

                count++;
            }
        }

        public static void SelectTab(TabControl tabCtrl, int tabIndex)
        {
            DispatcherTimer switchTabTimer = new DispatcherTimer();
            switchTabTimer.Interval = new TimeSpan(0);
            switchTabTimer.Tick += (object timerSender, EventArgs timerE) =>
            {
                tabCtrl.SelectedIndex = tabIndex;
                tabCtrl.SelectedItem = tabCtrl.Items[tabIndex];
                switchTabTimer.Stop();
            };

            switchTabTimer.Start();
        }
    }
}
