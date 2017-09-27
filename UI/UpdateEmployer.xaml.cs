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
    /// Interaction logic for UpdateEmployer.xaml
    /// </summary>
    public partial class UpdateEmployer : Window
    {
        BL.IBL bl;
        public UpdateEmployer()
        {
            InitializeComponent();
            bl = BL.Factory_BL.GetBL();
            loadFielComboBox();
        }

        void loadFielComboBox()
        {
            fieldComboBox.Items.Add("Data structures");
            fieldComboBox.Items.Add("Computer communications");
            fieldComboBox.Items.Add("Information security");
            fieldComboBox.Items.Add("Server programmer");
            fieldComboBox.Items.Add("Mobile programmer");
            fieldComboBox.Items.Add("User interface designer");

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

            else if (fundationTimeBox.Text.Equals(""))
                MessageBox.Show("Please enter a fundation time.", "Error");

            else if (telBox.Text.Equals(""))
                MessageBox.Show("Please enter a telephone number", "Error");

            else if (fieldComboBox.SelectedValue == null)
                MessageBox.Show("Please select an field", "Error");

            else if (checkBoxYes.IsChecked == true && companyNameBox.Text.Equals(""))
                MessageBox.Show("Please enter a company name.", "Error");
            string field = null;
            if (fieldComboBox.SelectedValue != null)
            {
                field = fieldComboBox.SelectedValue.ToString();
                switch (field)
                {
                    case "Data structures":
                        field = "dataStructures";
                        break;
                    case "Cmputer communications":
                        field = "computerCommunications";
                        break;
                    case "Information security":
                        field = "informationSecurity";
                        break;
                    case "Server programmer":
                        field = "serverProgrammer";
                        break;
                    case "Mobile programmer":
                        field = "mobileProgrammer";
                        break;
                    case "User interface designer":
                        field = "userInterfaceDesigner";
                        break;

                    default:
                        field = "dataStructures";
                        break;
                }
            }
            try
            {
                
                bl.UpdateEmployer(nameBox.Text, lastNameBox.Text, companyNameBox.Text, Int32.Parse(idBox.Text), Int32.Parse(telBox.Text),
                    addressBox.Text, fundationTimeBox.Text, (bool)checkBoxYes.IsChecked, (Field)Enum.Parse(typeof(Field), field));

                MessageBox.Show("Employer has been successfuly added.");
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
}

