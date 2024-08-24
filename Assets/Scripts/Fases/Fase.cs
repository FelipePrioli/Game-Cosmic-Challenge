using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(fileName = "Nova fase", menuName = "SpaceShooter/Fases/Nova fase")]
public class Fase : ScriptableObject
{

    [SerializeField]
    private string nome;

    [SerializeField]
    private ConfiguracaoControladorInimigo configuracaoControladorInimigo;


    public string Nome
    {
        get
        {
            return this.nome;
        }
    }

    public ConfiguracaoControladorInimigo ConfiguracaoControladorInimigo
    {
        get { return this.configuracaoControladorInimigo; }
    }


}
