using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Minimap : MonoBehaviour
{ 
   
    public Transform tf2;
    // Start is called before the first frame update
    void Start()
    {
        tf2=GetComponent<Transform>();
        
    }

    // Update is called once per frame
    void Update()
    {
        tf2.position=new Vector3(newBike.zettaiti.x,425,newBike.zettaiti.z);
    }
}
