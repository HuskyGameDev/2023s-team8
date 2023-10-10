using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Grid
{
    private int width;
    private int height;
    private float cellSize;
    //this is a multidimensional array
    private int[,] gridArray;
    private Vector3 originPosition;
    //constructor that creates a grid of given width and height with cell size and where to start at in the world
    public Grid(int width, int height, float cellSize, Vector3 originPosition){
        //initialize variables to use later
        this.width = width;
        this.height = height;
        this.cellSize = cellSize;
        this.originPosition = originPosition;
        //creates a gridArray to loop through
        gridArray = new int[width, height];
        //nested loop that draws out where the grid is
        for (int i = 0; i < gridArray.GetLength(0); i++){
            for (int j = 0; j < gridArray.GetLength(1); j++){
                //set to 0 so gettting a value doesn't break
                gridArray[i,j] = 0;
                Debug.DrawLine(GetWorldPosition(i,j), GetWorldPosition(i,j+1), Color.white, 100f);
                Debug.DrawLine(GetWorldPosition(i,j), GetWorldPosition(i +1,j), Color.white, 100f);
            }
        }
        Debug.DrawLine(GetWorldPosition(0,height), GetWorldPosition(width, height), Color.white, 100f);
        Debug.DrawLine(GetWorldPosition(width,0), GetWorldPosition(width,height), Color.white, 100f);
    }
    //gets the world position of a cell, this will change based on which cell we are looking at,
    //the cell size and where we want it to originate from
    public Vector3 GetWorldPosition(int x, int y){
        return new Vector3(x,y) * cellSize + originPosition;
    }
    //sets cell [x,y] to whatever value we want to pass in
    public void setValue(int x, int y, int value){
        if(x >= 0 && y >= 0 && x < width && y < height){
            gridArray[x,y] = value;
        }
    }
    //gets the value set at cell[x,y]
    public int getValue(int x, int y){
        //look for the value of the 
        if(x >= 0 && y >= 0 && x < width && y < height){
            return gridArray[x,y];
        }
        else{
            //I made it return -1 for now, change it if you need -1 as a return value
            return -1;
        }

    }
}
