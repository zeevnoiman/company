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
    /// Interaction logic for DeleteSpecializationWindow.xaml
    /// </summary>
    public partial class DeleteSpecializationWindow : Window
    {
        BL.IBL bl;

        public DeleteSpecializationWindow()
        {
            InitializeComponent();
            bl = BL.Factory_BL.GetBL();
            InitializeListBox();
        }

        private void InitializeListBox()
        {
            var specs = bl.ReturnSpecializations().Select(sp => sp.specializationNumber).ToList();
            specs.Sort();
            listBoxSpecs.ItemsSource = specs;
        }

        private void listBox_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            if (listBoxSpecs.SelectedValue != null)
            {
                boxSpecNumber.Text = listBoxSpecs.SelectedItem.ToString();
                boxSpecName.Text = bl.GetSpecialization(Int32.Parse(boxSpecNumber.Text)).specializationName.ToString();
                boxField.Text = bl.GetSpecialization(Int32.Parse(boxSpecNumber.Text)).specField.ToString();
            }
        }

        private void button_Click(object sender, RoutedEventArgs e)
        {
            try
            {
                bl.DelSpecialization(Int32.Parse(listBoxSpecs.SelectedItem.ToString()));
                MessageBox.Show("Specialization has been successfully deleted.");
                boxSpecName.Clear();
                boxSpecNumber.Clear();
                boxField.Clear();
                InitializeListBox();

            }
            catch(Exception ex)
            {
                MessageBox.Show(ex.Message, "Error", MessageBoxButton.OK, MessageBoxImage.Warning);
            }
        }

        private void button_Click2(object sender, RoutedEventArgs e)
        {
            this.Close();
        }
    }

}
