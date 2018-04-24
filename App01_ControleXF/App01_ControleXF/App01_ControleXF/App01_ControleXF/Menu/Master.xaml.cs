using System;
using Xamarin.Forms;
using Xamarin.Forms.Xaml;

namespace App01_ControleXF.Menu
{
	[XamlCompilation(XamlCompilationOptions.Compile)]
	public partial class Master : MasterDetailPage
	{
		public Master ()
		{
			InitializeComponent ();
		}

        private void GoActivityIndicatorPage(object sender, EventArgs args)
        {
            Detail = new Controles.ActivityIndicatorPage();
        }

        private void GoProgressBarPage(object sender, EventArgs args)
        {
            Detail = new Controles.ProgressBarPage();
        }

        private void GoBoxViewPage(object sender, EventArgs args)
        {
            Detail = new Controles.BoxViewPage();
        }

        private void GoLabelPage(object sender, EventArgs args)
        {
            Detail = new Controles.LabelPage();
        }

        private void GoButtonPage(object sender, EventArgs args)
        {
            Detail = new Controles.ButtonPage();
        }

        private void GoEntryEditorPage(object sender, EventArgs args)
        {
            Detail = new Controles.EntryEditorPage();
        }
    }
}