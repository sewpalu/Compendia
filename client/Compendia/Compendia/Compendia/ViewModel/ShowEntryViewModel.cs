using Compendia.Model;
using Compendia.ViewModel.Base;
using Newtonsoft.Json.Linq;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Compendia.ViewModel
{
    public class ShowEntryViewModel : BaseViewModel
    {
        public IList<EntryModel> Entrys { get; private set; }

        public ShowEntryViewModel()
        {

            Entrys = new List<EntryModel>();
            LoadEntrysAsync();
           

        }

        private async void LoadEntrysAsync()
        {

                var get = await Server.GetHTTPResquestAsync();
                // Entrys aus der Datenbank laden 
                var templresult = await Server.GetTemplates("testuser");


                JObject templ = JObject.Parse(templresult);
                JArray items = (JArray)templ["result"]["templates"];
                int length = items.Count;
                string terminId = String.Empty;
                string eintragId = String.Empty;
                for (int i = 0; i < length; i++)
                {
                    if (templ["result"]["templates"][i]["templateName"].ToString().Equals("Termin"))
                    {
                        terminId = templ["result"]["templates"][i]["templateUuid"].ToString();
                        await  Task.Delay(100);
                        LoadTerminAsync(terminId);

                    }
                    else if (templ["result"]["templates"][i]["templateName"].ToString().Equals("Eintrag"))
                    {
                        eintragId = templ["result"]["templates"][i]["templateUuid"].ToString();
                        await Task.Delay(100);
                        LoadEintraegeAsync(eintragId);

                    }

                }
            

        }
        private async void  LoadTerminAsync(string terminId)
        {
            
                var entries = await Server.getEntries("testuser", terminId, "2020-Mar-09 09:00:00");
                var termine = JObject.Parse(entries);//YYYY-MMM-DD hh:mm:ss

                var items = (JArray)termine["result"]["entries"];

                var length = items.Count;

                for (int i = 0; i < length; i++)
                {
                    var termin = termine["result"]["entries"][i]["entryDefinition"];
                    termin = JObject.Parse(termin.ToString());



                    // Entrys zu Entry-Liste hinzufügen
                    Entrys.Add(new EntryModel
                    {
                        Titel = termin["parameters"]["titel"].ToString(),
                        Date = termin["parameters"]["date"].ToString(),
                        Text = termin["parameters"]["text"].ToString()
                    }); ;

                }

           
            OnPropertyChanged();
        }

        private async void LoadEintraegeAsync(string eintragsId)
        {
           

                var entries = await Server.getEntries("testuser", eintragsId, "2020-Mar-09 09:00:00");
                var eintaege = JObject.Parse(entries);//YYYY-MMM-DD hh:mm:ss

                var items = (JArray)eintaege["result"]["entries"];

                var length = items.Count;

                for (int i = 0; i < length; i++)
                {
                    var eintrag = eintaege["result"]["entries"][i]["entryDefinition"];
                    eintrag = JObject.Parse(eintrag.ToString());



                    // Entrys zu Entry-Liste hinzufügen
                    Entrys.Add(new EntryModel
                    {
                        Titel = eintrag["parameters"]["titel"].ToString(),
                        Date = String.Empty,
                        Text = eintrag["parameters"]["text"].ToString()
                    }); ;

                }

            OnPropertyChanged();
        }


    }
}
