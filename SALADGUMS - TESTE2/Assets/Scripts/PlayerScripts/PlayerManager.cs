﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine.SceneManagement;
using TMPro;
using UnityEngine.UI;
using UnityEngine;

public class PlayerManager : MonoBehaviour
{
    //Coin Variables

    public static int numberOfCoins;
    public TextMeshProUGUI numberOfCoinsText;

    //Player Variables

    public static int currentHealth = 100;
    public Image damageScreen;
    public Slider healthBar;

    //Game Variables

    public static bool gameOver;
    public static bool winLevel;
    public GameObject gameOverPanel;
    public float timer = 0;

    // Start is called before the first frame update
    void Start()
    {
        //Life Settings
        damageScreen.enabled = false;
        //Reset the number of coins on each level
        numberOfCoins = 0;
        gameOver = winLevel = false;
    }

    // Update is called once per frame
    void Update()
    {
        //Display the number of coins
        numberOfCoinsText.text = "coins:" + numberOfCoins;

        //Update the slider(health) value

        healthBar.value = currentHealth;

        if (currentHealth <= 99)
        {
            damageScreen.enabled = true;
        }

        //GameOver

        if (currentHealth < 0)
        {
            gameOver = true;
            gameOverPanel.SetActive(true);

            //When respawn life gonna be full
            currentHealth = 100;
        }

        if (FindObjectsOfType<Enemy>().Length == 0)
        {
            //Win Level
            winLevel = true;
            timer += Time.deltaTime;
            if(timer > 5)
            {
                int nextLevel = SceneManager.GetActiveScene().buildIndex + 1;
                if(nextLevel == 4) // Because we didnt have fourth scene
                {
                    SceneManager.LoadScene(0); //Menu Loaded 
                }
                if (PlayerPrefs.GetInt("ReachedLevel", 1) < nextLevel)
                {
                    PlayerPrefs.SetInt("ReachedLevel", nextLevel);
                }
                SceneManager.LoadScene(nextLevel);
                winLevel = false;
                currentHealth = 100;
            }

        }
    }
}
