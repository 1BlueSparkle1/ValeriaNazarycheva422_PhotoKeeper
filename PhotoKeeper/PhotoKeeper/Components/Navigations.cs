using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Controls;

namespace PhotoKeeper.Components
{
    internal class Navigations
    {
        public static MainWindow mainWindow;

        public static void mainPage(Page page)
        {
            mainWindow.MainFrame.Navigate(page);
        }

        public static void topPage(Page page)
        {
            mainWindow.TopFrame.Navigate(page);
        }

        public static void leftPage(Page page)
        {
            mainWindow.LeftFrame.Navigate(page);
        }

        public static void valuePage(Page page)
        {
            mainWindow.ValueFrame.Navigate(page);
        }
    }
}
