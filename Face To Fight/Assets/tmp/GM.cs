using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class GM : MonoBehaviour {
    public Toggle fullscreen;
    public GameObject image;
    public GameObject optionMenu;
    public GameObject network;
    // Use this for initialization
    void Start () {
        optionMenu.SetActive(false);
        DontDestroyOnLoad(gameObject);
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetKeyDown(KeyCode.Escape) && optionMenu.GetActive())
        {
            image.SetActive(false);
            optionMenu.SetActive(false);
        }
        else if (Input.GetKeyDown(KeyCode.Escape))
        {
            image.SetActive(true);
            optionMenu.SetActive(true);
        }
    }

    public void OnFullscreen()
    {
        Screen.fullScreen = fullscreen.isOn;

    }

    public void BackButton()
    {
        optionMenu.SetActive(false);
        image.SetActive(false);
        //UnityEditor.PrefabUtility.ResetToPrefabState(network);
        SceneManager.LoadScene("SceneArena2");
    }

}
