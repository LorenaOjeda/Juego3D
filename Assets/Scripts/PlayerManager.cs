using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class PlayerManager : MonoBehaviour
{

    public static bool gameOver; 
    public GameObject gameOverPanel;
    
    public static bool isGameStarted;
    public GameObject startingText;

    public static int numberOfCoins;
    public TMP_Text CoinsText;
    
    
    void Start()
    {
        gameOver = false; 
        Time.timeScale = 1;
        isGameStarted = false;
        numberOfCoins = 0;

    }

    // Update is called once per frame
    void Update()
    {
        if (gameOver) 
        {
          Time.timeScale = 0;
          gameOverPanel.SetActive(true);
        }

        CoinsText.text = "Monedas:" + numberOfCoins;
        if(SwipeManager.tap)
        {
            isGameStarted = true;
            Destroy(startingText);
        }
    }
}