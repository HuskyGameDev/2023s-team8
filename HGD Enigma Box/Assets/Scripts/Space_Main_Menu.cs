using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
public class Space_Main_Menu : MonoBehaviour
{
    public void PlayGame ()

    {
     SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex + 1);

    }
    public void QuitGame ()
    {
        Debug.Log("QUIT");
        Application.Quit();
    }

public void SetVolume (float  volume)
{
    Debug.Log (volume);
}
}
