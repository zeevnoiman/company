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
    /// Interaction logic for DeleteContractWindow.xaml
    /// </summary>
    public partial class DeleteContractWindow : Window
    {
        BL.IBL bl;
        public DeleteContractWindow()
        {
            InitializeComponent();
            bl = BL.Factory_BL.GetBL();
            InitializeListBox();
        }

        private void listBox_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            if (listBoxContracts.SelectedValue != null)
            {
                var contract = bl.GetContract(Int32.Parse(listBoxContracts.SelectedItem.ToString()));
                boxContractNumber.Text = contract.contractNumber.ToString();
                boxEmployerID.Text = contract.employerId.ToString();
                boxEmployeeID.Text = contract.employeeId.ToString();
            }

        }

        private void InitializeListBox()
        {
            var contracts = bl.ReturnContracts().Select(c=>c.contractNumber);
            listBoxContracts.ItemsSource = contracts;

        }

        private void button_Click2(object sender, RoutedEventArgs e)
        {
            this.Close();
        }

        private void button_Click(object sender, RoutedEventArgs e)
        {
            try
            {

                bl.DeleteContract(Int32.Parse(listBoxContracts.SelectedItem.ToString()));
                MessageBox.Show("Contract has been successfully deleted.");
                InitializeListBox();
                boxContractNumber.Clear();
                boxEmployerID.Clear();
                boxEmployeeID.Clear();
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
}
