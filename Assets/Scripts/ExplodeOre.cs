using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ExplodeOre : MonoBehaviour
{
    public int cubesPerAxis = 7;
    public float delay = 1f;
    public float force = 450f;
    public float radius = 3f;

    void Start(){
        Invoke("Main",0.3f);
    }

    public void Main(){
        for(int x=0; x<cubesPerAxis; x++){
            for(int y=0; y<cubesPerAxis; y++){
                for(int z=0; z<cubesPerAxis; z++){
                    CreateCube(new Vector3(x,y,z));
                }
            }
        }
        Destroy(gameObject);
    }
    
    void CreateCube(Vector3 coordinates){
        GameObject cube = GameObject.CreatePrimitive(PrimitiveType.Cube);

        cube.GetComponent<BoxCollider>().isTrigger = true;
        Renderer rd = cube.GetComponent<Renderer>();
        rd.material = GetComponent<Renderer>().material;

        cube.transform.localScale = transform.localScale / cubesPerAxis;

        Vector3 firstCube = transform.position - transform.localScale / 2 + cube.transform.localScale / 2;
        cube.transform.position = firstCube + Vector3.Scale(coordinates, cube.transform.localScale);

        Rigidbody rb = cube.AddComponent<Rigidbody>();
        rb.AddExplosionForce(force, transform.position, radius);

       
    }

}
