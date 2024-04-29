using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TEMP : MonoBehaviour
{
    [SerializeField] GameObject suelo;
    [SerializeField] int tamaño = 100;

    private void Start()
    {
        for (int z = 0; z < tamaño; z++)
        {
            for (int x = 0; x < tamaño; x++)
            {
                GameObject hijo = Instantiate(suelo, new Vector3(x * 100, 0, z * 100), Quaternion.identity);
                hijo.transform.SetParent(transform);
            }
        }
    }
}
