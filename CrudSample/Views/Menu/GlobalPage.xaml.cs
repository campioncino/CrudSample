using CrudSample.Views.Anagrafiche.Transporter;
using CrudSample.Views.Anagrafiche.Truck;
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

// The Blank Page item template is documented at http://go.microsoft.com/fwlink/?LinkId=234238

namespace CrudSample.Views.Menu
{
    /// <summary>
    /// An empty page that can be used on its own or navigated to within a Frame.
    /// </summary>
    public sealed partial class GlobalPage : Page
    {
        
        public GlobalPage()
        {
            this.InitializeComponent();
            
        }

 
        Page rootPage = null;
        protected override void OnNavigatedTo(NavigationEventArgs e)
        {
            rootPage = e.Parameter as Page;
            topBarFrame.Navigate(typeof(MainPage), this);
        }

        private void Back_Click(object sender, RoutedEventArgs e)
        {
            if (topBarFrame.CanGoBack)
            {
                topBarFrame.GoBack();
            }
            else if (rootPage != null && rootPage.Frame.CanGoBack)
            {
                rootPage.Frame.GoBack();
            }
        }

        private void GoToTruckMenu(object sender, RoutedEventArgs e)
        {
            topBarFrame.Navigate(typeof(TruckListPage), this);
        }

        private void GoToTransporterMenu(object sender, RoutedEventArgs e)
        {
            topBarFrame.Navigate(typeof(TransporterListPage), this);
        }
    }
}

