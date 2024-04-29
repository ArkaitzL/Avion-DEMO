using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

[RequireComponent(typeof(Rigidbody))]
public class Avion : MonoBehaviour
{
    [Serializable] public class Teclas {
        public KeyCode acelerar = KeyCode.LeftShift;
        public KeyCode desacelerar = KeyCode.LeftControl;
    }
    float fuerzas {
        get => (rb.mass / 10f) * manejabilidad;
    }

    [SerializeField] float aceleracion = .1f, aceleracion_max = 100;
    [SerializeField] float velocidad_max = 200;
    [SerializeField] float manejabilidad = 10;
    [SerializeField] float fuerza_elevacion = 135;

    [Space] [SerializeField] Teclas teclas;

    [SerializeField] Transform helice;
    [SerializeField] TextMeshProUGUI info;

    float velociad;    
    float alabeo, cabeceo, guinada;     

    Rigidbody rb;

    void Awake() 
    {
        rb = GetComponent<Rigidbody>(); 
    }

    void Update()
    {
        Controles();
        Helice();
        Info();
    }

    private void FixedUpdate()
    {
        rb.AddForce(transform.forward * velocidad_max * velociad);  //Acelerar
        rb.AddTorque(transform.up * guinada * fuerzas);             //Rotar
        rb.AddTorque(transform.right * cabeceo * fuerzas);          //Ascender
        rb.AddTorque(transform.forward * alabeo * fuerzas);         //Inclinarse

        rb.AddForce(Vector3.up * rb.velocity.magnitude * fuerza_elevacion); //Elevacion
    }

    void Controles() 
    {
        //Control de avion
        alabeo = Input.GetAxis("Alabeo");
        cabeceo = Input.GetAxis("Cabeceo");
        guinada = Input.GetAxis("Guinada");

        //Aceleracion
        Acelerar();
    }

    void Acelerar() 
    {
        if (Input.GetKey(teclas.acelerar)) {
            velociad += aceleracion;
        }
        if (Input.GetKey(teclas.desacelerar)) {
            velociad -= aceleracion;
        }

        velociad = Mathf.Clamp(velociad, 0, aceleracion_max);
    }

    void Helice() 
    {
        if (helice == null) return;

        helice.Rotate(-Vector3.forward * (velociad / 5));
    }

    void Info() 
    {
        if (info == null) return;

        info.text  = $"Potencia: {velociad.ToString("F0")}%  \n";
        info.text += $"Velociad: {(rb.velocity.magnitude *3.6f).ToString("F0")}km/h \n";
        info.text += $"Altitud: {transform.position.y.ToString("F0")}m";
    }
}
