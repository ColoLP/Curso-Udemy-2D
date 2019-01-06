using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameManager : MonoBehaviour
{
    //Clave WIFI: YJZYYGMXEDME

    //Se declara dentro del Game Manager la variable de los estados, que es la que voy a cambiar
    public GameStates currGameStates = GameStates.menu; //Aca puedo arrancar con lo que quiera.
    public static GameManager sharedInstante; // La instnacia que se va a accede desde todos los  lados del codigo. 

    #region Singleton del GameManager
    void Awake()
    {
        sharedInstante = this;
    }

    #endregion

    void Start()
    {
        StartGame();
        //BacktoMenu();
    }    
    
    void Update()
    {

        // Estos dos inputs van acá por que va a ser el Game Manager el encargado de administrar los stops del usuario. 
        // El personaje va a tener solo los comportamientos puntuales del personaje. NO del todo.

        if (Input.GetButtonDown("Start") && currGameStates != GameStates.inGame)
        {
            StartGame();
        }

        if (Input.GetButtonDown("Pause"))
        {
            BacktoMenu();
        }
        if (Input.GetButton("Restart"))
        {

        }

    }

    //Metodo para comenzar el juego
    public void StartGame()
    {
        SetGameStates(GameStates.inGame);
        PlayerController.playerInstante.StartGame(); // Este es el StartGame del Player, no del Manager. 
    }

    public void BacktoMenu()
    {
        SetGameStates(GameStates.menu);
    }

    public void GameOver()
    {
        SetGameStates(GameStates.gameOver);
    }

    void SetGameStates(GameStates newGameStates)
    {
        //El chabon propone una Escena para cada cosa. Me resulta interesante 
        if(newGameStates == GameStates.menu)
        {
            //Codigo para volver al menu principal
        }else if(newGameStates == GameStates.inGame)
        {
            //Arranco el juego
        }else if(newGameStates == GameStates.gameOver)
        {
            //Pantalla de Game Over
        }

        // Le asigno el nuevo estado del juego, que me viene por parametro
        this.currGameStates = newGameStates;
    }
}
