using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System.IO.Ports;

public class Bike : MonoBehaviour {

    // public SerialPort sp = new SerialPort("COM6", 9600);

    public Transform handle;
    public List<AxleInfo> axleInfos;
    public float maxMotorTorque;
    public float maxSteeringAngle;
    public float tilt;
    public bool brake;
    void Start(){
        // sp.Open();
        // sp.ReadTimeout = 100;
        GetComponent<Rigidbody>().centerOfMass=new Vector3(0,-0.5f,0);
    }

   public void ApplyLocalPositionToVisuals(WheelCollider collider) {
        if(collider.transform.childCount == 0){
            return;
        }
        Transform visualWheel = collider.transform.GetChild(0);
        Vector3 position;
        Quaternion rotation;
        collider.GetWorldPose(out position, out rotation);
        visualWheel.transform.position = position;
        visualWheel.transform.rotation = rotation;
    } 
    public void Update() {
        // if(sp.IsOpen){
        //     try{
        //         tilt=int.Parse(sp.ReadExisting());
        //         print(int.Parse(sp.ReadExisting()));
        //     }
        //     catch(System.Exception){
                
        //     }
        // }
        tilt=Input.GetAxis("Horizontal");
        
        float motor = 0;
        motor= maxMotorTorque * (Input.GetAxis("Vertical")+1);
        // print(motor);
        
        
        // print("button"+(Input.GetAxis("brake").ToString()));
        brake = Input.GetButton("brake");
        if(brake){
            print("button");
        }

        float steering =-1* maxSteeringAngle * tilt ;//Input.GetAxis("Horizontal");
        foreach (AxleInfo axleInfo in axleInfos) {
            if (axleInfo.steering) {
                axleInfo.Wheel.steerAngle=steering;
                handle.localEulerAngles=new Vector3(0,steering,0);
            }
            if (axleInfo.motor) {
                axleInfo.Wheel.motorTorque = motor;
            }
            ApplyLocalPositionToVisuals(axleInfo.Wheel);
        }
    }
}
[System.Serializable]
public class AxleInfo {
    public WheelCollider Wheel;
    public bool motor; //駆動輪か?
    public bool steering; //ハンドル操作をしたときに角度が変わるか？
}