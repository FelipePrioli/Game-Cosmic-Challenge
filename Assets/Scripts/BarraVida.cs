using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BarraVida : MonoBehaviour
{

    public GameObject[] barrasVermelhas;


    public void ExibirVida(int vidas)
    {
        for (int i = 0; i < barrasVermelhas.Length; i++)
        {
            if (i<vidas)
            {
                //Ativas barra Vermelha
                this.barrasVermelhas[i].SetActive(true);
            }else
            {
                //Desativar Barra vermelha
                this.barrasVermelhas[i].SetActive(false);
            }


        }
    }


    


}
