﻿using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Runtime.CompilerServices;
using System.Text;
using System.Threading.Tasks;
using Xamarin.Forms;

namespace Compendia.ViewModel.Base
{
    public abstract class BaseViewModel : INotifyPropertyChanged
    {
        public async Task PushAsync(Page p)
        {
            await Application.Current.MainPage.Navigation.PushAsync(p);
        }

        public async Task PopAsybc()
        {
            await Application.Current.MainPage.Navigation.PopAsync();
        }

        public async Task PoModalAsynsc()
        {
            await Application.Current.MainPage.Navigation.PopModalAsync();
        }


        public async Task PushModalAsync(Page p)
        {
            await Application.Current.MainPage.Navigation.PushModalAsync(p);
        }


        public event PropertyChangedEventHandler PropertyChanged;
        protected virtual void OnPropertyChanged([CallerMemberName] string propertyName = "")
        {
            this.PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(propertyName));
        }
    }
}
