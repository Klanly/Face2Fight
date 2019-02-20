using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class GameManager : MonoBehaviour
{

    public static GameManager Instance { set; get; }
    public GameObject image;
    public GameObject mainMenu;
    public GameObject nicknameMenu;
    public GameObject joinMenu;
    public GameObject optionMenu;
    public GameObject selectMenu;
    public GameObject network;
    public GameObject audio_terrain;
    public GameObject audio_menu;
    public Text nameText;
    public Text loggedText;
    public Text room;
    public Toggle lava;
    public Toggle city;
    public Toggle fullscreen;
    public Camera camera;
    public Canvas canvas;
    private bool byother = false;

    void Start()
    {
        Instance = this;
        if (Attributes.nickname == "")
        {
            mainMenu.SetActive(false);
            joinMenu.SetActive(false);
            optionMenu.SetActive(false);
            selectMenu.SetActive(false);
            nicknameMenu.SetActive(true);
        } else {
            mainMenu.SetActive(true);
            joinMenu.SetActive(false);
            optionMenu.SetActive(false);
            selectMenu.SetActive(false);
            nicknameMenu.SetActive(false);
            loggedText.text = "Logged as : " + Attributes.nickname;
        }

        DontDestroyOnLoad(gameObject);
    }

    void Update()
    {
        if (Input.GetKeyDown(KeyCode.Escape) && optionMenu.GetActive())
            optionMenu.SetActive(false);
        else if(Input.GetKeyDown(KeyCode.Escape))
            optionMenu.SetActive(true);
    }

    public void OnFullscreen()
    {
        Screen.fullScreen = fullscreen.isOn;
    }

    public void OKButton()
    {
        if (loggedText.text != "")
        {
            Attributes.nickname = nameText.text;
            loggedText.text = "Logged as : " + Attributes.nickname;
            mainMenu.SetActive(true);
            nicknameMenu.SetActive(false);
        }
    }

    public void SoloButton()
    {
        


    }

    public void MultiButton()
    {
        mainMenu.SetActive(false);
        optionMenu.SetActive(false);
        joinMenu.SetActive(true);
    }

    public void OptionButton()
    {
        optionMenu.SetActive(true);
        mainMenu.SetActive(false);
        joinMenu.SetActive(false);
    }

    public void BackButton()
    {
        optionMenu.SetActive(false);
        mainMenu.SetActive(true);
        joinMenu.SetActive(false);
        image.SetActive(true);
        //UnityEditor.PrefabUtility.ResetToPrefabState(network);
        SceneManager.LoadScene("SceneArena2");
    }

    public void OnSelectLava()
    {
        if (byother)
            byother = false;
        else
        {
            byother = true;
            lava.isOn = true;
            city.isOn = false;
        }
    }

    public void OnSelectCity()
    {
        if (byother)
            byother = false;
        else
        {
            byother = true;
            lava.isOn = false;
            city.isOn = true;
        }
    }

    public void JoinButton()
    {
        Attributes.room = room.text;
        Attributes.map = city.isOn ? "SceneArena2" : "SceneArena";
        joinMenu.SetActive(false);
        selectMenu.SetActive(true);
    }

    public void PlayButton() {
        selectMenu.SetActive(false);
        image.SetActive(false);

        if (Attributes.map.Contains("2"))
        {
            network.SetActive(true);
            audio_menu.SetActive(false);
            audio_terrain.SetActive(true);
            //canvas.enabled = false;
            camera.enabled = false;
        }
        else
        {
            SceneManager.LoadScene("SceneArena");
        }
    }

    public void ExitButton()
    {
        Application.Quit();
    }
}
