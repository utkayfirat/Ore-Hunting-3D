using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Ore_Spawner : MonoBehaviour
{

    public GameManagers gameManagers;
    public List<GameObject> levelore;
    public List<GameObject> oreobject;
    public List<GameObject> orespawners;
    
    private int sControl;
    
    void Start(){

        for(int i=0; i<orespawners.Count; i++){
            if(gameManagers.level_ore == 0)
                sControl = Random.Range(0,8);

            GameObject gmgm = Instantiate(levelore[sControl], orespawners[i].transform.position, orespawners[i].transform.rotation);
            gmgm.transform.Rotate(0,Random.Range(0,90),0);
            oreobject.Add(gmgm);
        }

    }
    
    void Update(){
        
    }

}
