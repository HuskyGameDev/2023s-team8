using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class GameManager : MonoBehaviour
{
    int NextLevelIndex = 2;
    // Start is called before the first frame update
    void Start()
    {
    }

    // Update is called once per frame
    void Update()
    {
        
    }
    public void pogressMade(){
        PlayerPrefs.SetInt("levelReached", NextLevelIndex);
        NextLevelIndex++;
        SceneManager.LoadScene("Level Select");
    }
}
