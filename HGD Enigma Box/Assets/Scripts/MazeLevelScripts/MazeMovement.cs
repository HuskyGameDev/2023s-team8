using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class MazeMovement : MonoBehaviour
{
    //GameManager to end the level in the correct way
    public GameManager gameManager;

    //Speed of the player movement
    private float speed = 5f;

    //Used for movement of the player
    Rigidbody2D rig;

    //Boolean for if the player has reached the end to stop movement.
    bool finished = false;

    // Start is called before the first frame update
    void Start()
    {
        rig = GetComponent<Rigidbody2D>();
    }

    // Update is called once per frame
    void Update()
    {
        //Changes to speed value if their corresponding key is pressed
        float left = 0f;
        float right = 0f;
        float up = 0f;
        float down = 0f;
        if (!finished)
        {
            if (Input.GetKey(KeyCode.W))
            {
                up = speed;
                //Debug.Log("W pressed");
            }
            if (Input.GetKey(KeyCode.A))
            {
                left = -speed;
                //Debug.Log("A pressed");
            }
            if (Input.GetKey(KeyCode.S))
            {
                down = -speed;
                //Debug.Log("S pressed");
            }
            if (Input.GetKey(KeyCode.D))
            {
                right = speed;
                //Debug.Log("D pressed");
            }
            if (Input.GetKeyUp(KeyCode.W))
            {
                up = 0f;
                //Debug.Log("W released");
            }
            if (Input.GetKeyUp(KeyCode.A))
            {
                left = 0f;
                //Debug.Log("A released");
            }
            if (Input.GetKeyUp(KeyCode.S))
            {
                down = 0f;
                //Debug.Log("S released");
            }
            if (Input.GetKeyUp(KeyCode.D))
            {
                right = 0f;
                //Debug.Log("D released");
            }
            rig.velocity = new Vector2(left + right, up + down);
        }
        if (finished) 
        {
            //Will be changed once know what value to use in end level
            Invoke("ReloadScene", 3f);
        }
    }

    //For detection of player hitting walls
    private void OnCollisionEnter2D(Collision2D collision)
    {
        //To check when player reaches end
        //if end has collider then player cannot go through it
        if (collision.gameObject.tag == "Finish")
        {
            finished = true;
            //Debug.Log("Reached finish!");
            //sets the player position to the center of the finish just to make it look slightly better
            rig.constraints = RigidbodyConstraints2D.FreezeAll;
            rig.position = new Vector2(26.25f, 16.74f);
        }
    }

    public void EndLevel()
    {
        //gameManager.pogressMade(2);
    }

    public void ReloadScene()
    {
        SceneManager.LoadScene(SceneManager.GetActiveScene().name);
    }
}
