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

namespace CrudSample.Views.Anagrafiche.Transporter
{
    public sealed partial class TransporterFormUC : UserControl
    {
        public TransporterFormUC() 
        {
            this.InitializeComponent();
            this.DataContext = this;
            
        }

        public String trId
        {
            get { return (String)GetValue(EditIdTextProperty); }
            set { SetValue(EditIdTextProperty, value); }
        }

        public static readonly DependencyProperty EditIdTextProperty =
               DependencyProperty.Register("trId",
                   typeof(String),
                   typeof(TransporterFormUC),
                   new PropertyMetadata(""));

        public String trName
        {
            get { return (String)GetValue(EditNameTextProperty); }
            set { SetValue(EditNameTextProperty, value); }
        }

        public static readonly DependencyProperty EditNameTextProperty =
               DependencyProperty.Register("trName",
                   typeof(String),
                   typeof(TransporterFormUC),
                   new PropertyMetadata(""));

        public String trCode
        {
            get { return (String)GetValue(EditCodeTextProperty); }
            set { SetValue(EditCodeTextProperty, value); }
        }

        public static readonly DependencyProperty EditCodeTextProperty =
               DependencyProperty.Register("trCode",
                   typeof(String),
                   typeof(TransporterFormUC),
                   new PropertyMetadata(""));

        public String trUrl
        {
            get { return (String)GetValue(EditUrlTextProperty); }
            set { SetValue(EditUrlTextProperty, value); }
        }

        public static readonly DependencyProperty EditUrlTextProperty =
               DependencyProperty.Register("trUrl",
                   typeof(String),
                   typeof(TransporterFormUC),
                   new PropertyMetadata(""));
        
    }
    
}
