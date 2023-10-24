using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using System.Threading;
public class fourth_script : MonoBehaviour
{
    void Start(){
        
    }
    

    // Update is called once per frame
    void Update()
    {
        Invoke("func3",0.48f);
        
    }
    public void func3()
    {
        SceneManager.LoadScene(4);

    }
    
}
