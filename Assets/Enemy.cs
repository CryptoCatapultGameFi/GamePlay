using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Enemy : MonoBehaviour
{
    public GameObject EnemyParticles;
    

    private void OnCollisionEnter2D(Collision2D collision)
    {

        bool hasCollidedWithBird = collision.collider.GetComponent<birdie>() != null;

        if(hasCollidedWithBird == true)
        {
            enemyDie();
            
        }

        if(collision.collider.GetComponent<Enemy>() != null)
        {
            return;
        }

        bool hasCollidedWithCrate = collision.collider.GetComponent<Crate>() != null;
        if(hasCollidedWithCrate == true)
        {
            enemyDie();
            

        }

        void enemyDie()
        {
           
            Destroy(gameObject);
            Instantiate(EnemyParticles, transform.position, Quaternion.identity);
            return;
            
        }
    }
}

