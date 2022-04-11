using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;

public class upgradeItemManagers : MonoBehaviour
{
    [SerializeField] private string itemName;
    public TextMeshProUGUI infoText1;
    public TextMeshProUGUI infoText2;
    public Button upgradeBtn;
    public GameManagers gameManagers;

    void Start(){
        gameManagers = GameObject.Find("GameManagers").GetComponent<GameManagers>();
        itemName = gameObject.name;
        ReDesignItem(itemName);
    }

    void Update(){
       
        if(itemName == "0"){
            bool canBuy = gameManagers.anythingBuyItemJUSTBOOL(PlayerPrefs.GetInt("Ore Earn",2)*300);
            if(canBuy)
                upgradeBtn.interactable = true;
            else
                upgradeBtn.interactable = false;
        }

        if(itemName == "1"){
            bool canBuy = gameManagers.anythingBuyItemJUSTBOOL(PlayerPrefs.GetInt("Ore Spawn",25)*500);
            if(canBuy)
                upgradeBtn.interactable = true;
            else
                upgradeBtn.interactable = false;
        }

        if(itemName == "2"){
            bool canBuy = gameManagers.anythingBuyItemJUSTBOOL(Mathf.RoundToInt(PlayerPrefs.GetFloat("Character Speed",2.5f)*175));
            if(canBuy)
                upgradeBtn.interactable = true;
            else
                upgradeBtn.interactable = false;
        }

        if(itemName == "3"){
            bool canBuy = gameManagers.anythingBuyItemJUSTBOOL(Mathf.RoundToInt(PlayerPrefs.GetFloat("Pickaxe Speed",0.9f)*2000));
            if(canBuy)
                upgradeBtn.interactable = true;
            else
                upgradeBtn.interactable = false;
        }

        if(itemName == "4"){
            bool canBuy = gameManagers.anythingBuyItemJUSTBOOL(PlayerPrefs.GetInt("Pickaxe Damage",1)*500);
            if(canBuy)
                upgradeBtn.interactable = true;
            else
                upgradeBtn.interactable = false;
        }
 
    }


    private void ReDesignItem(string itemName){

        if(itemName == "0"){
            infoText1.SetText("ORE EARN");
            infoText2.SetText(PlayerPrefs.GetInt("Ore Earn",2)+" -"+PlayerPrefs.GetInt("Ore Earn",2)*300);
            if(PlayerPrefs.GetInt("Ore Earn",2) >= 100){
                upgradeBtn.gameObject.SetActive(false);
                PlayerPrefs.SetInt("Ore Earn",100);
                infoText2.SetText("MAX 100");
            }else
                upgradeBtn.onClick.AddListener(() => upgradeAction(itemName));
        }

        if(itemName == "1"){
            infoText1.SetText("ORE SPAWN");
            infoText2.SetText(PlayerPrefs.GetInt("Ore Spawn",25)+"s -"+PlayerPrefs.GetInt("Ore Spawn",25)*500);
            if(PlayerPrefs.GetInt("Ore Spawn",25) <= 1){
                upgradeBtn.gameObject.SetActive(false);
                PlayerPrefs.SetInt("Ore Spawn",1);
                infoText2.SetText("MAX 1");
            }else{
                upgradeBtn.onClick.AddListener(() => upgradeAction(itemName));
            }
        }

        if(itemName == "2"){
            infoText1.SetText("CHARACTER SPEED");
            infoText2.SetText(PlayerPrefs.GetFloat("Character Speed",2.5f)+" -"+Mathf.RoundToInt(PlayerPrefs.GetFloat("Character Speed",2.5f)*175));
            if(PlayerPrefs.GetFloat("Character Speed",2.5f) >= 4f){
                upgradeBtn.gameObject.SetActive(false);
                PlayerPrefs.SetFloat("Character Speed",4f);
                infoText2.SetText("MAX 4");
            }else
                upgradeBtn.onClick.AddListener(() => upgradeAction(itemName));
        }

        if(itemName == "3"){
            infoText1.SetText("PICKAXE SPEED");
            infoText2.SetText(PlayerPrefs.GetFloat("Pickaxe Speed",0.9f)+" -"+PlayerPrefs.GetFloat("Pickaxe Speed",0.9f)*2000);
            if(PlayerPrefs.GetFloat("Pickaxe Speed",0.9f) >= 3f){
                upgradeBtn.gameObject.SetActive(false);
                PlayerPrefs.SetFloat("Pickaxe Speed",3f);
                infoText2.SetText("MAX 3");
            }else
                upgradeBtn.onClick.AddListener(() => upgradeAction(itemName));
        }

        if(itemName == "4"){
            infoText1.SetText("PICKAXE DAMAGE");
            infoText2.SetText(PlayerPrefs.GetInt("Pickaxe Damage",1)+" -"+PlayerPrefs.GetInt("Pickaxe Damage",1)*500);
            if(PlayerPrefs.GetInt("Pickaxe Damage",1) >= 25){
                upgradeBtn.gameObject.SetActive(false);
                PlayerPrefs.SetInt("Pickaxe Damage",25);
                infoText2.SetText("MAX 25");
            }else
                upgradeBtn.onClick.AddListener(() => upgradeAction(itemName));
        }

    }

    private void upgradeAction(string lastItemName){
        if(lastItemName == "0"){
            int currentPrice = PlayerPrefs.GetInt("Ore Earn",2)*300;
            bool canBuy = gameManagers.anythingBuyItem(currentPrice);
            if(canBuy){
                int currentOreEarn = PlayerPrefs.GetInt("Ore Earn", 2);
                int newOreEarn = currentOreEarn + 2;
                PlayerPrefs.SetInt("Ore Earn", newOreEarn);
                ReDesignItem(lastItemName);
            }
            ReDesignItem(lastItemName);
        }

        if(lastItemName == "1"){
            int currentPrice = PlayerPrefs.GetInt("Ore Spawn",2)*500;
            bool canBuy = gameManagers.anythingBuyItem(currentPrice);
            if(canBuy){
                int currentOreSpawn = PlayerPrefs.GetInt("Ore Spawn", 25);
                int newOreSpawn = currentOreSpawn - 1;
                PlayerPrefs.SetInt("Ore Spawn", newOreSpawn);
                
            }
            ReDesignItem(lastItemName);
        }

        if(lastItemName == "2"){
            int currentPrice = Mathf.RoundToInt(PlayerPrefs.GetFloat("Character Speed",2.5f)*175);
            bool canBuy = gameManagers.anythingBuyItem(currentPrice);
            if(canBuy){
                float currentSpeed = PlayerPrefs.GetFloat("Character Speed", 2.5f);
                float newSpeed = currentSpeed + 0.5f;
                PlayerPrefs.SetFloat("Character Speed", newSpeed);
            }
            ReDesignItem(lastItemName);
        }

        if(lastItemName == "3"){
            int currentPrice = Mathf.RoundToInt(PlayerPrefs.GetFloat("Pickaxe Speed",0.9f)*2000);
            bool canBuy = gameManagers.anythingBuyItem(currentPrice);
            if(canBuy){
                float currentSpeed = PlayerPrefs.GetFloat("Pickaxe Speed", 0.9f);
                float newSpeed = currentSpeed + 0.3f;
                PlayerPrefs.SetFloat("Pickaxe Speed", newSpeed);
            }
            ReDesignItem(lastItemName);
        }

        if(lastItemName == "4"){
            int currentPrice = PlayerPrefs.GetInt("Pickaxe Damage",1)*500;
            bool canBuy = gameManagers.anythingBuyItem(currentPrice);
            if(canBuy){
                int currentDamage = PlayerPrefs.GetInt("Pickaxe Damage", 1);
                int newDamage = currentDamage + 1;
                PlayerPrefs.SetInt("Pickaxe Damage", newDamage);
            }
            ReDesignItem(lastItemName);
        }
    }

}
