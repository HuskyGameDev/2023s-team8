using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class GameManager : MonoBehaviour
{
    // Start is called before the first frame update
    void Start()
    {
    }

    // Update is called once per frame
    void Update()
    {
        
    }
    //function will determine if he level has been finished
    public void pogressMade(int finishedLevel){
        //if the finished level is the same as the one the player has reached, increase the level reached by 1
        if(finishedLevel == PlayerPrefs.GetInt("levelReached", 1)){
            PlayerPrefs.SetInt("levelReached", finishedLevel + 1);
        }
        SceneManager.LoadScene("Level Select");
    }
}
