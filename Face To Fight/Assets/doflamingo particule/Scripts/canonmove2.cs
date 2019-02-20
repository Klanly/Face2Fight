using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class canonmove2 : MonoBehaviour {
    float x = 0;
    float y = 0;
    public GameObject canon;
    // Use this for initialization
    void Start () {
		
	}
	
	// Update is called once per frame
	void Update () {
        x = cameramove.y ;
        y = cameramove.x -90;
        canon.transform.eulerAngles = new Vector3(y, x, 0);
	}
}
