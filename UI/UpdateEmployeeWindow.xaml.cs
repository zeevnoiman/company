using BE;
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
    /// Interaction logic for AddEmployee.xaml
    /// </summary>
    public partial class UpdateEmployeeWindow : Window
    {

        BL.IBL bl;
        public UpdateEmployeeWindow()
        {
            InitializeComponent();
            bl = BL.Factory_BL.GetBL();
            loadEducationComboBox();
        }


        void loadEducationComboBox()
        {
            educationComboBox.Items.Add("Student");
            educationComboBox.Items.Add("Certification");
            educationComboBox.Items.Add("First degree");
            educationComboBox.Items.Add("Second degree");
            educationComboBox.Items.Add("Third Degree");

        }

        private void comboBox_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {

        }

        private void button_Click(object sender, RoutedEventArgs e)
        {
            if (nameBox.Text.Equals(""))
                MessageBox.Show("Please enter a name.", "Error");

            else if (lastNameBox.Text.Equals(""))
                MessageBox.Show("Please enter a last name.", "Error");

            else if (idBox.Text.Equals(""))
                MessageBox.Show("Please enter an ID number.", "Error");

            else if (addressBox.Text.Equals(""))
                MessageBox.Show("Please enter an address.", "Error");

            else if (specBox.Text.Equals(""))
                MessageBox.Show("Please enter a specialization number.", "Error");

            else if (telBox.Text.Equals(""))
                MessageBox.Show("Please enter a telephone number", "Error");

            else if (educationComboBox.SelectedValue == null)
                MessageBox.Show("Please select an education", "Error");

            else if (bankAccountBox.Text.Equals(""))
                MessageBox.Show("Please enter a bank account number.", "Error");

            else if (bankNameBox.Text.Equals(""))
                MessageBox.Show("Please enter a bank name.", "Error");

            else if (bankCodeBox.Text.Equals(""))
                MessageBox.Show("Please enter a bank code.", "Error");

            else if (branchCodeBox.Text.Equals(""))
                MessageBox.Show("Please enter a branch code.", "Error");

            else if (branchCityBox.Text.Equals(""))
                MessageBox.Show("Please enter a branch city.", "Error");

            else if (branchAddressBox.Text.Equals(""))
                MessageBox.Show("Please enter a branch address.", "Error");

            else
            {
                bool army=false, record=false;
                if (armyYes.IsChecked == true)
                    army = true;
                if (recordYes.IsChecked == true)
                    record = true;



                string education = educationComboBox.SelectedValue.ToString();
                switch (education)
                {
                    case "Student":
                        education = "student";
                        break;
                    case "First degree":
                        education = "firstDegree";
                        break;
                    case "Second degree":
                        education = "secondDegree";
                        break;
                    case "Third degree":
                        education = "thirdDegree";
                        break;
                    case "Certification":
                        education = "certification";
                        break;
                    default:
                        education = "student";
                        break;
                }

                try
                {
                    bl.UpdateEmployee(nameBox.Text, lastNameBox.Text, Convert.ToInt32(idBox.Text), Convert.ToInt32(telBox.Text),
                   addressBox.Text, (Education)Enum.Parse(typeof(Education), education), army, record, Convert.ToInt32(telBox.Text), dobBox.Text, Convert.ToInt32(bankCodeBox.Text),
                   bankNameBox.Text, Convert.ToInt32(branchCodeBox.Text), branchAddressBox.Text, branchCityBox.Text, Convert.ToInt32(bankAccountBox.Text));

                    MessageBox.Show("Employee has been successfuly updated.");               
                    this.Close();
                   

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

        private void recordYes_Checked(object sender, RoutedEventArgs e)
        {

        }

        private void armyYes_Checked(object sender, RoutedEventArgs e)
        {

        }
    }
}

