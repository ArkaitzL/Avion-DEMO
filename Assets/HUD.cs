using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using BaboOnLite;

public class HUD : MonoBehaviour
{
    [SerializeField] TextMeshProUGUI info;

    void Awake()
    {
        Instanciar<HUD>.Añadir(this);
    }

    public void Info(float potencia, float velocidad, Vector3 coorenadas)
    {
        if (info == null) return;

        info.text = $"Potencia: {potencia.ToString("F0")}%  \n";
        info.text += $"Velociad: {velocidad.ToString("F0")}km/h \n";
        info.text += $"Altitud: {coorenadas.y.ToString("F0")}m \n";
        info.text += $"Coords: {coorenadas.x.ToString("F0")} X | {coorenadas.z.ToString("F0")} Y";
    }
}
