
using Entidades.Enums;
using JogoCobra;

namespace Entidades
{
    internal class Jogo
    {
        public int Linhas { get; private set; }
        public int Colunas { get; private set; }
        public bool Morreu { get; private set; }
        public Cobra Cobra { get; private set; }
        public List<Fruta> Frutas { get; private set; }

        private int controlSpawn = 0;

        public Jogo(int linhas, int colunas, int qteMaximaFrutas = 10)
        {
            Linhas = linhas;
            Colunas = colunas;
            Morreu = false;
            Frutas = new List<Fruta>();
            Cobra = new Cobra(new Posicao(1, 1));
        }

        public void ExecutarJogo()
        {
            if(Cobra.Direcao == Direcao.Direita)
            {
                Cobra.Posicao.MudarPosicao(Cobra.Posicao.Linha, Cobra.Posicao.Coluna + 1);
            }

            if(Cobra.Direcao == Direcao.Esquerda)
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

            PegouFruta(); // Checa se a cobra capturou uma fruta

            if(controlSpawn == 50)
            {
                SpawnarFruta();
            }
            

            controlSpawn++;
            
        }

        private void SpawnarFruta()
        {
            Random r = new Random();
            bool existente = false;

            do // Vai verificar se a posição de spawn da fruta já está ocupado
            {
                int linha = r.Next(0, Linhas);
                int coluna = r.Next(0, Colunas);

                Posicao pos = new Posicao(r.Next(0, linha), r.Next(0, coluna));
                Fruta novaFruta = new Fruta(pos);

                foreach(Fruta fruta in Frutas)
                {
                    if(novaFruta.Posicao == fruta.Posicao)
                    {
                        existente = true;
                    }
                }
            } while(existente == true);

            

            
        }

        private void PegouFruta()
        {
            foreach(Fruta fruta in Frutas)
            {
                if(Cobra.Posicao == fruta.Posicao)
                {
                    Frutas.Remove(fruta);
                }
            }
        }


    }
}
