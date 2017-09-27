using BE;
using System;
using System.Collections.Generic;
using System.ComponentModel;
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
    /// Interaction logic for AddEmployee.xaml
    /// </summary>
    public partial class DeleteEmployeeWindow : Window
    {
      
        BL.IBL bl;
  

        public DeleteEmployeeWindow()
        {
            InitializeComponent();
            bl = BL.Factory_BL.GetBL();
            try
            {
                InitializeEmployeeListBox();
            }
            catch(Exception ex)
            {
                MessageBox.Show(ex.Message, "Error");
            }
        }


        private void InitializeEmployeeListBox()
        {
            
            var employees = bl.ReturnEmployees().Select(em=>em.id).ToList();
            employees.Sort();
            employeesListBox.ItemsSource = employees;


        }

      
        private void button_Click(object sender, RoutedEventArgs e)
        {
            try
            {
                bl.DelEmployee(Convert.ToInt32(employeesListBox.SelectedItem.ToString()));
                         
                employeeIDBox.Text="";
                employeeNameBox.Text = "";
                employeeLastNameBox.Text = "";
                InitializeEmployeeListBox();
            }

            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "Error",MessageBoxButton.OK,MessageBoxImage.Warning);
            }


        }

        private void listBox_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            if (employeesListBox.SelectedValue != null)
            {
                employeeIDBox.Text = employeesListBox.SelectedValue.ToString();
                employeeNameBox.Text = bl.GetEmployeeName(Convert.ToInt32(employeesListBox.SelectedValue.ToString()));
                employeeLastNameBox.Text = bl.GetEmployeeLastName(Convert.ToInt32(employeesListBox.SelectedValue.ToString()));
            }
        }

        private void button_Click2(object sender, RoutedEventArgs e)
        {
            this.Close();
            
        }
    }
}

