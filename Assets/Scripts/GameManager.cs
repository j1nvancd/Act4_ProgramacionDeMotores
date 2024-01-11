using UnityEngine;
using UnityEngine.UI;

public class GameManager : MonoBehaviour
{
    public GameObject canvasMenu;
    public Text contadorEnemigosText;
    public Text temporizadorText;

    private bool juegoPausado = false;
    private int contadorEnemigos = 0;
    private float tiempoDeJuego = 0f;

    void Update()
    {
        if (Input.GetKeyDown(KeyCode.Escape))  //Verifica si se presiona la tecla Escape para pausar o reanudar el juego
        {
            juegoPausado = !juegoPausado;
            canvasMenu.SetActive(juegoPausado);
            Time.timeScale = juegoPausado ? 0f : 1f; //Pausa o reanuda el juego
        }
      
        if (!juegoPausado) //Actualiza el tiempo de juego si el juego no está pausado
        {
            tiempoDeJuego += Time.deltaTime;
        }

        ActualizarTextos(); //Llama al método para actualizar los textos en pantalla
    }

    
    public void AumentarContadorEnemigos() //Método llamado cuando una bala destruye a un enemigo para aumentar el contador
    {
        contadorEnemigos++;
    }
  
    public void IncrementoDelContador(Bala bala) //Método llamado desde el GameManager para incrementar el contador de la bala
    {
        bala.AumentarContador();
    }
    
    public void ReiniciarJuego() //Reinicia el juego restableciendo contadores y ocultando el menú
    {
        contadorEnemigos = 0;
        tiempoDeJuego = 0f;
        ActualizarTextos();
        canvasMenu.SetActive(false); //Oculta el menú al reiniciar el juego
        juegoPausado = false; //Reanuda el juego al reiniciar
        Time.timeScale = 1f;
    }

    public void ReanudarJuego()  //Reanuda el juego ocultando el menú y restableciendo la escala del tiempo
    {
        juegoPausado = false;
        canvasMenu.SetActive(false); //Oculta el menú al reanudar el juego
        Time.timeScale = 1f; //Reanuda el juego
    }

    void ActualizarTextos() //Método para actualizar los textos en pantalla
    {
        contadorEnemigosText.text = "Enemigos destruidos: " + contadorEnemigos.ToString();
        temporizadorText.text = "Tiempo: " + Mathf.FloorToInt(tiempoDeJuego).ToString();
    }

    public void ExitJuego() //Cierra la aplicación al hacer clic en el botón de Exit
    {
        Application.Quit(); //Salir del juego
    }
}