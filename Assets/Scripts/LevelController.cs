using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class LevelController : MonoBehaviour
{

    Enemy[] enemies;
    private void OnEnable()
    {
        enemies = FindObjectsOfType<Enemy>();

    }

    private void Update()
    {
        foreach (Enemy enemy in enemies)
        {
            if (enemy != null)
            {
                return;
            }
        }


        if (SceneManager.GetActiveScene().buildIndex < 2)
        {
            SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex + 1);
        }
        else
        {
            // Application.Quit();
            // Application.OpenURL("https://www.google.co.th/?hl=th");
            SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex + 1);
        }



    }

}
