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
    internal class EditCertificateCommand : SectionCommandBase
    {
        private readonly CertificateRepo certificateRepo;
        private readonly EditCertificateViewModel certificateViewModel;
        private readonly int certificateId;
        private readonly int userId;

        public EditCertificateCommand(EditCertificateViewModel certificateViewModel, CertificateRepo certificateRepo, int userId, int certificateId)
        {
            certificateRepo = certificateRepo;
            certificateViewModel = certificateViewModel;
            certificateId = certificateId;
            userId = userId;
            certificateViewModel.PropertyChanged += OnViewModelPropertyChanged;
        }

        public override void Execute(object parameter)
        {
            Certificate updatedCertificate = new Certificate(
                               certificateId,
                                              userId,
                                                             certificateViewModel.CertificateName,
                                                                            certificateViewModel.IssuedBy,
                                                                                           certificateViewModel.Description,
                                                                                                          certificateViewModel.IssuedDate,
                                                                                                                         certificateViewModel.ExpirationDate);

            try
            {
                certificateRepo.Update(updatedCertificate);
                MessageBox.Show("Certificate updated successfully", "Success", MessageBoxButton.OK, MessageBoxImage.Information);
            }
            catch (CustomSectionException ex)
            {
                MessageBox.Show(ex.Message, "Error", MessageBoxButton.OK, MessageBoxImage.Error);
            }
        }

        public override bool CanExecute(object parameter)
        {
            return !string.IsNullOrEmpty(certificateViewModel.CertificateName) &&
                !string.IsNullOrEmpty(certificateViewModel.IssuedBy) &&
                !string.IsNullOrEmpty(certificateViewModel.Description) &&
                base.CanExecute(parameter);
        }

        private void OnViewModelPropertyChanged(object? sender, PropertyChangedEventArgs e)
        {
            if (e.PropertyName == nameof(CertificateViewModel.CertificateName) ||
                e.PropertyName == nameof(CertificateViewModel.IssuedBy) ||
                e.PropertyName == nameof(CertificateViewModel.Description))
            {
                OnCanExecuteChanged();
            }
        }
    }
}
