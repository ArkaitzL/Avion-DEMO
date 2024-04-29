using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using BaboOnLite;

public class CamaraContr : MonoBehaviour
{
    Controlador controlador;
    int index = 0;

    void Start()
    {
        controlador = Instanciar<Controlador>.Coger();
    }
    private void Update()
    {
        if (Input.GetKeyDown(controlador.teclas.cambio_cam))
        {
            transform.GetChild(index).gameObject
                .SetActive(false);

            index = index.EquacionLimitada(+1, transform.childCount-1);
            transform.GetChild(index).gameObject
                .SetActive(true);
        }
    }
}
