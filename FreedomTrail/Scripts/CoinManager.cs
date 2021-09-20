using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CoinManager : MonoBehaviour
{
    private void Update()
    {
        transform.position = Vector3.Lerp(transform.position, GameManager.ins.Player.transform.position,Time.deltaTime*10f);
    }

    private void OnTriggerEnter(Collider other)
    {
        if(other.gameObject.tag == "Player")
        {
            ScoreManager.instance.Coin++;
            Destroy(gameObject);
        }
    }
}
