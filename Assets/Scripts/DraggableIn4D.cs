using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Engine4;
using Engine4.Internal;

public class DraggableIn4D : MonoBehaviour
{
    public float speed = 10.0f;
    public float rotationSpeed = 100.0f;
    Transform4 transform4 = new Transform4();

    void Update()
    {
        moveObject();
    }

    public void moveObject()
    {
        if (Input.GetMouseButton(0))
        {    
        // Get the horizontal and vertical axis.
        // By default they are mapped to the arrow keys.
        // The value is in the range -1 to 1
        float horizontalTranslation = Input.GetAxis("Mouse X") * speed;
        float verticalTranslation = Input.GetAxis("Mouse Y") * speed;

        // Make it move 10 meters per second instead of 10 meters per frame...
        horizontalTranslation *= Time.deltaTime;
        verticalTranslation *= Time.deltaTime;

        // Move translation along the object's z-axis
        transform.Translate(0, verticalTranslation, horizontalTranslation);

        }
        if(Input.GetMouseButton(2))
        {
            float horizontalAxeRotation = Input.GetAxis("Mouse X") * rotationSpeed;
            float verticalAxeRotation = Input.GetAxis("Mouse Y") * rotationSpeed;

            horizontalAxeRotation += Time.deltaTime * 10;
            verticalAxeRotation += Time.deltaTime * 10;

            transform.rotation = Quaternion.Euler(horizontalAxeRotation,verticalAxeRotation,0);

            Vector3 v = transform.rotation.ToEulerAngles();

            Space4 space = new Space4();

            Euler4 euler4 = new Euler4(v, v);

            transform4.Rotate(euler4,space);

             Debug.Log("Transform position from euler4: " + euler4);
        }

    }
    
}
