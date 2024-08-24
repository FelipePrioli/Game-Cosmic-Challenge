using System.Collections;
using System.Collections.Generic;
using UnityEngine;


[CreateAssetMenu(fileName = "Nova Configuracao", menuName = "SpaceShooter/Inimigos/Nova configuracao controlador inimigo")]
public class ConfiguracaoControladorInimigo : ScriptableObject
{
    [SerializeField]
    private ConfiguracaoInimigo[] configuracaoInimigos;

    [SerializeField]
    private float intervaloCriacaoInimigo;

    [SerializeField]
    private int quantidadeTotalInimigos;



    public ConfiguracaoInimigo[] ConfiguracaoInimigo
    {
        get
        {
            return this.configuracaoInimigos;
        }
    }


    public float IntervaloCriacaoInimigo
    {
        get
        {
            return this.intervaloCriacaoInimigo;
        }
    }

    public int QuantidadeTotalInimigos
    {
        get
        {
            return this.quantidadeTotalInimigos;


        }
    }
}

