using System.Collections;
using System.Collections.Generic;
using UnityEngine;


//Esta clase es la que me va a manejar todas las clases de comandos segun los inputs que tuvo. 

public class InputHandler {


    // Este es el manejador de Inputs, segun los botones que aprieta el PLAYER, cae sobre este script y devuelve los diferentes Commandos. 
	public Command HandleInput()
	{

        if ((Input.GetAxis("Horizontal") != 0 || Input.GetAxis("Vertical") != 0))
        {
            return new MoveCommand();
        }
        
		return null;// Si presiono algo que no sea lo que esta arriba GG. 

	} 

	
}
