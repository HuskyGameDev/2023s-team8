using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TilesScript : MonoBehaviour
{
    public Vector3 targetPos;
    public Vector3 correctPos;
    public int num;
    public bool inRightPlace;

    void Awake()
    {
        targetPos = transform.position;
        correctPos = transform.position;
        correctPos.z = 0;
    }

    void Update()
    {
        transform.position = Vector3.Lerp(transform.position, targetPos, 0.05f);
        if (targetPos == correctPos) {
            inRightPlace = true;
        } else {
            inRightPlace = false;
        }
    }
}
