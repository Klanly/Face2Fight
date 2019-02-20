using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class global : MonoBehaviour {

    public static string CurrentPlayer = "burner scripté";
    public static GameObject cursor;
    public static GameObject selection;
    public static Text nametext;

    private void Awake()
    {
        cursor = GameObject.Find("Cursor");
        selection = GameObject.Find("Selection");
        nametext = GameObject.Find("Textname").GetComponent<Text>();
    }
}
