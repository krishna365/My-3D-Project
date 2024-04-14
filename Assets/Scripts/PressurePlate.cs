using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[SelectionBase]
[RequireComponent(typeof(AudioSource))]
public class PressurePlate : MonoBehaviour
{
    [SerializeField] AudioClip clip;

    public static List<PressurePlate> plates = new List<PressurePlate>();

    public bool isActivated = false;

    private void Awake()
    {
        GetComponent<AudioSource>().playOnAwake = false;
        GetComponent<AudioSource>().clip = clip;
        plates.Add(this);
    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.CompareTag("Player") && !isActivated)
        {
            GetComponent<AudioSource>().Play();
            isActivated = true;
        }
    }
}
