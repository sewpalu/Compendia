using Compendia.Model;
using Compendia.ViewModel.Base;
using Newtonsoft.Json.Linq;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

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
                    
                }
                else if (templ["result"]["templates"][i]["templateName"].ToString().Equals("Eintrag"))
                {
                    eintragId = templ["result"]["templates"][i]["templateUuid"].ToString();

                }

            }
            var entries = await Server.getEntries("testuser", terminId, "2020-Mar-09 09:00:00");
            var termine = JObject.Parse(entries);//YYYY-MMM-DD hh:mm:ss

                items = (JArray)termine["result"]["entries"];
                
                length = items.Count;
               
                for (int i = 0; i < length; i++)
                {
                    var termin = termine["result"]["entries"][i]["entryDefinition"].ToString();
                    termin = termin.Remove(termin.Length-1,1);
                   
                    var newtermin = JToken.Parse(termin);

                // Entrys zu Entry-Liste hinzufügen
                Entrys.Add(new EntryModel
                    {
                        Titel = newtermin["parameters"]["titel"].ToString(),
                        Date = newtermin["parameters"]["date"].ToString(),
                        Text = newtermin["parameters"]["text"].ToString()
                    }); ;

            }
            


        }


    }
}
