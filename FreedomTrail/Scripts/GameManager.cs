using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class GameManager : MonoBehaviour
{
    public static GameManager ins;
    public GameObject Player;
    public bool _isEndGame;
    public List<CarAIControl> Cars;
    private void Awake()
    {
        ins = this;
        _isEndGame = true;
        Player = GameObject.FindGameObjectWithTag("Player");
    }
    private void Start()
    {
        Cars.Add(FindObjectOfType<CarAIControl>());        
    }
    public void Play()
    {       
        _isEndGame = false;
        foreach (var item in Cars)
        {
            item.enabled = true;
        }
    }
    public void ResetLevel()
    {
        LevelManager.instance.indexLevel = 1;
        PlayerPrefs.SetInt("IndexLevel", 1);
        LevelManager.instance.nameLevel = "Level" + LevelManager.instance.indexLevel;
        PlayerPrefs.SetString("Level", LevelManager.instance.nameLevel);
        SceneManager.LoadScene("SampleScene");
    }
    private void Update()
    {             
        if (_isEndGame)
        {
            //Gameover
            // PlayerPrefs.SetInt("Coin", ScoreManager.instance.Coin);
            // Time.timeScale = 0;
            foreach (var item in Cars)
            {
                item.enabled = false;
            }
        }
        else
        {            
            Time.timeScale = 1;
        }
    }
}
