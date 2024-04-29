using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using BaboOnLite;

public class HUD : MonoBehaviour
{
    [SerializeField] TextMeshProUGUI info1, info2;

    void Awake()
    {
        Instanciar<HUD>.A�adir(this);
    }

    public void Info1(float potencia, float velocidad, Vector3 coorenadas)
    {
        if (info1 == null) return;

        info1.text = $"Potencia: {potencia.ToString("F0")}%  \n";
        info1.text += $"Velociad: {velocidad.ToString("F0")}km/h \n";
        info1.text += $"Altitud: {coorenadas.y.ToString("F0")}m \n";
        info1.text += $"Coords: {coorenadas.x.ToString("F0")} X | {coorenadas.z.ToString("F0")} Y";
    }

    public void Info2(bool enSuelo)
    {
        if (info2 == null) return;
        info2.text = $"Suelo: {(enSuelo ? "SI" : "NO")}";
    }
}
