using System;
using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.Animations;
using UnityEngine.Serialization;

public class DobleHelice : MonoBehaviour
{
    //Rango para controlar la velocidad
    [SerializeField] [Range(0, 10)] private float velocidad;
    //Distancia de separación
    [SerializeField] float distancia; 

    private float angulo, suma;
    private Transform objecto;

    private void Start()
    {
        objecto = GetComponent<Transform>();
    }

    private Vector3 posicion = Vector3.zero;
    
    private void Update()
    {
        angulo += velocidad * Time.deltaTime; 
        
        posicion = objecto.localPosition;

        suma = angulo + distancia;

        posicion.Set(Mathf.Cos(suma), Mathf.Sin(suma), angulo);

        objecto.localPosition = posicion;
        
    }
}
