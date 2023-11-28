using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class MazeMovement : MonoBehaviour
{
    //GameManager to end the level in the correct way
    public GameManager gameManager;

    //Speed of the player movement
    private float speed = 10f;

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
            }
            if (Input.GetKey(KeyCode.A))
            {
                left = -speed;
            }
            if (Input.GetKey(KeyCode.S))
            {
                down = -speed;
            }
            if (Input.GetKey(KeyCode.D))
            {
                right = speed;
            }
            if (Input.GetKeyUp(KeyCode.W))
            {
                up = 0f;
            }
            if (Input.GetKeyUp(KeyCode.A))
            {
                left = 0f;
            }
            if (Input.GetKeyUp(KeyCode.S))
            {
                down = 0f;
            }
            if (Input.GetKeyUp(KeyCode.D))
            {
                right = 0f;
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
        if (collision.gameObject.tag == "Finish")
        {
            finished = true;
            
            //sets the player position to the center of the finish just to make it look slightly better
            rig.constraints = RigidbodyConstraints2D.FreezeAll;
            rig.position = new Vector2(26.25f, 16.74f);
        }
    }

    //Will end the level in the proper way
    public void EndLevel()
    {
        //Will either use gameManager if the level is treated like a primary level
        //or will just go to level select if the level is treated like a secondary level
        //gameManager.pogressMade(2);
    }

    //Used right now for the finish until secondary levels decided
    public void ReloadScene()
    {
        SceneManager.LoadScene(SceneManager.GetActiveScene().name);
    }
}
