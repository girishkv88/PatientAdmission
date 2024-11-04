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
    /// Interaction logic for AppointmentConfirmationControl.xaml
    /// </summary>
    public partial class AppointmentConfirmationControl : UserControl
    {
        private PatientViewModel _viewModel;
        public event Action NavigateToDashboard;
        public event Action AppointmentCompleted;


        public AppointmentConfirmationControl(PatientViewModel viewModel)
        {
            InitializeComponent();
            _viewModel = viewModel;
            LoadPatients();
        }
        private void LoadPatients()
        {
            // Assuming _viewModel.Patients is a List<Patient> that contains the registered patients
            foreach (var patient in _viewModel.Patients)
            {
                var checkBox = new CheckBox
                {
                    Content = $"{patient.Name} (Age: {patient.Age}, DOB: {patient.DateOfBirth.ToShortDateString()}, Address: {patient.Address})",
                    Tag = patient // Store the patient object in the Tag property for later use
                };
                PatientsListBox.Items.Add(checkBox);
            }
        }
        private void btnConfirm_Click(object sender, RoutedEventArgs e)
        {
            var selectedPatients = new List<Patient>();
            for (int i= PatientsListBox.Items.Count-1; i >= 0; i--)
            {
                CheckBox checkBox = PatientsListBox.Items[i] as CheckBox;
                if ( checkBox != null && checkBox.IsChecked == true && checkBox.Tag is Patient patient)
                {
                    selectedPatients.Add(patient);
                    PatientsListBox.Items.RemoveAt(i);
                }
            }
            foreach (var confirmedPatient in selectedPatients)
            {
                _viewModel.Patients.Remove(confirmedPatient);
            }
            // Iterate through the CheckBoxes in the ListBox to find checked ones
            //foreach (CheckBox checkBox in PatientsListBox.Items)
            //{
            //    if (checkBox.IsChecked == true && checkBox.Tag is Patient patient)
            //    {
            //        selectedPatients.Add(patient);
            //    }
            //}
            _viewModel.ConfirmPatients(selectedPatients);
            MessageBox.Show(messageBoxText: "Are you sure to Confirm?",
                    caption: "Confirm",
                    button: MessageBoxButton.YesNo,
                    icon: MessageBoxImage.Question);
            AppointmentCompleted?.Invoke();
            NavigateToDashboard?.Invoke();
        }
    }
}
