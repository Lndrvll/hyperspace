using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Engine4;
using Vector4 = Engine4.Vector4;
using Engine4.Rendering;

public class TransformIn4D : MonoBehaviour
{
    public Transform4 transform4;
    public float rotationSpeed = 10.0f;

    float diagonalAxeRotation = 0.0f;
    float horizontalAxeRotation = 0.0f;
    float verticalAxeRotation = 0.0f;

    Vector3 vec3;
    Vector3 newVec3;

    Vector4 vecA4;
    Vector4 vecB4;
    Vector4 vecC4;
    Vector4 vecD4;

    Euler4 euler;

    Matrix4 matrix; 

    void Update()
    {
        
        if(Input.GetMouseButton(2))
        {
            diagonalAxeRotation = Input.GetAxis("Mouse X") * rotationSpeed;
        }
        if(Input.GetMouseButton(0))
        {
            horizontalAxeRotation = Input.GetAxis("Mouse X") * rotationSpeed;
            verticalAxeRotation = Input.GetAxis("Mouse Y") * rotationSpeed; 
        }
        if(Input.GetMouseButton(1))
        {
            vec3 = new Vector3(diagonalAxeRotation, horizontalAxeRotation, verticalAxeRotation);
            newVec3 = Vector3.Scale(vec3, new Vector3(2, 2, 2));
            euler = new Euler4(vec3, newVec3);
            vecA4 = new Vector4(0, horizontalAxeRotation);
            vecB4 = new Vector4(1, diagonalAxeRotation);
            vecC4 = new Vector4(2, verticalAxeRotation);
            vecD4 = new Vector4(3, diagonalAxeRotation);

            matrix = new Matrix4(vecA4, vecB4, vecC4, vecD4);
            transform4.Rotate(euler, Space4.World);

        }   

        transform.Rotate(diagonalAxeRotation, horizontalAxeRotation, verticalAxeRotation);
        Debug.Log("Euler4 value: " + euler.ToString());


    }


  



}
