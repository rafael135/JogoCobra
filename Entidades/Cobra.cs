using Entidades.Enums;
using System.Runtime.CompilerServices;

namespace Entidades
{
    internal class Cobra
    {
        public int Tamanho { get; private set; }
        public Posicao Posicao { get; private set; }
        public Direcao Direcao { get; private set; }
        
        public Cobra(Posicao posicaoInicial)
        {
            Tamanho = 1;
            Posicao = posicaoInicial;
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

        public override string ToString()
        {
            return "#";
        }


    }
}