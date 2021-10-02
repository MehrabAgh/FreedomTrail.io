using System.Collections;
using System.Collections.Generic;
using RootMotion.FinalIK;
using UnityEngine;
using UnityEngine.SceneManagement;

public class OverGameManage : MonoBehaviour
{    
    public GameObject PlayerChar;
    private void Awake()
    {
        PlayerChar = transform.Find("PlayerChar").gameObject;

    }
    private void OnCollisionEnter(Collision collision)
    {
        if (collision.gameObject.tag == "Finish")
        {
            GameManager.ins.DisableCar();
            FinishLevel();
            PlayerChar.GetComponent<Animator>().SetLayerWeight(2, 1);
            PlayerChar.GetComponent<FullBodyBipedIK>().enabled = false;
            PlayerChar.GetComponent<PlayerWeapon>().DisableGuns();
            GameManager.ins.UIFinish.SetActive(true);
            GameManager.ins.UIOver.SetActive(false);
            GameManager.ins.UIGame.SetActive(false);
            PlayerChar.transform.localRotation = Quaternion.Euler(-1.148f, 141.081f, 0.927f);
        }
    }
    public void FinishLevel()
    {
        GameManager.ins.EndGame();
    }
    public void NextLevel()
    {
        var index = LevelManager.instance.indexLevel;
        index++;
        //
        if (LevelManager.instance.indexDelayShoot <= 0.1f)
        {
            LevelManager.instance.indexDelayShoot = 0.3f;
            PlayerPrefs.SetFloat("IndexDelay", LevelManager.instance.indexDelayShoot);
        }
        else
        {
            LevelManager.instance.indexDelayShoot -= 0.1f;
            PlayerPrefs.SetFloat("IndexDelay", LevelManager.instance.indexDelayShoot);
        }
        //
        PlayerPrefs.SetInt("IndexLevel", index);
        print("Go to Level = " + index);
        var nameL = "Level" + index;
        PlayerPrefs.SetString("Level", nameL);
        SceneManager.LoadScene("SampleScene");
    }
    public void Retry()
    {
        SceneManager.LoadScene("SampleScene");
    }
}
