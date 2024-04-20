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
    /// Interaction logic for EditVolunteeringWindow.xaml
    /// </summary>
    public partial class EditVolunteeringWindow : Window
    {
        public EditVolunteeringWindow(int userId, int volunteeringId)
        {
            InitializeComponent();
            WindowState = WindowState.Maximized;

            EditVolunteeringViewModel ViewModel = new EditVolunteeringViewModel(new VolunteeringRepo(), userId, volunteeringId);
            DataContext = ViewModel;
        }

        private void CloseWindow(object sender, RoutedEventArgs e)
        {
            this.Close();
        }
    }
}
