using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Escudo : MonoBehaviour
{
    [SerializeField]
    private int protecaoTotal;

    private int protecaoAtual;




    public void Ativar()
    {
        this.protecaoAtual = this.protecaoTotal;
        this.gameObject.SetActive(true);   
    }

    public void Desativar()
    {
        this.gameObject.SetActive(false);
    }

    public bool Ativo
    {
        get
        {
            return this.gameObject.activeSelf;
        }
    }
    public void ReceberDano()
    {
        this.protecaoAtual--;
       if (this.protecaoAtual <= 0){
            Desativar();
        }
    }

}
