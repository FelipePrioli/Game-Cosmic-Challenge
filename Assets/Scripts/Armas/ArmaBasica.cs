using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public abstract class ArmaBasica : MonoBehaviour
{
    public Laser LaserPrefab;
    public float tempoEsperaTiro;
    private float intervaloTiro;
    public Transform[] posicoesDisparo;



    // Start is called before the first frame update
   public virtual void Start()
    {
        this.intervaloTiro = 0;
    }

    // Update is called once per frame
    void Update()
    {

        this.intervaloTiro += Time.deltaTime;
        if (intervaloTiro > tempoEsperaTiro)
        {
            this.intervaloTiro = 0;
            Atirar();

        }
    }

    protected void CriarLaser(Vector2 posicao)
    {
        Instantiate(this.LaserPrefab, posicao, Quaternion.identity);
    }


    protected abstract void Atirar();
    
    public void Ativar()
    {
        this.gameObject.SetActive(true);
    }

    public void Desativar()
    {
        this.gameObject.SetActive(false);
    }

}
