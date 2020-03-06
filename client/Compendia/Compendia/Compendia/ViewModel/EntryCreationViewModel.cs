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
        private List<View> mylist = new List<View>();
        private List<View> child;
        private bool buttonvisible_show;
        private bool buttonvisible_create;
        private View Testview;



        #endregion Attributes

        #region Properties


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
                    
                    mylist.Add(Testview);
                    AddtoItem(mylist);
                    /*mylist.Clear();
                    AddtoItem(mylist);
                    switch (SelctedPickerItemMaske)
                    {
                        case "Eintrag":
                            Entry titel_e = new Entry();

                            titel_e.FontSize = 30;
                            titel_e.Placeholder = "Titel";
                            Editor text_e = new Editor();
                            text_e.AutoSize = EditorAutoSizeOption.TextChanges;
                            mylist.Add(titel_e);
                            mylist.Add(text_e);
                            AddtoItem(mylist);break;
                        case "Termin":
                            Entry titel_t = new Entry();
                            titel_t.Placeholder = "Titel";
                            titel_t.FontSize = 30;
                            DatePicker datepicker = new DatePicker();
                            Editor text_t = new Editor();
                            text_t.AutoSize = EditorAutoSizeOption.TextChanges;
                            mylist.Add(titel_t);
                            mylist.Add(datepicker);
                            mylist.Add(text_t);
                            AddtoItem(mylist); break;
                        default:
                            
                            Label label = new Label();
                            label.Text = "Keine Maske angegeben";
                            mylist.Add(label);
                            AddtoItem(mylist); break; 
                        
                    }*/
                    VisibleButtonShow = false;
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
            
            GeneratePicker();
            VisibleButtonShow = true;
            VisibleButtonCreate = false;
            TestDatabase();


        }
        #endregion Constructor

        private async void TestDatabase()
        {
            var tmp = ItemController<Button>.ViewtoDatabase(new Button(), new DBMask("Beispiel"));
            var item = DatabaseService._ItemRepository.GetObjects();
            var type = ItemController<View>.Deserialize(item[0].Itemtype);

            /*var mask = new DBMask("Name");
            mask.AddItem(new Button());
            var w = await DatabaseService._MaskRepository.AddObjectAsync(mask);

            var item = DatabaseService._ItemRepository.GetObjects();
            var view = ItemController.Deserialize(item[0].Viewitem);*/

        }
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
