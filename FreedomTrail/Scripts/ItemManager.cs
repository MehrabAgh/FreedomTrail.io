using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;

public class ItemManager : MonoBehaviour
{
    public static ItemManager instance;
    public PlayerWeapon weapon;
    public int Coin;
    private int indexGun;
    private void Start()
    {
        Coin = PlayerPrefs.GetInt("CoinStart");        
    }
    private void Update()
    {
        if(weapon == null)
        {
            weapon = FindObjectOfType<PlayerWeapon>();
            GunLoaded();
        }
    }
    public void Buy(int price)
    {      
        if (Coin >= price)
        {
            var x = EventSystem.current.currentSelectedGameObject;
            foreach (Transform i in x.transform)
            {
                i.gameObject.SetActive(true);
            }
            x = x.transform.Find("Lock").gameObject;           
            Destroy(x);
            Coin -= price;
            PlayerPrefs.SetInt("CoinStart", Coin);
        }        
    }
    #region Guns
    public void MG_Gun()
    {
        indexGun = 2;
        weapon.changeGun(indexGun);
        PlayerPrefs.SetString("Gun","MG");
    }
    public void Rifle_Gun()
    {
        indexGun = 0;
        weapon.changeGun(indexGun);
        PlayerPrefs.SetString("Gun", "Rifle");
    }
    public void ShotGun_Gun()
    {
        indexGun = 1;
        weapon.changeGun(indexGun);
        PlayerPrefs.SetString("Gun", "ShutGun");
    }
    public void SMG_Gun()
    {
        indexGun = 3;
        weapon.changeGun(indexGun);
        PlayerPrefs.SetString("Gun", "SMG");
    }
    #endregion
    private void GunLoaded()
    {
        var gunName = PlayerPrefs.GetString("Gun");
        switch (gunName)
        {
            case "MG":
                weapon.changeGun(2);
                break;
            case "SMG":
                weapon.changeGun(3);
                break;
            case "ShutGun":
                weapon.changeGun(1);
                break;
            case "Rifle":
                weapon.changeGun(0);
                break;
            default:
                break;
        }
    }
}
