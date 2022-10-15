using Entidades;
using Entidades.Enums;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace JogoCobra.Entidades
{
    internal class ParteCorpoCobra
    {
        public Posicao Posicao { get; private set; }
        public Direcao Direcao { get; private set; }

        public ParteCorpoCobra(Posicao posicao, Direcao direcao)
        {
            Posicao = posicao;
            Direcao = direcao;
        }


    }
}
