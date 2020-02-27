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
        private List<DBMask> maskList;
        private List<ItemModel> _itemList;
        private View child;



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

        public View Child
        {
            get
            {
                return child;   
            }
            set
            {
                child = value;

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
                return new Command(async() =>
                {
                   /* var tmp = await DatabaseService._MaskRepository.GetObjectsAsync();
                    foreach (var item in tmp)
                    {
                        if (SelctedPickerItemMaske.Equals(item.name))
                        {
                            foreach (var view in item.viewList)
                            {
                                AddtoItem(view);
                            }

                            break;
                        }
                    }*/

                });
            }
            set{ }
        }

        public ICommand PickerCommand
        {
            get
            {
                return new Command(async () =>
                {
                    /*var tmp = await DatabaseService._MaskRepository.GetObjectsAsync();
                    foreach(var item in tmp)
                    {
                        if (SelctedPickerItemMaske.Equals(item.name)){
                            foreach(var view in item.viewList)
                            {
                                AddtoItem(view);
                            }

                            break;
                        }
                    }*/
                    

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
            ItemList = new List<ItemModel>();
            AddtoPicker("Standardmaske");

            AddtoItem(new Entry());
            AddtoItem(new Label());
            AddtoItem(new BoxView());

           

        }
        #endregion Constructor
        private void AddtoPicker(string txt)
        {
            PickerItemMaske.Add(txt);
        }

        private void AddtoItem(View v)
        {
            Child = v;
        }


        public async void GeneratePickerKategorie()
        {
            /*var tmp = await DatabaseService._MaskRepository.GetObjectsAsync();

            maskList = tmp;

            for (int i = 0; i < maskList.Count; i++)
            {
                AddtoPicker(maskList[i].name);

            }*/

        }
    }
}
