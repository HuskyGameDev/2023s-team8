using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;
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
    private bool checkNext;
    private int currentXTile = 0;
    private int currentYTile = 0;
    private int[] nextTile = new int[2];
    public GameManager manager;
    public GameObject obstacleObj;
    public GameObject bubbleObj;
    public int movesLeft = 10;

    private Grid grid;
    public GameObject player;
    public GameObject finish;
    public string textValue;
    public TMP_Text text;
    // Start is called before the first frame update
    void Start()
    {
        /*The camera starts at the bottom left of the screen, so get an eighth of the screen size
        * in order to position the bottom left of the grid an eighth of the screen size right and up
        */
        gridPosition = Camera.main.ScreenToWorldPoint(new Vector3(Screen.width / 8, Screen.height / 8, 0));
        //create a width by height grid with a float cell size at position defined above
        grid = new Grid(width, height, cellSize, gridPosition);
        //these set certain tiles to be obstacles or bubble tiles
        grid.setValue(7, 3, 1);
        grid.setValue(6, 3, 1);
        grid.setValue(7, 4, 1);
        grid.setValue(6, 4, 1);
        //bubble tile
        grid.setValue(0, 6, 2);
        grid.setValue(1, 6, 2);
        grid.setValue(width - 1, height - 1, 3);
        //put objects in places based on what values are set
        for (int i = 0; i < width; i++)
        {
            for (int j = 0; j < height; j++)
            {
                int action = grid.getValue(i, j);
                switch (action)
                {
                    case 0:
                        break;
                    case 1:
                        GameObject obstacle = Instantiate(obstacleObj);
                        obstacle.transform.position = grid.GetWorldPositionCenter(i, j);
                        break;
                    case 2:
                        GameObject bubble = Instantiate(bubbleObj);
                        bubble.transform.position = grid.GetWorldPositionCenter(i, j);
                        break;
                    case 3:

                    default: break;
                }
            }
        }
        player.transform.position = grid.GetWorldPositionCenter(0, 0);
        finish.transform.position = grid.GetWorldPositionCenter(width-1, height-1);
    }
        
    void Update(){
        //if the player releases any of the movement keys, check if they are in bounds
        //then move forwards
        if(Input.GetKeyUp("w")){
            if((currentYTile + 1) < height)
            {
                nextTile[0] = currentXTile;
                nextTile[1] = currentYTile + 1;
                checkNext = true;
            }
            else
            {
                checkNext = false;
            }
        }
        else if(Input.GetKeyUp("a")){
            if((currentXTile - 1) >= 0){
                nextTile[0] = currentXTile - 1;
                nextTile[1] = currentYTile;
                checkNext = true;
            }
            else
            {
                checkNext = false;
            }
        }
        else if(Input.GetKeyUp("s")){
  
            if((currentYTile - 1) >= 0)
            {
                nextTile[0] = currentXTile;
                nextTile[1] = currentYTile - 1;
                checkNext = true;
            }
            else
            {
                checkNext = false;
            }
        }
        else if(Input.GetKeyUp("d")){

            if ((currentXTile + 1) < width)
            {
                nextTile[0] = currentXTile + 1;
                nextTile[1] = currentYTile;
                checkNext = true;
            }
            else 
            {
                checkNext = false;
            }
        }
        //check what type of tile is the tile we are trying to move to is
        if (checkNext && movesLeft > 0)
        {
            //move the player model to the next tile depending on which key was hit
            int action = grid.getValue(nextTile[0], nextTile[1]);
            switch (action)
            {
                case 0:
                    //this is an empty tile and should just move the player forward
                    player.transform.position = grid.GetWorldPositionCenter(nextTile[0], nextTile[1]);
                    currentXTile = nextTile[0];
                    currentYTile = nextTile[1];
                    movesLeft = movesLeft - 1;
                    break;
                case 1:  
                    break;
                case 2:
                    //this tile will eventually give the player five extra distance
                    player.transform.position = grid.GetWorldPositionCenter(nextTile[0], nextTile[1]);
                    currentXTile = nextTile[0];
                    currentYTile = nextTile[1];
                    movesLeft = movesLeft - 1;
                    movesLeft = movesLeft + 5;
                    break;
                case 3:
                    //this tile is the finish and will finish the level for the player
                    manager.pogressMade(1);
                    break;
                default: break;
            }
        }
        checkNext = false;
        textValue = movesLeft.ToString();
        text.text = "Moves Left: " + textValue;
    }
}
