using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class Tomenu : MonoBehaviour
{
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
        Invoke("arigatou",5.0f);
            
        
    }

    public void arigatou()
    {
        SceneManager.LoadScene(0);
    }
}
