using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;

public class GameManagers : MonoBehaviour
{

    [Header("Camera's")]
    public Camera shop_camera;
    public Camera main_camera;

    public TextMeshProUGUI StoneTMP;
    public int inventory_stone_value = 0; 

    public TextMeshProUGUI AttackTMP;
    public TextMeshProUGUI MoneyTMP;
    public int money_value = 0;
    public int pickaxe_skin;
    public int level_ore = 0;
    public int ccTime;

    [Header("Upgrade UI")]
    public PlayerMovement playerMovement;
    public GameObject PickAxeSkinUpgradeUI;
    public GameObject chooseUpgraderUI;
    public GameObject upgraderUI;
    public GameObject buyWorkersUI;
    
    [Header("PickAxe Spawner")]
    public GameObject pickaxe_holder_gobject;
    public ShopPickAxeManager spam;
    public GameObject[] inGamePickaxeModels;

    [Header("Joystick")]
    public GameObject joystickBG;

    [Header("Particles Methods")]
    public GameObject digParticleModel;
    [Header("ADS")]
    public UnityAds unityAdsGameObject;
    private float times = 150f;

    void Start(){
        //PlayerPrefs.DeleteAll();
        //DENEME
        unityAdsGameObject = GameObject.Find("UnityAdsGameObject").GetComponent<UnityAds>();
        joystickBG = GameObject.Find("JoystickBG").gameObject;
        Application.targetFrameRate = 60;
        money_value = PlayerPrefs.GetInt("Money",0);
        inventory_stone_value = PlayerPrefs.GetInt("Inventory",0);
        pickaxe_skin = PlayerPrefs.GetInt("PickaxeSkin", 0);
        pickaxe_holder_gobject = GameObject.Find("pickaxe_holder_gobject");
        sPickaxer();
    }

    void Update(){
       
        money_value = PlayerPrefs.GetInt("Money",0);
        pickaxe_skin = PlayerPrefs.GetInt("PickaxeSkin", 0);
        AttackTMP.SetText(PlayerPrefs.GetInt("Pickaxe Damage",1).ToString());
        inventory_stone_value = PlayerPrefs.GetInt("Inventory",0);
        StoneTMP.SetText(minifyLong((long)inventory_stone_value));

        MoneyTMP.SetText(""+minifyLong((long)money_value));

        specialTimer();
    }
    
    public void specialTimer(){
        if(times >= 0)

            if(times == 150f){
                Debug.Log("Control used");
                unityAdsGameObject.LoadAds();
            }
            times -= Time.deltaTime;
            Debug.Log("ZAMAN "+times/100);
            if(times <= 0){
                PlayerPrefs.SetInt("Money",PlayerPrefs.GetInt("Money",0)+200);
                unityAdsGameObject.ShowVideoAd();
                times = 150f;
            }
            
    }

    public string minifyLong(long value)
    {
        if (value >= 1000000000000)
            return (value / 1000000000000D).ToString("F") + " T";
        if (value >= 1000000000)
            return (value / 1000000000D).ToString("F") + " B";
        if (value >= 1000000)
            return (value / 1000000D).ToString("F") + " M";
        if (value >= 1000)
            return (value / 1000D).ToString("F") + " K";
        return value.ToString("#,0"); 
    }

    public void buySkinUIaction(){
        PickAxeSkinUpgradeUI.SetActive(true);
        main_camera.gameObject.SetActive(false);
        shop_camera.gameObject.SetActive(true);
        chooseUpgraderUI.SetActive(false);
    }

    public bool anythingBuyItem(int m_money){
        if(money_value >= m_money){
            PlayerPrefs.SetInt("Money", money_value - m_money);
            return true;
        }
        return false;
    }

    public bool anythingBuyItemJUSTBOOL(int m_money){
        if(money_value >= m_money){
            return true;
        }
        return false;
    }

    public void sPickaxer(){
        GameObject spab = inGamePickaxeModels[pickaxe_skin].gameObject;
        pickaxeChanger(spab);
    }

    public void pickaxeChanger(GameObject sPickaxe){

        if(pickaxe_holder_gobject.gameObject.transform.childCount > 0){
            GameObject child = pickaxe_holder_gobject.transform.GetChild(0).gameObject;
            Destroy(child);
        }

        Instantiate(sPickaxe, pickaxe_holder_gobject.transform.position, pickaxe_holder_gobject.transform.rotation).transform.parent = pickaxe_holder_gobject.transform;
    }

    // Close Actions
    public void choosingCloseAction(){
        chooseUpgraderUI.SetActive(false);
        playerMovement.canMovement = true;
        joystickBG.SetActive(true);
    }

    public void buySkinCloseBtnAction(){
        PickAxeSkinUpgradeUI.SetActive(false);
        main_camera.gameObject.SetActive(true);
        shop_camera.gameObject.SetActive(false);
        chooseUpgraderUI.SetActive(true);
    }

    public void buyUpgradeCloseBtnAction(){
        upgraderUI.SetActive(false);
        chooseUpgraderUI.SetActive(true);
    }

    public void buyUpgradeBtnAction(){
        upgraderUI.SetActive(true);
        chooseUpgraderUI.SetActive(false);   
    }

}
