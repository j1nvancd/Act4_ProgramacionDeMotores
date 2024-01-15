using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Enemigo : MonoBehaviour
{
    public float tiempoDeVida = 5f; // Tiempo de vida del enemigo
    public float velocidadMovEjeX = 2f; // Velocidad de movimiento 
    public float velocidadMovEjeY = 2f;

    private float ejeX;
    private float ejeY;
    

    void Start()
    {
        // Establecer el tiempo de vida del enemigo
        Invoke("Destruir", tiempoDeVida);
        InvokeRepeating(nameof(GenerarDirecciones), 0f, Random.Range(1f, 5f));
    }

    void Update()
    {
        //Mover al enemigo 
        Mover();
    }

    void Mover()
    {
        transform.Translate(new Vector2(ejeX, ejeY).normalized * Time.deltaTime);
        VerificarPosicion();
    }

    private void GenerarDirecciones()
    {
        ejeX = Random.Range(-5, 5) * velocidadMovEjeX;
        ejeY = -1 * velocidadMovEjeY;
    }

     void VerificarPosicion()
    {
        //Obtiene la posición actual 
        Vector3 posicion = transform.position;

        //Obtiene el tamaño de la pantalla en unidades de juego 
        float anchoDePantalla = Camera.main.orthographicSize * Screen.width / Screen.height;
        float altoDePantalla = Camera.main.orthographicSize;

        //Verifica si se sale por los bordes de la pantalla y ajusta su posición
        if (posicion.x > anchoDePantalla)
        {
            posicion.x = -anchoDePantalla;
        }
        else if (posicion.x < -anchoDePantalla)
        {
            posicion.x = anchoDePantalla;
        }
        if (posicion.y > altoDePantalla)
        {
            posicion.y = -altoDePantalla;
        }
        else if (posicion.y < -altoDePantalla)
        {
            posicion.y = altoDePantalla;
        }

        //Aplica la nueva posición 
        transform.position = posicion;
    }

    void Destruir()
    {
        Destroy(gameObject);
    }
}