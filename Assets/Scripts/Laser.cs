using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Laser : MonoBehaviour
{

    public Rigidbody2D rigidbody;
    public float velocidadeX;

    // Start is called before the first frame update
    void Start()
    {
        this.rigidbody.velocity = new Vector2(this.velocidadeX, 0);
    }

    private void Update()
    {
        Camera camera = Camera.main;
        Vector3 posicaoNaCamera = camera.WorldToScreenPoint(this.transform.position);

        // Saiu da tela pela parte direita
        if (posicaoNaCamera.x > Screen.width)
        {
            // Destr?i o objeto
            Destroy(this.gameObject);
        }

    }


    public void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.CompareTag("Inimigo"))
        {
            //Destrói o inimigo
            Inimigo inimigo = collision.GetComponent<Inimigo>();
            inimigo.ReceberDano();

            //Destrói o Laser
            Destroy(this.gameObject);
        }
    }

}
