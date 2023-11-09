using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LevelController : MonoBehaviour {
    public Rigidbody2D mousePoint;

    private void FixedUpdate() {
        mousePoint.MovePosition(Camera.main.WorldToScreenPoint(Input.mousePosition));
    }

    public void Move(SpringJoint2D springJoint) {
        if (!springJoint.connectedBody) {
            Debug.Log("Moving " + springJoint);
            springJoint.connectedBody = mousePoint;
        }
    }

    public void Release(SpringJoint2D springJoint) {
        Debug.Log("Released!");
        springJoint.connectedBody = null;
    }
}
