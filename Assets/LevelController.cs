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
        foreach(Enemy enemy in enemies)
        {
            if(enemy != null)
            {
                return;
            }
        }



        SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex + 1);


    }

}
