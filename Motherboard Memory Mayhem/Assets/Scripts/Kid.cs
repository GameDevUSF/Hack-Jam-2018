using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Kid : MonoBehaviour
{
    GameObject TimeMan;
    TimeMan levelManager;

    // Use this for initialization
    void Start ()
    {
        TimeMan = GameObject.FindGameObjectWithTag("GameController");
        levelManager = TimeMan.GetComponent<TimeMan>();
    }
	
	// Update is called once per frame
	void Update ()
    {
        if (gameObject.transform.position.y < -5)
        {
            destroyObject();
        }


    }

    void OnCollisionEnter(Collision col)
    {
        if (col.gameObject.tag == "Ball")
        {
            Vector3 dir = col.contacts[0].point - transform.position;
            dir = -dir.normalized;
            GetComponent<Rigidbody>().AddForce(dir * 2);

            destroyObject();

        }

    }

    private void destroyObject()
    {
        levelManager.children--;
        Destroy(gameObject);
    }
}
