using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class tir : MonoBehaviour {
    public ParticleSystem p1;
    public ParticleSystem p2;
	// Use this for initialization
	void Start () {
        p1.Stop();
        p2.Stop();
	}
	
	// Update is called once per frame
	void Update () {
        if (!   Input.GetKey(KeyCode.Mouse0))
        {
            p1.Play();
            p2.Play();
        }
	}
}
