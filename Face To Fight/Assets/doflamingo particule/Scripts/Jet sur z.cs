using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class key_control_particle : MonoBehaviour {
    // Use this for initialization
    public ParticleSystem light;
    void Start () {
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetKey(KeyCode.UpArrow) || Input.GetKey(KeyCode.Z))
        {
            light.Play();
        }
        else { light.Stop(); }
        
    }
}
