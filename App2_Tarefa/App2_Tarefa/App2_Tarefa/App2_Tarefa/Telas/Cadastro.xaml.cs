using App2_Tarefa.Modelos;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using Xamarin.Forms;
using Xamarin.Forms.Xaml;

namespace App2_Tarefa.Telas
{
    [XamlCompilation(XamlCompilationOptions.Compile)]
    public partial class Cadastro : ContentPage
    {
        private byte Prioridade { get; set; }

		public Cadastro ()
		{
			InitializeComponent ();
		}

        private void PrioridadeSelectAction(object sender, EventArgs args)
        {
            var Stacks = SLPrioridades.Children;

            foreach(var Linha in Stacks)
            {
                Label lblPrioridade = ((StackLayout)Linha).Children[1] as Label;
                lblPrioridade.TextColor = Color.Gray;
            }

            ((Label)((StackLayout)sender).Children[1]).TextColor = Color.Black;
            FileImageSource Source = ((Image)((StackLayout)sender).Children[0]).Source as FileImageSource;

            string Prioridade = Source.File.ToString().Replace("Resources/", "").Replace(".png", "").Replace("p", "");
            this.Prioridade = byte.Parse(Prioridade);
        }

        private void SalvarAction(object sender, EventArgs args)
        {
            bool ErroExiste = false;
            var valor = txtNome.Text.Trim();
            if (string.IsNullOrEmpty(valor) && valor.Length <= 0)
            {
                ErroExiste = true;
                DisplayAlert("Erro", "Nome não preenchido", "Ok");
            }
            
            if(! (Prioridade > 0))
            {
                ErroExiste = true;
                DisplayAlert("Erro", "Prioridade não foi informada", "Ok");
            }

            if(!ErroExiste)
            {
                var tarefa = new Tarefa();
                tarefa.Nome = txtNome.Text.Trim();
                tarefa.Prioridade = Prioridade;

                new GerenciadorTarefa().Salvar(tarefa);
                App.Current.MainPage = new NavigationPage(new Inicio());
            }
        }
    }
}