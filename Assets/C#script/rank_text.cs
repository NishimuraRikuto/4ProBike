using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class rank_text : MonoBehaviour
{
    public GameObject Rank_text1 = null;
    public GameObject Rank_text2 = null;
    public GameObject Rank_text3 = null;
    public GameObject Rank_text4 = null;
    
    // Start is called before the first frame update
    void Start()
    {

    }

    void Update(){
        Text rank_text1=Rank_text1.GetComponent<Text>();
        rank_text1.text="1位"+Timer.rank_result[0].ToString()+"秒";
        Text rank_text2=Rank_text2.GetComponent<Text>();
        rank_text2.text="2位"+Timer.rank_result[1].ToString()+"秒";
        Text rank_text3=Rank_text3.GetComponent<Text>();
        rank_text3.text="3位"+Timer.rank_result[2].ToString()+"秒";
        Text rank_text4=Rank_text4.GetComponent<Text>();
        rank_text4.text="4位"+Timer.rank_result[3].ToString()+"秒";
    }
    // Update is called once per frame
    
}
