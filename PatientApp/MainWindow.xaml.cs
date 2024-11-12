﻿using System;
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
            _viewModel.OnPatientRegistered += OnPatientRegistered;
        }

        private void OnPatientRegistered(object sender, Patient patient)
        {
            MessageBox.Show($"Patient {patient.Name} registered!", "Registration Success", MessageBoxButton.OK, MessageBoxImage.Information);
        }

        private void btnRegistration_Click(object sender, RoutedEventArgs e)
        {
            var patientRegControl = new PatientRegControl(_viewModel);
            patientRegControl.RegistrationCompleted += (s,args) => MainContent.Content = null;
            patientRegControl.NavigateToAppointment += (s,args) =>
            {
                var appointmentControl = new AppointmentConfirmationControl(_viewModel);
                appointmentControl.AppointmentCompleted += (s1, args1) => MainContent.Content = null;
                MainContent.Content = appointmentControl;
            };
            MainContent.Content = patientRegControl;
        }

        private void btnAppointment_Click(object sender, RoutedEventArgs e)
        {
            var appointmentConfirmationControl = new AppointmentConfirmationControl(_viewModel);
            appointmentConfirmationControl.AppointmentCompleted += (s,args) => MainContent.Content = null;
            MainContent.Content = appointmentConfirmationControl;
        }

        private void btnDashboard_Click(object sender, RoutedEventArgs e)
        {
            var patientDashboardControl = new PatientDashboardControl(_viewModel);
            MainContent.Content = patientDashboardControl;
        }

        private void Exit_Click(object sender, RoutedEventArgs e)
        {
            Application.Current.Shutdown();
        }
    }
}
