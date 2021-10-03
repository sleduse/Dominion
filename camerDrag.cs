using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class camerDrag : MonoBehaviour
{
    private Vector3 origin;
    private Vector3 difference;
    private Vector3 ResetCamera;

    private bool drag = false;
    private Camera cam;

    // Start is called before the first frame update
    void Start()
    {
        ResetCamera = Camera.main.transform.position;
        cam = Camera.main;
    }

    // Update is called once per frame
    void LateUpdate()
    {
        if(Input.GetMouseButton(2))
        {
            difference = (cam.ScreenToWorldPoint(Input.mousePosition)) - Camera.main.transform.position;
            if(drag == false)
            {
                drag = true;
                origin = (cam.ScreenToWorldPoint(Input.mousePosition));
            }
   
        }
        else
        {
            drag = false;
        }
        if (drag)
        {
            cam.transform.position = origin - difference;

            Camera.main.transform.position = new Vector3(
            Mathf.Clamp(Camera.main.transform.position.x, 23, 105),
            Mathf.Clamp(Camera.main.transform.position.y, -10, 10), transform.position.z);
        }
        if (Input.GetMouseButton(1))
        {
            cam.transform.position = ResetCamera;
        }
    }
}
