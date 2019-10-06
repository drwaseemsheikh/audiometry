using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Audiometry.Print
{
    public static class WPFUIRefreshExtensionMethods
    {
        private static System.Action EmptyDelegate = delegate() { };

        /// <summary>
        ///
        /// </summary>
        /// <param name="uiElement"></param>
        public static void Refresh(this System.Windows.UIElement uiElement)
        {
            //uiElement.UpdateLayout();
            uiElement.Dispatcher.Invoke(System.Windows.Threading.DispatcherPriority.Render, EmptyDelegate);
        }
    }
}
