using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TurbaController : MonoBehaviour
{
    //Este script administra la generacion de los proyectiles a partir de una Lista de proyectiles y una lista de spawnPoints
    // Cosa Negativa: Todos van a tener similar tiempo de spawn, solo cambiarian los spwnpoits y los proyectiles.(Como cambio de comportamiento)
    public List<GameObject> lstSpawnPoints;
    public List<GameObject> lstProyectile; // Con esto, le puedo meter diferentes objetos y ya es standard.

    //Variables a utilizar dentro del controlador.
    private float spawnTime;
    private GameObject cloneProyectile, spawnProyectile; // cloneProyectile: Objeto donde se guarda el Proyectile instanciado.
                                                        // spawnProyectile: Proyectile a Instanciar

    void Start()
    {
        spawnTime = 5f;
    }

    void FixedUpdate()
    {
        if(Time.time > spawnTime && GameManager.sharedInstante.currGameStates == GameStates.inGame) // Solo van a tirar bombas si el juego esta activado
        {
            
            Transform spawnPoint = lstSpawnPoints[Random.Range(0, lstSpawnPoints.Count)].transform; //Punto de Spawn seleccionado al azar
            spawnProyectile = lstProyectile[Random.Range(0, lstProyectile.Count)]; // Proyectile que se va a Generar.

            cloneProyectile = Instantiate(spawnProyectile, spawnPoint.position, spawnPoint.rotation);
            cloneProyectile.GetComponent<Rigidbody2D>().AddForce(new Vector2(-10, 10));

            spawnTime += 1.5f;
        }
    }
    
}
