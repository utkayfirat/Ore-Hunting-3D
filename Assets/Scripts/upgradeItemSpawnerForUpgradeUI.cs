using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;

public class upgradeItemSpawnerForUpgradeUI : MonoBehaviour
{
    
    public upgradeItemModel[] uItemModel;
    public GameObject content;
    public GameObject itemLayout;
    
    void Start(){
        spawnerAction();
    }

    void spawnerAction(){
        
        foreach (upgradeItemModel uim in uItemModel){
            GameObject gob = Instantiate(itemLayout);
            gob.name = uim.index.ToString();
            gob.transform.SetParent(content.gameObject.transform, false);
            GameObject gob2 = gob.transform.GetChild(0).gameObject;
            gob2.transform.GetChild(0).gameObject.GetComponent<Image>().sprite = uim.iconImage;
            gob2.transform.GetChild(1).gameObject.GetComponent<TextMeshProUGUI>().text = uim.infoText1;
            gob2.transform.GetChild(2).gameObject.GetComponent<TextMeshProUGUI>().text = uim.infoText2;
            
            gob = null;
            gob2 = null;
        }
    }
}
