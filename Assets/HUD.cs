using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using BaboOnLite;

public class HUD : MonoBehaviour
{
    [SerializeField] TextMeshProUGUI info1, info2;
    [SerializeField] Transform avion;
    [SerializeField] RectTransform brujula;

    void Awake()
    {
        Instanciar<HUD>.Añadir(this);
    }

    private void Update()
    {
        Brujula();
    }

    void Brujula() 
    {
        if (avion == null || brujula == null) return;
        brujula.rotation = Quaternion.Euler(0f, 0f, -avion.rotation.eulerAngles.y);
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
