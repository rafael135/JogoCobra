using Entidades;
using JogoCobra.Entidades;

namespace JogoCobra
{
    internal class Tela
    {
        public Tela()
        {

        }

        public static void Atualizar(Jogo jogo)
        {
            Fruta fruta = jogo.Fruta;
            Cobra cobra = jogo.Cobra;

            for (int i = 0; i < jogo.Linhas; i++)
            {
                for (int j = 0; j < jogo.Colunas; j++)
                {
                    bool existeObj = false;

                    Posicao aux = new Posicao(i, j);
                    if (jogo.Cobra.Posicao.Coluna == aux.Coluna && jogo.Cobra.Posicao.Linha == aux.Linha)
                    {
                        existeObj = true;
                        DesenharObjeto(jogo.Cobra);
                    }

                    if (jogo.Fruta.Posicao != null)
                    {
                        if (jogo.Fruta.Posicao.Linha == aux.Linha && jogo.Fruta.Posicao.Coluna == aux.Coluna)
                        {
                            existeObj = true;
                            DesenharObjeto(jogo.Fruta);
                        }
                    }
                    if (existeObj == false)
                    {
                        ConsoleColor corOriginal = ConsoleColor.Black;
                        Console.BackgroundColor = ConsoleColor.DarkGray;
                        Console.Write(" ");
                        Console.BackgroundColor = corOriginal;
                    }
                }
                Console.WriteLine();
            }

        }


        private static void DesenharObjeto(ObjInterativo obj)
        {
            ConsoleColor corBackOriginal = Console.BackgroundColor;
            ConsoleColor corOriginal = Console.ForegroundColor;

            switch (obj.ToString())
            {
                case "*":
                    ConsoleColor corFruta = ConsoleColor.Red;
                    Console.BackgroundColor = ConsoleColor.DarkGray;
                    Console.ForegroundColor = corFruta;
                    break;

                case "#":
                    ConsoleColor corCobra = ConsoleColor.Green;
                    Console.BackgroundColor = ConsoleColor.DarkGray;
                    Console.ForegroundColor = corCobra;
                    break;

                default:

                    break;
            }

            Console.Write(obj.ToString());
            Console.BackgroundColor = corOriginal;
        }
    }
}
