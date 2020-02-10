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
                    ((Button)uI).Click += Buttons_Click;
                }
            }
        }
        string operation = "";
        string left = "";
        string right = "";
        private void Buttons_Click(object sender, RoutedEventArgs e)
        {

            string sBut = (string)((Button)sender).Content;
            textMain.Text += sBut;

            bool flagDigit = int.TryParse(sBut, out int nam);
            if (flagDigit)
            {
                if(operation=="")
                {
                    left += sBut;
                }
                else
                {
                    right += sBut;
                }
            }else
            {
                if(sBut=="=")
                {
                    Operations();
                    textMain.Text += right;
                    operation = "";
                }
                else if (sBut=="Clear")
                {
                    right = "";
                    left = "";
                    operation = "";
                    textMain.Text = "";
                }
                else
                {
                    if(right!="")
                    {
                        Operations();
                        left = right;
                        right = "";
                    }
                    operation = sBut;
                }
                
            }



        }
        private void Operations()
        {
            switch(operation)
            {
                case "+":
                    right = Convert.ToString(int.Parse(left) + int.Parse(right));
                    
                    

                    break;
                case "-":
                    right = Convert.ToString(int.Parse(left) - int.Parse(right));
                    break;
                case "/":
                    if(int.Parse(right)==0)
                    {
                        MessageBox.Show("Ошибка, на ноль делить нельзя", "Ошибка", MessageBoxButton.OK, MessageBoxImage.Error);
                        right = "";
                    }
                    else
                    {
                        right = Convert.ToString(int.Parse(left) / int.Parse(right));
                    }
                    
                    break;
                case "*":
                    right = Convert.ToString(int.Parse(left) * int.Parse(right));
                    break;
            }
                
        }

    }
}
