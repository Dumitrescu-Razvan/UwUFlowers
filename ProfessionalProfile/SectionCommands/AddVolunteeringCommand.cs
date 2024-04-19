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
    public class AddVolunteeringCommand : SectionCommandBase
    {
        private readonly VolunteeringRepo volunteeringRepo;
        private readonly VolunteeringViewModel volunteeringViewModel;
        private readonly int userId;

        public AddVolunteeringCommand(VolunteeringRepo volunteeringRepo, VolunteeringViewModel volunteeringViewModel, int userId)
        {
            volunteeringRepo = volunteeringRepo;
            volunteeringViewModel = volunteeringViewModel;
            userId = userId;
            volunteeringViewModel.PropertyChanged += OnViewModelPropertyChanged;
        }
        public override void Execute(object parameter)
        {
            Volunteering volunteering = new Volunteering(4, userId, volunteeringViewModel.Organisation, volunteeringViewModel.Role, volunteeringViewModel.Description);

            volunteeringRepo.Add(volunteering);
            MessageBox.Show("Volunteering added successfully", "Success", MessageBoxButton.OK, MessageBoxImage.Information);
        }

        public override bool CanExecute(object parameter)
        {
            return !string.IsNullOrEmpty(volunteeringViewModel.Organisation) &&
                !string.IsNullOrEmpty(volunteeringViewModel.Role) &&
                !string.IsNullOrEmpty(volunteeringViewModel.Description) &&
                base.CanExecute(parameter);
        }

        private void OnViewModelPropertyChanged(object? sender, PropertyChangedEventArgs e)
        {
            if (e.PropertyName == nameof(VolunteeringViewModel.Organisation) ||
                               e.PropertyName == nameof(VolunteeringViewModel.Role) ||
                                              e.PropertyName == nameof(VolunteeringViewModel.Description))
            {
                OnCanExecuteChanged();
            }
        }
    }
}
