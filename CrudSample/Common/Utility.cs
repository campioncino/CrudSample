using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

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
    }
}
