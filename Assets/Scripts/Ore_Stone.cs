using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;

public class Ore_Stone : MonoBehaviour
{

    [Header("Ore (Stone) INFO")]
    public float stone_health;
    public TextMeshProUGUI shTmpro;

    void Start(){
       shTmpro.SetText(stone_health.ToString());
    }

    void Update(){
        shTmpro.SetText(stone_health.ToString());
    }



}
