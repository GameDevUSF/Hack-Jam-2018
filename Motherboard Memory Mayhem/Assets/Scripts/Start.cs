using UnityEngine;
using UnityEngine.SceneManagement;

public class Start : MonoBehaviour
{
    public void NextScene()
    {
        SceneManager.LoadScene("First_Level", LoadSceneMode.Single);
    }
}
