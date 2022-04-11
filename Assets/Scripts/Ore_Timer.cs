using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class Ore_Timer : MonoBehaviour
{

    public GameManagers gameManagers;
    [Header("Ore (Stone) Supporter")]
    public Ore_Spawner ore_spawner;    

    [Header("Ore (Stone) TIMER")]
    public TextMeshProUGUI shTmpro;
    public GameObject stoneItem;
    public float c_time;
    private Transform controlV3;
    private int sControl;
    private float local_time;

    void Start(){
        gameManagers = GameObject.Find("GameManagers").GetComponent<GameManagers>();
        ore_spawner = GameObject.Find("GameManagers").GetComponent<Ore_Spawner>();
        c_time =  PlayerPrefs.GetInt("Ore Spawn",25);
    }

    void Update(){
        if(stoneItem.gameObject == null){
            if(gameObject)
                controlV3 = gameObject.transform;

            if(c_time >= 0)
                c_time -= Time.deltaTime;
            if(c_time <= 0){
                Destroy(gameObject);
                if(ore_spawner.gameManagers.level_ore == 0)
                    sControl = Random.Range(0,8);

                GameObject gmgm = Instantiate(ore_spawner.levelore[sControl],controlV3.position, controlV3.rotation);
                gmgm.transform.Rotate(0,Random.Range(0,90),0);

            }else{
                shTmpro.SetText(Mathf.RoundToInt(c_time)+"s");
            }
        }

    }

}
