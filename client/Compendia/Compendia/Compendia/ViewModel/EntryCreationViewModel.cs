using Compendia.Database;
using Compendia.Model;
using Compendia.ViewModel.Base;
using Newtonsoft.Json.Linq;
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
        private string titel;
        private string text;
        private DateTime date;
        private bool buttonvisible_show;
        private bool buttonvisible_create;
        private bool pickerVisible;
        private bool itemVisible;
        private View Testview;

        #endregion Attributes

        #region Properties

        public string EntryTitel
        {
            get
            {
                return titel;
            }
            set
            {
                titel = value;
                OnPropertyChanged();

            }
        }
        public string EditorText
        {
            get
            {
                return text;
            }
            set
            {
                text = value;
                OnPropertyChanged();

            }
        }
        public DateTime PickerDate
        {
            get
            {
                return date;
            }
            set
            {
                date = value;
                OnPropertyChanged();
            }

        }

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
                   if (SelctedPickerItemMask != null) { 
                        ItemVisible = true;
                        if (SelctedPickerItemMask.Equals("Termin"))
                        {
                         PickerVisibel = true;
                        }
                        else
                        {
                        PickerVisibel = false;
                        }
                        VisibleButtonCreate = true;
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
                return new Command(async() =>
                {
                    //Daten in Datenbank schreiben 
                    await Server.GetHTTPResquestAsync();
                    var user = "testuser";//await DatabaseService._LogInRepository.GetObjectsAsync();
                    var templresult = await Server.GetTemplates(user);
                    JObject templ = JObject.Parse(templresult);
                    JArray items = (JArray)templ["result"]["templates"];
                    int length = items.Count;
                    var test = templ["result"]["templates"][0]["templateName"].ToString();


                    if (PickerVisibel)
                    {
                        //Termin
                        string[] types = {"titel", "date","text"};
                        string[] parameters = { EntryTitel, PickerDate.ToString(), EditorText };
                        var str = JsonHandler.Instance.GetRequestString("Termin", parameters, types);
                        
                        for (int i = 0; i < length; i++)
                        {
                            if (templ["result"]["templates"][i]["templateName"].ToString().Equals("Termin")){
                                var templateId = templ["result"]["templates"][i]["templateUuid"];
                                var result = await Server.AddEntry(user, templateId.ToString(), str);
                                break;
                            }
                        }
                        

                    }
                    else
                    {
                        //Eintrag
                        string[] types = { "titel", "text" };
                        string[] parameters = { EntryTitel, EditorText };
                        var str = JsonHandler.Instance.GetRequestString("Termin", parameters, types);
                        
                        for (int i = 0; i <length; i++)
                        {
                            if (templ["result"]["templates"][i]["templateName"].ToString().Equals("Eintrag")){
                                var templateId = templ["result"]["templates"][i]["templateUuid"];
                                var result = await Server.AddEntry(user,templateId.ToString(), str);
                            }
                        }
                        
                    }
                    EntryTitel = String.Empty;
                    EditorText = String.Empty;
                    
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
            PickerDate = DateTime.Today;



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
