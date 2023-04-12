using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ObjFollowMouse : MonoBehaviour
{
    PlaceObjectsOnGrid placeObjectsOnGrid;
    public bool isMouseHold;
    //public bool isOnGrid;
    void Start()
    {
        placeObjectsOnGrid = FindObjectOfType<PlaceObjectsOnGrid>();
    }

    void Update()
    {
        if (Input.touchCount>0 && isMouseHold)
        {
            transform.position = placeObjectsOnGrid.smoothMoussePosition + new Vector3(0 , 0, -0.3f);
        }
    }
    private void OnMouseDown()
    {
        isMouseHold = true;
    }
    private void OnMouseUp()
    {
        isMouseHold = false;
    }
}
