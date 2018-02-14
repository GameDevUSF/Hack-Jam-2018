using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;


public class TimeMan : MonoBehaviour
{
    private BallGenerate ballGenScript;
    private KidGenerate kidGenScript;

    float timer;
    float originalTime = 20f;
    float increment = 15f;

    int wave;
    int level;

    public Text levelText;
    public Text waveText;
    public Text numOfChildren;
    public Image childDeathText;
    public Image fallDeathText;
    public Image winRound;

    private GameObject player;

    public int children;

    bool alive;

    // Use this for initialization
    void Start()
    {
        ballGenScript = gameObject.GetComponent<BallGenerate>();
        kidGenScript = gameObject.GetComponent<KidGenerate>();

        player = GameObject.FindGameObjectWithTag("Player");

        childDeathText.gameObject.SetActive(false);
        fallDeathText.gameObject.SetActive(false);
        winRound.gameObject.SetActive(false);

        if (SceneManager.GetActiveScene().name == "First_Level")
        {
            level = 1;
        }
        if (SceneManager.GetActiveScene().name == "Second_Level")
        {
            level = 2;
        }

        wave = 1;
    }

    // Update is called once per frame
    void Update()
    {
        timer += Time.deltaTime;

        levelText.text = "Level: " + level;
        waveText.text = "Wave: " + wave;
        numOfChildren.text = "Number of Children: " + children;

        if (children == 0)
        {
            childDeathText.gameObject.SetActive(true);
            StartCoroutine(loadPreviousScene());
        }

        if (player.transform.position.y < -5)
        {
            fallDeathText.gameObject.SetActive(true);
            StartCoroutine(loadNextScene());
        }

        if (timer < originalTime)
        {
            wave = 1;
            ballGenScript.innerWait = 10f;
            ballGenScript.force = 50f;
        }

        if (timer > originalTime && timer < originalTime + increment)
        {
            wave = 2;
            ballGenScript.innerWait = 8f;
            ballGenScript.force = 60f;
        }

        if (timer > originalTime + increment && timer < originalTime + 2 * increment)
        {
            wave = 3;
            ballGenScript.innerWait = 6f;
            ballGenScript.force = 70f;
        }

        if (timer > originalTime + 2 * increment && timer < originalTime + 3 * increment)
        {
            wave = 4;
            ballGenScript.innerWait = 4f;
            ballGenScript.force = 80f;
        }

        if (timer > originalTime + 3 * increment && timer < originalTime + 4 * increment)
        {
            wave = 5;
            ballGenScript.innerWait = 2f;
            ballGenScript.force = 90f;
        }

        if (timer > originalTime + 4 * increment && timer < originalTime + 5 * increment)
        {
            wave = 6;
            ballGenScript.innerWait = 1f;
            ballGenScript.force = 100f;
        }

        if (timer > originalTime + 5 * increment && timer < originalTime + 6 * increment)
        {
            wave = 7;
            ballGenScript.innerWait = 0.5f;
            ballGenScript.force = 110f;
        }

        if (timer > originalTime + 6 * increment && timer < originalTime + 7 * increment)
        {
            wave = 8;
            ballGenScript.innerWait = 0.25f;
            ballGenScript.force = 120f;
        }

        if (timer > originalTime + 7 * increment && timer < originalTime + 7 * increment + 4)
        {
            winRound.gameObject.SetActive(true);
        }

        if (timer > originalTime + 7 * increment + 4 && kidGenScript.children != 0)
        {
            StartCoroutine(loadNextScene());
        }
    }

    IEnumerator loadNextScene()
    {
        yield return new WaitForSeconds(5f);
        SceneManager.LoadScene("Second_Level", LoadSceneMode.Single);
    }

    IEnumerator loadPreviousScene()
    {
        yield return new WaitForSeconds(5f);
        SceneManager.LoadScene("Start", LoadSceneMode.Single);
    }
}
