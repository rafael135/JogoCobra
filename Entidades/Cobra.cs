using Entidades.Enums;
using JogoCobra.Entidades;
using System.Runtime.CompilerServices;

namespace Entidades
{
    internal class Cobra : ObjInterativo
    {
        public int Tamanho { get; private set; }
        public int[,] EspacoOcupado { get; private set; }
        public Direcao Direcao { get; private set; }
        
        public Cobra(int linhasDisponiveis, int colunasDisponiveis, Posicao posicaoInicial) : base(posicaoInicial)
        {
            Tamanho = 1;
            EspacoOcupado = new int[linhasDisponiveis, colunasDisponiveis];
            Direcao = Direcao.Direita;
        }



        public void MudarDirecao(ConsoleKey key)
        {
            switch (key)
            {
                case ConsoleKey.RightArrow:
                    Direcao = Direcao.Direita;
                    break;

                case ConsoleKey.LeftArrow:
                    Direcao = Direcao.Esquerda;
                    break;

                case ConsoleKey.UpArrow:
                    Direcao = Direcao.Cima;
                    break;

                case ConsoleKey.DownArrow:
                    Direcao = Direcao.Baixo;
                    break;

                default:

                    break;
            }


        }

        public void AumentarTamanho()
        {
            Tamanho++;
        }

        public override string ToString()
        {
            return "#";
        }


    }
}