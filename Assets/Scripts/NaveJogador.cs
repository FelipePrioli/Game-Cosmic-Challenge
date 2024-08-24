using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class NaveJogador : MonoBehaviour
{
    private const int QuantidadeMaximaVidas = 5;

    public Rigidbody2D rigidbody;
    public float velocidadeMovimento;
    private int vidas;
    private FimJogo telaFimJogo;
    public SpriteRenderer spriteRenderer;

    [SerializeField]
    private ControladorArma controladorArma;

    [SerializeField]
    private Escudo escudo;

    private EfeitoPowerUp powerUpAtual;


    // Start is called before the first frame update
    void Start()
    {
        this.vidas = QuantidadeMaximaVidas;
        
       
        ControladorPontucao.Pontuacao = 0;

        GameObject fimJogoGameObject = GameObject.FindGameObjectWithTag("TelaFimJogo");
        this.telaFimJogo = fimJogoGameObject.GetComponent<FimJogo>();
        this.telaFimJogo.Esconder();

        EquiparArmaDisparoAlternado();
        this.escudo.Desativar();
    }

    // Update is called once per frame
    void Update()
    {


        float horizontal = Input.GetAxis("Horizontal");
        float vertical = Input.GetAxis("Vertical");

        float velociadex = (horizontal * this.velocidadeMovimento);
        float velocidadey = (vertical * this.velocidadeMovimento);

        this.rigidbody.velocity = new Vector2(velociadex, velocidadey);

        VerifocarLimiteTela();

        if(this.powerUpAtual != null)
        {
            this.powerUpAtual.Atualizar();
            if (!this.powerUpAtual.Ativo)
            {
                this.powerUpAtual.Remover(this);
                this.powerUpAtual = null;
            }

        }
    }

    public void EquiparArmaDisparoAlternado()
    {
        this.controladorArma.EquiparArmaDisparoAlternado();
    }

    public void EquiparDisparoDuplo()
    {
        this.controladorArma.EquiparArmaDisparoDuplo();
    }

    public void AtivarEscudo()
    {
        this.escudo.Ativar();
    }

    public void DesativarEscudo()
    {
        this.escudo.Desativar();
    }
    private void VerifocarLimiteTela() {
       
            Vector2 posicaoAtual = this.transform.position;

            float metadeLargura = Largura / 2f;
            float metadeAltura = Altura / 2f;

            Camera camera = Camera.main;
            Vector2 limiteInferiorEsquerdo = camera.ViewportToWorldPoint(Vector2.zero);
            Vector2 limiteSuperiorDireito = camera.ViewportToWorldPoint(Vector2.one);

            float pontoReferenciaEsquerdo = posicaoAtual.x - metadeLargura;
            float pontoReferenciaDireita = posicaoAtual.x + metadeLargura;

            // Verifica limites horizontais
            if (pontoReferenciaEsquerdo < limiteInferiorEsquerdo.x)
            {
                posicaoAtual.x = limiteInferiorEsquerdo.x + metadeLargura;
            }
            else if (pontoReferenciaDireita > limiteSuperiorDireito.x)
            {
                posicaoAtual.x = limiteSuperiorDireito.x - metadeLargura;
            }

            float pontoReferenciaSuperior = posicaoAtual.y + metadeAltura;
            float pontoReferenciaInferior = posicaoAtual.y - metadeAltura;

            // Verifica limites verticais
            if (pontoReferenciaSuperior > limiteSuperiorDireito.y)
            {
                posicaoAtual.y = limiteSuperiorDireito.y - metadeAltura;
            }
            else if (pontoReferenciaInferior < limiteInferiorEsquerdo.y)
            {
                posicaoAtual.y = limiteInferiorEsquerdo.y + metadeAltura;
            }

            // Atualiza a posição do jogador
            this.transform.position = posicaoAtual;
        


    }

    private float Largura
    {
        get
        {
            Bounds bounds = this.spriteRenderer.bounds;
            Vector3 tamanho = bounds.size;
            return tamanho.x;

        }
    }

    private float Altura
    {
        get
        {
            Bounds bounds = this.spriteRenderer.bounds;
            Vector3 tamanho = bounds.size;
            return tamanho.y;

        }
    }


    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.CompareTag("Inimigo"))
        {
            Inimigo inimigo = collision.GetComponent<Inimigo>();
            ColidirInimio(inimigo);
        }
        else if (collision.CompareTag("itemVida"))
        {
            ItemVida itemVida = collision.GetComponent<ItemVida>();
            ColetarItemVida(itemVida);
        }
        else if (collision.CompareTag("PowerUp"))
        {
            PowerUpColetavel powerUp = collision.GetComponentInParent<PowerUpColetavel>();
            ColetarPowerUp(powerUp);
        }
    }

    private void ColidirInimio(Inimigo inimigo)
    {
        if (this.escudo.Ativo)
        {
            this.escudo.ReceberDano();
        }
        else
        {
            Vida--;
        }
        inimigo.ReceberDano();
    }

    private void ColetarItemVida(ItemVida itemVida)
    {
        Vida += itemVida.QuantidadeVidas;
        itemVida.Coletar();
    }

    private void ColetarPowerUp(PowerUpColetavel powerUp)
    {
        if(this.powerUpAtual != null)
        {
            this.powerUpAtual.Remover(this);
        }
        
        EfeitoPowerUp efeitoPowerUp = powerUp.EfeitoPowerUp;
        efeitoPowerUp.Aplicar(this);
        this.powerUpAtual = efeitoPowerUp;

        powerUp.Coletar();
    }

    public int Vida
    {
        get
        {
            return this.vidas;
        }set
        {
            this.vidas = value;
            if (this.vidas > QuantidadeMaximaVidas)
            {
                this.vidas = QuantidadeMaximaVidas;
            }else if(this.vidas <= 0)
            {
                this.vidas = 0;
                this.gameObject.SetActive(false);
                //Exibir tela de fim de jogo
                telaFimJogo.Exibir();
            }
        }
    }
}
