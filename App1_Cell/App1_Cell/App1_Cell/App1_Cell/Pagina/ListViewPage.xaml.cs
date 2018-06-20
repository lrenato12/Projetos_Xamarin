using App1_Cell.Modelo;
using App1_Cell.Pagina.Detalhe;
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
	public partial class ListViewPage : ContentPage
	{
		public ListViewPage ()
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

        private void ItemSelecionadoAction(object sender, SelectedItemChangedEventArgs args)
        {
            Funcionario func = (Funcionario)args.SelectedItem;
            Navigation.PushAsync(new DetailPage(func));
        }

        private void FeriasAction(object sender, EventArgs args)
        {
            MenuItem botao = (MenuItem)sender;
            Funcionario func = (Funcionario)botao.CommandParameter;

            DisplayAlert("Titulo: " + func.Nome, "Mensagem: " + func.Nome + " - " + func.Cargo, "OK");
        }

        private void AbonoAction(object sender, EventArgs args)
        {

        }
    }
}