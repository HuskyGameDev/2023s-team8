using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class UnderwaterTilePuzzle : MonoBehaviour
{
    private Vector3 cameraPosition;
    // Start is called before the first frame update
    private void Start()
    {
        //gets the bottom left of the camera position and sendss it to the grid
        cameraPosition = Camera.main.ScreenToWorldPoint(new Vector3(0,0,0));
        //create a x by y grid with a float cell size at the bottom left of the camera
        Grid grid = new Grid(4, 2, 1f, cameraPosition);
    }
}
