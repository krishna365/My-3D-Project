using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class NextLevel : MonoBehaviour
{
    [SerializeField] int levelNumber = 1;
    [SerializeField] int numberOfCoins = 2;

    private void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.CompareTag("Player"))
        {
            if(GroundCheck.CoinCount >= numberOfCoins)
            {
                SceneManager.LoadScene(levelNumber);
            }
        }
    }
}
