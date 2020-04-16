using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyDieScript : MonoBehaviour

{ 
    public void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject.tag == "Player")
        {
            Debug.Log("Erintette a játékos a felso collidert");
            AudioManager.playBugSplash();
            Destroy(gameObject);
            transform.parent.GetComponent<EnemyScript>().CheckForDestroy();
            
        }
    }
}
