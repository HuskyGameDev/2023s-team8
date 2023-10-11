using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

/**
 * When the submit button is pressed, the selected weight will be checked and the scene will be reloaded if incorrect or go to the level select scene if correct
 */
public class WeightSubmit : MonoBehaviour
{
    //GameManager for moving to next level
    public GameManager gameManager;

    //Total weight based on what rocks are selected
    [SerializeField] int total;

    //Array of all rocks weight script for easy access
    [SerializeField] RockWeights[] rocks;

    //Rock detection to know when to start animation
    private RockCollisionDetection rockCollision;

    //Array of the actual game object for animation purposes, first 3 are the rocks, 4th is the log, 5th is the character
    [SerializeField] GameObject[] objects;

    //Will eventually be more waypoints that represent the different launches from the rocks
    [SerializeField] GameObject waypoint;

    //False if submit button was not pressed, true if it has been pressed, used only for the animation purposes in update method
    bool submitted = false;

    //False if the log has not been rotated, true if it has, only so that once it has been rotated, it wont continue to rotate
    bool rotated = false;

    // Start is called before the first frame update
    void Start()
    {
        total = 0;
        rockCollision = objects[3].GetComponent<RockCollisionDetection>();
    }

    // Update is called once per frame, just do animation in update, rest keep in onClick
    void Update()
    {
        if (submitted == true) {
            //probably detect colision here
            if (rockCollision.isColliding == true)
            {
                if (rotated == false)
                {
                    objects[3].transform.Rotate(0, 0, -16);
                    rotated = true;
                }

                if (total == 7)
                {
                    //not correct but will be similar
                    objects[4].transform.position = Vector3.MoveTowards(objects[4].transform.position, waypoint.transform.position, 40f * Time.deltaTime);
                }
                else if (total < 7)
                {
                    //not correct but will be similar
                    objects[4].transform.position = Vector3.MoveTowards(objects[4].transform.position, waypoint.transform.position, 40f * Time.deltaTime);
                }
                else
                {
                    //Moves character to mimic catapult look
                    objects[4].transform.position = Vector3.MoveTowards(objects[4].transform.position, waypoint.transform.position, 40f * Time.deltaTime);
                }
            }
        }
    }

    //When submit button is pressed, total weight is calculated and determines if level is passed or not
    public void OnClick()
    {
        //Loop calculates total weight
        for (int i = 0; i < rocks.Length; i++)
        {
            if (rocks[i].selected == true)
            {
                total = total + rocks[i].weight;
                objects[i].GetComponent<Rigidbody2D>().gravityScale = 1;
            }
        }

        submitted = true;

        //End level accordingly, possible animations depending on state
        if(total == 7)
        {
            //level will end succesfully
            //animation will be character going off screen then coming back onto screen and hitting tree
            Debug.Log("Correct weight");
            //Invoke("LoadLevelSelect", 3f);
            gameManager.pogressMade(1);
            
            
        } else if(total < 7)
        {
            //level ends with not enough weight
            Debug.Log("Not enough weight");
            Invoke("ReloadScene", 3f);

        } else 
        {
            //level ends with too much weight
            Debug.Log("Too much weight");
            Invoke("ReloadScene", 3f);
        }
    }

    //The following 2 methods were created just so Invoke could be called on them with a time delay

    //Loads the level select scene
    public void LoadLevelSelect()
    {
        SceneManager.LoadScene("Level Select");
        //could add progress made method here to still be able to have few secs before switch
    }

    //Reloads the current scene
    public void ReloadScene()
    {
        SceneManager.LoadScene(SceneManager.GetActiveScene().name);
    }
}
