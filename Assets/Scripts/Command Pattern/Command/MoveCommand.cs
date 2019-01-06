using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System;

 public class MoveCommand : Command {

    private Rigidbody2D rb;
    //private float runningSpeed = 1.5f;

	public void Execute(GameObject actor)
	{
        rb = actor.GetComponent<Rigidbody2D>();

        rb.AddForce(new Vector2(Input.GetAxis("Horizontal"), Input.GetAxis("Vertical")*10));


    }
 }
