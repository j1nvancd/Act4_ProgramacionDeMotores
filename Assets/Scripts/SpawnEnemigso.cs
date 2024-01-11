using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SpawnEnemigos : MonoBehaviour
{
    public GameObject enemigoPrefab; //Prefab del enemigo

    public float tiempoSpawnMin = 1f; //Tiempo mínimo entre spawns
    public float tiempoSpawnMax = 3f; //Tiempo máximo entre spawns
    private float tiempoProximoSpawn; //Tiempo para el próximo spawn

    public Vector2 areaSpawnMin; //Esquina inferior izquierda del área de spawn
    public Vector2 areaSpawnMax; //Esquina superior derecha del área de spawn

    void Start()
    {
        //Calcula el tiempo para el próximo spawn de forma aleatoria
        tiempoProximoSpawn = Random.Range(tiempoSpawnMin, tiempoSpawnMax);
    }

    void Update()
    {
        if (Time.time > tiempoProximoSpawn)  //Verifica si es el momento de realizar un nuevo spawn
        {
            SpawnEnemigo(); //Llama al método para instanciar un nuevo enemigo
            tiempoProximoSpawn = Time.time + Random.Range(tiempoSpawnMin, tiempoSpawnMax); //Actualiza el tiempo para el próximo spawn
        }
    }

    void SpawnEnemigo()
    {
        //Genera coordenadas aleatorias dentro del área de spawn
        float posicionX = Random.Range(areaSpawnMin.x, areaSpawnMax.x);
        float posicionY = Random.Range(areaSpawnMin.y, areaSpawnMax.y);
       
        Vector2 posicionSpawn = new Vector2(posicionX, areaSpawnMax.y);  //Crea un vector de posición con las coordenadas generadas y la coordenada Y máxima del área de spawn
  
        GameObject enemigo = Instantiate(enemigoPrefab, posicionSpawn, Quaternion.identity); //Instancia un nuevo enemigo en la posición generada
    }
}
