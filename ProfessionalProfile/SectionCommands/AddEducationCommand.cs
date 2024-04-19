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
    public class AddEducationCommand : SectionCommandBase
    {
        private readonly EducationRepo educationRepo;
        private readonly EducationViewModel educationViewModel;
        private readonly int userId;

        public AddEducationCommand(EducationViewModel educationViewModel, EducationRepo educationRepo, int userId)
        {
            educationRepo = educationRepo;
            educationViewModel = educationViewModel;
            userId = userId;
            educationViewModel.PropertyChanged += OnViewModelPropertyChanged;
        }

        public override void Execute(object parameter)
        {
            double gpa;
            if (double.TryParse(educationViewModel.GPA, out gpa))
            {
                Education education = new Education(
                                                4,
                                                userId,
                                                educationViewModel.Degree,
                                                educationViewModel.Institution,
                                                educationViewModel.FieldOfStudy,
                                                educationViewModel.GraduationDate,
                                                gpa);

                try
                {
                    educationRepo.Add(education);
                    MessageBox.Show("Education added successfully", "Success", MessageBoxButton.OK, MessageBoxImage.Information);
                }
                catch (CustomSectionException ex)
                {
                    MessageBox.Show(ex.Message, "Error", MessageBoxButton.OK, MessageBoxImage.Error);
                }
            }
            else
            {
                MessageBox.Show("Invalid GPA value. Please enter a numerical value.", "Error", MessageBoxButton.OK, MessageBoxImage.Error);
            }
        }

        public override bool CanExecute(object parameter)
        {
            return !string.IsNullOrEmpty(educationViewModel.Degree) &&
                !string.IsNullOrEmpty(educationViewModel.Institution) &&
                !string.IsNullOrEmpty(educationViewModel.FieldOfStudy) &&
                !string.IsNullOrEmpty(educationViewModel.GPA) &&
                base.CanExecute(parameter);
        }

        private void OnViewModelPropertyChanged(object? sender, PropertyChangedEventArgs e)
        {
            if (e.PropertyName == nameof(EducationViewModel.Degree) ||
                               e.PropertyName == nameof(EducationViewModel.Institution) ||
                                              e.PropertyName == nameof(EducationViewModel.FieldOfStudy) ||
                                                             e.PropertyName == nameof(EducationViewModel.GPA))
            {
                OnCanExecuteChanged();
            }
        }
    }
}
