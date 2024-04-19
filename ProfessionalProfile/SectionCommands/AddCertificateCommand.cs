using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using ProfessionalProfile.Domain;
using ProfessionalProfile.Profile_page;
using ProfessionalProfile.Repo;
using ProfessionalProfile.SectionExceptions;
using ProfessionalProfile.SectionViewModels;

namespace ProfessionalProfile.SectionCommands
{
    public class AddCertificateCommand : SectionCommandBase
    {
        private readonly CertificateRepo certificateRepo;
        private readonly CertificateViewModel certificateViewModel;
        private readonly int userId;
        private bool isLoggedIn;

        public AddCertificateCommand(SectionViewModels.CertificateViewModel certificateViewModel, CertificateRepo certificateRepo, int userId, bool isLoggedIn)
        {
            certificateRepo = certificateRepo;
            certificateViewModel = certificateViewModel;
            userId = userId;
            this.isLoggedIn = isLoggedIn;
            certificateViewModel.PropertyChanged += OnViewModelPropertyChanged;
        }

        public override void Execute(object parameter)
        {
            Certificate certificate = new Certificate(
                    4,
                    userId,
                    certificateViewModel.CertificateName,
                    certificateViewModel.IssuedBy,
                    certificateViewModel.Description,
                    certificateViewModel.IssuedDate,
                    certificateViewModel.ExpirationDate);

            try
            {
                certificateRepo.Add(certificate);
                MessageBox.Show("Certificate added successfully", "Success", MessageBoxButton.OK, MessageBoxImage.Information);
                ProfilePage profilePage = new ProfilePage(userId, userId);
                profilePage.Show();
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
