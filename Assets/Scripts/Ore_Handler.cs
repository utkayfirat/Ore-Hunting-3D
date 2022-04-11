using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Ore_Handler : MonoBehaviour
{
    private PlayerMovement playerMovement;
    
    void Start(){
        playerMovement = GameObject.Find("Character").GetComponent<PlayerMovement>();
    }

    void Update(){
        
    }

    private void OnTriggerEnter(Collider other){
        if(other.gameObject.tag.Contains("ore"))
            playerMovement.isOreHave = true;
        
    }

    private void OnTriggerExit(Collider other){
        if(other.gameObject.tag.Contains("ore"))
            playerMovement.isOreHave = false;
    }

}
