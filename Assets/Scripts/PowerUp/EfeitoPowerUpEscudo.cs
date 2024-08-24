using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EfeitoPowerUpEscudo : EfeitoPowerUp
{
    public EfeitoPowerUpEscudo(float duracaoEmSegundos) : base(duracaoEmSegundos)
    {
    }

    public override void Aplicar(NaveJogador jogador)
    {
        jogador.AtivarEscudo();
    }

    public override void Remover(NaveJogador jogador)
    {
        jogador.DesativarEscudo();
    }
}
