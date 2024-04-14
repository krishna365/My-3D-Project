using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using TMPro;

public class NextLevel : MonoBehaviour
{
    [SerializeField] GameObject gameOverScreen;
    [SerializeField] int levelNumber = 1;
    [SerializeField] int numberOfCoins = 2;
    [SerializeField] TMP_Text timeText;

    public static bool gameOver = false;    

    private void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.CompareTag("Player"))
        {
            if(GroundCheck.instance.CoinCount >= numberOfCoins)
            {
                if(levelNumber == 0)
                {
                    gameOver = true;
                    gameOverScreen.SetActive(true);
                    PlayerController.instance.canMove = false;
                    timeText.text = "Completed in  : " + (60f - Timer.instance.timeRemaining).ToString() + " Seconds";
                }
                else
                {
                    SceneManager.LoadScene(levelNumber);
                }
            }
        }
    }
}
