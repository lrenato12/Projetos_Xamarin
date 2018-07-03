using App1_Mimica.Model;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Text;
using Xamarin.Forms;

namespace App1_Mimica.ViewModel
{
    public class JogoViewModel : INotifyPropertyChanged
    {
        public byte _PalavraPontuacao;
        public byte PalavraPontuacao { get { return _PalavraPontuacao; } set { _PalavraPontuacao = value; OnPropertyChanged("PalavraPontuacao"); } }

        private string _Palavra;
        public string Palavra { get { return _Palavra; } set { _Palavra = value; OnPropertyChanged("Palavra"); } }

        private string _TextoContagem;
        public string TextoContagem { get { return _TextoContagem; } set { _TextoContagem = value; OnPropertyChanged("TextoContagem"); } }

        private bool _IsVisibleContainerContagem;
        public bool IsVisibleContainerContagem { get { return _IsVisibleContainerContagem; } set { _IsVisibleContainerContagem = value; OnPropertyChanged("IsVisibleContainerContagem"); } }

        private bool _IsVisibleBtnIniciar;
        public bool IsVisibleBtnIniciar { get { return _IsVisibleBtnIniciar; } set { _IsVisibleBtnIniciar = value; OnPropertyChanged("IsVisibleBtnIniciar"); } }

        private bool _IsVisibleBtnMostrar;
        public bool IsVisibleBtnMostrar { get { return _IsVisibleBtnMostrar; } set { _IsVisibleBtnMostrar = value; OnPropertyChanged("IsVisibleBtnMostrar"); } }

        public Command MostrarPalavra { get; set; }
        public Command Acertou { get; set; }
        public Command Errou { get; set; }
        public Command Iniciar { get; set; }

        public JogoViewModel()
        {
            IsVisibleContainerContagem = false;
            IsVisibleBtnIniciar = false;
            IsVisibleBtnMostrar = true;
            Palavra = "***********";

            MostrarPalavra = new Command(MostrarPalavraAction);
            Acertou = new Command(AcertouAction);
            Errou = new Command(ErrouAction);
            Iniciar = new Command(IniciarAction);
        }
       
        private void MostrarPalavraAction()
        {
            Palavra = "Sentar";
            IsVisibleBtnMostrar = false;
            IsVisibleBtnIniciar = true;
        }

        private void IniciarAction()
        {
            IsVisibleBtnIniciar = false;
            IsVisibleContainerContagem = true;

            int i = Armazenamento.Armazenamento.Jogo.TempoPalavra;
            Device.StartTimer(TimeSpan.FromSeconds(1), () => {
                TextoContagem = i.ToString();
                i--;
                return true;
            });
        }

        private void AcertouAction()
        {
            Armazenamento.Armazenamento.Jogo.Grupo1.Pontuacao += PalavraPontuacao;
            Armazenamento.Armazenamento.Jogo.Grupo2.Pontuacao += PalavraPontuacao;
        }

        private void ErrouAction()
        {
            
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