using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using System.Threading;
public class second_script : MonoBehaviour
{
    void Start(){
       
    }
    

    // Update is called once per frame
    void Update()
    {
        Invoke("func",0.7f);
            
        
    }
    public void func(){
        SceneManager.LoadScene(2);
    }
}
