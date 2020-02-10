using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Navigation;
using System.Windows.Shapes;

namespace Ferst_App_cacl_
{
    /// <summary>
    /// Логика взаимодействия для MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        public MainWindow()
        {
            InitializeComponent();
            foreach (UIElement uI in mainGrid.Children)
            {
                if (uI is Button)
                {
                    ((Button)uI).Click += buttons_Click;
                }
            }
        }
        private void buttons_Click(object sender, RoutedEventArgs e)
        {
            textMain.Text += ((Button)sender).Content;
        }

    }
}
