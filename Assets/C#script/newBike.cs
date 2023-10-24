using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class newBike : MonoBehaviour {
    public static float speedm=0;
    public static Vector3 zettaiti;
    public float maxMotorTorque = 10f;
    public float maxSteeringAngle= 30f;
    public float maxSpeed = 100f;
    public float magariyasusa = 0.1f;
    public float breaki = 10;
    public float distToGround=2.0f;
    public float katamuki = 0.01f;
    public float yokoteikou = 5;
    public float nanameriyasusa = 0.05f;
    public float ue=1;

    AudioSource audioSource;
    public AudioClip sound1;
    public AudioClip sound2;
    
    private Transform tf;
    private Rigidbody rb;
    private float motor = 0;
    private float steering = 0;
    private Vector3 localVelocity;
    

    void Start(){
        rb = GetComponent<Rigidbody>();
        GetComponent<Rigidbody>().centerOfMass=new Vector3(0,-0.5f,0);
        tf=GetComponent<Transform>();
        audioSource=GetComponent<AudioSource>();
    }

    public void FixedUpdate() {//FixedUpdate→Update
        motor = maxMotorTorque * (Input.GetAxis("Vertical")+1);
        steering = maxSteeringAngle * Input.GetAxis("Horizontal") * magariyasusa;
        
        if (Physics.Raycast(tf.position,Vector3.down,distToGround))
        speedm=rb.velocity.magnitude;
        MoveController();
        PostureControl();
        SoundPlayer();
        Reset();
        zettaititi();
        // TiltController();
        

    }
    public void zettaititi(){
        zettaiti=tf.position;

    }
    public void Reset()
    {
        if(tf.position.y<-80.0f|| Input.GetKey(KeyCode.R))
        {
            rb.velocity=Vector3.zero;
            tf.rotation=new Quaternion(0,0,0,0);
            tf.position=new Vector3(-348.56f,-67.3f,-588.19f);
        }
    }
    public void SoundPlayer()
    {
        float speed = rb.velocity.magnitude;
        

        if((Input.GetAxis("Vertical"))>=-1 && !audioSource.isPlaying)
        {
            audioSource.PlayOneShot(sound1);
            audioSource.PlayOneShot(sound2);
            
        }
        if(speed > 150.0f)
        {
            ue=0.025f*speed-2.2f;
        }
        else if(speed > 80.0f)
        {
            ue=0.022f*speed-1.3f;
        }
        else if(speed > 0.3f)
        {
            ue=0.01f*speed + 0.5f;
        }
        else if(speed >= 0)
        {
            ue = 0.5f;
        }
        audioSource.pitch=ue;       
    }
    
    // public void TiltController()
    // {
    //    Vector3 bikeAngle=tf.localEulerAngles;
    //    if(bikeAngle.z>45){
    //     rb.angularVelocity=new Vector3(0,0,-5);
    //    }
    //    if (bikeAngle.z>325){
    //     rb.angularVelocity=new Vector3(0,0,5);
    //     transform.eulerAngles = bikeAngle;
    //    }
    // }
    
    private void MoveController()
    {
        float speed = rb.velocity.magnitude;
        localVelocity = rb.transform.InverseTransformDirection(rb.velocity);
        float naname = steering / (maxSteeringAngle * magariyasusa) * nanameriyasusa;

        Quaternion rotation = this.transform.localRotation;// Transform値を取得する
        Vector3 rotationAngles = rotation.eulerAngles;// クォータニオン → オイラー角への変換

        float speedx=rb.velocity.x;
        float speedz=rb.velocity.z;
        
        rotationAngles.z += naname;


        rotationAngles.y +=steering;
        rotation = Quaternion.Euler(rotationAngles);// オイラー角 → クォータニオンへの変換
        this.transform.localRotation = rotation;

        if(localVelocity.x >0)
        {
            localVelocity.x *= 0.5f;
        }
        rb.velocity = rb.transform.TransformDirection(localVelocity);

        

        if (speed < maxSpeed && speed > 150)
        {
            rb.AddRelativeForce(Vector3.forward * motor * 0.82f);
        }
        else if (speed < maxSpeed && speed > 70)
        {
            rb.AddRelativeForce(Vector3.forward * motor * 0.85f);
        }
        else if (speed < maxSpeed && speed > 50)
        {
            rb.AddRelativeForce(Vector3.forward * motor * 0.9f);
        }
        else if(speed < maxSpeed)
        {
            rb.AddRelativeForce(Vector3.forward * motor* 0.95f);
        }

        if (Input.GetButton("brake"))
        {
            
            if (speed != 0)
            {
                rb.AddForce(new Vector3(-speedx*breaki,0,-speedz*breaki));
            }
            
        }

    }

    private void PostureControl()
    {
        Quaternion rotation = this.transform.localRotation;// Transform値を取得する
        Vector3 rotationAngles = rotation.eulerAngles;// クォータニオン → オイラー角への変換

        //Debug.Log(rotationAngles.z);
        
        if (rotationAngles.z < 360 && rotationAngles.z > 240)
        {
            rotationAngles.z = rotationAngles.z + (360-rotationAngles.z) * katamuki;
           // Debug.Log("右から" + rotationAngles.z);
        }else if(rotationAngles.z > 0 && rotationAngles.z < 100)
        {
            rotationAngles.z = rotationAngles.z - rotationAngles.z * katamuki;
            //Debug.Log("左から" + rotationAngles.z);
        }

        if (rotationAngles.x < 360 && rotationAngles.x > 240)
        {
            rotationAngles.x = rotationAngles.x + (360 - rotationAngles.x) * katamuki*1.5f;
            // Debug.Log("右から" + rotationAngles.z);
        }else if (rotationAngles.x > 0 && rotationAngles.x < 100)
        {
            rotationAngles.x = rotationAngles.x - rotationAngles.x * katamuki*1.5f;
            //Debug.Log("左から" + rotationAngles.z);
        }


        rotation = Quaternion.Euler(rotationAngles);// オイラー角 → クォータニオンへの変換
        this.transform.localRotation = rotation;
    }



}