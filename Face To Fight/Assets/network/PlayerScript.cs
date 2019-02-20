using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerScript : Photon.MonoBehaviour {

    PhotonView view;
    public GameObject camera;

	// Use this for initialization
	void Start () {
        view = GetComponent<PhotonView>();
        if (view.isMine)
            camera.SetActive(true);

    }
	
	// Update is called once per frame
	void Update () {
		
	}
}
