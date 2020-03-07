using Compendia.Model;
using Compendia.ViewModel.Base;
using System;
using System.Collections.Generic;
using System.Text;

namespace Compendia.ViewModel
{
    public class ShowEntryViewModel : BaseViewModel
    {
        public IList<EntryModel> Entrys { get; private set; }

        public ShowEntryViewModel()
        {

            Entrys = new List<EntryModel>();
            LoadEntrys();
           

        }

        private void LoadEntrys()
        {
            for(int i = 0; i<30; i++)
            {
                Entrys.Add(new EntryModel
                {
                    Titel = "Mein Eintrag " + i,
                    Date = "07.03.2020",
                    Text = "Bla Bla Bla "+(i+3)+" Bla Bla Bla Bla Bla "+i
                });


            }

            
            

        }


    }
}
