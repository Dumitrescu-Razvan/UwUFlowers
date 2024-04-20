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
    public class EditWorkExperienceCommand : SectionCommandBase
    {
        private readonly EditWorkExperienceViewModel ViewModel;
        private readonly WorkExperienceRepo workExperienceRepo;
        private readonly int userId;
        private readonly int workExperienceId;

        public EditWorkExperienceCommand(EditWorkExperienceViewModel ViewModel, WorkExperienceRepo workExperienceRepo, int userId, int workExperienceId)
        {
            ViewModel = ViewModel;
            workExperienceRepo = workExperienceRepo;
            userId = userId;
            workExperienceId = workExperienceId;

            ViewModel.PropertyChanged += OnViewModelPropertyChanged;
        }

        private void OnViewModelPropertyChanged(object? sender, PropertyChangedEventArgs e)
        {
            if (e.PropertyName == nameof(ViewModel.JobTitle) ||
                               e.PropertyName == nameof(ViewModel.Company) ||
                                              e.PropertyName == nameof(ViewModel.Location) ||
                                                             e.PropertyName == nameof(ViewModel.EmploymentPeriod) ||
                                                                            e.PropertyName == nameof(ViewModel.Responsibilities) ||
                                                                                           e.PropertyName == nameof(ViewModel.Achievements) ||
                                                                                                          e.PropertyName == nameof(ViewModel.Description))
            {
                OnCanExecuteChanged();
            }
        }

        public override void Execute(object parameter)
        {
            WorkExperience updatedWorkExperience = new WorkExperience(
                               workExperienceId,
                                              userId,
                                                             ViewModel.JobTitle,
                                                                            ViewModel.Company,
                                                                                           ViewModel.Location,
                                                                                                          ViewModel.EmploymentPeriod,
                                                                                                                         ViewModel.Responsibilities,
                                                                                                                                        ViewModel.Achievements,
                                                                                                                                                       ViewModel.Description);

            try
            {
                workExperienceRepo.Update(updatedWorkExperience);
                MessageBox.Show("Work Experience updated successfully", "Success", MessageBoxButton.OK, MessageBoxImage.Information);
            }
            catch (CustomSectionException ex)
            {
                MessageBox.Show(ex.Message, "Error", MessageBoxButton.OK, MessageBoxImage.Error);
            }
        }

        public override bool CanExecute(object parameter)
        {
            return !string.IsNullOrEmpty(ViewModel.JobTitle) &&
                !string.IsNullOrEmpty(ViewModel.Company) &&
                !string.IsNullOrEmpty(ViewModel.Location) &&
                !string.IsNullOrEmpty(ViewModel.EmploymentPeriod) &&
                !string.IsNullOrEmpty(ViewModel.Responsibilities) &&
                !string.IsNullOrEmpty(ViewModel.Achievements) &&
                !string.IsNullOrEmpty(ViewModel.Description) &&
                base.CanExecute(parameter);
        }
    }
}
