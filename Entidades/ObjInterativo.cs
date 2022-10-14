using Entidades;
using Entidades.Enums;

namespace JogoCobra.Entidades
{
    internal abstract class ObjInterativo
    {
        public Posicao Posicao { get; set; }
        public Cor Cor { get; private set; } // Não implementado

        public ObjInterativo(Posicao? posicao)
        {
            Posicao = posicao;
        }

        public abstract override string ToString();


    }
}
