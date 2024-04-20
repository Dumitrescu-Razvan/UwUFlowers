using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using ProfessionalProfile.Domain;
using ProfessionalProfile.Repo;
using ProfessionalProfile.SectionExceptions;
using ProfessionalProfile.SectionViewModels;

namespace ProfessionalProfile.SectionCommands
{
    public class EditVolunteeringCommand : SectionCommandBase
    {
        private readonly EditVolunteeringViewModel ViewModel;
        private readonly VolunteeringRepo volunteeringRepo;
        private readonly int userId;
        private readonly int volunteeringId;

        public EditVolunteeringCommand(EditVolunteeringViewModel ViewModel, VolunteeringRepo volunteeringRepo, int userId, int volunteeringId)
        {
            ViewModel = ViewModel;
            volunteeringRepo = volunteeringRepo;
            userId = userId;
            volunteeringId = volunteeringId;

            ViewModel.PropertyChanged += OnViewModelPropertyChanged;
        }

        private void OnViewModelPropertyChanged(object? sender, PropertyChangedEventArgs e)
        {
            if (e.PropertyName == nameof(ViewModel.Organisation) ||
                               e.PropertyName == nameof(ViewModel.Role) ||
                                             e.PropertyName == nameof(ViewModel.Description))
            {
                OnCanExecuteChanged();
            }
        }

        public override void Execute(object parameter)
        {
            Volunteering updatedVolunteering = new Volunteering(
                                               volunteeringId,
                                              userId,
                                              ViewModel.Organisation, ViewModel.Role, ViewModel.Description);

            try
            {
                volunteeringRepo.Update(updatedVolunteering);
                MessageBox.Show("Volunteering updated successfully", "Success", MessageBoxButton.OK, MessageBoxImage.Information);
            }
            catch (CustomSectionException ex)
            {
                MessageBox.Show(ex.Message, "Error", MessageBoxButton.OK, MessageBoxImage.Error);
            }
        }

        public override bool CanExecute(object parameter)
        {
            return !string.IsNullOrEmpty(ViewModel.Organisation) &&
                !string.IsNullOrEmpty(ViewModel.Role) &&
                !string.IsNullOrEmpty(ViewModel.Description);
        }
    }
}
