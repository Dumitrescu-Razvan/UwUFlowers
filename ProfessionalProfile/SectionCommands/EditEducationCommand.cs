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
    public class EditEducationCommand : SectionCommandBase
    {
        private readonly EditEducationViewModel ViewModel;
        private readonly EducationRepo educationRepo;
        private readonly int userId;
        private readonly int educationId;

        public EditEducationCommand(EditEducationViewModel ViewModel, EducationRepo educationRepo, int userId, int educationId)
        {
            ViewModel = ViewModel;
            educationRepo = educationRepo;
            userId = userId;
            educationId = educationId;
            ViewModel.PropertyChanged += OnViewModelPropertyChanged;
        }

        public override void Execute(object parameter)
        {
            double gpa;
            if (double.TryParse(ViewModel.GPA, out gpa))
            {
                Education updatedEducation = new Education(
                                   educationId,
                                                  userId,
                                                                 ViewModel.Degree,
                                                                                ViewModel.Institution,
                                                                                               ViewModel.FieldOfStudy,
                                                                                                              ViewModel.GraduationDate,
                                                                                                                             gpa);
                try
                {
                    educationRepo.Update(updatedEducation);
                    MessageBox.Show("Education updated successfully", "Success", MessageBoxButton.OK, MessageBoxImage.Information);
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
            return !string.IsNullOrEmpty(ViewModel.Degree) &&
                !string.IsNullOrEmpty(ViewModel.Institution) &&
                !string.IsNullOrEmpty(ViewModel.FieldOfStudy) &&
                !string.IsNullOrEmpty(ViewModel.GPA) &&
                base.CanExecute(parameter);
        }

        private void OnViewModelPropertyChanged(object? sender, PropertyChangedEventArgs e)
        {
            if (e.PropertyName == nameof(ViewModel.Degree) ||
                               e.PropertyName == nameof(ViewModel.Institution) ||
                                              e.PropertyName == nameof(ViewModel.FieldOfStudy) ||
                                                             e.PropertyName == nameof(ViewModel.GPA))
            {
                OnCanExecuteChanged();
            }
        }
    }
}
