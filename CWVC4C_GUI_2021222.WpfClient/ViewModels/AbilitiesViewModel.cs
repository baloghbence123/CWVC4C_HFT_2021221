using CWVC4C_HFT_2021221.Models;
using Microsoft.Toolkit.Mvvm.ComponentModel;
using Microsoft.Toolkit.Mvvm.Input;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Input;

namespace CWVC4C_GUI_2021222.WpfClient.ViewModels
{
    public class AbilitiesViewModel :ObservableRecipient
    {
    
        public RestCollection<Ability> Abilities { get; set; }

        
        RestService restService = new("http://localhost:29868/");
        public IList<int> heroids { get => restService.Get<Hero>("hero").Select(t => t.HeroId).ToList(); }
        private Ability selectedAbility;
        public Ability SelectedAbility
        {
            get { return selectedAbility; }
            set
            {
                if (value!=null)
                {
                    selectedAbility = new Ability()
                    {
                        AbilityId =value.AbilityId,
                        Name = value.Name,
                        DMG = value.DMG,
                        HeroId = value.HeroId,
                        ManaCost = value.ManaCost,
                        
                    };
                    OnPropertyChanged();
                    (DeleteAbilityCommand as RelayCommand).NotifyCanExecuteChanged();
                }
            }
        }

        public ICommand CreateAbilityCommand { get; set; }
        public ICommand UpdateAbilityCommand { get; set; }
        public ICommand DeleteAbilityCommand { get; set; }

        public bool IsInDesignMode { get 
            {
                var prop = DesignerProperties.IsInDesignModeProperty;
                return (bool)DependencyPropertyDescriptor.FromProperty(prop, typeof(FrameworkElement)).Metadata.DefaultValue;
            } 
        }

        public AbilitiesViewModel()
        {
            
            if (!IsInDesignMode)
            {
                Abilities = new RestCollection<Ability>("http://localhost:29868/", "Ability", "hub");

                CreateAbilityCommand = new RelayCommand(() =>
                {

                    Abilities.Add(new CWVC4C_HFT_2021221.Models.Ability()
                    {
                        Name = SelectedAbility.Name,
                        DMG = SelectedAbility.DMG,
                        HeroId = SelectedAbility.HeroId,
                        ManaCost = SelectedAbility.ManaCost,
                    });
                });

                DeleteAbilityCommand = new RelayCommand(
                    () => Abilities.Delete(SelectedAbility.AbilityId),
                    () => SelectedAbility != null
                );

                UpdateAbilityCommand = new RelayCommand(() =>
                {
                    Abilities.Update(SelectedAbility);
                });

                SelectedAbility = new();

            }


        }

    }
}
