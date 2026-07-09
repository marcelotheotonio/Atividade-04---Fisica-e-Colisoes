using System.Diagnostics;
using System.Numerics;
using UnityEngine;

public class EcoController : MonoBehaviour
{
    [Header("Movimentação")]
    [SerializeField] private float velocidade = 5f;

    [Header("Sistema de Pontos")]
    [SerializeField] private int pontos = 0;

    [Header("Sistema de Energia")]
    [SerializeField] private int energia = 100;
    [SerializeField] private int energiaMaxima = 100;

    // Exercício 4
    private Rigidbody2D rb;

    private float horizontal;

    void Start()
    {
        // Exercício 4
        rb = GetComponent<Rigidbody2D>();

        if (rb == null)
        {
            Debug.LogError("Rigidbody2D não encontrado no jogador!");
        }

        Debug.Log("Eco iniciado.");

        /*
         EXERCÍCIO 1
         Configure no Inspector:

         Rigidbody2D
         Body Type = Dynamic
         Gravity Scale = 2.5

         Resultado:
         O personagem cairá mais rapidamente que o padrão.
        */

        /*
         EXERCÍCIO 10
         Configure no Inspector:

         Constraints
         Freeze Rotation Z = TRUE

         Evita que o personagem gire ao colidir.
        */
    }

    void Update()
    {
        // Captura da entrada do jogador
        horizontal = Input.GetAxisRaw("Horizontal");
    }

    void FixedUpdate()
    {
        /*
         EXERCÍCIO 3
                
        */

        /*
         EXERCÍCIO 4
         Movimento físico oficial usando Rigidbody2D
         em vez de transform.Translate().
        */

        rb.velocity = new Vector2(
            horizontal * velocidade,
            rb.velocity.y
        );
    }

    
    // EXERCÍCIO 11
   

    private void OnCollisionEnter2D(Collision2D col)
    {
        if (col.gameObject.CompareTag("Inimigo"))
        {
            Debug.Log("Eco sofreu impacto físico!");
        }
    }

    
    // EXERCÍCIOS 12 E 13
 

    private void OnTriggerEnter2D(Collider2D area)
    {
        // Exercício 12
        if (area.CompareTag("Fantasma"))
        {
            Debug.Log("Eco atravessou o fantasma!");
        }

        // Exercício 13
        if (area.CompareTag("Semente"))
        {
            pontos += 10;

            Debug.Log("+10 Pontos");
            Debug.Log("Pontuação Atual: " + pontos);

            Destroy(area.gameObject);
        }
    }

  
    // EXERCÍCIO 14
   
   

    private void OnTriggerStay2D(Collider2D area)
    {
        if (area.CompareTag("Agua"))
        {
            if (energia < energiaMaxima)
            {
                energia++;
            }

            Debug.Log("Recuperando energia...");
        }
    }

    // EXERCÍCIO 15
  

    private void OnTriggerExit2D(Collider2D area)
    {
        if (area.CompareTag("Agua"))
        {
            Debug.Log("Fora da água. Energia estabilizada.");
        }
    }
}