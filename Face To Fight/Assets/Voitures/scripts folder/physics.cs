using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class physics : Photon.MonoBehaviour {
    public Text StatusText;
    public Text SpeedText;
    public float Torque;
    public float speed;
    public float maxspeed;
    public int Brake;
    public float Acceleration;
    public float minangle; //wheel direction
    public float maxangle; //wheel direction
    private bool freinage = false;
    public GameObject backlight;
    public GameObject regresslight;

    //for the masscenter
    public Transform Masscenter;
    private Rigidbody RGbody;

    //wheel colliders
    public WheelCollider[] wheelcolliders = new WheelCollider[4];
    public Transform[] roues = new Transform[4];


    private void Start()
    {
        RGbody = GetComponent<Rigidbody>();
        RGbody.centerOfMass = Masscenter.localPosition;
    }
    public void stopspeed()
    {
        for (int i = 0; i < 4; i++)
        {
            wheelcolliders[i].motorTorque = 0;
            wheelcolliders[i].brakeTorque = Mathf.Infinity;

        }
    }

    private void UpdateMeshesPositions()
    {
        for (int i = 0; i < 4; i++)
        {
            Quaternion quat;
            Vector3 pos;
            wheelcolliders[i].GetWorldPose(out pos, out quat);
            roues[i].position = pos;
            roues[i].rotation = quat;
        }
    }
    private void FixedUpdate()
    {
        StatusText.text = Attributes.status;
        //Affichage de la vitesse
        speed = GetComponent<Rigidbody>().velocity.magnitude * 3.6f;
        SpeedText.text = "Speed : " + (int)speed + " KM/H";
        //directory
        float angle = (minangle - maxangle) * speed / maxspeed + maxangle;
        wheelcolliders[0].steerAngle = Input.GetAxis("Horizontal") * angle;
        wheelcolliders[1].steerAngle = Input.GetAxis("Horizontal") * angle;
        //acceleration
        if (!freinage && Input.GetKey(KeyCode.Z) && speed < maxspeed)
        {
            for (int i = 2; i < 4; i++)
            {
                wheelcolliders[i].brakeTorque = 0;
                wheelcolliders[i-2].brakeTorque = 0; //enlever le brake des autres roues
                wheelcolliders[i].motorTorque = -Input.GetAxis("Vertical") * Torque * Acceleration * Time.deltaTime;
            }
        }
        //deceleration
        else
        {
                for (int i = 0; i < 4; i++)
                {
                    wheelcolliders[i].motorTorque = 0;
                    wheelcolliders[i].brakeTorque = Brake * Acceleration * Time.deltaTime;
                }

        }
        //freinage
        if (Input.GetKey(KeyCode.Space))
        {
            freinage = true;
            for (int i = 0; i < 4; i++)
            {
                wheelcolliders[i].motorTorque = 0;
                wheelcolliders[i].brakeTorque = Mathf.Infinity;
            }
            backlight.SetActive(true);
        }
        else
        {
            freinage = false;
            backlight.SetActive(false);
        }
        //son du moteur
        float Pitch = speed / maxspeed * 3 + 1;
        GetComponent<AudioSource>().pitch = Mathf.Clamp(Pitch, 1f, 3f);
        //marche arrière
        if (Input.GetKey(KeyCode.S)&& !freinage)
        {
            for (int i = 2; i < 4; i++)
            {
                wheelcolliders[i].brakeTorque = 0;
                wheelcolliders[i - 2].brakeTorque = 0;
                wheelcolliders[i].motorTorque = -Input.GetAxis("Vertical") * Torque * Acceleration * Time.deltaTime;
            }
            regresslight.SetActive(true);
        }
        else
        {
            regresslight.SetActive(false);
        }


    }


    private void Update()
    {
        UpdateMeshesPositions(); //visual rotation of the meshes
    }

}
