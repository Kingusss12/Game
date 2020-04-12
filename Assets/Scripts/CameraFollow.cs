using System.Collections;
using System.Collections.Generic;
using UnityEngine;


/*
 This script manages Camera to follow the movement of the player
     */

public class CameraFollow : MonoBehaviour
{
    [SerializeField]
    GameObject player;
    
    float timeOffset = 0.125f;

    private Vector3 velocity;

    // Update is called once per frame
    void FixedUpdate()
    {
        //cameras start position
        Vector3 cameraPosition = transform.position;
        //players current position
        Vector3 playerPosition = player.transform.position;
        playerPosition.x += 5f;
        playerPosition.y += 3f;
        playerPosition.z = -10;


        transform.position = Vector3.SmoothDamp(cameraPosition, playerPosition, ref velocity, timeOffset);

        
    }
}
