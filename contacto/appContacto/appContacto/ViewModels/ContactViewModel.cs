using appContacto.Models;
using appContacto.Services;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using Xamarin.Forms;

namespace appContacto.ViewModels
{
    public class ContactViewModel:BaseViewModel 
    {
        #region Attributes
        ApiService apiservice;
        private ObservableCollection<Contact> contacts;
        private ApiService apiService;
        #endregion

        #region Properties
        public ObservableCollection<Contact> Contacts
        {
            get { return this.contacts; }
            set { SetValue(ref this.contacts, value); }
        }
        #endregion

        #region Constructor
        public ContactViewModel()
        {
            this.apiService = new ApiService();
            this.LoadContacts();
        }
        #endregion

        #region Methods
        private async void LoadContacts()
        {
            var connection = await this.apiService.CheckConnection();
            if (!connection.IsSuccess)
            {
                await Application.Current.MainPage.DisplayAlert(
                    "Connection Error",
                    connection.Message,
                    "Accept"
                    );
                return;
            }

            var response = await this.apiService.GetList<Contact>(
                "http://localhost:49999/",
                "api/",
                "Contacts");
            if (!response.IsSuccess)
            {
                await Application.Current.MainPage.DisplayAlert(
                    "Get Contact Error",
                    response.Message,
                    "Accept"
                    );
                return;
            }

            MainViewModel mainViewModel = MainViewModel.GetInstance();
            mainViewModel.ContactList = (List<Contact>)response.Result;
            //this.Contacts = new ObservableCollection<Contact>();
        }
        #endregion




    }
}
