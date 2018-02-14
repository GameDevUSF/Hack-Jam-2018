using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class KidGenerate : MonoBehaviour
{

    public GameObject kid;
    public GameObject spawnPoint;
    public int area;
    public int children;

    // Use this for initialization
    void Start ()
    {
        for (int i = 0; i < children; i++)
        {
            genKid();
        }
    }
	
	// Update is called once per frame
	void Update ()
    {

    }

    private void genKid()
    {
        GameObject newBall = Instantiate(kid, spawnPoint.transform.position + GeneratedPositionLength(-area, area), Quaternion.identity);
    }

    private Vector3 GeneratedPositionSquare(int min, int max)
    {
        int x, y, z;
        x = Random.Range(min, max);
        y = Random.Range(min, max);
        z = Random.Range(min, max);
        return new Vector3(x, y, z);
    }

    private Vector3 GeneratedPositionLength(int min, int max)
    {
        int x, y, z;
        x = Random.Range(min, max);
        //y = Random.Range(min, max);
        z = Random.Range(min, max);
        return new Vector3(x, 1, z);
    }
}
