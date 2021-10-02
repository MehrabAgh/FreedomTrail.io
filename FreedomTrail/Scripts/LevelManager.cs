using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LevelManager : MonoBehaviour
{
    public CarController[] Cars;
    public EnemyManager[] c;
    public List<Transform> Levels;
    public string nameLevel;
    public Transform levelSubmit,pivStart;
    public int indexLevel;
    public static LevelManager instance;
    public float indexDelayShoot;
    private void Awake()
    {
        instance = this;
    }
    void Start()
    {
        nameLevel = PlayerPrefs.GetString("Level");
        indexLevel = PlayerPrefs.GetInt("IndexLevel");
        indexDelayShoot = PlayerPrefs.GetFloat("IndexDelay");
        if(indexDelayShoot <= 0)
        {
            indexDelayShoot = 2f;
            PlayerPrefs.SetFloat("IndexDelay", indexDelayShoot);
        }
        print(indexDelayShoot);
        Cars =FindObjectsOfType<CarController>();      
        if (nameLevel == ""||name == null)
        {
            indexLevel = 1;
            indexDelayShoot = 2f;
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
        foreach (CarController item in Cars)
        {            
            item.SpeedMAX = 10 + (indexLevel*20);
            item.MaxSpeed = item.SpeedMAX;
        }      
        pivStart = levelSubmit.transform.Find("PivotStart");
        GameManager.ins.Player.transform.position = pivStart.transform.position;
    }
    public void EnemyDelayEdit()
    {
        if (c.Length <= EnemySpawner.ES.maxEnemy)
        {
            c = FindObjectsOfType<EnemyManager>();

            foreach (EnemyManager item in c)
            {
                item.DelayStart = indexDelayShoot;
            }
        }
    }
    private void Update()
    {
        EnemyDelayEdit();
    }
}
