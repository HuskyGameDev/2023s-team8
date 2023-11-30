using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class Light_Finish : MonoBehaviour
{
    //List of all the lights
    public List<Light_Controller> lights = new List<Light_Controller>();

    //Bool for if all the lights are green
    bool finished;

    // Start is called before the first frame update
    void Start()
    {
        finished = false;
    }

    // Update is called once per frame
    void Update()
    {
        foreach (Light_Controller light in lights) { 
            if (light.on == true)
            {
                finished = true;
            }
            
            if (light.on == false)
            {
                finished = false;
                break;
            }
        }

        if (finished)
        {
            Invoke("EndLevel", 3f);
        }
    }

    //Ends the level
    public void EndLevel()
    {
        SceneManager.LoadScene("MainMenuScene");
    }
}
