using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ControladorInimigo : MonoBehaviour
{
 
    private ConfiguracaoControladorInimigo configuracaoControladorInimigo;
    private float tempoDecorrido;
    private bool criacaoInimigosConcluido;
    private int quantidadeInimigosCriados;
    private List<Inimigo> inimigos;
    private ControladorFase controladorFase;


    private void Update()
    {
        if (this.criacaoInimigosConcluido)
        {
            return;
        }
        this.tempoDecorrido += Time.deltaTime;
        if (this.tempoDecorrido >= this.configuracaoControladorInimigo.IntervaloCriacaoInimigo)
        {
            this.tempoDecorrido = 0;
            this.quantidadeInimigosCriados++;
            CriarInimigo();
           
            if (this.quantidadeInimigosCriados >= this.configuracaoControladorInimigo.QuantidadeTotalInimigos)
            {
                this.criacaoInimigosConcluido = true;

            }
        }
    }

    public void Configurar(ControladorFase controladorFase, ConfiguracaoControladorInimigo configuracaoControladorInimigo)
    {
        this.controladorFase = controladorFase;
        this.configuracaoControladorInimigo = configuracaoControladorInimigo;

        this.quantidadeInimigosCriados = 0;
        this.criacaoInimigosConcluido = false;
        this.tempoDecorrido = 0;
        this.inimigos = new List<Inimigo>();

    }

    public void RemoverInimigo(Inimigo inimigo)
    {
        if (this.inimigos.Contains(inimigo))
        {
            this.inimigos.Remove(inimigo);
        }

        if (this.criacaoInimigosConcluido && (this.inimigos.Count == 0))
        {
            this.controladorFase.ConcluirFase();
        }
    }
    private void CriarInimigo()
    {
        ConfiguracaoInimigo configuracaoInimigo = GetConfiguracaoInimigoAleatoria();
        Inimigo prefabInimigo = configuracaoInimigo.InimigoPrefab;


        Vector2 posicaoInimigo = GetPosicaoAleatoriaParaInimigo();
        Inimigo novoInimigo = Instantiate(prefabInimigo, posicaoInimigo, Quaternion.identity);
        novoInimigo.Configurar(this, configuracaoInimigo.PropriedadesInimigo);
        this.inimigos.Add(novoInimigo);
    }

    private Vector2 GetPosicaoAleatoriaParaInimigo()
    {
        Vector2 posicaoMaxima = Camera.main.ViewportToWorldPoint(new Vector2(1, 1));
        Vector2 posicaoMinima = Camera.main.ViewportToWorldPoint(new Vector2(0, 0));


        float posicaoY = Random.Range(posicaoMinima.y, posicaoMaxima.y);
        Vector2 posicaoInimigo = new Vector2(posicaoMaxima.x, posicaoY);
        return posicaoInimigo;
    }

    private ConfiguracaoInimigo GetConfiguracaoInimigoAleatoria()
    {
        ConfiguracaoInimigo[] configuracaoInimigos = this.configuracaoControladorInimigo.ConfiguracaoInimigo;
        if ((configuracaoInimigos == null) || (configuracaoInimigos.Length == 0)) {
            return null;
        }

        int indiceAleatorio = Random.Range(0, configuracaoInimigos.Length);
        return configuracaoInimigos[indiceAleatorio];
    }

}
