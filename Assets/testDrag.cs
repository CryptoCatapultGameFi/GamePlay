using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class testDrag : MonoBehaviour
{
    private void OnMouseDrag()
    {
        Vector3 newPosition = Camera.main.ScreenToWorldPoint(Input.mousePosition);
        transform.position = new Vector3 (newPosition.x, newPosition.y, 0);   
    }
}
