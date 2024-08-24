using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class AnimacaoTransicaoFase : MonoBehaviour
{
    public delegate void AnimacaoTransicaoFasesConcluidaDelegate();
    public AnimacaoTransicaoFasesConcluidaDelegate AnimacaotransicaoConcluida;

    [SerializeField]
    private TextMeshProUGUI textoNomeFase;

    [SerializeField]
    private Animator animator;

    private static AnimacaoTransicaoFase instancia;

    private void Awake()
    {
        instancia = this;
        Esconder();
    }

    public  static AnimacaoTransicaoFase Instancia
    {
        get { return instancia; }
    }

    public void Ebixir(string nomeFase)
    {
        this.textoNomeFase.text = nomeFase;
        this.gameObject.SetActive(true);
        this.animator.Play("TransicaoFase");
    }


    public void Esconder()
    {
        this.gameObject.SetActive(false);
    }

    public void ConcluirAnimacaoTransicao()
    {
        Esconder();
        if (this.AnimacaotransicaoConcluida != null)
        {
            this.AnimacaotransicaoConcluida.Invoke();
        }
    }
}
