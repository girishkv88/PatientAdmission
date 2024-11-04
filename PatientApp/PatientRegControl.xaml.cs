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

namespace PatientApp
{
    /// <summary>
    /// Interaction logic for PatientRegControl.xaml
    /// </summary>
    public partial class PatientRegControl : UserControl
    {
        private PatientViewModel _viewModel;
        public event Action NavigateToAppointment;
        public event Action RegistrationCompleted;
        public PatientRegControl(PatientViewModel viewModel)
        {
            InitializeComponent();
            _viewModel = viewModel;
        }

        private void btnRegister_Click(object sender, RoutedEventArgs e)
        {
            var patient = new Patient
            {
                Name = NameTextBox.Text,
                Age = int.Parse(AgeTextBox.Text),
                DateOfBirth = DOBPicker.SelectedDate.Value,
                Address = AddressTextBox.Text,
                Slot = SlotComboBox.SelectedItem.ToString(),
                BookingDate = DateTime.Now
            };
            _viewModel.RegisterPatient(patient);
            MessageBox.Show("Patient Details entered Succesfully");
            RegistrationCompleted?.Invoke();

            // Trigger navigation to appointment confirmation
            NavigateToAppointment?.Invoke();
        }
    }
}
