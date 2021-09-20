using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ScoreManager : MonoBehaviour
{
    public static ScoreManager instance;
    public GameObject CoinObj;
    public int Coin;
    public int Kill;

    private void Awake()
    {
        instance = this;
    }
}
