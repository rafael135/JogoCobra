
using Entidades.Enums;
using Entidades.Exceptions;
using JogoCobra;
using JogoCobra.Entidades;

namespace Entidades
{
    internal class Jogo
    {
        public int Linhas { get; private set; }
        public int Colunas { get; private set; }
        public bool Morreu { get; private set; }
        public Cobra Cobra { get; private set; }
        public Fruta? Fruta { get; private set; }
        public bool[,] EspacosOcupados { get; private set; } // Faltando implementar espaços atualmente ocupados


        private int controlSpawn = 14;

        public Jogo(int linhas, int colunas, int qteMaximaFrutas = 10)
        {
            Linhas = linhas;
            Colunas = colunas;
            Morreu = false;
            Fruta = null;
            Cobra = new Cobra(linhas, colunas, new Posicao(1, 1));
            controlSpawn = 14;
            EspacosOcupados = new bool[linhas, colunas];
        }

        public void ExecutarJogo()
        {
            EspacosOcupados = Cobra.GetEspacosOcupados(Linhas, Colunas);

            

            PosicionarCobra();

            VerificarMorte();

            if (Fruta != null)
            {
                PegouFruta(); // Checa se a cobra capturou uma fruta
            }
            if (controlSpawn == 14)
            {
                SpawnarFruta();
                controlSpawn = 0;
            }




            controlSpawn++;

        }

        private void PosicionarCobra()
        {
            switch (Cobra.Direcao)
            {
                case Direcao.Direita:
                    Cobra.Posicao.MudarPosicao(Cobra.Posicao.Linha, Cobra.Posicao.Coluna + 1);
                    break;

                case Direcao.Esquerda:
                    Cobra.Posicao.MudarPosicao(Cobra.Posicao.Linha, Cobra.Posicao.Coluna - 1);
                    break;

                case Direcao.Cima:
                    Cobra.Posicao.MudarPosicao(Cobra.Posicao.Linha - 1, Cobra.Posicao.Coluna);
                    break;

                case Direcao.Baixo:
                    Cobra.Posicao.MudarPosicao(Cobra.Posicao.Linha + 1, Cobra.Posicao.Coluna);
                    break;
            }

            // O CÓDIGO ABAIXO NÃO ESTÁ PRONTO

            /*
            ParteCorpoCobra aux = new ParteCorpoCobra(new Posicao(Cobra.Posicao.Linha, Cobra.Posicao.Coluna), Cobra.Direcao);

            foreach(ParteCorpoCobra parte in Cobra.PartesCorpoCobra)
            {
                Cobra.AjeitarParte(parte, aux);

                aux = parte;
            }
            */
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
                if (Fruta != null)
                {
                    if (novaFruta.Posicao == Fruta.Posicao)
                    {
                        existente = true;
                    }
                }

            } while (existente == true);


            Fruta = novaFruta;

        }

        private void RemoverFruta()
        {
            Fruta = null;
        }

        private void PegouFruta()
        {
            if (Cobra.Posicao.Linha == Fruta.Posicao.Linha && Cobra.Posicao.Coluna == Fruta.Posicao.Coluna)
            {
                Cobra.AumentarTamanho();
                RemoverFruta();
            }

        }


    }
}
