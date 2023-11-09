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
    //the bottom left corner of the grid is the position
    private Vector3 gridPosition;
    //this checks to see if the next tile exists
    private bool checkNext;
    //keep track of where the player is on the grid
    private int currentXTile = 0;
    private int currentYTile = 0;
    //used by my checker to keep track of the next tile that I'm going to check
    private int[] nextTile = new int[2];
    //seperate game objects that are able to hold their grid coordinate that I can delete them while the user is playing
    public GameManager manager;
    public GameObject obstacleObj;
    public GameObject bubbleObj;
    public int movesLeft = 10;
    private List<GridGameObject> onScreenObjects = new List<GridGameObject>();
    

    private Grid grid;
    public GameObject player;
    public GameObject finish;
    public string textValue;
    public TMP_Text text;
    GameObject findObjectToDestroy(int i, int j)
    {
        foreach (GridGameObject obj in onScreenObjects) {
            if (obj.gridPosition[0] == i && obj.gridPosition[1] == j) {
                onScreenObjects.Remove(obj);
                return obj.getGameObj();
            }
        }
        return null;
    }

    //This class is being made because I need to make a gameobject that I can store the 
    //current tile position in
    public class GridGameObject
    {
        private GameObject actualGameObject;
        public int[] gridPosition = new int[2];
        public GridGameObject(int x, int y, GameObject givenObj)
        {
            actualGameObject = givenObj;
            gridPosition[0] = x;
            gridPosition[1] = y;
        }
        public GameObject getGameObj()
        {
            return actualGameObject;
        }
        public void setPosition(int x, int y)
        {
            gridPosition[0] = x;
            gridPosition[1] = y;
        }
    }
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
        //bubble tiles
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
                        //create the underlying obstacle for the grid game object
                        GameObject obstacle = Instantiate(obstacleObj);
                        obstacle.transform.position = grid.GetWorldPositionCenter(i, j);
                        //I might use this to make it so that you can push obstacles
                        GridGameObject gridObstacle = new GridGameObject(i, j, obstacle);
                        onScreenObjects.Add(gridObstacle);
                        break;
                    case 2:
                        //create the underlying bubble for the grid game object
                        GameObject bubble = Instantiate(bubbleObj);
                        bubble.transform.position = grid.GetWorldPositionCenter(i, j);
                        //shove the new game object into this list to destroy them later
                        GridGameObject gridBubble = new GridGameObject(i, j, bubble);
                        onScreenObjects.Add(gridBubble);
                        break;
                    case 3:
                        //will spawn custom finish line later
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
                    //put the player at the next tile
                    player.transform.position = grid.GetWorldPositionCenter(nextTile[0], nextTile[1]);
                    //update where the player currently is
                    currentXTile = nextTile[0];
                    currentYTile = nextTile[1];
                    //make it so the tile doesn't give moves anymore
                    grid.setValue(currentXTile, currentYTile, 0);
                    //destroy the sprite
                    GameObject foundObject = findObjectToDestroy(currentXTile, currentYTile);
                    if (foundObject != null) {
                        Destroy(foundObject);
                    }
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
        //reset check next for next movement
        checkNext = false;
        textValue = movesLeft.ToString();
        //concatonate text value to update the on screen value
        text.text = "Moves Left: " + textValue;
    }
}
