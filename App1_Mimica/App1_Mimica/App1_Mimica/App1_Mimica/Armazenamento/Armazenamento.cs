using App1_Mimica.Model;
using System;
using System.Collections.Generic;
using System.Text;

namespace App1_Mimica.Armazenamento
{
    public class Armazenamento
    {
        public static Jogo Jogo { get; set; }
        public static short RodadaAtual { get; set; }
        public static string[][] Palavras =
        {
            new string[]{"Olho", "Lingua", "Chinelo", "Milho", "Penalty", "Bola", "Ping-pong"},
            new string[]{"Carpinteiro", "Amarelo", "Limão", "Abelha"},
            new string[]{ "Sisterna", "Lanterna", "Batman vs Superman", "Notebook" }
        };
    }
}