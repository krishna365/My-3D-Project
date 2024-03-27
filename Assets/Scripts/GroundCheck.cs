using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

public class GroundCheck : MonoBehaviour
{
    [SerializeField] PlayerController controller;

    [SerializeField] TMP_Text coinsText;
    public static int CoinCount = 0;

    private void OnTriggerEnter(Collider other)
    {
        if (other.transform == controller.transform)
        {
            return;
        }
        if (other.tag == "Coin")
        {
            CoinCount++;
            coinsText.text = "Coins : " + CoinCount.ToString();
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
