using System.Collections;
using UnityEngine;
using UnityEngine.SceneManagement;

public class SplashSequence : MonoBehaviour
{
    public static int sceneNumber = 0;

    // Start is called before the first frame update
    void Start()
    {
        if (sceneNumber == 0)
        {
            StartCoroutine(ToMainMenu());
        }
    }

    IEnumerator ToMainMenu()
    {
        yield return new WaitForSeconds(3f);
        SceneManager.LoadScene("MainMenu");
    }
}
