using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

/**
 * When the submit button is pressed, the selected weight will be checked and the scene will be reloaded if incorrect or go to the level select scene if correct
 * and play an animation accordingly
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

    //0 is the waypoint for too much, next 4 are for too little wieght, last one will be for correct weight
    [SerializeField] GameObject[] waypoints;

    //Int that represents the current index for the waypoints of the too little weight animation
    int tooLittleCurrent;

    //Int that represents the current index for the waypoints of the correct weight animation
    int correctCurrent;

    //False if submit button was not pressed, true if it has been pressed, used only for the animation purposes in update method
    bool submitted = false;

    //False if the log has not been rotated, true if it has, only so that once it has been rotated, it wont continue to rotate
    bool rotated = false;

    // Start is called before the first frame update
    void Start()
    {
        total = 0;
        tooLittleCurrent = 1;
        correctCurrent = 0;
        rockCollision = objects[3].GetComponent<RockCollisionDetection>();
    }

    // Update is called once per frame, just do animation in update, rest keep in onClick
    void Update()
    {
        if (submitted == true) {
            
            if (rockCollision.isColliding == true)
            {
                //So the log doesn't continue to rotate
                if (rotated == false)
                {
                    objects[3].transform.Rotate(0, 0, -16);
                    rotated = true;
                }

                //correct weight
                if (total == 7)
                {
                    //Changes waypoint as the character approaches it
                    if (Vector3.Distance(waypoints[correctCurrent].transform.position, objects[4].transform.position) < 1)
                    {
                        correctCurrent = 5;
                    }
                    objects[4].transform.position = Vector3.MoveTowards(objects[4].transform.position, waypoints[correctCurrent].transform.position, 35f * Time.deltaTime);
                }
                //too little weight
                else if (total < 7)
                {
                    //Changes waypoint as the character approaches it until the last one
                    if (Vector3.Distance(waypoints[tooLittleCurrent].transform.position, objects[4].transform.position) < 1)
                    {
                        if(tooLittleCurrent < 4)
                        {
                            tooLittleCurrent++;
                        }
                    }
                    objects[4].transform.position = Vector3.MoveTowards(objects[4].transform.position, waypoints[tooLittleCurrent].transform.position, 30f * Time.deltaTime);
                }
                //too much weight
                else
                {
                    objects[4].transform.position = Vector3.MoveTowards(objects[4].transform.position, waypoints[0].transform.position, 40f * Time.deltaTime);
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

        //End level accordingly
        if(total == 7)
        {
            Debug.Log("Correct weight");
            Invoke("EndLevel", 3f);
            
            
        } else if(total < 7)
        {
            Debug.Log("Not enough weight");
            Invoke("ReloadScene", 3f);

        } else 
        {
            Debug.Log("Too much weight");
            Invoke("ReloadScene", 3f);
        }
    }

    //The following 2 methods were created just so Invoke could be called on them with a time delay

    //Reloads the current scene
    public void ReloadScene()
    {
        SceneManager.LoadScene(SceneManager.GetActiveScene().name);
    }

    //Loads the level select screen and tracks that the level is done
    public void EndLevel()
    {
        gameManager.pogressMade(2, false);
    }
}
