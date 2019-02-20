using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SelectionPlayer : MonoBehaviour {

    public string Name;
    private Vector3 newpos;
    public GameObject image3D;
	// Use this for initialization
	void Start () {
        newpos = transform.position + new Vector3(-0.01F, 0, 0);
	}

    private void OnMouseEnter()
    {
        if(global.cursor != null)
        {
            global.cursor.transform.position = newpos;
            global.cursor.SetActive(true);
            image3D.SetActive(true);
            global.nametext.text = "Selection : " + this.name + "!";
        }
    }
    private void OnMouseExit()
    {
        if(global.cursor != null)
        {
            global.cursor.SetActive(false);
            image3D.SetActive(false);
        }
    }
    private void OnMouseDown()
    {
        global.CurrentPlayer = Name;
        Attributes.scar = Name;
        if(global.selection != null)
        {
            global.selection.transform.position = newpos;
            global.selection.SetActive(true);
            global.nametext.color = Color.cyan;
        }
    }
}
