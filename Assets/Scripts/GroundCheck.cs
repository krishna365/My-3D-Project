using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

[RequireComponent(typeof(AudioSource))]

public class GroundCheck : MonoBehaviour
{
    public static GroundCheck instance;

    [SerializeField] PlayerController controller;
    [SerializeField] AudioClip coinAudio;
    [SerializeField] TMP_Text coinsText;
    public int CoinCount = 0;

    private void Awake()
    {
        instance = this;
    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.transform == controller.transform)
        {
            return;
        }
        if (other.tag == "Coin")
        {
            CoinCount++;
            coinsText.text = "Coins : " + CoinCount.ToString() + "\\2";
            GetComponent<AudioSource>().PlayOneShot(coinAudio);
            Destroy(other.gameObject);
        }
        controller.isGrounded = true;
    }

    private void OnTriggerStay(Collider other)
    {
        
    }

    private void OnTriggerExit(Collider other)
    {
        if (other.transform == controller.transform)
        {
            return;
        }
        controller.isGrounded = false;
    }
}
