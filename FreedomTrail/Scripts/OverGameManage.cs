using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class OverGameManage : MonoBehaviour
{
    private void OnCollisionEnter(Collision collision)
    {
        if (collision.gameObject.tag == "Finish")
        {
            var index = LevelManager.instance.indexLevel;
            index++;
            PlayerPrefs.SetInt("IndexLevel", index);
            print("Go to Level = " + index) ;
            var nameL = "Level" + index;
            PlayerPrefs.SetString("Level", nameL);
            SceneManager.LoadScene("SampleScene");
        }
    }
}
