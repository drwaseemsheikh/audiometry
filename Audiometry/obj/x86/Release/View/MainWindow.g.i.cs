﻿#pragma checksum "..\..\..\..\View\MainWindow.xaml" "{406ea660-64cf-4c82-b6f0-42d48172a799}" "D13C6E3B87A2519AF0FBC0F4817A5615"
//------------------------------------------------------------------------------
// <auto-generated>
//     This code was generated by a tool.
//     Runtime Version:4.0.30319.34209
//
//     Changes to this file may cause incorrect behavior and will be lost if
//     the code is regenerated.
// </auto-generated>
//------------------------------------------------------------------------------

using Audiometry.Audiogram;
using Audiometry.Helper;
using Audiometry.PatientData;
using Audiometry.PureToneAMData;
using Audiometry.Validation;
using Audiometry.ViewModel;
using Audiometry.ViewModel.SpecialTestsVM;
using OxyPlot.Wpf;
using System;
using System.Diagnostics;
using System.Windows;
using System.Windows.Automation;
using System.Windows.Controls;
using System.Windows.Controls.Primitives;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Ink;
using System.Windows.Input;
using System.Windows.Markup;
using System.Windows.Media;
using System.Windows.Media.Animation;
using System.Windows.Media.Effects;
using System.Windows.Media.Imaging;
using System.Windows.Media.Media3D;
using System.Windows.Media.TextFormatting;
using System.Windows.Navigation;
using System.Windows.Shapes;
using System.Windows.Shell;
using Xceed.Wpf.Toolkit;


namespace Audiometry.View {
    
    
    /// <summary>
    /// MainWindow
    /// </summary>
    public partial class MainWindow : System.Windows.Window, System.Windows.Markup.IComponentConnector, System.Windows.Markup.IStyleConnector {
        
        
        #line 514 "..\..\..\..\View\MainWindow.xaml"
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1823:AvoidUnusedPrivateFields")]
        internal System.Windows.Controls.ListBox lbSymptoms;
        
        #line default
        #line hidden
        
        
        #line 520 "..\..\..\..\View\MainWindow.xaml"
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1823:AvoidUnusedPrivateFields")]
        internal System.Windows.Controls.ListBox lbDiagnosis;
        
        #line default
        #line hidden
        
        
        #line 538 "..\..\..\..\View\MainWindow.xaml"
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1823:AvoidUnusedPrivateFields")]
        internal System.Windows.Controls.GroupBox pureToneGrpBox;
        
        #line default
        #line hidden
        
        
        #line 541 "..\..\..\..\View\MainWindow.xaml"
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1823:AvoidUnusedPrivateFields")]
        internal System.Windows.Controls.CheckBox isPureToneTestConducted;
        
        #line default
        #line hidden
        
        
        #line 675 "..\..\..\..\View\MainWindow.xaml"
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1823:AvoidUnusedPrivateFields")]
        internal System.Windows.Controls.CheckBox isSpecialTestConducted;
        
        #line default
        #line hidden
        
        
        #line 701 "..\..\..\..\View\MainWindow.xaml"
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1823:AvoidUnusedPrivateFields")]
        internal System.Windows.Controls.ComboBox RightEar1;
        
        #line default
        #line hidden
        
        
        #line 715 "..\..\..\..\View\MainWindow.xaml"
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1823:AvoidUnusedPrivateFields")]
        internal System.Windows.Controls.ComboBox RightEar2;
        
        #line default
        #line hidden
        
        
        #line 729 "..\..\..\..\View\MainWindow.xaml"
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1823:AvoidUnusedPrivateFields")]
        internal System.Windows.Controls.ComboBox RightEar3;
        
        #line default
        #line hidden
        
        
        #line 743 "..\..\..\..\View\MainWindow.xaml"
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1823:AvoidUnusedPrivateFields")]
        internal System.Windows.Controls.ComboBox RightEar4;
        
        #line default
        #line hidden
        
        
        #line 757 "..\..\..\..\View\MainWindow.xaml"
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1823:AvoidUnusedPrivateFields")]
        internal System.Windows.Controls.ComboBox RightEar5;
        
        #line default
        #line hidden
        
        
        #line 771 "..\..\..\..\View\MainWindow.xaml"
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1823:AvoidUnusedPrivateFields")]
        internal System.Windows.Controls.ComboBox RightEar6;
        
        #line default
        #line hidden
        
        
        #line 785 "..\..\..\..\View\MainWindow.xaml"
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1823:AvoidUnusedPrivateFields")]
        internal System.Windows.Controls.ComboBox RightEar7;
        
        #line default
        #line hidden
        
        
        #line 799 "..\..\..\..\View\MainWindow.xaml"
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1823:AvoidUnusedPrivateFields")]
        internal System.Windows.Controls.ComboBox RightEar8;
        
        #line default
        #line hidden
        
        
        #line 813 "..\..\..\..\View\MainWindow.xaml"
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1823:AvoidUnusedPrivateFields")]
        internal System.Windows.Controls.ComboBox RightEar9;
        
        #line default
        #line hidden
        
        
        #line 827 "..\..\..\..\View\MainWindow.xaml"
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1823:AvoidUnusedPrivateFields")]
        internal System.Windows.Controls.ComboBox RightEar10;
        
        #line default
        #line hidden
        
        
        #line 842 "..\..\..\..\View\MainWindow.xaml"
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1823:AvoidUnusedPrivateFields")]
        internal System.Windows.Controls.ComboBox LeftEar1;
        
        #line default
        #line hidden
        
        
        #line 856 "..\..\..\..\View\MainWindow.xaml"
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1823:AvoidUnusedPrivateFields")]
        internal System.Windows.Controls.ComboBox LeftEar2;
        
        #line default
        #line hidden
        
        
        #line 870 "..\..\..\..\View\MainWindow.xaml"
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1823:AvoidUnusedPrivateFields")]
        internal System.Windows.Controls.ComboBox LeftEar3;
        
        #line default
        #line hidden
        
        
        #line 884 "..\..\..\..\View\MainWindow.xaml"
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1823:AvoidUnusedPrivateFields")]
        internal System.Windows.Controls.ComboBox LeftEar4;
        
        #line default
        #line hidden
        
        
        #line 898 "..\..\..\..\View\MainWindow.xaml"
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1823:AvoidUnusedPrivateFields")]
        internal System.Windows.Controls.ComboBox LeftEar5;
        
        #line default
        #line hidden
        
        
        #line 912 "..\..\..\..\View\MainWindow.xaml"
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1823:AvoidUnusedPrivateFields")]
        internal System.Windows.Controls.ComboBox LeftEar6;
        
        #line default
        #line hidden
        
        
        #line 926 "..\..\..\..\View\MainWindow.xaml"
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1823:AvoidUnusedPrivateFields")]
        internal System.Windows.Controls.ComboBox LeftEar7;
        
        #line default
        #line hidden
        
        
        #line 940 "..\..\..\..\View\MainWindow.xaml"
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1823:AvoidUnusedPrivateFields")]
        internal System.Windows.Controls.ComboBox LeftEar8;
        
        #line default
        #line hidden
        
        
        #line 954 "..\..\..\..\View\MainWindow.xaml"
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1823:AvoidUnusedPrivateFields")]
        internal System.Windows.Controls.ComboBox LeftEar9;
        
        #line default
        #line hidden
        
        
        #line 968 "..\..\..\..\View\MainWindow.xaml"
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1823:AvoidUnusedPrivateFields")]
        internal System.Windows.Controls.ComboBox LeftEar10;
        
        #line default
        #line hidden
        
        
        #line 1053 "..\..\..\..\View\MainWindow.xaml"
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1823:AvoidUnusedPrivateFields")]
        internal System.Windows.Controls.CheckBox isTuningForkTestConducted;
        
        #line default
        #line hidden
        
        
        #line 1190 "..\..\..\..\View\MainWindow.xaml"
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1823:AvoidUnusedPrivateFields")]
        internal System.Windows.Controls.CheckBox isSpeechTestConducted;
        
        #line default
        #line hidden
        
        
        #line 1338 "..\..\..\..\View\MainWindow.xaml"
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1823:AvoidUnusedPrivateFields")]
        internal System.Windows.Controls.CheckBox isImpedanceTestConducted;
        
        #line default
        #line hidden
        
        
        #line 1403 "..\..\..\..\View\MainWindow.xaml"
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1823:AvoidUnusedPrivateFields")]
        internal System.Windows.Controls.CheckBox isBithermalCaloricTestConducted;
        
        #line default
        #line hidden
        
        private bool _contentLoaded;
        
        /// <summary>
        /// InitializeComponent
        /// </summary>
        [System.Diagnostics.DebuggerNonUserCodeAttribute()]
        [System.CodeDom.Compiler.GeneratedCodeAttribute("PresentationBuildTasks", "4.0.0.0")]
        public void InitializeComponent() {
            if (_contentLoaded) {
                return;
            }
            _contentLoaded = true;
            System.Uri resourceLocater = new System.Uri("/Audiometry;component/view/mainwindow.xaml", System.UriKind.Relative);
            
            #line 1 "..\..\..\..\View\MainWindow.xaml"
            System.Windows.Application.LoadComponent(this, resourceLocater);
            
            #line default
            #line hidden
        }
        
        [System.Diagnostics.DebuggerNonUserCodeAttribute()]
        [System.CodeDom.Compiler.GeneratedCodeAttribute("PresentationBuildTasks", "4.0.0.0")]
        [System.ComponentModel.EditorBrowsableAttribute(System.ComponentModel.EditorBrowsableState.Never)]
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Design", "CA1033:InterfaceMethodsShouldBeCallableByChildTypes")]
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Maintainability", "CA1502:AvoidExcessiveComplexity")]
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1800:DoNotCastUnnecessarily")]
        void System.Windows.Markup.IComponentConnector.Connect(int connectionId, object target) {
            switch (connectionId)
            {
            case 1:
            
            #line 15 "..\..\..\..\View\MainWindow.xaml"
            ((Audiometry.View.MainWindow)(target)).Closing += new System.ComponentModel.CancelEventHandler(this.Window_Closing);
            
            #line default
            #line hidden
            return;
            case 21:
            
            #line 402 "..\..\..\..\View\MainWindow.xaml"
            ((System.Windows.Controls.Button)(target)).Click += new System.Windows.RoutedEventHandler(this.PrintBtn_Click);
            
            #line default
            #line hidden
            return;
            case 22:
            this.lbSymptoms = ((System.Windows.Controls.ListBox)(target));
            return;
            case 23:
            this.lbDiagnosis = ((System.Windows.Controls.ListBox)(target));
            return;
            case 24:
            this.pureToneGrpBox = ((System.Windows.Controls.GroupBox)(target));
            return;
            case 25:
            this.isPureToneTestConducted = ((System.Windows.Controls.CheckBox)(target));
            return;
            case 26:
            this.isSpecialTestConducted = ((System.Windows.Controls.CheckBox)(target));
            return;
            case 27:
            this.RightEar1 = ((System.Windows.Controls.ComboBox)(target));
            return;
            case 28:
            this.RightEar2 = ((System.Windows.Controls.ComboBox)(target));
            return;
            case 29:
            this.RightEar3 = ((System.Windows.Controls.ComboBox)(target));
            return;
            case 30:
            this.RightEar4 = ((System.Windows.Controls.ComboBox)(target));
            return;
            case 31:
            this.RightEar5 = ((System.Windows.Controls.ComboBox)(target));
            return;
            case 32:
            this.RightEar6 = ((System.Windows.Controls.ComboBox)(target));
            return;
            case 33:
            this.RightEar7 = ((System.Windows.Controls.ComboBox)(target));
            return;
            case 34:
            this.RightEar8 = ((System.Windows.Controls.ComboBox)(target));
            return;
            case 35:
            this.RightEar9 = ((System.Windows.Controls.ComboBox)(target));
            return;
            case 36:
            this.RightEar10 = ((System.Windows.Controls.ComboBox)(target));
            return;
            case 37:
            this.LeftEar1 = ((System.Windows.Controls.ComboBox)(target));
            return;
            case 38:
            this.LeftEar2 = ((System.Windows.Controls.ComboBox)(target));
            return;
            case 39:
            this.LeftEar3 = ((System.Windows.Controls.ComboBox)(target));
            return;
            case 40:
            this.LeftEar4 = ((System.Windows.Controls.ComboBox)(target));
            return;
            case 41:
            this.LeftEar5 = ((System.Windows.Controls.ComboBox)(target));
            return;
            case 42:
            this.LeftEar6 = ((System.Windows.Controls.ComboBox)(target));
            return;
            case 43:
            this.LeftEar7 = ((System.Windows.Controls.ComboBox)(target));
            return;
            case 44:
            this.LeftEar8 = ((System.Windows.Controls.ComboBox)(target));
            return;
            case 45:
            this.LeftEar9 = ((System.Windows.Controls.ComboBox)(target));
            return;
            case 46:
            this.LeftEar10 = ((System.Windows.Controls.ComboBox)(target));
            return;
            case 47:
            this.isTuningForkTestConducted = ((System.Windows.Controls.CheckBox)(target));
            return;
            case 48:
            this.isSpeechTestConducted = ((System.Windows.Controls.CheckBox)(target));
            return;
            case 49:
            this.isImpedanceTestConducted = ((System.Windows.Controls.CheckBox)(target));
            return;
            case 50:
            this.isBithermalCaloricTestConducted = ((System.Windows.Controls.CheckBox)(target));
            return;
            }
            this._contentLoaded = true;
        }
        
        [System.Diagnostics.DebuggerNonUserCodeAttribute()]
        [System.CodeDom.Compiler.GeneratedCodeAttribute("PresentationBuildTasks", "4.0.0.0")]
        [System.ComponentModel.EditorBrowsableAttribute(System.ComponentModel.EditorBrowsableState.Never)]
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Design", "CA1033:InterfaceMethodsShouldBeCallableByChildTypes")]
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1800:DoNotCastUnnecessarily")]
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Maintainability", "CA1502:AvoidExcessiveComplexity")]
        void System.Windows.Markup.IStyleConnector.Connect(int connectionId, object target) {
            System.Windows.EventSetter eventSetter;
            switch (connectionId)
            {
            case 2:
            eventSetter = new System.Windows.EventSetter();
            eventSetter.Event = System.Windows.UIElement.GotKeyboardFocusEvent;
            
            #line 61 "..\..\..\..\View\MainWindow.xaml"
            eventSetter.Handler = new System.Windows.Input.KeyboardFocusChangedEventHandler(this.TextBox_GotKeyboardFocus);
            
            #line default
            #line hidden
            ((System.Windows.Style)(target)).Setters.Add(eventSetter);
            break;
            case 3:
            
            #line 108 "..\..\..\..\View\MainWindow.xaml"
            ((System.Windows.Controls.TextBox)(target)).LostFocus += new System.Windows.RoutedEventHandler(this.HLTextBox_LostFocus);
            
            #line default
            #line hidden
            break;
            case 4:
            
            #line 123 "..\..\..\..\View\MainWindow.xaml"
            ((System.Windows.Controls.TextBox)(target)).LostFocus += new System.Windows.RoutedEventHandler(this.HLTextBox_LostFocus);
            
            #line default
            #line hidden
            break;
            case 5:
            
            #line 138 "..\..\..\..\View\MainWindow.xaml"
            ((System.Windows.Controls.TextBox)(target)).LostFocus += new System.Windows.RoutedEventHandler(this.HLTextBox_LostFocus);
            
            #line default
            #line hidden
            break;
            case 6:
            
            #line 153 "..\..\..\..\View\MainWindow.xaml"
            ((System.Windows.Controls.TextBox)(target)).LostFocus += new System.Windows.RoutedEventHandler(this.HLTextBox_LostFocus);
            
            #line default
            #line hidden
            break;
            case 7:
            
            #line 168 "..\..\..\..\View\MainWindow.xaml"
            ((System.Windows.Controls.TextBox)(target)).LostFocus += new System.Windows.RoutedEventHandler(this.HLTextBox_LostFocus);
            
            #line default
            #line hidden
            break;
            case 8:
            
            #line 183 "..\..\..\..\View\MainWindow.xaml"
            ((System.Windows.Controls.TextBox)(target)).LostFocus += new System.Windows.RoutedEventHandler(this.HLTextBox_LostFocus);
            
            #line default
            #line hidden
            break;
            case 9:
            
            #line 198 "..\..\..\..\View\MainWindow.xaml"
            ((System.Windows.Controls.TextBox)(target)).LostFocus += new System.Windows.RoutedEventHandler(this.HLTextBox_LostFocus);
            
            #line default
            #line hidden
            break;
            case 10:
            
            #line 213 "..\..\..\..\View\MainWindow.xaml"
            ((System.Windows.Controls.TextBox)(target)).LostFocus += new System.Windows.RoutedEventHandler(this.HLTextBox_LostFocus);
            
            #line default
            #line hidden
            break;
            case 11:
            
            #line 228 "..\..\..\..\View\MainWindow.xaml"
            ((System.Windows.Controls.TextBox)(target)).LostFocus += new System.Windows.RoutedEventHandler(this.HLTextBox_LostFocus);
            
            #line default
            #line hidden
            break;
            case 12:
            
            #line 243 "..\..\..\..\View\MainWindow.xaml"
            ((System.Windows.Controls.TextBox)(target)).LostFocus += new System.Windows.RoutedEventHandler(this.HLTextBox_LostFocus);
            
            #line default
            #line hidden
            break;
            case 13:
            
            #line 258 "..\..\..\..\View\MainWindow.xaml"
            ((System.Windows.Controls.TextBox)(target)).LostFocus += new System.Windows.RoutedEventHandler(this.HLTextBox_LostFocus);
            
            #line default
            #line hidden
            break;
            case 14:
            
            #line 273 "..\..\..\..\View\MainWindow.xaml"
            ((System.Windows.Controls.TextBox)(target)).LostFocus += new System.Windows.RoutedEventHandler(this.HLTextBox_LostFocus);
            
            #line default
            #line hidden
            break;
            case 15:
            
            #line 288 "..\..\..\..\View\MainWindow.xaml"
            ((System.Windows.Controls.TextBox)(target)).LostFocus += new System.Windows.RoutedEventHandler(this.HLTextBox_LostFocus);
            
            #line default
            #line hidden
            break;
            case 16:
            
            #line 303 "..\..\..\..\View\MainWindow.xaml"
            ((System.Windows.Controls.TextBox)(target)).LostFocus += new System.Windows.RoutedEventHandler(this.HLTextBox_LostFocus);
            
            #line default
            #line hidden
            break;
            case 17:
            
            #line 318 "..\..\..\..\View\MainWindow.xaml"
            ((System.Windows.Controls.TextBox)(target)).LostFocus += new System.Windows.RoutedEventHandler(this.HLTextBox_LostFocus);
            
            #line default
            #line hidden
            break;
            case 18:
            
            #line 333 "..\..\..\..\View\MainWindow.xaml"
            ((System.Windows.Controls.TextBox)(target)).LostFocus += new System.Windows.RoutedEventHandler(this.HLTextBox_LostFocus);
            
            #line default
            #line hidden
            break;
            case 19:
            
            #line 348 "..\..\..\..\View\MainWindow.xaml"
            ((System.Windows.Controls.TextBox)(target)).LostFocus += new System.Windows.RoutedEventHandler(this.HLTextBox_LostFocus);
            
            #line default
            #line hidden
            break;
            case 20:
            
            #line 363 "..\..\..\..\View\MainWindow.xaml"
            ((System.Windows.Controls.TextBox)(target)).LostFocus += new System.Windows.RoutedEventHandler(this.HLTextBox_LostFocus);
            
            #line default
            #line hidden
            break;
            }
        }
    }
}
