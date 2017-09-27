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
    /// Interaction logic for AdvancedTools.xaml
    /// </summary>
    public partial class AdvancedTools : Window
    {
        BL.IBL bl;
        public AdvancedTools()
        {
            InitializeComponent();
            bl = BL.Factory_BL.GetBL();
        }

        private void sumOfSalariesButton_Click(object sender, RoutedEventArgs e)
        {
            sumOfSalariesLabel.Visibility = Visibility.Visible;
            sumOfSalariesTextBox.Visibility = Visibility.Visible;
            GETSumSalariesbutton.Visibility = Visibility.Visible;

            contractByAdresButton.Visibility = Visibility.Collapsed;
            contractByAdresCheckBox.Visibility = Visibility.Collapsed;

            contractBySpecCheckBox.Visibility = Visibility.Collapsed;
            contractBySpecButton.Visibility = Visibility.Collapsed;

            profitBySpanButton.Visibility = Visibility.Collapsed;
            profitBySpanCheckBox.Visibility = Visibility.Collapsed;

        }

        private void GETSumSalariesbutton_Click(object sender, RoutedEventArgs e)
        {
            listBox.Items.Clear();

            int sumOfSalaries = bl.ReturnSumOfSalariesGreatherThen(c => c.brutoSalary > Int32.Parse(sumOfSalariesTextBox.Text));
            listBox.Items.Add("the sum of salaries is:");
            listBox.Items.Add(sumOfSalaries);
        }


        private void interviewedButton_Click(object sender, RoutedEventArgs e)
        {
            int numberOfInterviewed;
            numberOfInterviewed = bl.HowManyWereInterviewed();
            numberOfInterviewedLabel.Content = numberOfInterviewed.ToString();

            sumOfSalariesLabel.Visibility = Visibility.Collapsed;
            sumOfSalariesTextBox.Visibility = Visibility.Collapsed;
            GETSumSalariesbutton.Visibility = Visibility.Collapsed;

            contractByAdresButton.Visibility = Visibility.Collapsed;
            contractByAdresCheckBox.Visibility = Visibility.Collapsed;

            contractBySpecCheckBox.Visibility = Visibility.Collapsed;
            contractBySpecButton.Visibility = Visibility.Collapsed;

            profitBySpanButton.Visibility = Visibility.Collapsed;
            profitBySpanCheckBox.Visibility = Visibility.Collapsed;

        }

        private void branchesButton_Click(object sender, RoutedEventArgs e)
        {
            sumOfSalariesLabel.Visibility = Visibility.Collapsed;
            sumOfSalariesTextBox.Visibility = Visibility.Collapsed;
            GETSumSalariesbutton.Visibility = Visibility.Collapsed;

            contractByAdresButton.Visibility = Visibility.Collapsed;
            contractByAdresCheckBox.Visibility = Visibility.Collapsed;

            contractBySpecCheckBox.Visibility = Visibility.Collapsed;
            contractBySpecButton.Visibility = Visibility.Collapsed;

            profitBySpanButton.Visibility = Visibility.Collapsed;
            profitBySpanCheckBox.Visibility = Visibility.Collapsed;

            List<BE.BankAccount> branchesList = bl.ReturnAllBranches();
            foreach (var bank in branchesList)
            {
                listBox.Items.Add(bank);
            }
        }

        private void contractsSpeGroupingButton_Click(object sender, RoutedEventArgs e)
        {
            contractBySpecCheckBox.Visibility = Visibility.Visible;
            contractBySpecButton.Visibility = Visibility.Visible;

            contractByAdresButton.Visibility = Visibility.Collapsed;
            contractByAdresCheckBox.Visibility = Visibility.Collapsed;

            profitBySpanButton.Visibility = Visibility.Collapsed;
            profitBySpanCheckBox.Visibility = Visibility.Collapsed;

            sumOfSalariesLabel.Visibility = Visibility.Collapsed;
            sumOfSalariesTextBox.Visibility = Visibility.Collapsed;
            GETSumSalariesbutton.Visibility = Visibility.Collapsed;

        }

        private void contractsAdresGroupingButton_Click(object sender, RoutedEventArgs e)
        {
            contractByAdresButton.Visibility = Visibility.Visible;
            contractByAdresCheckBox.Visibility = Visibility.Visible;

            contractBySpecCheckBox.Visibility = Visibility.Collapsed;
            contractBySpecButton.Visibility = Visibility.Collapsed;

            profitBySpanButton.Visibility = Visibility.Collapsed;
            profitBySpanCheckBox.Visibility = Visibility.Collapsed;

            sumOfSalariesLabel.Visibility = Visibility.Collapsed;
            sumOfSalariesTextBox.Visibility = Visibility.Collapsed;
            GETSumSalariesbutton.Visibility = Visibility.Collapsed;

        }

        private void profitSpanGroupingButton_Click(object sender, RoutedEventArgs e)
        {
            profitBySpanButton.Visibility = Visibility.Visible;
            profitBySpanCheckBox.Visibility = Visibility.Visible;

            contractByAdresButton.Visibility = Visibility.Collapsed;
            contractByAdresCheckBox.Visibility = Visibility.Collapsed;

            contractBySpecCheckBox.Visibility = Visibility.Collapsed;
            contractBySpecButton.Visibility = Visibility.Collapsed;

            sumOfSalariesLabel.Visibility = Visibility.Collapsed;
            sumOfSalariesTextBox.Visibility = Visibility.Collapsed;
            GETSumSalariesbutton.Visibility = Visibility.Collapsed;
        }


        private void contractBySpecButton_Click(object sender, RoutedEventArgs e)
        {
            listBox.Items.Clear();

            var contracts = bl.ContractsBySpecialization((bool)contractBySpecCheckBox.IsChecked);
            IEnumerable<BE.Contract> contractsList = contracts.SelectMany(group => group);
            foreach (var c in contractsList)
            {
                listBox.Items.Add(c);
            }

        }

        private void contractByAdresButton_Click(object sender, RoutedEventArgs e)
        {
            listBox.Items.Clear();

            var contracts = bl.ContractsByAddress((bool)contractByAdresCheckBox.IsChecked);
            IEnumerable<BE.Contract> contractsList = contracts.SelectMany(group => group);
            foreach (var c in contractsList)
            {
                listBox.Items.Add(c);
            }

        }

        //private void profitBySpanButton_Click(object sender, RoutedEventArgs e)
        //{
        //    listBox.Items.Clear();

        //    var profits = bl.ProfitByTimespan();
        //    IEnumerable<BE.Contract> contractsList = contracts.SelectMany(group => group);
        //    foreach (var p in profitsList)
        //    {
        //        listBox.Items.Add(p);
        //    }

        //}
    }
}
