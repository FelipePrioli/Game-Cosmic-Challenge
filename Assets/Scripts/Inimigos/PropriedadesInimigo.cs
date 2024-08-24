using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(fileName = "Nova propriedade inimigo", menuName = "SpaceShooter/Inimigos/Propriedades Inimigo")]
public class PropriedadesInimigo : ScriptableObject
{
    [SerializeField]
    private float velocidadeMinima;
    [SerializeField]
    private float velocidadeMaxima;

    [SerializeField]
    private int quantidadeMaximaVidas;

    [SerializeField]
    [Range(0, 100)]
    private float chanceSoltarItemVida;

    [SerializeField]
    private ItemVida itemVidaPrefab;

    [SerializeField]
    [Range(0, 100)]
    private float chanceSoltarPowerUp;

    [SerializeField]
    private PowerUpColetavel[] powerupsPrefabs;


    public float VelocidadeMinima
    {
        get { return this.velocidadeMinima; }
    }

    public float VelocidadeMaxima
    {
        get { return this.velocidadeMaxima;}
    }

    public int QuantidadeMaximaVidas
    {

        get
        {
            return this.quantidadeMaximaVidas;
        }
    }

    public float ChanceSoltarItemVidas
    {
        get {
        return this.chanceSoltarItemVida;
        }
    }

    public ItemVida ItemVidaPrefab
    {
        get { return this.itemVidaPrefab; }
    }


    public float ChanceSoltarPowerUp
    {
        get
        {
            return this.chanceSoltarPowerUp;
        }
    }

    public PowerUpColetavel[] PowerUpPrefabs
    {
        get { return this.powerupsPrefabs; }
    }
}


