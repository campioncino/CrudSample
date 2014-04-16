using CrudSample.Business;
using CrudSample.Business.Model;
using CrudSample.Common;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Diagnostics;
using System.IO;
using System.Linq;
using System.Runtime.InteropServices.WindowsRuntime;
using System.Threading.Tasks;
using Windows.Foundation;
using Windows.Foundation.Collections;
using Windows.Storage.Streams;
using Windows.UI.Xaml;
using Windows.UI.Xaml.Controls;
using Windows.UI.Xaml.Controls.Primitives;
using Windows.UI.Xaml.Data;
using Windows.UI.Xaml.Input;
using Windows.UI.Xaml.Media;
using Windows.UI.Xaml.Navigation;

// The User Control item template is documented at http://go.microsoft.com/fwlink/?LinkId=234236

namespace CrudSample.Views.Anagrafiche.Truck
{
    using CrudSample.Business.Model;
    public sealed partial class TruckFormUC : UserControl
    {
        public TruckFormUC()
        {
            this.InitializeComponent();
            this.DataContext = this;
           
        }

        public static IRandomAccessStreamReference imgRef = RandomAccessStreamReference.CreateFromUri(new Uri("ms-appx:///Assets/transporter-512.png"));

        public ObservableCollection<TransporterExt> suggested = new ObservableCollection<TransporterExt>();

        
        // Truck's values
        public String truckId
        {
            get { return (String)GetValue(EditTruckIdTextProperty); }
            set { SetValue(EditTruckIdTextProperty, value); }
        }

        public static readonly DependencyProperty EditTruckIdTextProperty =
               DependencyProperty.Register("truckId",
                   typeof(String),
                   typeof(TruckFormUC),
                   new PropertyMetadata(""));


        public String code
        {
            get { return (String)GetValue(EditTruckCodeTextProperty); }
            set { SetValue(EditTruckCodeTextProperty, value); }
        }

        public static readonly DependencyProperty EditTruckCodeTextProperty =
               DependencyProperty.Register("code",
                   typeof(String),
                   typeof(TruckFormUC),
                   new PropertyMetadata(""));

        public String vin
        {
            get { return (String)GetValue(EditTruckVinTextProperty); }
            set { SetValue(EditTruckVinTextProperty, value); }
        }

        public static readonly DependencyProperty EditTruckVinTextProperty =
               DependencyProperty.Register("vin",
                   typeof(String),
                   typeof(TruckFormUC),
                   new PropertyMetadata(""));

        public String url
        {
            get { return (String)GetValue(EditTruckUrlTextProperty); }
            set { SetValue(EditTruckUrlTextProperty, value); }
        }

        public static readonly DependencyProperty EditTruckUrlTextProperty =
               DependencyProperty.Register("url",
                   typeof(String),
                   typeof(TruckFormUC),
                   new PropertyMetadata(""));

        // Transporter's value

        public String trId
        {
            get { return (String)GetValue(EditTransporterIdTextProperty); }
            set { SetValue(EditTransporterIdTextProperty, value); }
        }

        public static readonly DependencyProperty EditTransporterIdTextProperty =
               DependencyProperty.Register("trId",
                   typeof(String),
                   typeof(TruckFormUC),
                   new PropertyMetadata(""));

        public String trName
        {
            get { return (String)GetValue(EditTransporterNameTextProperty); }
            set { SetValue(EditTransporterNameTextProperty, value); }
        }

        public static readonly DependencyProperty EditTransporterNameTextProperty =
               DependencyProperty.Register("trName",
                   typeof(String),
                   typeof(TruckFormUC),
                   new PropertyMetadata(""));

        public String trCode
        {
            get { return (String)GetValue(EditTransporterCodeTextProperty); }
            set { SetValue(EditTransporterCodeTextProperty, value); }
        }

        public static readonly DependencyProperty EditTransporterCodeTextProperty =
               DependencyProperty.Register("trCode",
                   typeof(String),
                   typeof(TruckFormUC),
                   new PropertyMetadata(""));

        public String trUrl
        {
            get { return (String)GetValue(EditTransporterUrlTextProperty); }
            set { SetValue(EditTransporterUrlTextProperty, value); }
        }

        public static readonly DependencyProperty EditTransporterUrlTextProperty =
               DependencyProperty.Register("trUrl",
                   typeof(String),
                   typeof(TruckFormUC),
                   new PropertyMetadata(""));


        /* Gestione click sul bottone */

        //public delegate void ValueChangedEventHandler(object sender, EventArgs e);

        //public event ValueChangedEventHandler Button_Clicked;
        //private void Button_Click(object sender, RoutedEventArgs e)
        //{
        //    if (Button_Clicked != null)
        //    {
        //        Button_Clicked(this, EventArgs.Empty);
        //    }
        //}

        //public Visibility ButtonVisibility
        //{
        //    get { return (Visibility)GetValue(ButtonVisibilityProperty); }
        //    set { SetValue(ButtonVisibilityProperty, value); }
        //}

        //public static DependencyProperty ButtonVisibilityProperty = 
        //    DependencyProperty.Register("ButtonVisibility", 
        //        typeof(Visibility), 
        //        typeof(TruckFormUC),
        //        null);

       

        //public ImageSource ButtonSource
        //{
        //    get { return (ImageSource)GetValue(SourceProperty); }
        //    set { SetValue(SourceProperty, value); }
        //}

        //// Using a DependencyProperty as the backing store for Source.  This enables animation, styling, binding, etc...
        //public static readonly DependencyProperty SourceProperty =
        //    DependencyProperty.Register("Source", typeof(ImageSource), typeof(TruckFormUC),null);


        /* Fine Gestione CLick sul Bottone */


        /* Gestione SearchBox */

        public String placeholder
        {
            get { return (String)GetValue(PlaceHolderTextProperty); }
            set { SetValue(PlaceHolderTextProperty, value); }
        }

        public static readonly DependencyProperty PlaceHolderTextProperty =
               DependencyProperty.Register("placeholder",
                   typeof(String),
                   typeof(TruckFormUC),
                   new PropertyMetadata(""));

        public async void SearchBoxSuggestions(SearchBox sender, SearchBoxSuggestionsRequestedEventArgs args) {
            var deferral = args.Request.GetDeferral();
            try
            {
            
            TransporterExt tr_search = new TransporterExt();
            ObservableCollection<TransporterExt> querySuggestions = new ObservableCollection<TransporterExt>();
            var queryText = args.QueryText != null ? args.QueryText.Trim() : null;


            if (string.IsNullOrEmpty(queryText)) return;

            suggested.Clear();
            tr_search.name = queryText;
            

                var suggestionCollection = args.Request.SearchSuggestionCollection;


                querySuggestions = await TransporterService.Search_StartsWith(tr_search);


                if (querySuggestions != null && querySuggestions.Count > 0)
                
                {

                    int i = 0;
                    foreach (TransporterExt tr in querySuggestions)
                    {
                        string name = tr.name;
                        string detail = tr.trId.ToString();
                        string tag = i.ToString();
                        string imageAlternate = "imgDesc";

                        suggestionCollection.AppendResultSuggestion(name, detail, tag, imgRef, imageAlternate);
                        
                        this.suggested.Add(tr);

                        i++;
                   }

                }
            }
            catch (System.ArgumentException exc)
            {
                //Ignore any exceptions that occur trying to find search suggestions.
                Debug.WriteLine(exc.Message);
                Debug.WriteLine(exc.StackTrace);
            }
            
            deferral.Complete();
        }

       
        private void SuggestionChoosen(SearchBox sender, SearchBoxResultSuggestionChosenEventArgs args)
        {

            int p = Convert.ToInt32(args.Tag);
            TransporterExt t = new TransporterExt();
            t = suggested[p];
            getTransporterValues(t);
        }


        private void SearchQueryChanged(SearchBox sender, SearchBoxQueryChangedEventArgs args)
        {
            TransporterExt t = new TransporterExt();
            getTransporterValues(t);

        }


        //public delegate void QueryChanged(SearchBox sender, SearchBoxQueryChangedEventArgs args);

        //public event TypedEventHandler<SearchBox, SearchBoxQueryChangedEventArgs> SearchBoxQueryChanged;
        //public void SearchQueryChanged(SearchBox sender, SearchBoxQueryChangedEventArgs args)
        //{
        //    if (SearchBoxQueryChanged != null)
        //        SearchBoxQueryChanged(sender, args);

        //}

        //public delegate void SuggestionsRequested(SearchBox sender, SearchBoxSuggestionsRequestedEventArgs args);

        //public event TypedEventHandler<SearchBox, SearchBoxSuggestionsRequestedEventArgs> SearchBoxSuggestionsRequested;

        //public void SearchBoxSuggestions(SearchBox sender, SearchBoxSuggestionsRequestedEventArgs args)
        //{

        //    if (SearchBoxSuggestionsRequested != null)
        //        SearchBoxSuggestionsRequested(sender, args);
        //}


        //public delegate void ResultSuggestionChosen(SearchBox sender, SearchBoxResultSuggestionChosenEventArgs args);

        //public event TypedEventHandler<SearchBox, SearchBoxResultSuggestionChosenEventArgs> SearchBoxSuggestionChoosen;
        //public void SuggestionChoosen(SearchBox sender, SearchBoxResultSuggestionChosenEventArgs args)
        //{
        //    if (SearchBoxSuggestionChoosen != null)
        //        SearchBoxSuggestionChoosen(sender, args);
        //}

        //public delegate void QuerySubmitted(SearchBox sender, SearchBoxQuerySubmittedEventArgs args);

        //public event TypedEventHandler<SearchBox, SearchBoxQuerySubmittedEventArgs> SearchBoxQuerySubmitted;
        //public void SearchBoxQuery(SearchBox sender, SearchBoxQuerySubmittedEventArgs args)
        //{
        //    if (SearchBoxQuerySubmitted != null)
        //        SearchBoxQuerySubmitted(sender, args);
        //}

        /* Fine Gestione SearchBox */

        /* funzioni di utilità */
        public void getTransporterValues(TransporterExt t)
        {

            trId = t.trId.ToString();
            trName= t.name;
            trUrl = t.url;
            trCode = t.code;

        }

        public void getTruckExt(TruckExt t) 
        {
            truckId = t.truckId.ToString();
            url = t.url;
            vin = t.vin;
            code = t.code;
            trId = t.trId.ToString();
            trName = t.trName;
            trCode = t.trCode;
            trUrl = t.trUrl;
        }

        public void setValues(Truck t) 
        {

            if (!string.IsNullOrEmpty(truckId))
                t.truckId = Convert.ToInt32(truckId);
            t.code = code;
            t.vin = vin;
            t.url = url;

            //dati opzionali
            if (!string.IsNullOrEmpty(trId))
                t.trId = Convert.ToInt32(trId);  
            
        }

        //controllo che i dati necessari al salvataggio del Truck ci siano tutti
        public async Task<bool> checkFields()
        {
            if ((String.IsNullOrEmpty(vin))
                || (String.IsNullOrEmpty(code))
                || (String.IsNullOrEmpty(url)))
            {
                await Utility.ShowMessage("compila tutti i dati relativi al Truck");
                return false;
            }

            else
                return true;

        }
        
    }
}
