using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LevelManager : MonoBehaviour
{
    public List<Transform> Levels;
    public string nameLevel;
    public Transform levelSubmit,pivStart;
    public int indexLevel;
    public static LevelManager instance;

    private void Awake()
    {
        instance = this;
    }
    void Start()
    {
        nameLevel = PlayerPrefs.GetString("Level");
        indexLevel = PlayerPrefs.GetInt("IndexLevel");

        if (nameLevel == ""||name == null)
        {
            indexLevel = 1;
            nameLevel = "Level"+indexLevel;
            PlayerPrefs.SetString("Level", nameLevel);
        }
        foreach (Transform item in Levels)
        {
            if(item.name == nameLevel)
            {
                levelSubmit = Instantiate(item, transform.position, transform.rotation);
            }
        }
        pivStart = levelSubmit.transform.Find("PivotStart");
        GameManager.ins.Player.transform.position = pivStart.transform.position;
    }    
}
