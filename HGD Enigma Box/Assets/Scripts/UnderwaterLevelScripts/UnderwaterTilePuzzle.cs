using System.Collections;
using System.Collections.Generic;
using UnityEngine;
    /*Whenever the player hits a direction, check if the place they are trying to go 
        * exists, then check to see if it's an obstacle (value = 1), an open space (value = 0)
        * a bubble square(value = 2), or the finish, (value = 3).
        * 
        * if the space is open, go to that spot, add it to the previously travelled
        * list, and remove one from distance left. if the space is an obstacle, deny access
        * and do pretty much nothing except play a noise. if it's a bubble square, still remove
        * one from distance left for traveling, but add five to distance left afterward. If the 
        * finish is reached, finish the level
        *
        * The previously travelled list should be a 2D array of the x and y values that we just
        * travelled across so that the player can hit the undo button to go back and get
        * their distance travelled back. Pretty much will work similarly to above but adding
        * 1 distance back and removing 5 if it's a bubble square
    */
public class UnderwaterTilePuzzle : MonoBehaviour
{
    //these are just sizes I decided on
    private int width = 14;
    private int height = 7;
    private float cellSize = 1f;
    private Vector3 gridPosition;

    private int currentXTile = 0;
    private int currentYTile = 0;

    private Grid grid;
    // Start is called before the first frame update
    void Start()
    {
        /*The camera starts at the bottom left of the screen, so get an eighth of the screen size
        * in order to position the bottom left of the grid an eighth of the screen size right and up
        */
        gridPosition = Camera.main.ScreenToWorldPoint(new Vector3(Screen.width/8,Screen.height/8,0));
        //create a width by height grid with a float cell size at position defined above
        grid = new Grid(width, height, cellSize, gridPosition);
    }
    void Update(){
    }
}
