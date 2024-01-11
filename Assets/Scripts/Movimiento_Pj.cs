using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Movimiento_Pj : MonoBehaviour
{
    public float velocidad = 5f; //Velocidad de movimiento normal
    private float multiplicadorVelocidad = 1f; //Multiplicador de velocidad inicial
    public GameObject balaPrefab; //Prefab de la bala
    public Transform puntoDisparo; //Punto de origen de la bala
    public float velocidadBala = 10f; //Velocidad de la bala

    void Update()
    {
        ControlMovimiento();
        ControlDisparo();
    }

    void ControlMovimiento()
    {
        CalcularMultiplicadorDeVelocidad();
        MoverPersonaje();
        VerificarPosicion();
    }

    void CalcularMultiplicadorDeVelocidad()
    {
        if (Input.GetKeyDown(KeyCode.LeftShift) || Input.GetKeyDown(KeyCode.RightShift)) //Verifica si se presiona o se suelta la tecla Shift para ajustar el multiplicador de velocidad
        {
            multiplicadorVelocidad = 2f; //Aumenta la velocidad cuando se presiona Shift
        }
        else if (Input.GetKeyUp(KeyCode.LeftShift) || Input.GetKeyUp(KeyCode.RightShift))
        {
            multiplicadorVelocidad = 1f; // Restaura la velocidad normal cuando se suelta Shift
        }
    }

    void MoverPersonaje()
    {
        //Obtiene los valores de entrada horizontal y vertical
        float movimientoHorizontal = Input.GetAxis("Horizontal");
        float movimientoVertical = Input.GetAxis("Vertical");
       
        Vector2 direccion = new Vector2(movimientoHorizontal, movimientoVertical); //Calcula la dirección del movimiento

        transform.Translate(direccion * velocidad * multiplicadorVelocidad * Time.deltaTime); //Aplica el movimiento al personaje teniendo en cuenta la velocidad y el multiplicador
    }

    void ControlDisparo()
    {
       
        if (Input.GetMouseButtonDown(0)) //Verifica si se presiona el botón izquierdo del ratón para disparar
        {
            Disparar(); //Llama al método para realizar el disparo
        }
    }

    void Disparar()
    {
        //Calcula la dirección del disparo en función de la posición del ratón
        Vector3 direccionDisparo = (Input.mousePosition - Camera.main.WorldToScreenPoint(transform.position)).normalized;

        //Instancia una bala en el punto de disparo con la dirección calculada
        GameObject bala = Instantiate(balaPrefab, puntoDisparo.position, Quaternion.identity);
        
        //Configura la bala con la dirección del disparo
        bala.GetComponent<Bala>().ConfigurarBala(direccionDisparo);
    }

    void VerificarPosicion()
    {
        //Obtiene la posición actual del personaje
        Vector3 posicion = transform.position;

        //Obtiene el tamaño de la pantalla en unidades de juego 
        float anchoDePantalla = Camera.main.orthographicSize * Screen.width / Screen.height;
        float altoDePantalla = Camera.main.orthographicSize;

        //Verifica si el personaje se sale por los bordes de la pantalla y ajusta su posición
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

        //Aplica la nueva posición al personaje
        transform.position = posicion;
    }
}