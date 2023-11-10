using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BlockMovementScript : MonoBehaviour
{
    private bool dragging;
    private Vector2 offset, originalPosition;
    public void Awake()
    {
        originalPosition = transform.position;
    }
    private void OnMouseDown()
    {
        dragging = true;
        offset = getMousePos() - (Vector2)transform.position;
    }
    private void OnMouseUp()
    {
        transform.position = originalPosition;
        dragging = false;
    }
    private void Update()
    {
        if (!dragging) {
            return;
        }
        Vector2 mousePosition = getMousePos();
        transform.position = mousePosition - offset;
    }
    Vector2 getMousePos() {
        return Camera.main.ScreenToWorldPoint(Input.mousePosition);
    }
}
