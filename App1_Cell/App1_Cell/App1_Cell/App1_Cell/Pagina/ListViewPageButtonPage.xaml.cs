using App1_Cell.Modelo;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using Xamarin.Forms;
using Xamarin.Forms.Xaml;

namespace App1_Cell.Pagina
{
	[XamlCompilation(XamlCompilationOptions.Compile)]
	public partial class ListViewPageButtonPage : ContentPage
	{
		public ListViewPageButtonPage ()
		{
			InitializeComponent ();

            List<Funcionario> Lista = new List<Funcionario>();
            Lista.Add(new Funcionario() { Nome = "Renato", Cargo = "Presidente" });
            Lista.Add(new Funcionario() { Nome = "Luiz", Cargo = "Vendedor" });
            Lista.Add(new Funcionario() { Nome = "Camila", Cargo = "Tester" });
            Lista.Add(new Funcionario() { Nome = "Otávio", Cargo = "Design" });
            Lista.Add(new Funcionario() { Nome = "João", Cargo = "MotoBoy" });

            ListaFuncionario.ItemsSource = Lista;
        }

        private void FeriasAction(object sender, EventArgs args)
        {
            Button btnFerias = (Button)sender;
            Funcionario func = (Funcionario)btnFerias.CommandParameter;

            DisplayAlert("Ferias", $"Funcionario {func.Nome}", "OK");
        }
	}
}