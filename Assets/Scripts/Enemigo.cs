using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Enemigo : MonoBehaviour
{
    public float tiempoDeVida = 5f; // Tiempo de vida del enemigo
    public float velocidadVertical = 2f; // Velocidad de movimiento vertical (cayendo)
    public float velocidadHorizontalMin = -1f; // Velocidad mínima de movimiento horizontal
    public float velocidadHorizontalMax = 1f; // Velocidad máxima de movimiento horizontal

    void Start()
    {
        // Establecer el tiempo de vida del enemigo
        Invoke("Destruir", tiempoDeVida);
    }

    void Update()
    {
        // Mover al enemigo verticalmente
        transform.Translate(Vector2.down * velocidadVertical * Time.deltaTime);

        // Mover al enemigo horizontalmente de manera aleatoria
        float velocidadHorizontal = Random.Range(velocidadHorizontalMin, velocidadHorizontalMax);
        transform.Translate(new Vector2(velocidadHorizontal, 0f) * Time.deltaTime);
    }

    void Destruir()
    {
        Destroy(gameObject);
    }
}