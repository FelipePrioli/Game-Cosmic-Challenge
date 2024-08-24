using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ArmaDisparoAlternado : ArmaBasica
{
    private Transform posicaoProximoDisparo;


    

   public override void Start()
    {
        base.Start();
        this.posicaoProximoDisparo = this.posicoesDisparo[0];
    }

    protected override void Atirar()
    {
        CriarLaser(this.posicaoProximoDisparo.position);

    }

}
