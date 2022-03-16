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
    public class HeroesViewModel :ObservableRecipient
    {
        public RestCollection<Hero> Heroes { get; set; }
        private Hero selectedHero;
        RestService restService = new("http://localhost:29868/");
        public IList<int> elements { get => restService.Get<Element>("element").Select(t => t.ElementId).ToList(); }

        public Hero SelectedHero
        {
            get { return selectedHero; }
            set
            {
                if (value != null)
                {
                    selectedHero = new Hero()
                    {
                        Name = value.Name,
                        HeroId = value.HeroId,
                        Abilities = value.Abilities,
                        AttackPower = value.AttackPower,
                        DefensePower = value.DefensePower,
                        Element = value.Element,
                        ElementId = value.ElementId
                    };
                    OnPropertyChanged();
                    (DeleteHeroCommand as RelayCommand).NotifyCanExecuteChanged();
                }


            }
        }

        public static bool IsInDesignMode
        {
            get
            {
                var prop = DesignerProperties.IsInDesignModeProperty;
                return (bool)DependencyPropertyDescriptor.FromProperty(prop, typeof(FrameworkElement)).Metadata.DefaultValue;
            }
        }

        public ICommand CreateHeroCommand { get; set; }
        public ICommand DeleteHeroCommand { get; set; }
        public ICommand UpdateHeroCommand { get; set; }

        public HeroesViewModel()
        {

            if (!IsInDesignMode)
            {
                Heroes = new RestCollection<Hero>("http://localhost:29868/", "Hero", "hub");

                CreateHeroCommand = new RelayCommand(() =>
                {

                    Heroes.Add(new Hero()
                    {
                        Name = SelectedHero.Name,
                        AttackPower = SelectedHero.AttackPower,
                        DefensePower = SelectedHero.DefensePower,
                        ElementId = SelectedHero.ElementId,
                        
                    });
                });

                DeleteHeroCommand = new RelayCommand(
                    () => Heroes.Delete(SelectedHero.HeroId),
                    () => SelectedHero != null
                );

                UpdateHeroCommand = new RelayCommand(() =>
                {
                    Heroes.Update(SelectedHero);
                });

                SelectedHero = new();
            }


        }
    }
}
