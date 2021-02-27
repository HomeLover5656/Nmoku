using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraCon : MonoBehaviour
{
    Vector2 mouse;
    Vector2 pmouse;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        mouse = Input.mousePosition;
        if (Input.GetMouseButtonDown(1))
        {
            pmouse = mouse;
        }
        if (Input.GetMouseButton(1))
        {
            this.transform.rotation *= Quaternion.AngleAxis((mouse.x - pmouse.x)/5 , Vector3.up);
        }
            pmouse = mouse;
        
    }
}
