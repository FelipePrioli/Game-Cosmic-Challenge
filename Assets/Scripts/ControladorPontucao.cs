using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public static class ControladorPontucao  {

    private static int pontucao;



    public static int Pontuacao
    {
        get
        {
            return pontucao;
        } set
        {
            pontucao = value;
            if ( pontucao <0 )
            {
                pontucao = 0;
            }   

            if(pontucao > MelhorPontuacao )
            {
                MelhorPontuacao = pontucao;
            }
        }
    }


    public static int MelhorPontuacao
    {
        get
        {
            int melhorPontuacao = PlayerPrefs.GetInt("melhorPontuacao", 0);
            return melhorPontuacao;
        } set
        {
            if (value > MelhorPontuacao)
            {
                PlayerPrefs.SetInt("melhorPontuacao", value);
            }
        }
    }



}

