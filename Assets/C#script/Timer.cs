using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;
using System.Threading;
using UnityEngine.SceneManagement;
using System.Threading;
using System.Globalization;
using UnityEngine.UI;

public class Timer : MonoBehaviour
{
    public GameObject SpeedText=null;
    public float[] rank_result2={0,0,0,0};
    public static float[] rank_result={100,100,100,100};
    public static float time_result;

    [Header("Component")]
    public TextMeshProUGUI timerText;

    [Header("Timer Settings")]
    public float currentTime;
    public bool countDown;

    [Header("Limit Settings")]
    public bool hasLimit;
    public float timerLimit;

    private bool finnished = false;




    // Start is called before the first frame update
    void Start()
    {
        currentTime = 0;
        countDown = true;
        hasLimit = true;
        timerLimit = 0;
    }

    // Update is called once per frame
    void Update()
    {
        Speedmeter();
        if (currentTime <= 0.05 && currentTime >= -0.05)
        {
            SetTimerText();
            timerText.text = "GO!";
            
            countDown = false;
            hasLimit = false;
        }

        if (finnished)
            return;

        currentTime = countDown ? currentTime -= Time.deltaTime : currentTime += Time.deltaTime;
        // print(currentTime);
        if(hasLimit && ((countDown && currentTime <= timerLimit) || (!countDown && currentTime >= timerLimit)))
        {
            currentTime = timerLimit;
            SetTimerText();
            timerText.color = Color.red;
            enabled = false;
        }

        SetTimerText();
        
        
    }
    private void Speedmeter(){
        Text speedtext=SpeedText.GetComponent<Text>();
        speedtext.text=newBike.speedm.ToString("0.0"+ "km/h");
    }

    private void SetTimerText()
    {
        timerText.text = currentTime.ToString("0.0");
    }

    public void Finnish()
    {
        finnished = true;
        timerText.color = Color.yellow;
        time_result=float.Parse(timerText.text,CultureInfo.InvariantCulture.NumberFormat);
        rank_result.CopyTo(rank_result2,0);

        if (time_result<65.0f){
            Invoke("Toresult",1.0f);

        }
        else{
            Invoke("Toresult",1.0f);
        }
        
        


    }
    public void Rank_Sort()
    {
        if(rank_result[0]>time_result){
            rank_result[0]=time_result;
            rank_result[1]=rank_result2[0];
            rank_result[2]=rank_result2[1];
            rank_result[3]=rank_result2[2];

        }
        else if(rank_result[1]>time_result){
            rank_result[1]=time_result;
            rank_result[2]=rank_result2[1];
            rank_result[3]=rank_result2[2];
        }
        else if(rank_result[2]>time_result){
            rank_result[2]=time_result;
            rank_result[3]=rank_result2[2];
        }
        else if(rank_result[3]>time_result){
            rank_result[3]=time_result;
        }
        else{

        }

    }
    public void Toresult()
    {
        Rank_Sort();
        SceneManager.LoadScene(5);
    }
    public void Toresult2()
    {
        Rank_Sort();
        SceneManager.LoadScene(5);
    }
}