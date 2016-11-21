﻿using FabrikamFood.APIManagers;
using FabrikamFood.Views;
using Microsoft.WindowsAzure.MobileServices;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using Xamarin.Forms;

namespace FabrikamFood
{
    public interface IAuthenticate
        {
            Task<bool> Authenticate(MobileServiceAuthenticationProvider authProvider);
        Task<bool> LogoutAsync();
    }

    public partial class App : Application
    {

        public static NavigationPage NavigationPage { get; private set; }
        public static RootPage RootPage;
        public static IAuthenticate Authenticator { get; private set; }


        public static void Init(IAuthenticate authenticator)
        {
            Authenticator = authenticator;
        }

        public static bool MenuIsPresented
        {
            get
            {
                return RootPage.IsPresented;
            }
            set
            {
                RootPage.IsPresented = value;
            }
        }

        public App()
        {


            if (AzureAuthManager.Instance.CurrentClient.CurrentUser == null)
            {
                NavigationPage = new NavigationPage(new LoginPage());
            }
            else
            {
                NavigationPage = new NavigationPage(new MainPage());
            }
            var menuPage = new MenuPage();
            RootPage = new RootPage();
            RootPage.Master = menuPage;
            RootPage.Detail = NavigationPage;
            MainPage = RootPage;

            

        }


        protected override void OnStart()
        {
            // Handle when your app starts
        }

        protected override void OnSleep()
        {
            // Handle when your app sleeps
        }

        protected override void OnResume()
        {
            // Handle when your app resumes
        }
    }
}