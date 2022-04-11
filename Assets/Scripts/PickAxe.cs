using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PickAxe : MonoBehaviour
{
    [Header("Pickaxe Info")]
    public float pickaxe_damage = 1;
    public float pickaxe_level = 1;

    [Header("PlayerMovement Info")]
    [SerializeField] private PlayerMovement playerMovement;

    [Header("PlayerMovement Info")]
    [SerializeField] private GameManagers gameManagers;

    void Start(){
        pickaxe_damage = PlayerPrefs.GetInt("Pickaxe Damage",1);
        gameManagers = GameObject.Find("GameManagers").GetComponent<GameManagers>();
        playerMovement = GameObject.Find("Character").GetComponent<PlayerMovement>();
    }

    void Update(){
        pickaxe_damage = PlayerPrefs.GetInt("Pickaxe Damage",1);
    }
   

    private void OnTriggerEnter(Collider other){
        if(playerMovement.isMining && other.gameObject.tag.Contains("ore")){
            if(other.gameObject.tag == "ore stone"){
                SoundManager.PlaySound("dig");

                GameObject mat = Instantiate(gameManagers.digParticleModel, 
                other.gameObject.transform.position+new Vector3(0,0.2f,0), 
                gameManagers.digParticleModel.gameObject.transform.rotation);
                ParticleSystem.MainModule settings = mat.GetComponent<ParticleSystem>().main;
                settings.startColor = other.gameObject.GetComponent<Renderer>().material.color;
                //mat.gameObject.GetComponent<Renderer>().material = other.gameObject.GetComponent<Renderer>().material;

                Ore_Stone orestone = other.gameObject.GetComponent<Ore_Stone>(); 
                Transform vv3 = other.gameObject.transform;
                orestone.stone_health -= pickaxe_damage;
                if(orestone.stone_health <= 0){
                    SoundManager.PlaySound("destroy");
                    int oldInventory = PlayerPrefs.GetInt("Inventory",0);
                    PlayerPrefs.SetInt("Inventory",(PlayerPrefs.GetInt("Ore Earn",2)*8)+oldInventory);
                    
                    playerMovement.isOreHave = false;
                    other.gameObject.AddComponent<ExplodeOre>();
                    //Destroy(other.gameObject);
                }
            }
        }
            
    }

}
