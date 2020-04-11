using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyDieScript : MonoBehaviour

{ 
    public void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject.tag == "Player")
        {
            Destroy(gameObject);
            transform.parent.GetComponent<EnemyScript>().CheckForDestroy();
            
        }
    }
}
