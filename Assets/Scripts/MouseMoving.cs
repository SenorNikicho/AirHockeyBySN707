using System.Collections;
using System.Collections.Generic;
using System.ComponentModel.Design.Serialization;
using UnityEngine;

public class cursor : MonoBehaviour
{
    /*
    void Start()
    {
        Cursor.visible = false;
    }
    */
    void Update()
    {

        Vector3 mousePosition = new Vector3(Input.mousePosition.x/100, 0.33f, Input.mousePosition.z/100);
        //Vector3 objPosition = Camera.main.ScreenToWorldPoint(mousePosition);
        transform.position = mousePosition;
    }
}