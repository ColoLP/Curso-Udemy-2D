using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraController : MonoBehaviour
{
    public Transform targetToFollow; // A quien va a seguir. 
    public Vector2 offset = new Vector2(0.16f,1.8f);
    public float dampTime = 0.3f;
    public Vector3 velocity = Vector3.zero;


    void Awake()
    {
        Application.targetFrameRate = 60; // A cuantos Frame deberia de renderizar. 
    }

    // Update is called once per frame
    void Update()
    {
        // Se puso el GetComponent<Camera>() para acceder todo el tiempo, y no estar accediendo a la primer referencia.
        //Devuelve el punto en el que el personaje se encuentra respecto del cuadrado que enfoca la camara. 
        Vector3 point = GetComponent<Camera>().WorldToViewportPoint(targetToFollow.position);
        Vector3 delta = targetToFollow.position - GetComponent<Camera>().ViewportToWorldPoint(new Vector3(offset.x, offset.y, point.z)); //Calculo la diferencia donde se movio el personaje
        Vector3 destination = point + delta; //Las sumo, va a donde esta el personaje.

        // En el caso que quiera que la camara no siga  al personaje lo que tengo que hacer es la siguiente linea de codigo
        destination = new Vector3(destination.x, offset.y, -10);
        this.transform.position = Vector3.SmoothDamp(this.transform.position,destination,ref velocity,dampTime); // Lo mueve de manera suave, asi queda lindo.
    }
}
