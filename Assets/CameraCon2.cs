using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraCon2 : MonoBehaviour
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
            this.transform.localRotation *= Quaternion.AngleAxis((mouse.y - pmouse.y)/5, Vector3.right);
        }
        pmouse = mouse;

    }
}
