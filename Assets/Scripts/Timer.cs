using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.SceneManagement;

public class Timer : MonoBehaviour
{
    [SerializeField] TMP_Text timerText;
    public float timeRemaining = 60f;

    public static Timer instance;

    private void Awake()
    {
        instance = this;
    }

    // Update is called once per frame
    void Update()
    {
        if(NextLevel.gameOver)
        {
            return;
        }

        timeRemaining -= Time.deltaTime;
        timerText.text = timeRemaining.ToString() + " Seconds";
        if (timeRemaining < 0)
        {
            SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex);
        }
    }
}
