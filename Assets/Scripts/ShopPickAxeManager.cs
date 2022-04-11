using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;

public class ShopPickAxeManager : MonoBehaviour
{

    private GameManagers gameManagers;
    public int currentPickAxeIndex;
    public GameObject[] pickaxeModels;
    public ShopPickAxeBlueprint[] pickaxes;
    public Button buyButton;
    public Button useBtn;
    public Button currentPickaxeBtn;
    public int skinNumberTaken;

    void Start(){
        gameManagers = GameObject.Find("GameManagers").GetComponent<GameManagers>();

        foreach (ShopPickAxeBlueprint pickaxeSing in pickaxes){
            if(pickaxeSing.pickAxeSkinNumber == 0){
                pickaxeSing.isUnlocked = true;
            }else{
                pickaxeSing.isUnlocked = PlayerPrefs.GetInt(pickaxeSing.name, 0) == 0  ? false : true;
            }
        }

        currentPickAxeIndex = PlayerPrefs.GetInt("SelectedPickaxe",0);
        foreach(GameObject pickaxeSing in pickaxeModels)
            pickaxeSing.SetActive(false);

        pickaxeModels[currentPickAxeIndex].SetActive(true);
        skinNumberTaken = PlayerPrefs.GetInt("PickaxeSkin", 0);
    }

    void Update(){
        UpdateUI();
    }

    public void ChangeNext(){
        
        pickaxeModels[currentPickAxeIndex].SetActive(false);
        currentPickAxeIndex++;
        if(currentPickAxeIndex == pickaxeModels.Length)
            currentPickAxeIndex = 0;

        pickaxeModels[currentPickAxeIndex].SetActive(true);
        ShopPickAxeBlueprint spab = pickaxes[currentPickAxeIndex];
        
        if(!spab.isUnlocked)
            return;

        PlayerPrefs.SetInt("SelectedPickaxe", currentPickAxeIndex);
        
    }

    public void ChangePrev(){

        pickaxeModels[currentPickAxeIndex].SetActive(false);
        currentPickAxeIndex--;
        if(currentPickAxeIndex == -1)
            currentPickAxeIndex = pickaxeModels.Length - 1;

        pickaxeModels[currentPickAxeIndex].SetActive(true);
        ShopPickAxeBlueprint spab = pickaxes[currentPickAxeIndex];
        
        if(!spab.isUnlocked)
            return;

        PlayerPrefs.SetInt("SelectedPickaxe", currentPickAxeIndex);

    }

    public void UnlockPickaxe(){
        
        ShopPickAxeBlueprint spab = pickaxes[currentPickAxeIndex];

        bool canibuy = gameManagers.anythingBuyItem(spab.price);
        if(canibuy){
            PlayerPrefs.SetInt(spab.name, 1);
            PlayerPrefs.SetInt("SelectedPickaxe", currentPickAxeIndex);
            spab.isUnlocked = false;
        }else{
            Debug.Log("Paran yetersiz SHOP PICK AXE MANAGER");
        }
    }

    private void UpdateUI(){

        ShopPickAxeBlueprint spab = pickaxes[currentPickAxeIndex];

        if(spab.isUnlocked || PlayerPrefs.GetInt(spab.name, 0) == 1){
            buyButton.gameObject.SetActive(false);
            if(gameManagers.pickaxe_skin != spab.pickAxeSkinNumber){
                useBtn.gameObject.SetActive(true);
                currentPickaxeBtn.gameObject.SetActive(false);
            }else{
                currentPickaxeBtn.gameObject.SetActive(true);
                useBtn.gameObject.SetActive(false);
            }
        }else{
            buyButton.gameObject.SetActive(true);
            useBtn.gameObject.SetActive(false);
            currentPickaxeBtn.gameObject.SetActive(false);
            buyButton.GetComponentInChildren<TextMeshProUGUI>().text = "Buy -" + spab.price;
        }

    }

    public void useBtnAction(){
        PlayerPrefs.SetInt("PickaxeSkin",currentPickAxeIndex);
        sPickaxer();
    }

    public void sPickaxer(){
        GameObject spab = gameManagers.inGamePickaxeModels[PlayerPrefs.GetInt("PickaxeSkin",0)].gameObject;
        gameManagers.pickaxeChanger(spab);
    }


}
