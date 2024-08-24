using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ControladorFase : MonoBehaviour
{

    [SerializeField]
    private Fase[] fases;

    [SerializeField]
    private ControladorInimigo controladorInimigo;

    private int indiceFaseAtual;
    private Fase faseAtual;

    
    private void Start()
    {
        this.indiceFaseAtual = 0;
        IniciarFaseAtual();
    }

    public void ConcluirFase()
    {
       


        if (TemProximaFase())
        {
           AvancarParaProximaFase();

        }else
        {
            Debug.Log("Fim de jogo. Todas as fases foram concluidas");
        }
    }

    private void AvancarParaProximaFase()
    {

        AnimacaoTransicaoFase.Instancia.AnimacaotransicaoConcluida += TransicaoFaseConcluida;

        Fase proximaFase = this.fases[this.indiceFaseAtual +1];
        AnimacaoTransicaoFase.Instancia.Ebixir(proximaFase.Nome);
    }

    private void TransicaoFaseConcluida()
    {
        AnimacaoTransicaoFase.Instancia.AnimacaotransicaoConcluida -= TransicaoFaseConcluida;

        this.indiceFaseAtual++;
        IniciarFaseAtual();
    }

    private bool TemProximaFase()
    {
        if (this.indiceFaseAtual < (this.fases.Length - 1)) 
        {
            return true; 
        }return false;
    }

    private void IniciarFaseAtual()
    {
        this.faseAtual = this.fases[this.indiceFaseAtual];
        this.controladorInimigo.Configurar(this, this.faseAtual.ConfiguracaoControladorInimigo);
    }
}
