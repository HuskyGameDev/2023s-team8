using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class PuzzleUI : MonoBehaviour
{
    public void BackPrimary(){
        SceneManager.LoadScene("Level Select");
    }
    public void BackSecondary()
    {
        SceneManager.LoadScene("Main Menu");
    }
}
