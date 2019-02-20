using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class cameramove : MonoBehaviour {
    public Camera cam;
    //public TextMesh text;
    public float horizontalSpeed = 10;
    public float verticalSpeed = 10;
    public static float x = 0;
    public static float y = 0;

	// Use this for initialization
	void Start () {

	}

    // Update is called once per frame
    void Update()
    {

            y += horizontalSpeed * Input.GetAxis("Mouse X");
            x += -verticalSpeed * Input.GetAxis("Mouse Y");
            if (x >40)
                x = 40;
            if (x < -60)
                x = -60;
            if (y >= 360 || y <= -360)
                y = 0;
            cam.transform.eulerAngles = new Vector3(x, y, 0);
            //text.text = "x =" + x + " y=" + y;
    }
}
