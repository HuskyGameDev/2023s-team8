using System.Collections;
using System.Collections.Generic;
using UnityEngine;

/**
 * Just determines if the rocks have hit the log in order to start the animation at the right time
 */
public class RockCollisionDetection : MonoBehaviour
{
    //True if the rock(s) have hit the log
    public bool isColliding = false;

    //Detects when the rocks hit the log so the animation can start
    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (isColliding == false)
        {
            Debug.Log("rock has hit log");
            isColliding = true;
        }
    }
}
