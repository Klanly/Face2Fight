using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class viseur : MonoBehaviour {
    public Texture vis;
    Rect rect;
	// Use this for initialization
	void Start () {
        float size = Screen.width * 0.06f;
        rect = new Rect(Screen.width / 2 - size / 2, Screen.height / 2 - (size-20) / 2, size, size);
	}
	
	// Update is called once per frame
	void OnGUI () {
        GUI.DrawTexture(rect, vis);
	}
}
