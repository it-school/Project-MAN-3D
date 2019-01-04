using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ArrowMove : MonoBehaviour {
    private Vector3 screenPoint;
    private Vector3 offset;
    private Vector3 scanPos;

    //public GameObject arrow;

    private void Start()
    {
//        scanPos = GetComponent<Camera>().transform.position;
    }

    public void ArrowMoveStart()
    {
        print(gameObject.transform.rotation.z);
    }

    public void OnMouseDown()
    {
        screenPoint = Camera.main.WorldToScreenPoint(scanPos);


        offset = scanPos - Camera.main.ScreenToWorldPoint(
            new Vector3(Input.mousePosition.x, Input.mousePosition.y, screenPoint.z));
        print("Down (" + offset.x + ", " + offset.y + "," + offset.z + " )");
    }


    public void OnMouseDrag()
    {
        Vector3 curScreenPoint = new Vector3(Input.mousePosition.x, Input.mousePosition.y, screenPoint.z);
        Vector3 curPosition = Camera.main.ScreenToWorldPoint(curScreenPoint) + offset;
        transform.position = curPosition;
        print("Drag (" + offset.x + ", " + offset.y + "," + offset.z + " )");

    }

}
