namespace Entidades
{
    internal class Fruta
    {
        public Posicao Posicao { get; private set; }

        public Fruta()
        {
            
        }

        public Fruta(Posicao posicao)
        {
            Posicao = posicao;
        }

        public override string ToString()
        {
            return "*";
        }
    }
}
