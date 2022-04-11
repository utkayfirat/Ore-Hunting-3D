using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class WorldSpaceUI_LookCamera : MonoBehaviour
{
    public Transform mLookAt;
    private Transform localTrans;
    void Start()
    {
        localTrans = GetComponent<Transform>();   
    }

    void Update()
    {
        if(Camera.main){
            localTrans.LookAt(2 * localTrans.position - Camera.main.gameObject.transform.position);
        }
    }
}
