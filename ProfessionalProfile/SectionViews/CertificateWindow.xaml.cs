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
using ProfessionalProfile.Repo;
using ProfessionalProfile.SectionViewModels;

namespace ProfessionalProfile.SectionViews
{
    /// <summary>
    /// Interaction logic for CertificateWindow.xaml
    /// </summary>
    public partial class CertificateWindow : Window
    {
        private int userId;
        private bool isLoggedIn;
        public CertificateWindow(int userId, bool isLoggedIn = false)
        {
            InitializeComponent();
            WindowState = WindowState.Maximized;
            this.UserId = userId;
            this.isLoggedIn = isLoggedIn;
            CertificateViewModel ViewModel = new CertificateViewModel(new CertificateRepo(), userId, isLoggedIn);
            DataContext = ViewModel;
        }

        public int UserId { get => userId; set => userId = value; }

        private void OpenVolunteeringWindow(object sender, RoutedEventArgs e)
        {
            VolunteeringWindow volunteeringWindow = new VolunteeringWindow(UserId);
            this.Visibility = Visibility.Hidden;
            volunteeringWindow.Show();
        }
    }
}
