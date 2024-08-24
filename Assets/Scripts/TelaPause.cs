using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class TelaPause : MonoBehaviour
{

    public void Menu()
    {
        SceneManager.LoadScene("Menu");
        Time.timeScale = 1;
    }

    public void Ativar()
    {
        Time.timeScale = 0;
        this.gameObject.SetActive(true);
       
    }

    public void Desativar()
    {
        Time.timeScale = 1;
        this.gameObject.SetActive(false);

    }
}
