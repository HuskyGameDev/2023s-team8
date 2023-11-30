using System.Collections;
using System.Collections.Generic;
using UnityEditor;
using UnityEditor.SearchService;
using UnityEngine;
using UnityEngine.SceneManagement;

public class GoalObject : MonoBehaviour
{

    private bool isCovered = true;

    public SceneAsset scene;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    void OnCollisionEnter2D(Collision2D collision)
    {
        isCovered = true;
    }

    void OnCollisionExit2D(Collision2D collision)
    {
        isCovered = false;
    }

    void OnMouseDown()
    {
        if (!isCovered)
        {
            SceneManager.LoadScene(scene.name);
        }
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
