using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class InGame : MonoBehaviour
{


    public Text textoPontuacao;
    public BarraVida barravida;

    private NaveJogador jogador;

    [SerializeField]
    private TelaPause telaPause;

    private void Start()
    {
        this.telaPause.Desativar();
        this.jogador = GameObject.FindGameObjectWithTag("Player").GetComponent<NaveJogador>();
    }


    void Update()
    {
        this.barravida.ExibirVida(this.jogador.Vida);
        this.textoPontuacao.text = ControladorPontucao.Pontuacao + "x";
    }

    public void Pausar()
    {
        this.telaPause.Ativar();
    }

}
