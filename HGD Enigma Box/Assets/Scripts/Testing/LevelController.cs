using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LevelController : MonoBehaviour {
    public Vector2 mousePoint;
    private Vector2 velocity;
    private Rigidbody2D curr;

    private void FixedUpdate() {
        mousePoint = Camera.main.ScreenToWorldPoint(Input.mousePosition);
        if (curr) {
            velocity = curr.velocity;
            curr.position = Vector2.SmoothDamp(curr.position, mousePoint, ref velocity, 0.05f);
        }
    }

    public void Move(Rigidbody2D rigidbody) {
        curr = rigidbody;
        //velocity = rigidbody.velocity;
        //rigidbody.position = Vector2.SmoothDamp(rigidbody.position, mousePoint, ref velocity, 0.01f);
    }

    public void Release() {
        Debug.Log("Released!");
        curr = null;
    }
}

/*public class LevelController : MonoBehaviour {
    public Rigidbody2D mousePoint;

    private void FixedUpdate() {
        mousePoint.MovePosition(Camera.main.ScreenToWorldPoint(Input.mousePosition));
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
}*/
