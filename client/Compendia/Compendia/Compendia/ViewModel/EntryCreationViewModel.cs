using Compendia.Database;
using Compendia.Model;
using Compendia.ViewModel.Base;
using System;
using System.Collections.Generic;
using System.Text;
using System.Windows.Input;
using Xamarin.Forms;

namespace Compendia.ViewModel
{
    public class EntryCreationViewModel : BaseViewModel
    {

        #region Attributes
        private List<string> pickerItemMaske;

        private string selectedItem;
        private bool buttonvisible_show;
        private bool buttonvisible_create;
        private bool pickerVisible;
        private bool itemVisible;
        private View Testview;

        #endregion Attributes

        #region Properties


        public string SelctedPickerItemMask
        {
            get
            {
                return selectedItem;
            }
            set
            {
                selectedItem = value;
                OnPropertyChanged();

            }

        }

        public List<string> PickerItemMaske
        {
            get => pickerItemMaske;
            set
            {
                pickerItemMaske = value;
                OnPropertyChanged(nameof(PickerItemMaske));
            }
        }
        public bool VisibleButtonShow
        {
            get => buttonvisible_show;
            set
            {
                buttonvisible_show = value;
                OnPropertyChanged();
            }
        }
        public bool VisibleButtonCreate
        {
            get => buttonvisible_create;
            set
            {
                buttonvisible_create = value;
                OnPropertyChanged();
            }
        }
        public bool PickerVisibel
        {
            get => pickerVisible;
            set
            {
                pickerVisible = value;
                OnPropertyChanged();
            }
        }
        public bool ItemVisible
        {
            get => itemVisible;
            set
            {
                itemVisible = value;
                OnPropertyChanged();
            }
        }


        public ICommand ShowCommand
        {
            get
            {
                return new Command(() =>
                {
                    ItemVisible = true;
                    if (SelctedPickerItemMask.Equals("Termin"))
                    {
                        PickerVisibel = true;
                    }
                    else
                    {
                        PickerVisibel = false;
                    }
                   

                });
            }
            set
            {

            }
        }
        public ICommand CreateCommand
        {
            get
            {
                return new Command(() =>
                {
                    //Daten in Datenbank schreiben 


                });
            }
            set
            {

            }
        }
        



        #endregion Properties
        #region Consturctor
        public EntryCreationViewModel()
        {
            PickerItemMaske = new List<string>();
            
            GeneratePicker();
            VisibleButtonShow = true;
            VisibleButtonCreate = false;
            ItemVisible = false;
            PickerVisibel = false;




        }
        #endregion Constructor

        
        private void AddtoPicker(string txt)
        {
            PickerItemMaske.Add(txt);
        }


        public  void GeneratePicker()
        {
            AddtoPicker("Eintrag");
            AddtoPicker("Termin");


        }
    }
}
