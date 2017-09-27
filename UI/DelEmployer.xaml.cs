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
    /// Interaction logic for DelEmployer.xaml
    /// </summary>
    public partial class DelEmployer : Window
    {

        BL.IBL bl;
        public DelEmployer()
        {
            InitializeComponent();
            bl = BL.Factory_BL.GetBL();
            try
            {
                InitializeEmployeeListBox();
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "Error");
            }
        }


        private void InitializeEmployeeListBox()
        {

            var employers = bl.ReturnEmployers();
            foreach (var e in employers)
                employersListBox.Items.Add(e.id);
        }

        private void listBox_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            if (employersListBox.Items.Count != 0)
            {
                string employersID = employersListBox.SelectedValue.ToString();

                var employer = bl.GetEmployer(Int32.Parse(employersID));
                employerIDBox.Text = employer.id.ToString();
                employerLastNameBox.Text = employer.surname.ToString();
                employerNameBox.Text = employer.name.ToString();
            }
            
        }

        private void deleteEmployer_Click(object sender, RoutedEventArgs e)
        {
            var employersID = employerIDBox.Text;
            var employer = bl.GetEmployer(Int32.Parse(employersID));
            bl.DelEmployer(employer);
            MessageBox.Show("Employer deleted.");
            employersListBox.Items.Clear();
            employerIDBox.Text = "";
            employerLastNameBox.Text = "";
            employerNameBox.Text = "";
            InitializeEmployeeListBox();
        }
    }

}
