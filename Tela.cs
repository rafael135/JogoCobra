using Entidades;

namespace JogoCobra
{
    internal class Tela
    {   
        public Tela()
        {
            
        }

        public static void Atualizar(Jogo jogo)
        {
            List<Fruta> frutas = jogo.Frutas;
            Cobra cobra = jogo.Cobra;

            for(int i = 0; i < jogo.Linhas; i++)
            {
                for(int j = 0; j < jogo.Colunas; j++)
                {
                    Posicao aux = new Posicao(i, j);
                    if(cobra.Posicao == aux)
                    {
                        DesenharObjeto(cobra.ToString(), cobra.Posicao);
                    }

                    foreach(Fruta fruta in frutas)
                    {
                        if(fruta.Posicao == aux)
                        {
                            DesenharObjeto(fruta.ToString(), aux);
                        } // Criar superclasse para entidades de cobra e fruta serem compativeis
                    }


                }
            }
        }

        private static void DesenharObjeto(string ch, Posicao posicao)
        {
            Console.Write(ch);
        }
    }
}
