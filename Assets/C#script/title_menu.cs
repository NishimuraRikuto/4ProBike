using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using System.Threading;
public class title_menu : MonoBehaviour
{
    void Start(){
        System.Threading.Thread.Sleep(2000);
    }
    

    // Update is called once per frame
    void Update()
    {
        
        if(Input.GetButton("brake")){

            SceneManager.LoadScene(1);
            
            
        }
    }
}
