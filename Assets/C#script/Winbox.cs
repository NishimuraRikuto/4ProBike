using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Winbox : MonoBehaviour
{
    private void OnTriggerEnter(Collider XJR400){
        GameObject.Find("TimerManager").SendMessage("Finnish");
    }
}
