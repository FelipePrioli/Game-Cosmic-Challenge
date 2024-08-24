using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Inimigo : MonoBehaviour
{
    public SpriteRenderer spriteRenderer;
    public Rigidbody2D rigidbody;
    
    private int vidas;
    private float velocidadex;

    private PropriedadesInimigo propriedadesInimigo;
    private ControladorInimigo controladorInimigo;

    
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        this.rigidbody.velocity = new Vector2(-this.velocidadex, 0);

        Camera camera = Camera.main;
        Vector3 posicaoNaCamera = camera.WorldToScreenPoint(this.transform.position);
        if (posicaoNaCamera.x < 0)
        {
            NaveJogador jogador = GameObject.FindGameObjectWithTag("Player").GetComponent<NaveJogador>();
            jogador.Vida--;
            Destruir(false);
        }
    }

    public void Configurar(ControladorInimigo controladorinimigo, PropriedadesInimigo propriedadesInimigo)
    {
        this.controladorInimigo = controladorinimigo;
        this.propriedadesInimigo = propriedadesInimigo;
        this.velocidadex = Random.Range(this.propriedadesInimigo.VelocidadeMinima, this.propriedadesInimigo.VelocidadeMaxima);
        this.vidas = this.propriedadesInimigo.QuantidadeMaximaVidas;
    }

    public void ReceberDano()
    {
        this.vidas--;
        if (this.vidas <= 0)
        {
            Destruir(true);
        }
    }


    private void Destruir(bool derrotado)
    {
        if (derrotado)
        {
            ControladorPontucao.Pontuacao++;
            SoltarItemVida();
            SoltarPowerUp();

        }

        this.controladorInimigo.RemoverInimigo(this);

        Destroy(this.gameObject);
    }

    private void SoltarItemVida()
    {
        float chanceAleatoria = Random.Range(0f, 100f);
        if(chanceAleatoria <= this.propriedadesInimigo.ChanceSoltarItemVidas)
        {
            //Soltar o item de vida
            Instantiate(this.propriedadesInimigo.ItemVidaPrefab, this.transform.position, Quaternion.identity);
        }
    }

    private void SoltarPowerUp()
    {
        float chanceAleatoria = Random.Range(0f, 100f);
        if(chanceAleatoria <= this.propriedadesInimigo.ChanceSoltarPowerUp)
        {
            PowerUpColetavel[] powerUpPrefabs = this.propriedadesInimigo.PowerUpPrefabs;
            int indiceAleatorioPowerUp = Random.Range(0, powerUpPrefabs.Length);
            PowerUpColetavel powerUpColetavel = powerUpPrefabs[indiceAleatorioPowerUp];
            Instantiate(powerUpColetavel, this.transform.position, Quaternion.identity);
        }
    }

}
