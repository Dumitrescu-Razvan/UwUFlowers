using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using ProfessionalProfile.Domain;
using ProfessionalProfile.Repo;
using ProfessionalProfile.SectionViewModels;

namespace ProfessionalProfile.SectionCommands
{
    public class AddSkillCommand : SectionCommandBase
    {
        private readonly SkillViewModel skillViewModel;
        private readonly SkillRepo skillRepo;
        private readonly int userId;

        public AddSkillCommand(SkillViewModel skillViewModel, SkillRepo skillRepo, int userId)
        {
            skillViewModel = skillViewModel;
            skillRepo = skillRepo;
            userId = userId;
            skillViewModel.PropertyChanged += OnViewModelPropertyChanged;
        }
        public override void Execute(object parameter)
        {
            string modifiedSkillName = skillViewModel.SkillName.ToLower().Replace(" ", string.Empty);
            Skill skill = new Skill(4, modifiedSkillName);

            skillRepo.Add(skill);
            MessageBox.Show("Skill added successfully", "Success", MessageBoxButton.OK, MessageBoxImage.Information);
        }

        public override bool CanExecute(object parameter)
        {
            return !string.IsNullOrEmpty(skillViewModel.SkillName) &&
                base.CanExecute(parameter);
        }

        private void OnViewModelPropertyChanged(object? sender, PropertyChangedEventArgs e)
        {
            if (e.PropertyName == nameof(SkillViewModel.SkillName))
            {
                OnCanExecuteChanged();
            }
        }
    }
}
