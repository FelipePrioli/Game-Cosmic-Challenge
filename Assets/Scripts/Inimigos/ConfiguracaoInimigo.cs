using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(fileName = "Nova configuracao", menuName = "SpaceShooter/Inimigos/Configuração Inimigo")]
public class ConfiguracaoInimigo : ScriptableObject
{

    [SerializeField]
    private Inimigo inimigoPrefab;

    [SerializeField]
    private PropriedadesInimigo propriedadesInimigo;


    public Inimigo InimigoPrefab
    {
        get
        {
            return this.inimigoPrefab;
        }
    }

    public PropriedadesInimigo PropriedadesInimigo
    {
        get { return this.propriedadesInimigo;}
    }

}
