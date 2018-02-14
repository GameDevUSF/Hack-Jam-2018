using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BallGenerate : MonoBehaviour
{

    public GameObject Ball;
    GameObject player;
    float InnerCounter;
    Vector3 throw_dir;

    public GameObject spawnPoint;

    public float force;
    public float innerWait;


    // Use this for initialization
    void Start ()
    {
        player = GameObject.FindGameObjectWithTag("Player");
        throw_dir = player.transform.position - Ball.transform.position;
    }
	
	// Update is called once per frame
	void Update ()
    {
        InnerCounter += Time.deltaTime;

        if (InnerCounter > innerWait)
        {
            genBall(force);
        }
    }

    private void genBall(float force)
    {
        GameObject newBall = Instantiate(Ball, Random.insideUnitSphere * 10 + spawnPoint.transform.position, Random.rotation);
        newBall.GetComponent<Rigidbody>().AddForce(throw_dir * Random.Range(force - 10, force + 10));
        InnerCounter = 0;
    }

}
