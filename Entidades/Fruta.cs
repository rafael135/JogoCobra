using JogoCobra.Entidades;

namespace Entidades
{
    internal class Fruta : ObjInterativo
    {

        public Fruta(Posicao posicao) : base(posicao)
        {
            
        }

        public override string ToString()
        {
            return "*";
        }
    }
}
