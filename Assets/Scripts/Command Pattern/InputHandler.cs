using System.Collections;
using System.Collections.Generic;
using UnityEngine;


//Esta clase es la que me va a manejar todas las clases de comandos segun los inputs que tuvo. 

public class InputHandler {


    // Este es el manejador de Inputs, segun los botones que aprieta el PLAYER, cae sobre este script y devuelve los diferentes Commandos. 
	public Command HandleInput()
	{

        if (Input.GetKeyDown(KeyCode.LeftShift) || Input.GetKeyDown(KeyCode.RightShift))
		{
			return new RunCommand();
		}

        if ((Input.GetAxis("Horizontal") != 0 || Input.GetAxis("Vertical") != 0))
        {
            return new MoveCommand();
        }

        if (Input.GetMouseButton(1))
		{
			return new FireCommand();
		}

		if (Input.GetAxis("Horizontal")==0 && Input.GetAxis("Vertical") == 0)
		{
			return new IdleCommand();
		}

		if (Input.GetKeyDown(KeyCode.E))
		{
			return new PickUpCommand();
		}
	
		return null;// Si presiono algo que no sea lo que esta arriba GG. 

	} 

	
}
