using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlaceObjectsOnGrid : MonoBehaviour
{
    

    public Transform gridCellPrefab;
    public Transform prefabOnMouse;
    public Transform sphere;

    public Vector3 smoothMoussePosition;
    //public float clampedPosx;
    //public float clampedPosy;

    public int _height;
    public int _width;

    Vector3 mousePosition;
    private Node[,] nodes;
    private Plane plane;

    private void Start()
    {
        CreateGrid();
        plane = new Plane(Vector3.forward, transform.position);
    }
    private void Update()
    {
        GetMousePositionOnGrid();
    }
    public class Node
    {
        public bool isPlaceable;
        public Vector3 cellPosition;
        public Transform obj;

        public Node(bool isPlaceable, Vector3 cellPosition, Transform obj)
        {
            this.isPlaceable = isPlaceable;
            this.cellPosition = cellPosition;
            this.obj = obj;

        }
    }

    public void GetMousePositionOnGrid()
    {
        Ray ray = Camera.main.ScreenPointToRay(Input.mousePosition);

        if (plane.Raycast(ray, out var enter))
        {
            mousePosition = ray.GetPoint(enter);
            mousePosition = Vector3Int.RoundToInt(mousePosition);
            smoothMoussePosition =mousePosition;

            //print(mousePosition);
            //clampedPosx = Mathf.Clamp(mousePosition.x, _width - 1, 0);
            //clampedPosy = Mathf.Clamp(mousePosition.y, _height - 1, 0);
            //mousePosition = new Vector3(clampedPosx, clampedPosy, 0);


            //foreach (var node in nodes)
            //{
            //    if (  mousePosition== node.cellPosition && node.isPlaceable)
            //    {
            //        if (Input.GetMouseButtonUp(0) && prefabOnMouse != null)
            //        {
            //            //node.isPlaceable = false;
            //            //prefabOnMouse.GetComponent<ObjFollowMouse>().isOnGrid = true;
            //            prefabOnMouse.position = node.cellPosition;
            //            //prefabOnMouse = null;
            //        }
            //    }
            //}
        }
    }
    private void CreateGrid()
    {
        nodes = new Node[_width, _height];
        var name = 0;
        for (int i = 0; i < _width; i++)
        {
            for (int j = 0; j < _height; j++)
            {
                Vector3 worldPosition = new Vector3(i-5, j-7 , -.07f);
                Transform obj = Instantiate(gridCellPrefab, worldPosition, Quaternion.Euler(new Vector3(-90, 0, 0)));
                obj.name = "Cell" + name;
                nodes[i, j] = new Node(true, worldPosition, obj);
                name++;
            }
        }
    }

   
}
