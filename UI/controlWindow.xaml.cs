using System;
using System.Collections.Generic;
using System.Globalization;
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
using System.Windows.Shapes;

namespace UI
{
    /// <summary>
    /// Interaction logic for controlWindow.xaml
    /// </summary>
    public partial class controlWindow : Window
    {
        public controlWindow()
        {
            InitializeComponent();
        }
       

        static private AddEmployer addEmployerWindow;
        static private DelEmployer delEmployerWindow;
        static private UpdateEmployer updateEmployerWindow;

        static private AddSpecialiazationWindow addSpecializationWindow;
        static private UpdateSpecializationWindow updateSpecializationWindow;
        static private DeleteSpecializationWindow deleteSpecializationWindow;

        static private DeleteEmployeeWindow deleteEmployeeWindow;
        static private UpdateEmployeeWindow updateEmployeeWindow;
        static private AddEmployeeWindow addEmployeeWindow;

        static private AddContractWindow addContractWindow;
        static private UpdateContractWindow updateContractWindow;
        static private DeleteContractWindow deleteContractWindow;


        private void button1_Click(object sender, RoutedEventArgs e)
        {
            addContractWindow = new AddContractWindow();
            addContractWindow.Show();
            
        }

        private void button2_Click(object sender, RoutedEventArgs e)
        {
            updateContractWindow = new UpdateContractWindow();
            updateContractWindow.Show();


        }

        private void button3_Click(object sender, RoutedEventArgs e)
        {
           deleteContractWindow = new DeleteContractWindow();
           deleteContractWindow.Show();


        }

        private void button4_Click(object sender, RoutedEventArgs e)
        {
            addEmployerWindow = new AddEmployer();
            addEmployerWindow.Show();

        }

        private void button5_Click(object sender, RoutedEventArgs e)
        {
            updateEmployerWindow = new UpdateEmployer();
            updateEmployerWindow.Show();

        }

        private void button6_Click(object sender, RoutedEventArgs e)
        {
           
            delEmployerWindow = new DelEmployer();
            delEmployerWindow.Show();

        }

        private void button7_Click(object sender, RoutedEventArgs e)
        {
            addEmployeeWindow = new AddEmployeeWindow();
            addEmployeeWindow.Show();

        }

        private void button8_Click(object sender, RoutedEventArgs e)
        {
            updateEmployeeWindow = new UpdateEmployeeWindow();
            updateEmployeeWindow.Show();

        }

        private void button9_Click(object sender, RoutedEventArgs e)
        {

            deleteEmployeeWindow = new DeleteEmployeeWindow();
            deleteEmployeeWindow.Show();

        }

        private void button10_Click(object sender, RoutedEventArgs e)
        {
            addSpecializationWindow = new AddSpecialiazationWindow();
            addSpecializationWindow.Show();
        }

        private void button11_Click(object sender, RoutedEventArgs e)
        {
            updateSpecializationWindow = new UpdateSpecializationWindow();
            updateSpecializationWindow.Show();

        }

        private void button12_Click(object sender, RoutedEventArgs e)
        {
            deleteSpecializationWindow = new DeleteSpecializationWindow();
            deleteSpecializationWindow.Show();

        }
        private void checkBox1_Click(object sender, RoutedEventArgs e)
        {
            checkBox2.IsChecked = false;
            checkBox3.IsChecked = false;
            checkBox4.IsChecked = false;
            advancedCheckBox.IsChecked = false;
        }

        private void checkBox2_Click(object sender, RoutedEventArgs e)
        {
            checkBox1.IsChecked = false;
            checkBox3.IsChecked = false;
            checkBox4.IsChecked = false;
            advancedCheckBox.IsChecked = false;
        }

        private void checkBox3_Click(object sender, RoutedEventArgs e)
        {
            checkBox1.IsChecked = false;
            checkBox2.IsChecked = false;
            checkBox4.IsChecked = false;
            advancedCheckBox.IsChecked = false;

        }

        private void checkBox4_Click(object sender, RoutedEventArgs e)
        {
            checkBox1.IsChecked = false;
            checkBox2.IsChecked = false;
            checkBox3.IsChecked = false;
            advancedCheckBox.IsChecked = false;

        }

        private void goButton_Click(object sender, RoutedEventArgs e)
        {
            AdvancedTools myAdvancedTool = new AdvancedTools();
            myAdvancedTool.Show();
        }

        private void advancedCheckBox_Click(object sender, RoutedEventArgs e)
        {
            checkBox1.IsChecked = false;
            checkBox2.IsChecked = false;
            checkBox3.IsChecked = false;
            checkBox4.IsChecked = false;
        }
    }

    public class BooleanToVisibilityConverter : IValueConverter
    {
        public object Convert(
          object value,
          Type targetType,
          object parameter,
          CultureInfo culture)
        {
            bool boolValue = (bool)value;
            if (boolValue)
            {
                return Visibility.Visible;
            }
            else
            {
                return Visibility.Collapsed;
            }
        }

        public object ConvertBack(
          object value,
          Type targetType,
          object parameter,
          CultureInfo culture)
        {
            throw new NotImplementedException();
        }
    }
}
