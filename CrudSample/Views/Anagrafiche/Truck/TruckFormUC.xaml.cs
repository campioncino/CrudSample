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

// The User Control item template is documented at http://go.microsoft.com/fwlink/?LinkId=234236

namespace CrudSample.Views.Anagrafiche.Truck
{
    public sealed partial class TruckFormUC : UserControl
    {
        public TruckFormUC()
        {
            this.InitializeComponent();
            this.DataContext = this;
        }

        public delegate void ValueChangedEventHandler(object sender, EventArgs e);

        public event ValueChangedEventHandler Button_Clicked;
        private void Button_Click(object sender, RoutedEventArgs e)
        {
            if (Button_Clicked != null)
            {
                Button_Clicked(this, EventArgs.Empty);
            }
        }

        public Visibility ButtonVisibility
        {
            get { return (Visibility)GetValue(ButtonVisibilityProperty); }
            set { SetValue(ButtonVisibilityProperty, value); }
        }

        public static DependencyProperty ButtonVisibilityProperty = 
            DependencyProperty.Register("ButtonVisibility", 
                typeof(Visibility), 
                typeof(TruckFormUC),
                null);

       

        //public ImageSource ButtonSource
        //{
        //    get { return (ImageSource)GetValue(SourceProperty); }
        //    set { SetValue(SourceProperty, value); }
        //}

        //// Using a DependencyProperty as the backing store for Source.  This enables animation, styling, binding, etc...
        //public static readonly DependencyProperty SourceProperty =
        //    DependencyProperty.Register("Source", typeof(ImageSource), typeof(TruckFormUC),null);




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


        public String Code
        {
            get { return (String)GetValue(EditTruckCodeTextProperty); }
            set { SetValue(EditTruckCodeTextProperty, value); }
        }

        public static readonly DependencyProperty EditTruckCodeTextProperty =
               DependencyProperty.Register("Code",
                   typeof(String),
                   typeof(TruckFormUC),
                   new PropertyMetadata(""));

        public String Vin
        {
            get { return (String)GetValue(EditTruckVinTextProperty); }
            set { SetValue(EditTruckVinTextProperty, value); }
        }

        public static readonly DependencyProperty EditTruckVinTextProperty =
               DependencyProperty.Register("Vin",
                   typeof(String),
                   typeof(TruckFormUC),
                   new PropertyMetadata(""));

        public String Url
        {
            get { return (String)GetValue(EditTruckUrlTextProperty); }
            set { SetValue(EditTruckUrlTextProperty, value); }
        }

        public static readonly DependencyProperty EditTruckUrlTextProperty =
               DependencyProperty.Register("Url",
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

        private void button_Click(object sender, RoutedEventArgs e)
        {

        }
        
    }
}
