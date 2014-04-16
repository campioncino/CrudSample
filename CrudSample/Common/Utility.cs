using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading.Tasks;


// mi serve per gestire Path.Combine ... concatena la Stringa con il path del db
using System.IO;

//con windows.storage recupero i percorso tramite l'application data
using Windows.Storage;
using Windows.Storage.Search;

namespace CrudSample.Common
{
    public class Utility
    {
        public static async Task ShowMessage(string myStringMessage)
        {
            var msgDlg = new Windows.UI.Popups.MessageDialog(myStringMessage);
            msgDlg.DefaultCommandIndex = 1;
            await msgDlg.ShowAsync();
        }

        public static string getBetween(string strSource, string strStart, string strEnd)
        {
            int Start, End;
            if (strSource.Contains(strStart) && strSource.Contains(strEnd))
            {
                Start = strSource.IndexOf(strStart, 0) + strStart.Length;
                End = strSource.IndexOf(strEnd, Start);
                return strSource.Substring(Start, End - Start);
            }
            else
            {
                return "";
            }
        }

        public static async Task<bool>Compare(string A, string B) {
                       
            bool contains = Regex.Match(A, B, RegexOptions.IgnoreCase).Success;
            Debug.WriteLine("regex ="+contains);
            return contains;
        }
	

        public static async void ReadFile()
        {
            
            StorageFolder installedLocation = ApplicationData.Current.LocalFolder;
              
            var files = await installedLocation.GetFilesAsync(CommonFileQuery.OrderByName);
            var file = files.FirstOrDefault(x => x.Name == "myDb.sqlite");
            if (file != null)
            {
                Debug.WriteLine("Database present!");
            }
            else
            {
                await ShowMessage("Database non presente o cancellato");
                await ShowMessage("Importo database di default");

                //questo blocco verrà sostituito con un download o quello che è
                //StorageFolder install = Windows.ApplicationModel.Package.Current.InstalledLocation;
                //StorageFile dbfile = await install.GetFileAsync("Assets/myDb.sqlite");
                try
                {
                    //StorageFile defaultfile = await StorageFile.GetFileFromApplicationUriAsync(new Uri("ms-appx:///Assets/myDb.sqlite"));
                    StorageFolder InstallationFolder = Windows.ApplicationModel.Package.Current.InstalledLocation;
                    
                    
                    var myfiles = await InstallationFolder.GetFilesAsync(CommonFileQuery.OrderByName);
                    var myfile = myfiles.FirstOrDefault(x => x.Name.Contains("test"));
                    await myfile.CopyAsync(ApplicationData.Current.LocalFolder,"myDb.sqlite");

                }
                catch (Exception e) { Debug.WriteLine("impossibile copiare il file perchè " + e.Message); }
                
                //await dbfile.CopyAsync(ApplicationData.Current.LocalFolder, "myDb.sqlite");
            }

        }

    }
}
