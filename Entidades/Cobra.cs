using Entidades.Enums;
using JogoCobra.Entidades;

namespace Entidades
{
    internal class Cobra : ObjInterativo
    {
        public int Tamanho { get; private set; }
        public ParteCorpoCobra[] PartesCorpoCobra { get; private set; }
        public Direcao Direcao { get; private set; }

        public Cobra(int linhasDisponiveis, int colunasDisponiveis, Posicao posicaoInicial) : base(posicaoInicial)
        {
            Tamanho = 1;
            PartesCorpoCobra = new ParteCorpoCobra[linhasDisponiveis * colunasDisponiveis];
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

        public bool[,] GetEspacosOcupados(int linhas, int colunas) // Retorna os espaços que estão sendo ocupados pela cobra e possíveis partes do corpo
        {
            bool[,] checkEspacos = new bool[linhas, colunas];

            for (int i = 0; i < linhas; i++)
            {
                for (int j = 0; j < colunas; j++)
                {
                    foreach (ParteCorpoCobra parte in PartesCorpoCobra)
                    {
                        if (parte.Posicao.Linha == i && parte.Posicao.Coluna == j)
                        {
                            checkEspacos[i, j] = true;
                        }
                    }
                }
            }

            return checkEspacos;
        }

        public void AjeitarParte(ParteCorpoCobra atual, ParteCorpoCobra anterior) // Faltando implementar, vai controlar a posição e direção de cada Parte do corpo da cobra
        {
            if(atual.Direcao == Direcao.Direita)
            {
                atual.Posicao.MudarPosicao(atual.Posicao.Linha, atual.Posicao.Coluna + 1);
            }else if(atual.Direcao == Direcao.Esquerda)
            {
                atual.Posicao.MudarPosicao(atual.Posicao.Linha, atual.Posicao.Coluna - 1);
            }else if(atual.Direcao == Direcao.Cima)
            {
                atual.Posicao.MudarPosicao(atual.Posicao.Linha - 1, atual.Posicao.Coluna);
            }
            else
            {
                atual.Posicao.MudarPosicao(atual.Posicao.Linha + 1, atual.Posicao.Coluna);
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