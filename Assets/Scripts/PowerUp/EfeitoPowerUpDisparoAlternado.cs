using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EfeitoPowerUpDisparoAlternado : EfeitoPowerUp
{
    public EfeitoPowerUpDisparoAlternado(float duracaoEmSegundos) : base(duracaoEmSegundos)
    {
    }

    public override void Aplicar(NaveJogador jogador)
    {
        jogador.EquiparArmaDisparoAlternado();
    }

    public override void Remover(NaveJogador jogador)
    {
        jogador.EquiparArmaDisparoAlternado();
    }
}
