using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[SelectionBase]
public class PressurePlate : MonoBehaviour
{
    public static List<PressurePlate> plates = new List<PressurePlate>();

    public bool isActivated = false;

    private void Awake()
    {
        plates.Add(this);
    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.CompareTag("Player"))
        {
            isActivated = true;
        }
    }
}
