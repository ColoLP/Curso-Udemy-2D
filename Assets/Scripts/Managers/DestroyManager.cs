using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DestroyManager : MonoBehaviour
{
    // Este Script se va a encargar de manejar los sucesos de muerte. 
    string tagName = "";

    /*void OnTriggerEnter2D(Collider2D other)
    {
        if(other.CompareTag("Player"))
        {
            PlayerController.playerInstante.Kill();
        }
    }*/

    void OnTriggerExit2D(Collider2D other)
    {
        tagName = other.tag;

        switch (tagName)
        {
            case "Player":
                PlayerController.playerInstante.Kill();
                return;
            case "Proyectile":
                Destroy(other.gameObject);
                return;
            default:
                break;
        }
    }
}
