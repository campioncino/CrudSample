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
    public sealed partial class TruckListUC : UserControl
    {
        public TruckListUC()
        {
            this.InitializeComponent();
            this.DataContext = this;
        }



        public event EventHandler<EventArgs> SelectionChangedEvent;


        public void truckList_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            SelectionChangedEvent(sender, new EventArgs());
        }


        private ListBox myVar;

        public ListBox getList
        {
            get { return truckListUC; }
            set { truckListUC = value; }
        }
    }
}
