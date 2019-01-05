using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerController : MonoBehaviour
{
    //Aca ponemos todas las variables que vamos a usar solo acá
    private InputHandler inputHandler;
    private Animator anim;
    private Vector3 startPosition; //Variable para saber en que lugar inicia el personaje. 

    //Todo lo que vamos a sacar para afuera. 
    public static PlayerController playerInstante;
    
    void Awake()
    {
        // Cada ves que Inicia el Juego seteamos la start position para los restarts.
        startPosition = this.transform.position; 
        playerInstante = this;
    }

    // Start is called before the first frame update
    public void StartGame()
    {
        inputHandler = new InputHandler();
        anim = this.GetComponent<Animator>();

        anim.SetBool("isAlive", true);
        anim.SetBool("isGrounded", true);

        this.transform.position = startPosition; // Toma el valor de donde nace el personaje incialmente. Es para el Restart. 
    }

    // Solo se va a utilizar para el salto.
    void Update()
    {
        if (GameManager.sharedInstante.currGameStates == GameStates.inGame) // Solo podra realizar acciones si, se encuentra en estado en Juego
        {
            //Se crea un variable del tipo inputHandler que va a ser la encargda de manejar los ingresos por tclado, haciendo que retorne un comand.
            if (inputHandler.HandleInput() != null)
            {
                Command cmd = inputHandler.HandleInput(); // Me devuelve que commando se va a ejecutar
                cmd.Execute(this.gameObject); //Ejecuta el comando especifico,aca podria ir cualquier cosa, siempre y cuando matchee con algun comando. 
            }
        }
    }

    // El unico que sabe como morir es el personaje. Pero a su vez tiene que afectar al GameManager. 
    public void Kill()
    {
        GameManager.sharedInstante.GameOver();
        anim.SetBool("isAlive", false); //Ejecuto la animacion de morir. 
    }
    
}
