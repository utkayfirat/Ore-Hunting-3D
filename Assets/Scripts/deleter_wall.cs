using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class deleter_wall : MonoBehaviour
{
   
    void OnTriggerEnter(Collider other){
        Destroy(other.gameObject);
    }

}
