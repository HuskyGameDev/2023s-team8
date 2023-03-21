using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class RocketPuzzle : MonoBehaviour
{
    //allows user to go back
    public void Back(){
        SceneManager.LoadScene("Level Select");
    }
    // Update is called once per frame
    void Update()
    {
        
    }
}
