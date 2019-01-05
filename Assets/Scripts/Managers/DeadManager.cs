using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DeadManager : MonoBehaviour
{
    // Este Script se va a encargar de manejar los sucesos de muerte. 

    void OnTriggerEnter2D(Collider2D other)
    {
        if(other.CompareTag("Player"))
        {
            PlayerController.playerInstante.Kill();
        }
    }
}
