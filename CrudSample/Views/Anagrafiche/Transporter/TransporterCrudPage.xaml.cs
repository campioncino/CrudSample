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

namespace CrudSample.Views.Anagrafiche.Transporter
{
    
    // se lo metto fuori non funziona confonde Transporter (Model) con la cartella della View 
    using CrudSample.Business.Model;
    using CrudSample.Business;
    using System.Diagnostics;
    using System.Threading.Tasks;
    using CrudSample.Views.Anagrafiche.Truck;
    /// <summary>
    /// A basic page that provides characteristics common to most applications.
    /// </summary>
    public sealed partial class TransporterCrudPage : Page
    {

        private NavigationHelper navigationHelper;
        private ObservableDictionary defaultViewModel = new ObservableDictionary();

        Transporter Transporter = null;

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


        public TransporterCrudPage()
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
            /* se l'oggetto è inizializzato è una modifica */
            Transporter = e.NavigationParameter as Transporter;

            if (Transporter != null)
            {
                this.getValues(Transporter); 
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

        private void Btn_Cancel(object sender, RoutedEventArgs e)
        {
            Frame.Navigate(typeof(TransporterListPage));
        }

        private async void Btn_SaveTransporter(object sender, RoutedEventArgs e)
        {
            Transporter transporter = new Transporter();
            //per fare l'update devo costruire completamente l'oggetto
            if (Transporter != null) { transporter.Id = Transporter.Id; }

            if (await checkFields(this.transporterForm))
            {
                this.setValues(transporter);
                await TransporterService.SaveTransporter(transporter);
                this.Frame.Navigate(typeof(TransporterListPage));
            }
            
        }

        //set the object values from the inserted values of the Form Fields
        public void setValues(Transporter t) {
            
            t.trId = this.transporterForm.trId;
            t.trName = this.transporterForm.trName;
            t.trUrl = this.transporterForm.trUrl;
            t.trCode = this.transporterForm.trCode;
        
        }

        //get the object values and set the Form Fields
        public void getValues(Transporter t) {
            this.transporterForm.trId = t.trId;
            this.transporterForm.trName = t.trName;
            this.transporterForm.trUrl = t.trUrl;
            this.transporterForm.trCode= t.trCode;
        }

        public async Task<bool> checkFields(TransporterFormUC tfUC) {
            if ((String.IsNullOrEmpty(this.transporterForm.trId))
                || (String.IsNullOrEmpty(this.transporterForm.trName))
                || (String.IsNullOrEmpty(this.transporterForm.trCode))
                || (String.IsNullOrEmpty(this.transporterForm.trUrl)))
            {
                await Utility.ShowMessage("compila i dati relativi al transporter");
                return false;
            }
                
            else
                return true;

        }

    }
}
