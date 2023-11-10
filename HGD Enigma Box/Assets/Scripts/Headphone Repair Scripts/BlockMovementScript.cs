using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BlockMovementScript : MonoBehaviour
{
    private bool dragging;
    private void OnMouseDown()
    {
        dragging = true;
    }
    private void Update()
    {
        if (!dragging) {
            return;
        }
        Vector2 mousePosition = (Vector2)Camera.main.ScreenToWorldPoint(Input.mousePosition);
        transform.position = mousePosition;
    }
}
