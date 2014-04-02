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
// The User Control item template is documented at http://go.microsoft.com/fwlink/?LinkId=234236

using CrudSample.Views.Anagrafiche.Truck;
using CrudSample.Views.Anagrafiche.Transporter;

namespace CrudSample.Views.Menu
{
    public sealed partial class MyTopBar : UserControl
    {
        public MyTopBar()
        {
            this.InitializeComponent();
            DataContext = this.DataContext;
        }

        
        private async void GoToTruckMenu(object sender, RoutedEventArgs e)
        {
            ((Frame)(Window.Current.Content)).Navigate(typeof(TruckListPage)); 
        }

        private async void GoToTransporterMenu(object sender, RoutedEventArgs e)
        {
            //OutputText.Text = string.Format("Hello {0}", NameInput.Text);
            ((Frame)(Window.Current.Content)).Navigate(typeof(TransporterListPage));           
        }

    }
}
