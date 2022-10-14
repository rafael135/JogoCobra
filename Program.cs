using Entidades;

namespace JogoCobra
{
    internal class Program
    {
        static void Main(string[] args)
        {
            Jogo jogo = new Jogo(30, 30);

            
            while(jogo.Morreu != true)
            {
                try
                {
                    jogo.ExecutarJogo();
                    ConsoleKey comando = Console.ReadKey().Key;
                    jogo.Cobra.MudarDirecao(comando);

                    Thread.Sleep(100);


                }
                catch(IndexOutOfRangeException e)
                {

                }
            }
        }
    }
}