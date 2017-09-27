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
using System.Windows.Shapes;

namespace UI
{
    /// <summary>
    /// Interaction logic for UpdateContractWindow.xaml
    /// </summary>
    public partial class UpdateContractWindow : Window
    {
        BL.IBL bl;
        public UpdateContractWindow()
        {
            InitializeComponent();
            bl = BL.Factory_BL.GetBL();
            InitializeListBoxes();
        }

        private void button_Click(object sender, RoutedEventArgs e)
        {
            if (boxContractNumber.Text.Equals(""))
                MessageBox.Show("Please enter contract number.", "Error");

            else if (boxEmployerID.Text.Equals(""))
                MessageBox.Show("Please select employer ID.", "Error");

            else if (boxEmployeeID.Text.Equals(""))
                MessageBox.Show("Please select employee ID.", "Error");

            else if (boxBruto.Text.Equals(""))
                MessageBox.Show("Please enter bruto wage.", "Error");

            else if (boxStartDate.Text.Equals(""))
                MessageBox.Show("Please enter a start of employment date", "Error");

            else if (boxEndDate.Text.Equals(""))
                MessageBox.Show("Please enter an end of employment date.", "Error");

            else if (boxHours.Text.Equals(""))
                MessageBox.Show("Please enter daily hours.", "Error");
            else
            {
                try
                {
                    bool signed = checkBoxSigned.IsChecked == true ? true : false;
                    bool interviewed = checkBoxInterview.IsChecked == true ? true : false;

                    bl.UpdateContract(Int32.Parse(boxContractNumber.Text), Int32.Parse(boxEmployerID.Text), Int32.Parse(boxEmployeeID.Text),
                          interviewed, signed, double.Parse(boxBruto.Text), boxStartDate.Text, boxEndDate.Text, Int32.Parse(boxHours.Text));


                    MessageBox.Show("Contract has been successfully updated");

                    boxEmployerID.Clear();
                    boxEmployeeID.Clear();
                    boxBruto.Clear();
                    boxStartDate.Clear();
                    boxEndDate.Clear();
                    boxHours.Clear();

                    InitializeListBoxes();
                }
                catch (FormatException ex)
                {
                    MessageBox.Show(ex.Message, "Error");

                }

                catch (Exception ex)
                {
                    MessageBox.Show(ex.Message, "Error");
                }
            }
        }

        private void button_Click2(object sender, RoutedEventArgs e)
        {
            this.Close();
        }

        private void InitializeListBoxes()
        {
            var employees = bl.ReturnUnemployedEmployees().Select(e => e.id);
            var employers = bl.ReturnEmployers().Select(e => e.id);

            listBoxEmployers.ItemsSource = employers;
            listBoxEmployees.ItemsSource = employees;
        }

        private void listBoxEmployers_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            boxEmployerID.Text = listBoxEmployers.SelectedItem.ToString();
        }

        private void listBoxEmployees_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            boxEmployeeID.Text = listBoxEmployees.SelectedItem.ToString();
        }
    }
}
