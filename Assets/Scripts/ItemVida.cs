using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ItemVida : MonoBehaviour
{
    [SerializeField]
    private int quantidadeVidas;

    public ParticleSystem particulaPrefab;
    
    public int QuantidadeVidas
    {
        get
        {
            return this.quantidadeVidas;
        }
    }

    public void Coletar()
    {
        //particla
      ParticleSystem particula = Instantiate(this.particulaPrefab, this.transform.position, Quaternion.identity);
        Destroy(particula.gameObject, 1f);

       Destroy(this.gameObject);
    }
}
