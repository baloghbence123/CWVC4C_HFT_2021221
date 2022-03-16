using CWVC4C_HFT_2021221.Models;
using Microsoft.Toolkit.Mvvm.ComponentModel;
using Microsoft.Toolkit.Mvvm.Input;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Input;

namespace CWVC4C_GUI_2021222.WpfClient.ViewModels
{
    public class ElementsViewModel : ObservableRecipient
    {
        public RestCollection<Element> Element { get; set; }
        private Element selectedElement;

        public Element SelectedElement
        {
            get { return selectedElement; }
            set
            {
                if (value != null)
                {
                    selectedElement = new CWVC4C_HFT_2021221.Models.Element()
                    {
                       Name=value.Name,
                       
                    };
                    OnPropertyChanged();
                    (DeleteElementCommand as RelayCommand).NotifyCanExecuteChanged();
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

        public ICommand CreateElementCommand { get; set; }
        public ICommand DeleteElementCommand { get; set; }
        public ICommand UpdateElementCommand { get; set; }

        public ElementsViewModel()
        {

            if (!IsInDesignMode)
            {
                Element = new RestCollection<Element>("http://localhost:29868/", "Element", "hub");

                CreateElementCommand = new RelayCommand(() =>
                {

                    Element.Add(new CWVC4C_HFT_2021221.Models.Element()
                    {
                        Name = SelectedElement.Name
                    });
                });

                DeleteElementCommand = new RelayCommand(
                    () => Element.Delete(SelectedElement.ElementId),
                    () => SelectedElement != null
                );

                UpdateElementCommand = new RelayCommand(() =>
                {
                    Element.Update(SelectedElement);
                });

                SelectedElement = new();
            }


        }
    }
}
