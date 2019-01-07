using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DestroyManager : MonoBehaviour
{
    // Este Script se va a encargar de manejar los sucesos de muerte y de destruir los objetos que salgan del mapa. 
    string tagName = "";

    void OnTriggerExit2D(Collider2D other)
    {
        tagName = other.tag;

        //Puedo ir jugando con las diferentes tags para destruir cosas.
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
