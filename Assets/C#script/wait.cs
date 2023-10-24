using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System.Threading;
public class wait : MonoBehaviour
{
    // Start is called before the first frame update
    void Start()
    {
        System.Threading.Thread.Sleep(1000);
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
