﻿using Compendia.Database;
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
        private List<View> mylist = new List<View>();
        private List<View> child;
        private bool buttonvisible_show;
        private bool buttonvisible_create;



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
        public string SelctedPickerItemMaske{get;set;}

        public List<View> Child
        {
            get
            {
                return child;   
            }
            set
            {
                child = value;

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
        public ICommand AddItemCommand
        {
            
            get
            {
                return new Command(() =>
                {
                    mylist.Clear();
                    switch (SelctedPickerItemMaske)
                    {
                        case "Eintrag":
                            Entry titel_e = new Entry();
                            titel_e.Placeholder = "Titel";
                            Editor text_e = new Editor();
                            mylist.Add(titel_e);
                            mylist.Add(text_e);
                            AddtoItem(mylist);break;
                        case "Termin":
                            Entry titel_t = new Entry();
                            titel_t.Placeholder = "Titel";
                            DatePicker datepicker = new DatePicker();
                            Editor text_t = new Editor();
                            mylist.Add(titel_t);
                            mylist.Add(datepicker);
                            mylist.Add(text_t);
                            AddtoItem(mylist); break;
                        default:
                            
                            Label label = new Label();
                            label.Text = "Keine Maske angegeben";
                            mylist.Add(label);
                            AddtoItem(mylist); break; 
                        
                    }
                   // VisibleButtonShow = false;
                    VisibleButtonCreate = true;
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
            GeneratePicker();
            VisibleButtonShow = true;
            VisibleButtonCreate = false;



        }
        #endregion Constructor
        private void AddtoPicker(string txt)
        {
            PickerItemMaske.Add(txt);
        }

        private void AddtoItem(List<View> v)
        {
            Child = v;
        }


        public async void GeneratePicker()
        {
            AddtoPicker("Eintrag");
            AddtoPicker("Termin");
            /*var tmp = await DatabaseService._MaskRepository.GetObjectsAsync();

            maskList = tmp;

            for (int i = 0; i < maskList.Count; i++)
            {
                AddtoPicker(maskList[i].name);

            }*/

        }
    }
}
