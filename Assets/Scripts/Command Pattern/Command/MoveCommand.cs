using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System;

 public class MoveCommand : Command {

    private Rigidbody2D rb;
    private float runningSpeed = 1.5f;

	public void Execute(GameObject actor)
	{
        rb = actor.GetComponent<Rigidbody2D>();

        if(rb != null && rb.velocity.x < runningSpeed)
        {
            rb.velocity = new Vector2(runningSpeed, rb.velocity.y);
        }

    }
 }
