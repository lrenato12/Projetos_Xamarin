using App1_Mimica.Model;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Text;
using Xamarin.Forms;

namespace App1_Mimica.ViewModel
{
    public class ResultadoViewModel : INotifyPropertyChanged
    {
        public Jogo Jogo { get; set; }
        public Command JogarNovamente { get; set; }

        public ResultadoViewModel()
        {
            Jogo = Armazenamento.Armazenamento.Jogo;
            JogarNovamente = new Command(JogarNovamenteAction);
        }

        private void JogarNovamenteAction()
        {
            App.Current.MainPage = new View.Inicio();
        }

        public event PropertyChangedEventHandler PropertyChanged;
        private void OnPropertyChanged(string NameProperty)
        {
            if (PropertyChanged != null)
            {
                PropertyChanged(this, new PropertyChangedEventArgs(NameProperty));
            }
        }
    }
}