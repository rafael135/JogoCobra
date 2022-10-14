
using Entidades.Enums;
using Entidades.Exceptions;
using JogoCobra;

namespace Entidades
{
    internal class Jogo
    {
        public int Linhas { get; private set; }
        public int Colunas { get; private set; }
        public bool Morreu { get; private set; }
        public Cobra Cobra { get; private set; }
        public Fruta Fruta { get; private set; }
        

        private int controlSpawn = 30;

        public Jogo(int linhas, int colunas, int qteMaximaFrutas = 10)
        {
            Linhas = linhas;
            Colunas = colunas;
            Morreu = false;
            Fruta = new Fruta();
            Cobra = new Cobra(linhas, colunas, new Posicao(1, 1));
        }

        public void ExecutarJogo()
        {
            if (Cobra.Direcao == Direcao.Direita)
            {
                Cobra.Posicao.MudarPosicao(Cobra.Posicao.Linha, Cobra.Posicao.Coluna + 1);
            }

            if (Cobra.Direcao == Direcao.Esquerda)
            {
                Cobra.Posicao.MudarPosicao(Cobra.Posicao.Linha, Cobra.Posicao.Coluna - 1);
            }

            if (Cobra.Direcao == Direcao.Cima)
            {
                Cobra.Posicao.MudarPosicao(Cobra.Posicao.Linha - 1, Cobra.Posicao.Coluna);
            }

            if (Cobra.Direcao == Direcao.Baixo)
            {
                Cobra.Posicao.MudarPosicao(Cobra.Posicao.Linha + 1, Cobra.Posicao.Coluna);
            }

            VerificarMorte();

            if (Fruta.Posicao != null)
            {
                PegouFruta(); // Checa se a cobra capturou uma fruta
            }
            if (controlSpawn == 30)
            {
                SpawnarFruta();
                controlSpawn = 0;
            }




            controlSpawn++;

        }

        private void VerificarMorte()
        {
            Posicao posicaoCobra = Cobra.Posicao;
            int linha = posicaoCobra.Linha;
            int coluna = posicaoCobra.Coluna;

            if (linha > Linhas || linha < 0 || coluna > Colunas || coluna < 0)
            {
                Morreu = true;
                Console.ForegroundColor = ConsoleColor.White;
                throw new JogoException("Perdeu ;-;");
            }

        }

        private void SpawnarFruta()
        {
            Random r = new Random();
            bool existente = false;
            Fruta novaFruta;

            do // Vai verificar se a posição de spawn da fruta já está ocupado
            {
                int linha = r.Next(0, Linhas);
                int coluna = r.Next(0, Colunas);

                Posicao pos = new Posicao(linha, coluna);
                novaFruta = new Fruta(pos);
                if (Fruta.Posicao != null)
                {
                    if (novaFruta.Posicao == Fruta.Posicao)
                    {
                        existente = true;
                    }
                }

            } while (existente == true);


            Fruta = novaFruta;



        }

        private void PegouFruta()
        {
            if (Cobra.Posicao.Linha == Fruta.Posicao.Linha && Cobra.Posicao.Coluna == Fruta.Posicao.Coluna)
            {
                Cobra.AumentarTamanho();
                Fruta.RemoverFruta();
            }

        }


    }
}
