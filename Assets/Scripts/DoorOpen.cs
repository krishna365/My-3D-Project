using System.Collections;
using System.Collections.Generic;
using UnityEngine;


[RequireComponent(typeof(AudioSource))]
public class DoorOpen : MonoBehaviour
{
    public static DoorOpen instance;

    [SerializeField] Animator animator;
    [SerializeField] AudioClip clip;

    public bool isOpen = false;

    private void Awake()
    {
        instance = this;
        GetComponent<AudioSource>().playOnAwake = false;
        GetComponent<AudioSource>().clip = clip;
    }

    private void Update()
    {
        if(PressurePlate.plates.Count > 0)
        {
            bool activate = true;
            foreach (PressurePlate plate in PressurePlate.plates)
            {
                if(!plate.isActivated)
                {
                    activate = false;
                }
            }
            if (activate && !isOpen)
            {
                OpenDoor();
            }
        }
    }

    public void OpenDoor()
    {
        animator.SetTrigger("Open");
        isOpen = true;
        GetComponent<AudioSource>().Play();
    }

    public void CloseDoorAfterSeconds(float seconds)
    {
        StartCoroutine(CloseDoorAfter(seconds));
    }

    IEnumerator CloseDoorAfter(float seconds)
    {
        yield return new WaitForSeconds(seconds);
        animator.SetTrigger("Close");
        GetComponent<AudioSource>().Play();
    }
}
