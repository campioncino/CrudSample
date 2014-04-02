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

namespace CrudSample.Views
{
    /// <summary>
    /// A basic page that provides characteristics common to most applications.
    /// </summary>
    public partial class BasicPage1 : Page
{
    private NavigationHelper navigationHelper;
    private ObservableDictionary defaultViewModel = new ObservableDictionary();
 
    public ObservableDictionary DefaultViewModel
    {
        get { return this.defaultViewModel; }
    }
 
    public NavigationHelper NavigationHelper
    {
        get { return this.navigationHelper; }
    }
 
    public BasicPage1()
    {
        this.InitializeComponent();
        this.navigationHelper = new NavigationHelper(this);
        this.navigationHelper.LoadState += navigationHelper_LoadState;
        this.navigationHelper.SaveState += navigationHelper_SaveState;
    }
 
    private void navigationHelper_LoadState(object sender, LoadStateEventArgs e)
    {
        LoadState(e);
    }
 
    private void navigationHelper_SaveState(object sender, SaveStateEventArgs e)
    {
        SaveState(e);
    }
 
    protected virtual void LoadState(LoadStateEventArgs e) { }
    protected virtual void SaveState(SaveStateEventArgs e) { }
 
    #region NavigationHelper registration
 
    protected override void OnNavigatedTo(NavigationEventArgs e)
    {
        navigationHelper.OnNavigatedTo(e);
    }
 
    protected override void OnNavigatedFrom(NavigationEventArgs e)
    {
        navigationHelper.OnNavigatedFrom(e);
    }
 
    #endregion
}
    
}
