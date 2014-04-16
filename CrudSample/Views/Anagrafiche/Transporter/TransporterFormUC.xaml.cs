using CrudSample.Business.Model;
using CrudSample.Common;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Runtime.InteropServices.WindowsRuntime;
using System.Threading.Tasks;
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
    using CrudSample.Business.Model;
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

        public String name
        {
            get { return (String)GetValue(EditNameTextProperty); }
            set { SetValue(EditNameTextProperty, value); }
        }

        public static readonly DependencyProperty EditNameTextProperty =
               DependencyProperty.Register("name",
                   typeof(String),
                   typeof(TransporterFormUC),
                   new PropertyMetadata(""));

        public String code
        {
            get { return (String)GetValue(EditCodeTextProperty); }
            set { SetValue(EditCodeTextProperty, value); }
        }

        public static readonly DependencyProperty EditCodeTextProperty =
               DependencyProperty.Register("code",
                   typeof(String),
                   typeof(TransporterFormUC),
                   new PropertyMetadata(""));

        public String url
        {
            get { return (String)GetValue(EditUrlTextProperty); }
            set { SetValue(EditUrlTextProperty, value); }
        }

        public static readonly DependencyProperty EditUrlTextProperty =
               DependencyProperty.Register("url",
                   typeof(String),
                   typeof(TransporterFormUC),
                   new PropertyMetadata(""));


        public void getValues(TransporterExt t)
        {
            this.trId = t.trId.ToString();
            this.name = t.name;
            this.url = t.url;
            this.code = t.code;
        }

        public void setValues(Transporter t) {
            if(!string.IsNullOrEmpty(this.trId))
                t.trId = Convert.ToInt32(this.trId);
            t.url = this.url;
            t.name = this.name;
            t.code = this.code;
            

        }
        /*
         * va qui?
         */
        public async Task<bool> checkFields()
        {

            if ((String.IsNullOrEmpty(this.name))
              || (String.IsNullOrEmpty(this.code))
              || (String.IsNullOrEmpty(this.url)))
            {
                await Utility.ShowMessage("compila i dati relativi al transporter");
                return false;
            }

            else
                return true;

        }
    }
    
}
