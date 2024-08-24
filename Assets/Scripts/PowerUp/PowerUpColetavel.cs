using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public abstract class PowerUpColetavel : MonoBehaviour
{

    [SerializeField]
    private SpriteRenderer spriteRenderer;

    [SerializeField]
    private float intervaloTempoAntesAutodestruir;

    [SerializeField]
    private float IntervaloTempoEntrePiscadas;

    [SerializeField]
    private int quantidadeTotalPiscadas;

    [SerializeField]
    private float reducaoTempoEntrePiscadas;

    [SerializeField]
    private float duracaoEmSegundos;


    private float contagemTempoAntesAutodestruir;
    private bool autodestruindo;

    public abstract EfeitoPowerUp EfeitoPowerUp { get; }


    public void Start()
    {
        this.autodestruindo = false;
        this.contagemTempoAntesAutodestruir = 0;
    }

    public void Update()
    {
        this.contagemTempoAntesAutodestruir += Time.deltaTime;

        if (!this.autodestruindo)
        {
            if (this.contagemTempoAntesAutodestruir >= this.intervaloTempoAntesAutodestruir)
            {
                IniciarAutoDestruicao();
            }
        }
    }

    public float DuracaoEmSegundos
    {
        get
        {
            return this.duracaoEmSegundos;
        }
    }


    public void Coletar()
    {
        Destroy(this.gameObject);
    }


    private void IniciarAutoDestruicao()
    {
        this.autodestruindo = true;
        StartCoroutine(AutoDestruir());
    }

    private IEnumerator AutoDestruir()
    {
        int contadorPiscadas = 0;
        do
        {
            this.spriteRenderer.enabled = !this.spriteRenderer.enabled;

            yield return new WaitForSeconds(this.IntervaloTempoEntrePiscadas);
            contadorPiscadas++;
            this.IntervaloTempoEntrePiscadas -= contadorPiscadas * this.reducaoTempoEntrePiscadas;

            
        } while (contadorPiscadas < this.quantidadeTotalPiscadas);
        Destroy(this.gameObject);

    }

}
