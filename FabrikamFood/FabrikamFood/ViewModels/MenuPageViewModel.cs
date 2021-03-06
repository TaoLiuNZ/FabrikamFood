﻿using FabrikamFood.Views;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Input;
using Xamarin.Forms;

namespace FabrikamFood.ViewModels
{
    class MenuPageViewModel
    {
        public ICommand GoHomeCommand { get; set; }
        public ICommand LogOutCommand { get; set; }
        public ICommand GoMenuCommand { get; set; }
        public ICommand GoReservationCommand { get; set; }

        public MenuPageViewModel()
        {
            GoHomeCommand = new Command(GoHome);
            LogOutCommand = new Command(LogOut);
            GoMenuCommand = new Command(GoMenu);
            GoReservationCommand = new Command(GoReservation);
        }

        void GoHome(object obj)
        {
            App.RootPage.Detail = new NavigationPage(new HomePage());
            App.MenuIsPresented = false;
        }
        void GoMenu(object obj)
        {
            App.RootPage.Detail = new NavigationPage(new DishMenuPage());
            App.MenuIsPresented = false;
        }
        void  GoReservation(object obj)
        {

            App.RootPage.Detail = new NavigationPage(new ReservationPage());
            App.MenuIsPresented = false;
        }

        async void LogOut(object obj)
        {

            bool loggedOut = false;

            if (App.Authenticator != null)
            {
                loggedOut = await App.Authenticator.LogoutAsync();
            }

            if (loggedOut)
            {
                App.RootPage.Detail = new NavigationPage(new LoginPage());
                App.RootPage.Master.IsVisible = false;

            }
        
        }
    }
}
