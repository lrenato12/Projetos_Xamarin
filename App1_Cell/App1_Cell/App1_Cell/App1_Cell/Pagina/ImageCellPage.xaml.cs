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
	public partial class ImageCellPage : ContentPage
	{
		public ImageCellPage ()
		{
			InitializeComponent ();

            List<Funcionario> Lista = new List<Funcionario>();
            Lista.Add(new Funcionario() { Foto= "http://pt.heroquizz.com/imgquizz/icon/p9h5b.png", Nome = "Renato", Cargo = "Presidente" });
            Lista.Add(new Funcionario() { Foto= "https://image.freepik.com/icones-gratis/perfil-nerd-avatar-masculino_318-68813.jpg", Nome = "Luiz", Cargo = "Vendedor" });
            Lista.Add(new Funcionario() { Foto= "http://arabis.com.br/wp-content/uploads/2015/01/icon_perfil_amarelo.png", Nome = "Camila", Cargo = "Tester" });

            ListaFuncionario.ItemsSource = Lista;
        }
	}
}