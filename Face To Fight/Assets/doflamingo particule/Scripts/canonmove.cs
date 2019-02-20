using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class canonmove : MonoBehaviour {
    float x = 0;
    float y = 0;
    public GameObject canon1;
    public GameObject canon2;

    // Use this for initialization
    void Start () {
		
	}
	
	// Update is called once per frame
	void Update () {
        x = cameramove.y + 180;
        y = -cameramove.x;
        canon1.transform.eulerAngles = new Vector3(y, x, 0);
        canon2.transform.eulerAngles = new Vector3(y, x, 0);
    }
}
