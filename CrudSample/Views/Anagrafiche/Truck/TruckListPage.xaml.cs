﻿using CrudSample.Common;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Runtime.InteropServices.WindowsRuntime;
using Windows.Foundation;
using Windows.Foundation.Collections;
using Windows.UI.Xaml;
using Windows.UI.Xaml.Controls;
using Windows.UI.Xaml.Controls.Primitives;
using Windows.UI.Xaml.Data;
using Windows.UI.Xaml.Input;
using Windows.UI.Xaml.Media;
using Windows.UI.Xaml.Navigation;

// The Basic Page item template is documented at http://go.microsoft.com/fwlink/?LinkId=234237

namespace CrudSample.Views.Anagrafiche.Truck
{
    using CrudSample.Business;
    using CrudSample.Business.Model;

    using CrudSample.Business.Dao;
    using System.Collections.ObjectModel;
    /// <summary>
    /// A basic page that provides characteristics common to most applications.
    /// </summary>
    public sealed partial class TruckListPage : Page
    {

        private NavigationHelper navigationHelper;
        private ObservableDictionary defaultViewModel = new ObservableDictionary();

        public ObservableCollection<Truck> Trucks { get; set; }

        public ObservableCollection<Truck> seachResult = null;

        public Truck truck { get; set; }

        /// <summary>
        /// This can be changed to a strongly typed view model.
        /// </summary>
        public ObservableDictionary DefaultViewModel
        {
            get { return this.defaultViewModel; }
        }

        /// <summary>
        /// NavigationHelper is used on each page to aid in navigation and 
        /// process lifetime management
        /// </summary>
        public NavigationHelper NavigationHelper
        {
            get { return this.navigationHelper; }
        }


        public TruckListPage()
        {
            this.InitializeComponent();
            this.navigationHelper = new NavigationHelper(this);
            this.navigationHelper.LoadState += navigationHelper_LoadState;
            this.navigationHelper.SaveState += navigationHelper_SaveState;
        }

        /// <summary>
        /// Populates the page with content passed during navigation. Any saved state is also
        /// provided when recreating a page from a prior session.
        /// </summary>
        /// <param name="sender">
        /// The source of the event; typically <see cref="NavigationHelper"/>
        /// </param>
        /// <param name="e">Event data that provides both the navigation parameter passed to
        /// <see cref="Frame.Navigate(Type, Object)"/> when this page was initially requested and
        /// a dictionary of state preserved by this page during an earlier
        /// session. The state will be null the first time a page is visited.</param>
        private async void navigationHelper_LoadState(object sender, LoadStateEventArgs e)
        {
            seachResult = e.NavigationParameter as ObservableCollection<Truck>;
            if (seachResult != null)
            {
                Trucks = seachResult;
            }
            else
            {
                Trucks = await TruckService.GetAll();
            }
            
            truckList.getList.ItemsSource = Trucks;
        }

        /// <summary>
        /// Preserves state associated with this page in case the application is suspended or the
        /// page is discarded from the navigation cache.  Values must conform to the serialization
        /// requirements of <see cref="SuspensionManager.SessionState"/>.
        /// </summary>
        /// <param name="sender">The source of the event; typically <see cref="NavigationHelper"/></param>
        /// <param name="e">Event data that provides an empty dictionary to be populated with
        /// serializable state.</param>
        private void navigationHelper_SaveState(object sender, SaveStateEventArgs e)
        {
        }

        public async void truckList_SelectionChangedEvent(object sender, EventArgs e)
        {
            //Truck selectedT = (Truck)transporterList.MyProperty.SelectedItem;

            //var msgDlg = new Windows.UI.Popups.MessageDialog(selectedT.trName);
            //msgDlg.DefaultCommandIndex = 1;
            //await msgDlg.ShowAsync();
            truck = (Truck)truckList.getList.SelectedItem;

            //ci spostiamo sulla pagina dettaglio
            Frame.Navigate(typeof(TruckCrudPage), truck);

        }

        private void Btn_AddTruck(object sender, RoutedEventArgs e)
        {
            Frame.Navigate(typeof(TruckCrudPage));
        }

        private void Btn_SearchTruck(object sender, RoutedEventArgs e)
        {
            Frame.Navigate(typeof(TruckSearchPage));
        }

        private async void Btn_RefreshTruck(object sender, RoutedEventArgs e)
        {
            Trucks = await TruckService.GetAll();
            this.Frame.Navigate(this.GetType());
        }

        //private async void Btn_DeleteTruck(object sender, RoutedEventArgs e)
        //{
        //    if (transporter != null)

        //        await TruckService.DeleteTruck(transporter);

        //        //reload Page
        //        this.Frame.Navigate(this.GetType());
        //}
        #region NavigationHelper registration

        /// The methods provided in this section are simply used to allow
        /// NavigationHelper to respond to the page's navigation methods.
        /// 
        /// Page specific logic should be placed in event handlers for the  
        /// <see cref="GridCS.Common.NavigationHelper.LoadState"/>
        /// and <see cref="GridCS.Common.NavigationHelper.SaveState"/>.
        /// The navigation parameter is available in the LoadState method 
        /// in addition to page state preserved during an earlier session.

        protected override void OnNavigatedTo(NavigationEventArgs e)
        {
            navigationHelper.OnNavigatedTo(e);
        }

        protected override void OnNavigatedFrom(NavigationEventArgs e)
        {
            navigationHelper.OnNavigatedFrom(e);
        }

        #endregion
    }
}
