using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class FimJogo : MonoBehaviour
{
    public Text textoPontuacao;
    public Text textoMelhorPontuacao;


    public void Exibir()
    {
        this.gameObject.SetActive(true);
        this.textoPontuacao.text = ControladorPontucao.Pontuacao + "x";
        this.textoMelhorPontuacao.text = ControladorPontucao.MelhorPontuacao.ToString();
        //Pausar o jogo
        Time.timeScale = 0;
    }

    public void Menu()
    {
        SceneManager.LoadScene("Menu");
        Time.timeScale = 1;
    }

    public void Esconder()
    {
        this.gameObject.SetActive(false);
    }

    public void TentarNovamente()
    {
        //volta o jogo
        Time.timeScale = 1;
        SceneManager.LoadScene("Fase01");
    }
}
