using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using Xamarin.Forms;
using Xamarin.Forms.Xaml;

namespace App01_ControleXF.Controles
{
	[XamlCompilation(XamlCompilationOptions.Compile)]
	public partial class DatePickerPage : ContentPage
	{
		public DatePickerPage ()
		{
			InitializeComponent ();
		}

        private void ActionDateSelected(object sender, DateChangedEventArgs args)
        {
            lblResultado.Text = $"Data antiga: {args.OldDate.ToString("dd/MM/yyyy")} - Nova data: {args.NewDate.ToString("dd/MM/yyyy")}";
        }
    }
}