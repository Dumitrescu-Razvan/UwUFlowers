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
    /// Interaction logic for EditEducationWindow.xaml
    /// </summary>
    public partial class EditEducationWindow : Window
    {
        public EditEducationWindow(int userId, int educationId)
        {
            InitializeComponent();
            WindowState = WindowState.Maximized;

            EditEducationViewModel ViewModel = new EditEducationViewModel(new EducationRepo(), userId, educationId);
            DataContext = ViewModel;
        }

        private void CloseWindow(object sender, RoutedEventArgs e)
        {
            this.Close();
        }
    }
}
