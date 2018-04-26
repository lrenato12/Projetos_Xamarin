using App01_ControleXF.Modelo;
using System.Collections.Generic;
using Xamarin.Forms;
using Xamarin.Forms.Xaml;

namespace App01_ControleXF.Controles
{
	[XamlCompilation(XamlCompilationOptions.Compile)]
	public partial class ListViewPage : ContentPage
	{
		public ListViewPage ()
		{
			InitializeComponent ();
            
            List<Pessoa> lista = new List<Pessoa>();
            lista.Add(new Pessoa { Nome = "Patricia", Idade = "25"});
            lista.Add(new Pessoa { Nome = "Felipe", Idade = "45" });
            lista.Add(new Pessoa { Nome = "Maria", Idade = "29" });
            lista.Add(new Pessoa { Nome = "Joaquim", Idade = "15" });
            lista.Add(new Pessoa { Nome = "Airton", Idade = "40" });
            ListaPessoas.ItemsSource = lista;
        }
	}
}