using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Bala : MonoBehaviour
{
    public float tiempoVida = 2f; //Tiempo de vida de la bala

    void Start()
    {
        Destroy(gameObject, tiempoVida); //Destruye la bala después del tiempo de vida predefinido
    }

    public void ConfigurarBala(Vector3 direccion)
    {
        //Configura la velocidad de la bala basándose en la dirección y la velocidad de la bala definida en el script Movimiento_Pj
        Rigidbody2D rb = GetComponent<Rigidbody2D>();
        rb.velocity = direccion * FindObjectOfType<Movimiento_Pj>().velocidadBala;
    }

    void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject.CompareTag("Enemigo")) //Verifica si la bala colisiona con un objeto etiquetado como "Enemigo"
        {
            AumentarContador(); //Llama al método para aumentar el contador del GameManager
            Destroy(gameObject); //Destruye la bala
            Destroy(collision.gameObject); //Destruye el objeto enemigo con el que colisiona la bala
        }
    }

    public void AumentarContador()
    {
        //Busca una instancia del GameManager y aumenta el contador de enemigos
        GameManager controlMenu = FindObjectOfType<GameManager>();
        if (controlMenu != null)
        {
            controlMenu.AumentarContadorEnemigos(); //Aumenta el contador al colisionar con un enemigo
        }
    }
}