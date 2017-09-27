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
using BE;
using BL;

namespace UI
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
       
        private string myPassword = "123456";

        public MainWindow()
        {
            InitializeComponent();        
        }

        private void startButton_Click(object sender, RoutedEventArgs e)
        {
            passwordBox.Visibility = Visibility.Visible;
            confirmButton.Visibility = Visibility.Visible;
            passwordBox.Focus();
        }

        private void confirmButton_Click(object sender, RoutedEventArgs e)
        {
            if(passwordBox.Password == myPassword)
            {           
                    controlWindow myCW = new controlWindow();
                    myCW.Show();             
            }
            else
            {
                MessageBox.Show("Wrong password.\nPlease Try Again.","Error");
                passwordBox.Clear();
                passwordBox.Focus();
            }
        }
    }
}
