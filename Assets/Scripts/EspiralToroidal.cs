using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Animations;

public class EspiralToroidal : MonoBehaviour
{
    //Rango para controlar la velocidad
    [SerializeField] [Range(0, 50)] private float velocidad;

    //variables que modifican el radio en x, y y la rotacion
    [SerializeField] private float radio1, radio2, rotacion;

    
    private Transform objeto;
    private float angulo, multiplicacion;

    private void Start()
    {
        objeto = GetComponent<Transform>();
    }
    
    Vector3 posicion = Vector3.zero;
    private void Update()
    {
        multiplicacion = rotacion * angulo;

        angulo += velocidad * Time.deltaTime * Mathf.Deg2Rad;

        float x = (radio1 + (radio2 * Mathf.Cos(multiplicacion))) * Mathf.Cos(angulo);
        float y = (radio1 + (radio2 * Mathf.Cos(multiplicacion))) * Mathf.Sin(angulo);
        float z = radio2 * Mathf.Sin(multiplicacion);

        posicion.Set(x,y,z);
        
        objeto.localPosition = posicion; 
    }
}
