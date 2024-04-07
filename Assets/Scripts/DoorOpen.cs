using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DoorOpen : MonoBehaviour
{
    public static DoorOpen instance;

    [SerializeField] Animator animator;

    private void Awake()
    {
        instance = this;
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
            if (activate)
            {
                OpenDoor();
            }
        }
    }

    public void OpenDoor()
    {
        animator.SetTrigger("Open");
    }

    public void CloseDoorAfterSeconds(float seconds)
    {
        StartCoroutine(CloseDoorAfter(seconds));
    }

    IEnumerator CloseDoorAfter(float seconds)
    {
        yield return new WaitForSeconds(seconds);
        animator.SetTrigger("Close");
    }
}
