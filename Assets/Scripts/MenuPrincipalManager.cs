using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class MenuPrincipalManager : MonoBehaviour
{
    [SerializeField]
    private string nomeDoLevelDeJogo;

    [SerializeField]
    private GameObject painelMenuInicial;

    [SerializeField]
    private GameObject painelControles;

    [SerializeField]
    private GameObject painelSobre;

    private bool jogoIniciado = false;

    private void Start()
    {
        
    }


    public void Jogar()
    {
        SceneManager.LoadScene(nomeDoLevelDeJogo);
        Time.timeScale = 1;
    }

    public void AbrirControles()
    {
        painelMenuInicial.SetActive(false);
        painelControles.SetActive(true);
    }

    public void FecharControles()
    {
        painelControles.SetActive(false);
        painelMenuInicial.SetActive(true);
    }

    public void AbrirSobre()
    {
        painelSobre.SetActive(true);
        painelMenuInicial.SetActive(false);
    }

    public void FecharSobre()
    {
        painelSobre.SetActive(false);
        painelMenuInicial.SetActive(true);
    }

   /* public void SairJogo()
    {
        Application.Quit();
    }
    */

}
