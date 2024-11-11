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
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        private PatientViewModel _viewModel;

        public MainWindow()
        {
            InitializeComponent();
            _viewModel = new PatientViewModel();
        }

        private void btnRegistration_Click(object sender, RoutedEventArgs e)
        {
            var patientRegControl = new PatientRegControl(_viewModel);
            patientRegControl.RegistrationCompleted += () => MainContent.Content = null;
            patientRegControl.NavigateToAppointment += () =>
            {
                var appointmentControl = new AppointmentConfirmationControl(_viewModel);
                appointmentControl.AppointmentCompleted += () => MainContent.Content = null;
                MainContent.Content = appointmentControl;
            };
            MainContent.Content = patientRegControl;
        }

        private void btnAppointment_Click(object sender, RoutedEventArgs e)
        {
            var appointmentConfirmationControl = new AppointmentConfirmationControl(_viewModel);
            appointmentConfirmationControl.AppointmentCompleted += () => MainContent.Content = null;
            MainContent.Content = appointmentConfirmationControl;
        }

        private void btnDashboard_Click(object sender, RoutedEventArgs e)
        {
            var patientDashboardControl = new PatientDashboardControl(_viewModel);
            MainContent.Content = patientDashboardControl;
        }
    }
}
