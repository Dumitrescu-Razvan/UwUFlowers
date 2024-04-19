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
    public class AddWorkExperienceCommand : SectionCommandBase
    {
        private readonly WorkExperienceRepo workExperienceRepo;
        private readonly WorkExperienceViewModel workExperienceViewModel;
        private readonly int userId;

        public AddWorkExperienceCommand(WorkExperienceViewModel workExperienceViewModel, WorkExperienceRepo workExperienceRepo, int userId)
        {
            workExperienceRepo = workExperienceRepo;
            workExperienceViewModel = workExperienceViewModel;
            userId = userId;
            workExperienceViewModel.PropertyChanged += OnViewModelPropertyChanged;
        }

        public override void Execute(object parameter)
        {
            WorkExperience workExperience = new WorkExperience(4, userId, workExperienceViewModel.JobTitle, workExperienceViewModel.Company, workExperienceViewModel.Location, workExperienceViewModel.EmploymentPeriod, workExperienceViewModel.Responsibilities, workExperienceViewModel.Achievements, workExperienceViewModel.Description);

            try
            {
                workExperienceRepo.Add(workExperience);
                MessageBox.Show("Work Experience added successfully", "Success", MessageBoxButton.OK, MessageBoxImage.Information);
            }
            catch (CustomSectionException ex)
            {
                MessageBox.Show(ex.Message, "Error", MessageBoxButton.OK, MessageBoxImage.Error);
            }
        }

        public override bool CanExecute(object parameter)
        {
            return !string.IsNullOrEmpty(workExperienceViewModel.JobTitle) &&
                !string.IsNullOrEmpty(workExperienceViewModel.Company) &&
                !string.IsNullOrEmpty(workExperienceViewModel.Location) &&
                !string.IsNullOrEmpty(workExperienceViewModel.EmploymentPeriod) &&
                !string.IsNullOrEmpty(workExperienceViewModel.Responsibilities) &&
                !string.IsNullOrEmpty(workExperienceViewModel.Achievements) &&
                !string.IsNullOrEmpty(workExperienceViewModel.Description) &&
                base.CanExecute(parameter);
        }

        private void OnViewModelPropertyChanged(object? sender, PropertyChangedEventArgs e)
        {
            if (e.PropertyName == nameof(WorkExperienceViewModel.JobTitle) ||
                               e.PropertyName == nameof(WorkExperienceViewModel.Company) ||
                                              e.PropertyName == nameof(WorkExperienceViewModel.Location) ||
                                                             e.PropertyName == nameof(WorkExperienceViewModel.EmploymentPeriod) ||
                                                                            e.PropertyName == nameof(WorkExperienceViewModel.Responsibilities) ||
                                                                                           e.PropertyName == nameof(WorkExperienceViewModel.Achievements) ||
                                                                                                          e.PropertyName == nameof(WorkExperienceViewModel.Description))
            {
                OnCanExecuteChanged();
            }
        }
    }
}
