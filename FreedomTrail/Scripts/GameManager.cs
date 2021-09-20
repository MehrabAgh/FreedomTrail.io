using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameManager : MonoBehaviour
{
    public static GameManager ins;
    public PlayerMovement Player;
    public Transform EndLine;
    public bool _isEndGame;
    private void Awake()
    {
        ins = this;
        Player = FindObjectOfType<PlayerMovement>();
    }

    private void Update()
    {        
        var dis = Vector3.Distance(Player.transform.position, EndLine.position);        
        if(dis <= 2)
        {
            _isEndGame = true;
        }
        if (_isEndGame)
        {
            //Gameover
            PlayerPrefs.SetInt("Coin", ScoreManager.instance.Coin);
            Time.timeScale = 0;
        }
        else
        {            
            Time.timeScale = 1;
        }
    }
}
