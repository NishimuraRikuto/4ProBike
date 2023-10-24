using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using System.Threading;
public class third_script : MonoBehaviour
{
    void Start(){
       
    }
    

    // Update is called once per frame
    void Update()
    {
        Invoke("func2",0.90f);
            
        
    }
    public void func2()
    {
        SceneManager.LoadScene(3);
    }
}
