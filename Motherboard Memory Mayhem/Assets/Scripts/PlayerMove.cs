using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerMove : MonoBehaviour
{

    public float speed;
    private bool isAlive;
    public float force = 20f;

    // Use this for initialization
    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {
        float h = Input.GetAxisRaw("Horizontal");
        float v = Input.GetAxisRaw("Vertical");

        transform.position += transform.forward * speed * h * Time.deltaTime;
        transform.position += transform.right * speed * -v * Time.deltaTime;

        if (gameObject.transform.position.y < -5)
        {
            Destroy(gameObject, 2f);
        }
    }

}