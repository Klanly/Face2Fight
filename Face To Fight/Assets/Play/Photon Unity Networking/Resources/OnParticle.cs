using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class OnParticle : MonoBehaviour {

    private PhotonView view;

	void Start () {
        view = GetComponent<PhotonView>();
	}

    void Update()
    {
        if(Input.GetKeyDown(KeyCode.I))
            view.RPC("PUN_OnBoost", PhotonTargets.Others, Attributes.team);
        else if (Input.GetKeyUp(KeyCode.I))
            view.RPC("PUN_OffBoost", PhotonTargets.Others, Attributes.team);
    }

    public bool OnBoost()
    {
        try
        {
            view.RPC("PUN_OnBoost", PhotonTargets.Others, Attributes.team);
        }
        catch (System.Exception a)
        {
        }
        return true;
    }

    public bool OffBoost()
    {
        try
        {
            view.RPC("PUN_OffBoost", PhotonTargets.Others, Attributes.team);
        }
        catch (System.Exception a)
        {
        }
        return true;
    }

    public bool Scoring()
    {
        try
        {
            view.RPC("PUN_Scoring", PhotonTargets.Others, Attributes.team == "red" ? Attributes.bluescore : Attributes.redscore);
        }
        catch (System.Exception a)
        {
        }
        return true;
    }

    public bool OnActivate() {
        try
        {
            view.RPC("PUN_OnDeactivate", PhotonTargets.Others, Attributes.team, Attributes.scar);
        }
        catch (System.Exception a)
        {
        }
        return true;
    }

    public bool OnDeactivate() {
        try
        {
            view.RPC("PUN_OnActivate", PhotonTargets.Others, Attributes.team, Attributes.scar);
        }
        catch (System.Exception a)
        {
        }
        return true;
    }

    [PunRPC]
    void PUN_OnActivate(string team, string scar) {
        GameObject car = GameObject.Find(team);
        if (scar.Contains("burner")) {
            GameObject w1 = car.transform.Find("Mesh/canon/canon/decatline").gameObject;
            GameObject w2 = car.transform.Find("Mesh/canon/canon2/decatline").gameObject;
            w1.SetActiveRecursively(true);
            w2.SetActiveRecursively(true);
        } else {
            GameObject w = car.transform.Find("Mesh/laser/weapon").gameObject;
            w.SetActiveRecursively(true);
        }
    }

    [PunRPC]
    void PUN_OnDeactivate(string team, string scar) {
        GameObject car = GameObject.Find(team);
        if (scar.Contains("burner"))
        {
            GameObject w1 = car.transform.Find("Mesh/canon/canon/decatline").gameObject;
            GameObject w2 = car.transform.Find("Mesh/canon/canon2/decatline").gameObject;
            w1.SetActiveRecursively(false);
            w2.SetActiveRecursively(false);
        }
        else
        {
            GameObject w = car.transform.Find("Mesh/laser/weapon").gameObject;
            w.SetActiveRecursively(false);
        }
    }

    [PunRPC]
    void PUN_Scoring(int score)
    {
        if (Attributes.team == "red")
            Attributes.redscore = score;
        else
            Attributes.bluescore = score;
    }

    [PunRPC]
    void PUN_OnBoost(string team)
    {
        GameObject car = GameObject.Find(team);
        GameObject w = car.transform.Find("jet").gameObject;
        w.SetActiveRecursively(true);
    }

    [PunRPC]
    void PUN_OffBoost(string team)
    {
        GameObject car = GameObject.Find(team);
        GameObject w = car.transform.Find("jet").gameObject;
        w.SetActiveRecursively(false);
    }
}
