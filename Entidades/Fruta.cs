using JogoCobra.Entidades;

namespace Entidades
{
    internal class Fruta : ObjInterativo
    {

        public Fruta(Posicao? posicao = null) : base(posicao)
        {
            
        }

        public void RemoverFruta()
        {
            Posicao = null;
        }

        public override string ToString()
        {
            return "*";
        }
    }
}
