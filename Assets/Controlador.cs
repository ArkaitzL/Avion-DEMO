using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using BaboOnLite;

public class Controlador : MonoBehaviour
{
    [Serializable] public class Teclas {

        public Avion avion;
        public KeyCode cambio_cam = KeyCode.Tab;

        [Serializable] public class Avion {    
            public KeyCode acelerar = KeyCode.LeftShift;
            public KeyCode desacelerar = KeyCode.LeftControl;
            public KeyCode alabeo_negativo = KeyCode.D;
            public KeyCode alabeo_positivo = KeyCode.A;
            public KeyCode cabeceo_negativo = KeyCode.S;
            public KeyCode cabeceo_positivo = KeyCode.W;
            public KeyCode guinada_negativo = KeyCode.Q;
            public KeyCode guinada_positivo = KeyCode.E;
        }
    }

    [SerializeField] public Teclas teclas;

    void Awake()
    {
        Instanciar<Controlador>.Añadir(this);
    }

}
