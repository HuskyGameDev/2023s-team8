using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GridGameobject
{
    private GameObject actualGameObject;
    public int[] gridPosition;
    public GridGameobject(int x, int y, GameObject givenObj)
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
