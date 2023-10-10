using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

//there will be a submit button and this will go to that to check the weights when submit is pressed

public class WeightSubmit : MonoBehaviour
{
    //Total weight based on what rocks are selected
    [SerializeField] int total;
    //Array of all rocks for easy access
    [SerializeField] RockWeights[] rocks;

    // Start is called before the first frame update
    void Start()
    {
        total = 0;
    }

    // Update is called once per frame
    void Update()
    {

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
            }
        }

        //End level accordingly, possible animations depending on state
        if(total == 7)
        {
            //level will end succesfully
            Debug.Log("Correct weight");
            Invoke("LoadLevelSelect", 3f);
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
        //For now will just reset total for testing
        total = 0;
    }

    public void LoadLevelSelect()
    {
        SceneManager.LoadScene("Level Select");
    }

    public void ReloadScene()
    {
        SceneManager.LoadScene(SceneManager.GetActiveScene().name);
    }
}
