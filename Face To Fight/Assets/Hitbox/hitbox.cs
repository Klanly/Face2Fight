using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using System.Threading;


public class hitbox : MonoBehaviour
{
    public string collision;
    void Start()
    {
        collision = "";
    }

    void Update()
    {
    }
    public void resetcollision()
    {
        collision = "";
    }
    void OnParticleCollision(GameObject other)
    {
        if (other.tag == "Bullet")
            collision = "Bullet";
        if (other.tag == "Ray")
            collision = "Ray";
        else
            collision = "";
    }
    private void OnCollisionEnter(Collision other)
    {
        if (other.gameObject.tag == "Player")
            collision = "Player";
    }
    public string getcollision()
    {
        return collision;
    }
    
}
