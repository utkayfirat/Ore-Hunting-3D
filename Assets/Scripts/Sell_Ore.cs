using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Sell_Ore : MonoBehaviour
{
    [Header("Sell Place Supporters")]
    public GameManagers gameManagers;

    [Header("Price")]
    [SerializeField] private int stone_price;

    void Start(){
        stone_price = PlayerPrefs.GetInt("Ore Earn",2);
    }

    void Update(){
        stone_price = PlayerPrefs.GetInt("Ore Earn",2);
    }

    private void OnTriggerEnter(Collider other){
        if(other.gameObject.tag == "player"){
            if(gameManagers.inventory_stone_value > 0){
                SoundManager.PlaySound("money");
                int new_money_value = gameManagers.inventory_stone_value * stone_price;
                PlayerPrefs.SetInt("Money", PlayerPrefs.GetInt("Money",0)+new_money_value);
                PlayerPrefs.SetInt("Inventory",0);
            }
        }
    }

}
