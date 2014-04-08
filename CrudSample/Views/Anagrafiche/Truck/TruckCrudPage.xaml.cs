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
    using CrudSample.Business.Model;
    using CrudSample.Business;
    using System.Diagnostics;
    using CrudSample.Views.Anagrafiche.Transporter;
    using System.Threading.Tasks;
    using System.Collections.ObjectModel;
    using Windows.Storage.Streams;
    /// <summary>
    /// A basic page that provides characteristics common to most applications.
    /// </summary>
    public sealed partial class TruckCrudPage : Page
    {

        private NavigationHelper navigationHelper;
        private ObservableDictionary defaultViewModel = new ObservableDictionary();

        public static Truck Truck;

        public static int Id;
        //public static Truck tmp;
        public Transporter Transporter = null;
        public string selection = null;
        
        public static int item;
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


        public TruckCrudPage()
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
            /* se l'oggetto è inizializzato è una modifica */

            //Transporter = e.NavigationParameter as Transporter;

            this.truckForm.placeholder = "Inserisci nome Transporter";

            //if (Transporter == null)
            //{
            //    Truck = e.NavigationParameter as Truck;
                
            //    Debug.WriteLine("transporter == null");
            //}

            Truck = e.NavigationParameter as Truck;

            if (Truck != null)
            {
                this.getValues(Truck);
                Id = Truck.Id;
               
                //ovvero c'è anche un transporter associato
                if (!string.IsNullOrEmpty(Truck.trName))
                {
                    this.truckForm.placeholder = Truck.trName;
                }
                
                
            }

            //if (Transporter != null && Truck != null)
            //{
            //    this.getTransporterValues(Transporter);
            //    this.getTruckValues(Truck);
            //    this.truckForm.placeholder = Transporter.trName;
            //    Debug.WriteLine("Transporter!=null && Truck=! null");
            //}
          
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

        private void Btn_Cancel(object sender, RoutedEventArgs e)
        {
            Frame.GoBack();
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

        private async void Btn_SaveTruck(object sender, RoutedEventArgs e)
        {
            
            //per fare l'update devo costruire completamente l'oggetto


            bool check = await checkFields(this.truckForm);
            if (check)
            {
                Truck = new Truck();
                Truck.Id = Id;

                setValues(Truck);
                await TruckService.SaveTruck(Truck);
                Truck = null;
                this.Frame.Navigate(typeof(TruckListPage));
            }
        }

        //private async void Select_Transporter(object sender, EventArgs e)
        //{
        //    Debug.WriteLine("is it called?");
        //    selection = "fromCrudPage";
        //    bool check = await checkFields(this.truckForm);
        //    bool empty = await TransporterService.isEmpty();
        //    Truck = new Truck();
        //    setValues(Truck);
        //    Truck.Id = Id;
        //    if (empty) 
        //    {
        //        await Utility.ShowMessage("non ci sono Transporter nel DB");
        //    }
        //    if (check && (!empty))
        //    {
        //        Frame.Navigate(typeof(TransporterListPage), selection);
        //    }
        
        //}

        public async void OnSuggest(Windows.UI.Xaml.Controls.SearchBox e, SearchBoxSuggestionsRequestedEventArgs args)
        {
            var queryText = args.QueryText != null ? args.QueryText.Trim() : null;
            
            if (string.IsNullOrEmpty(queryText)) return;
            var deferral = args.Request.GetDeferral();

            Transporter tr_search = new Transporter();
            tr_search.trName = queryText;
            int count = 0;

            try
            {
                var suggestionCollection = args.Request.SearchSuggestionCollection;
                

                ObservableCollection<Transporter> querySuggestions = await TransporterService.Search(tr_search);


                if (querySuggestions != null && querySuggestions.Count > 0)
                {
                    count = querySuggestions.Count;
                    for (int i = 0; i <= count; i++)
                    {
                        string query = "[" + querySuggestions[i].trId + "] " + querySuggestions[i].trName;
                        //suggestionCollection.AppendQuerySuggestion(querySuggestions[i].trName);
                        suggestionCollection.AppendQuerySuggestion(query);
                    }
                }

            }
            catch (Exception)
            {
                //Ignore any exceptions that occur trying to find search suggestions.
                Debug.WriteLine("Exception rilevate nella searchBox");
            }

            deferral.Complete();
        }

        private void SearchBox_QueryChanged(SearchBox sender, SearchBoxQueryChangedEventArgs args)
        {
            Debug.WriteLine("che fai?");
        }

        private async void SearchBox_QuerySubmitted(Windows.UI.Xaml.Controls.SearchBox sender, SearchBoxQuerySubmittedEventArgs args)
        {
            string queryText = args.QueryText;
            Transporter tr_query = new Transporter();
            tr_query.trId = Utility.getBetween(queryText, "[", "]");
            //tr_query.trName = queryText;
            ObservableCollection<Transporter> result = await TransporterService.Search(tr_query);
            if(result!=null)
            getTransporterValues(result[0]);

            

        }


        //get the partial-object values and set the FORM
        public void getTransporterValues(Transporter t)
        {

            //dati provenienti dal transporter selezionato 

            this.truckForm.trId = t.trId;
            this.truckForm.trName = t.trName;
            this.truckForm.trUrl =  t.trUrl;
            this.truckForm.trCode = t.trCode;

        }

        //get the partial-object values and set the FORM
        public void getTruckValues(Truck t)
        {
            // prelevo i dati strettamente necessari al truck
            this.truckForm.truckId = t.truckId;
            this.truckForm.Code = t.Code;
            this.truckForm.Vin = t.Vin;
            this.truckForm.Url = t.Url;

        }


        //Get objet values to initialize the FORM
        public void getValues(Truck t) 
        {
            // prelevo i dati strettamente necessari al truck
            this.truckForm.truckId = t.truckId;
            this.truckForm.Code = t.Code;
            this.truckForm.Vin = t.Vin;
            this.truckForm.Url = t.Url;
            this.truckForm.trId = t.trId;
            this.truckForm.trName = t.trName;
            this.truckForm.trUrl = t.trUrl;
            this.truckForm.trCode = t.trCode;
            
  
        }


        //Set objet values from the fields of the FORM
        public void setValues(Truck t)
        {
            
            //dati necessari
            t.truckId = this.truckForm.truckId;
            t.Code = this.truckForm.Code;
            t.Vin = this.truckForm.Vin;
            t.Url = this.truckForm.Url;

            //dati opzionali
            t.trId = this.truckForm.trId;
            t.trName = this.truckForm.trName;
            t.trUrl = this.truckForm.trUrl;
            t.trCode = this.truckForm.trCode;
            
            
        }

        public async Task<bool> checkFields(TruckFormUC tfUC)
        {
            if ((String.IsNullOrEmpty(this.truckForm.truckId))
                || (String.IsNullOrEmpty(this.truckForm.Vin))
                || (String.IsNullOrEmpty(this.truckForm.Code))
                || (String.IsNullOrEmpty(this.truckForm.Url)))
            {
                await Utility.ShowMessage("compila tutti i dati relativi al Truck");
                return false;
            }

            else
                return true;

        }

    }
    
}
