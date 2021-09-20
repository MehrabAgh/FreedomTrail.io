using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CoinManager : MonoBehaviour
{
    private void Update()
    {
        transform.SetParent(GameManager.ins.Player.transform);
        transform.position = Vector3.Lerp(transform.position, GameManager.ins.Player.transform.position,Time.deltaTime*3f);
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
