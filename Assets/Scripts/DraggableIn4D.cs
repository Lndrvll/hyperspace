using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DraggableIn4D : MonoBehaviour
{
    public float speed = 10.0f;
    public float rotationSpeed = 100.0f;


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

            horizontalAxeRotation *= Time.deltaTime;
            verticalAxeRotation *= Time.deltaTime;
    
            // Rotate around our y-axis
            transform.Rotate(0, horizontalAxeRotation, verticalAxeRotation);
        }

    }
    
}
