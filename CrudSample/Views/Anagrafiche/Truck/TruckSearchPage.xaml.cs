using CrudSample.Common;
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
    using CrudSample.Views.Anagrafiche.Transporter;
    using System.Collections.ObjectModel;
    using System.Threading.Tasks;
    /// <summary>
    /// A basic page that provides characteristics common to most applications.
    /// </summary>
    
    public sealed partial class TruckSearchPage : Page
    {

        private NavigationHelper navigationHelper;
        private ObservableDictionary defaultViewModel = new ObservableDictionary();
        public ObservableCollection<Truck> searchList = new ObservableCollection<Truck>();
        public string selection = null;
        public Transporter Transporter = null;
        public static Truck Truck;

        
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


        public TruckSearchPage()
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
        private void navigationHelper_LoadState(object sender, LoadStateEventArgs e)
        {
            Transporter = e.NavigationParameter as Transporter;
            if (Transporter == null) 
            {
                Truck = new Truck();
            }
                

            if (Transporter != null)
            {
                setTransporterValues(Transporter);
            }


            if (Truck != null) 
            {
                getValues(Truck);
            }
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

        private async void Btn_SearchTruck(object sender, RoutedEventArgs e)
        {
            setValues(Truck);
            searchList = await TruckService.Search(Truck);
            Frame.Navigate(typeof(TruckListPage), searchList);
        }


        private async void Select_Transporter(object sender, EventArgs e)
        {
            selection = "fromSearchPage";
                
            setValues(Truck);

            Frame.Navigate(typeof(TransporterListPage), selection);
        }

        //Set objet values from the fields of the form
        public void setValues(Truck t)
        {

            //dati  truck
            t.truckId = this.truckSearch.truckId;
            t.Code = this.truckSearch.Code;
            t.Vin = this.truckSearch.Vin;
            t.Url = this.truckSearch.Url;

            //dati transporter opzionali
            t.trId = this.truckSearch.trId;
            t.trName = this.truckSearch.trName;
            t.trUrl = this.truckSearch.trUrl;
            t.trCode = this.truckSearch.trCode;


        }

        //Get objet values to initialize the form
        public void getValues(Truck t) 
        {
            this.truckSearch.truckId = t.truckId;
            this.truckSearch.Code = t.Code;
            this.truckSearch.Vin = t.Vin;
            this.truckSearch.Url = t.Url;

            this.truckSearch.trId = t.trId;
            this.truckSearch.trName = t.trName;
            this.truckSearch.trUrl = t.trUrl;
            this.truckSearch.trCode = t.trCode;
        }


        //Set object values from Transporter object
        public void setTransporterValues(Transporter t)
        {
            Truck.trId = Transporter.trId;
            Truck.trName = Transporter.trName;
            Truck.trCode = Transporter.trCode;
            Truck.trUrl = Transporter.trUrl;
        }
    }
}
