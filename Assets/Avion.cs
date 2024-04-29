using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using BaboOnLite;

[RequireComponent(typeof(Rigidbody))]
public class Avion : MonoBehaviour
{
    Controlador.Teclas.Avion teclas {
        get => controlador.teclas.avion;
    }

    [Header("Velocidades")]
    [SerializeField] float aceleracion = .1f;
    [SerializeField] float aceleracion_max = 100;
    [SerializeField] float velocidad = 200;
    [Header("Friccion")]
    [SerializeField] float friccion_aire = 0.01f;
    [SerializeField] float friccion_suelo = 1f;
    [Header("Manejabiliad")]
    [SerializeField] float manejabilidad_alabeo = 20;
    [SerializeField] float manejabilidad_cabeceo = 20;
    [SerializeField] float manejabilidad_guinada = 20;
    [Header("Otras fuerzas")]
    [SerializeField] float fuerza_elevacion = 135;

    [Header("Componentes")]
    [SerializeField] Transform helice;

    float potencia, planeo;             //Fuerzas   
    float alabeo, cabeceo, guinada;     //Controles
    bool enSuelo;

    Controlador controlador;
    HUD hud;
    Rigidbody rb;

    void Start() 
    {
        controlador = Instanciar<Controlador>.Coger();
        hud = Instanciar<HUD>.Coger();

        rb = GetComponent<Rigidbody>();
    }

    void Update()
    {
        Controles();
        Helice();

        hud.Info1(
            potencia,
            rb.velocity.magnitude * 3.6f,
            //rb.velocity.z * 3.6f,
            transform.position
       );
    }

    private void FixedUpdate()
    {
        rb.AddForce(transform.forward * velocidad * planeo);         //Acelerar

        rb.AddTorque(transform.up * guinada * fuerzas(manejabilidad_guinada));      //Rotar
        rb.AddTorque(transform.right * cabeceo * fuerzas(manejabilidad_cabeceo));   //Ascender
        rb.AddTorque(transform.forward * alabeo * fuerzas(manejabilidad_alabeo));   //Inclinarse

        rb.AddForce(Vector3.up * rb.velocity.magnitude * fuerza_elevacion);         //Elevacion
    }

    float fuerzas(float manejabilidad) => (rb.mass / 10f) * manejabilidad;

    void Controles() 
    {
        //Control de avion
        alabeo = Input.GetKey(teclas.alabeo_positivo) ? 1 : (Input.GetKey(teclas.alabeo_negativo) ? -1 : 0);
        cabeceo = Input.GetKey(teclas.cabeceo_positivo) ? 1 : (Input.GetKey(teclas.cabeceo_negativo) ? -1 : 0);
        guinada = Input.GetKey(teclas.guinada_positivo) ? 1 : (Input.GetKey(teclas.guinada_negativo) ? -1 : 0);

        //alabeo = Input.GetAxis("Alabeo");
        //cabeceo = Input.GetAxis("Cabeceo");
        //guinada = Input.GetAxis("Guinada");

        //Aceleracion
        Acelerar();
    }

    void Acelerar() 
    {
        if (Input.GetKey(teclas.acelerar)) {
            potencia += aceleracion;
        }
        if (Input.GetKey(teclas.desacelerar)) {
            potencia -= aceleracion;
        }

        potencia = Mathf.Clamp(potencia, 0, aceleracion_max);

        //Friccion
        if (planeo < potencia) planeo = potencia;               
        if (planeo > potencia && planeo >= 0) planeo -= (enSuelo) ? friccion_suelo : friccion_aire;
    }

    void Helice() 
    {
        if (helice == null) return;
        helice.Rotate(-Vector3.forward * (potencia / 5));
    }

    private void OnCollisionStay(Collision collision)
    {
        if (!enSuelo)
        {
            hud.Info2(true);
            enSuelo = true;
        }
    }

    private void OnCollisionExit(Collision collision)
    {
        hud.Info2(false);
        enSuelo = false;
    }
}
