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
            //LoadInitialView();
        }
        //private void LoadInitialView()
        //{
        //    var registerControl = new PatientRegControl(_viewModel);
        //    registerControl.NavigateToAppointment += RegisterControl_NavigateToAppointment;
        //    MainContent.Content = registerControl;
        //}
        //private void RegisterControl_NavigateToAppointment()
        //{
        //    var appointmentControl = new AppointmentConfirmationControl(_viewModel);
        //    appointmentControl.NavigateToDashboard += AppointmentControl_NavigateToDashboard;
        //    MainContent.Content = appointmentControl;
        //}

        //private void AppointmentControl_NavigateToDashboard()
        //{
        //    var dashboardControl = new PatientDashboardControl(_viewModel);
        //    MainContent.Content = dashboardControl;
        //}

        private void btnRegistration_Click(object sender, RoutedEventArgs e)
        {
            var patientRegControl = new PatientRegControl(_viewModel);
            patientRegControl.RegistrationCompleted += () => MainContent.Content = null;
            //var mainWindow  = Window.GetWindow(this) as MainWindow;
            //if(mainWindow != null)
            //{
            //    mainWindow.MainContent.Content = patientRegControl;
            //}
            MainContent.Content = patientRegControl;
        }

        private void btnAppointment_Click(object sender, RoutedEventArgs e)
        {
            var appointmentConfirmationControl = new AppointmentConfirmationControl(_viewModel);
            appointmentConfirmationControl.AppointmentCompleted += () => MainContent.Content = null;
            //var mainWindow = Window.GetWindow(this) as MainWindow;
            //if (mainWindow != null)
            //{
            //    mainWindow.MainContent.Content = appointmentConfirmationControl;
            //}
            MainContent.Content = appointmentConfirmationControl;

        }

        private void btnDashboard_Click(object sender, RoutedEventArgs e)
        {
            var patientDashboardControl = new PatientDashboardControl(_viewModel);
            //var mainWindow = Window.GetWindow(this) as MainWindow;
            //if (mainWindow != null)
            //{
            //    mainWindow.MainContent.Content = patientDashboardControl;
            //}
            MainContent.Content = patientDashboardControl;

        }
    }
}
