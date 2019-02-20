using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class ManagerScript : MonoBehaviour {

    //public Text txtStatus;
    public List<Transform> SpawnPoints;
    public GameObject car1;
    public GameObject car2;

    // Use this for initialization
    void Start () {
        PhotonNetwork.ConnectUsingSettings("1.0.0");
	}
	
    void OnJoinedLobby() {
        RoomOptions roomOptions = new RoomOptions();
        roomOptions.MaxPlayers = 2;
        PhotonNetwork.JoinOrCreateRoom(Attributes.room, roomOptions, TypedLobby.Default);
    }

    void OnJoinedRoom () {
        //Debug.Log(car2.name);
        //PhotonNetwork.Instantiate(car2.name, SpawnPoints[0].position, Quaternion.identity, 0);
        GameObject car;

        if (PhotonNetwork.room.PlayerCount == 1)
        {
            Attributes.team = "red";
            car = PhotonNetwork.Instantiate(Attributes.scar, SpawnPoints[0].position, Quaternion.identity, 0);
        }
        else
        {
            Attributes.team = "blue";
            car = PhotonNetwork.Instantiate(Attributes.scar, SpawnPoints[1].position, Quaternion.identity, 0);
        }
        car.name = Attributes.team;

    }

	// Update is called once per frame
	void Update () {
        if (PhotonNetwork.connectionStateDetailed != ClientState.Joined)
            Attributes.status = "Room: " + Attributes.room + " | Status: " + PhotonNetwork.connectionStateDetailed.ToString();
        else
            Attributes.status = "Room: " + Attributes.room + " | Status: Connected | Player(s) online:" + PhotonNetwork.room.PlayerCount;
        try
        {
            GameObject car = GameObject.Find("Velyxor scripté(Clone)");
            car.name = Attributes.team == "red" ? "blue" : "red";
        }
        catch (System.Exception)
        {
        }
        try
        {
            GameObject car = GameObject.Find("burner scripté(Clone)");
            car.name = Attributes.team == "red" ? "blue" : "red";
        }
        catch (System.Exception)
        {
        }
    }
}
