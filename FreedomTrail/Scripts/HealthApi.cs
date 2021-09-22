using System.Collections;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class HealthApi : MonoBehaviour
{
    public float MaxHealth;
    private float health;
    public Slider healthBar;
    public GameObject explosionFX;

    private void Start()
    {
        healthBar.maxValue = MaxHealth;
        health = MaxHealth;
        healthBar.value = MaxHealth;
    }
    private void Update()
    {
        if (health <= 0)
        {
            //GameOver            
            if (gameObject.tag == "Player")
            {
                //PlayerDeath
                SceneManager.LoadScene("MehrabSceneDemo02");
                print("! GameOver !");
            }
            if (gameObject.tag == "Enemy")
            {
                Instantiate(ScoreManager.instance.CoinObj, transform.position, transform.rotation);
                Instantiate(explosionFX, transform.position, transform.rotation);
                Destroy(gameObject);    
                EnemySpawner.aliveEnemies--;            
            }
        }
    }
    private void OnTriggerEnter(Collider collision)
    {
        if (collision.gameObject.tag == "AmmoEnemy")
        {
            if (gameObject.tag == "Player")
            {
                health--;
                healthBar.value = health;
                Destroy(collision.gameObject);
            }
        }
        if (collision.gameObject.tag == "AmmoPlayer")
        {
            if (gameObject.tag == "Enemy")
            {
                health--;
                healthBar.value = health;
                Destroy(collision.gameObject);
            }
        }
    }
}
