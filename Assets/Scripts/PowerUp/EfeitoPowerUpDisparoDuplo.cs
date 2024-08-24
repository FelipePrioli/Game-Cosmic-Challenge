using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EfeitoPowerUpDisparoDuplo : EfeitoPowerUp
{
    public EfeitoPowerUpDisparoDuplo(float duracaoEmSegundos) : base(duracaoEmSegundos)
    {

    }


    public override void Aplicar(NaveJogador jogador)
    {
        jogador.EquiparDisparoDuplo();
    }

    public override void Remover(NaveJogador jogador)
    {
        jogador.EquiparArmaDisparoAlternado();
    }
}
