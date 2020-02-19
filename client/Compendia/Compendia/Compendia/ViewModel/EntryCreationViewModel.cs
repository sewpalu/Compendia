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

        private List<ItemModel> _itemList;
        private ItemModel child;



        #endregion Attributes

        #region Properties

        public List<ItemModel> ItemList
        {
            get => _itemList;
            set
            {
                _itemList = value;
                OnPropertyChanged(nameof(ItemList));
            }
        }
        public string SelctedPickerItemMaske { get; set; }

        public Object Child
        {
            get
            {
                return child;   
            }
            set
            {
                child = new ItemModel(value);

                OnPropertyChanged(nameof(Child));

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
        public ICommand AddItemCommand
        {
            get
            {
                return new Command(() =>
                {
                    AddtoItem(new ItemModel(new Button()));
                });
            }
            set{ }
        }

        #endregion Properties
        #region Consturctor
        public EntryCreationViewModel()
        {
            PickerItemMaske = new List<string>();
            ItemList = new List<ItemModel>();
            AddtoPicker("Standardmaske");
            AddtoPicker("Standardmaske2");
            AddtoPicker("Standardmaske45q");

           

        }
        #endregion Constructor
        private void AddtoPicker(string txt)
        {
            PickerItemMaske.Add(txt);
        }

        private void AddtoItem(Object o)
        {
            Child = o;
        }
/*

        private void AddtoItemList(string txt)
        {
            var tmp = new List<ItemModel>(ItemList);
            tmp.Add(new ItemModel(new Entry()));;

            ItemList = tmp;

            
        }*/
    }
}
