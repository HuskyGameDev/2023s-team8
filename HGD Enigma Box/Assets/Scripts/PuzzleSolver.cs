using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PuzzleSolver : MonoBehaviour {
    public GameManager gameManager;
    public int currLevel;
    // Start is called before the first frame update
    void Start() { }

    // Update is called once per frame
    void Update() { }
    //function is called by the finished button on each level, will pass in the level that was finished
    public void finished(){
        gameManager.pogressMade(currLevel);
    }
}