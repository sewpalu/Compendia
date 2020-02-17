using Compendia.ViewModel.Base;
using System;
using System.Collections.Generic;
using System.Text;

namespace Compendia.ViewModel
{
    public class EntryCreationViewModel : BaseViewModel
    {

        #region Attributes
        private List<string> pickerItemMaske;


        #endregion Attributes

        #region Properties

        public string SelctedPickerItemMaske { get; set; }
        public List<string> PickerItemMaske
        {
            get => pickerItemMaske;
            set
            {
                pickerItemMaske = value;
                OnPropertyChanged(nameof(PickerItemMaske));
            }
        }

        #endregion Properties
        #region Consturctor
        public EntryCreationViewModel()
        {
            PickerItemMaske = new List<string>();
            AddtoPicker("Standardmaske");
            AddtoPicker("Standardmaske2");
            AddtoPicker("Standardmaske45q");

        }
        #endregion Constructor
        private void AddtoPicker(string txt)
        {
            PickerItemMaske.Add(txt);
        }
    }
}
