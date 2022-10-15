using Entidades;
using Entidades.Exceptions;

namespace JogoCobra
{
    internal class Program
    {
        
        static void Main(string[] args)
        {
            Console.BackgroundColor = ConsoleColor.Black;
            Console.ForegroundColor = ConsoleColor.White;

            Jogo jogo = new Jogo(12, 36);

            
            while(jogo.Morreu != true)
            {
                Console.Clear();
                try
                {
                    jogo.ExecutarJogo();
                    Tela.Atualizar(jogo); // Desenha a cobra e as frutas

                    
                    ConsoleKey comando = Console.ReadKey().Key;
                    jogo.Cobra.MudarDirecao(comando);

                    
                    

                }
                catch(JogoException e)
                {
                    Console.WriteLine(e.Message);
                    Console.ReadKey();
                }
                catch(Exception e)
                {
                    Console.WriteLine("Erro inesperado: " + e.Message);
                    Console.ReadKey();
                }
            }
        }
    }
}