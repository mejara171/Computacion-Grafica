using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Animations;

public class Seno : MonoBehaviour
{
    [SerializeField] [Range(0, 50)] private float velocidad;
    [SerializeField] private float radio, velocidadangular;

    private Transform objeto;
    private float angulo, multiplicacion;

    private void Start()
    {
        objeto = GetComponent<Transform>();
    }
    
    Vector3 Posicion = Vector3.zero;

    private void Update()
    {
        multiplicacion = velocidadangular * angulo;
        angulo += velocidad * Time.deltaTime * Mathf.Deg2Rad;

        float x = (radio * Mathf.Cos(angulo));
        float y = (radio * Mathf.Sin(angulo));
        float z = Mathf.Sin(multiplicacion);

        Posicion.Set(x,y,z);
        
        objeto.localPosition = Posicion;
        
    }
}
