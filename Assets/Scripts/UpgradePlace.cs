using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class UpgradePlace : MonoBehaviour
{
    [Header("Close Buttons")]
    public Button buySkinCloseBtn;
    public Button choosingCloseBtn;
    public Button buyUpgradeCloseBtn;

    [Header("Opening Buttons")]
    public Button buyUpgradeBtn;
    public Button buySkinBtn;
    private GameManagers gameManagers;
    public PlayerMovement playerMovement;
    public GameObject joystickBG;
    
    void Start(){
        gameManagers = GameObject.Find("GameManagers").GetComponent<GameManagers>();
        joystickBG = GameObject.Find("JoystickBG").gameObject;
        // Close
        buyUpgradeCloseBtn.onClick.AddListener(gameManagers.buyUpgradeCloseBtnAction);
        buySkinCloseBtn.onClick.AddListener(gameManagers.buySkinCloseBtnAction);
        choosingCloseBtn.onClick.AddListener(gameManagers.choosingCloseAction);

        // Open
        buySkinBtn.onClick.AddListener(gameManagers.buySkinUIaction);
        buyUpgradeBtn.onClick.AddListener(gameManagers.buyUpgradeBtnAction);
    }

    private void OnTriggerEnter(Collider other){
        if(other.gameObject.tag == "player"){
            playerMovement.canMovement = false;
            gameManagers.chooseUpgraderUI.SetActive(true);
            joystickBG.SetActive(false);
        }
    }
    
}
