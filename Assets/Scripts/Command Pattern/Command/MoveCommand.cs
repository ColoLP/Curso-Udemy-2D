using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System;

 public class MoveCommand : Command {

    private Rigidbody2D rb;
    //private float runningSpeed = 1.5f;

	public void Execute(GameObject actor)
	{
        //Tengo que ajustar mejor el movimiento de personaje. Asi como está no esta muy funcional y estetico. 
        rb = actor.GetComponent<Rigidbody2D>();

        rb.AddForce(new Vector2(Input.GetAxis("Horizontal"), Input.GetAxis("Vertical") * 15));

    }
 }
