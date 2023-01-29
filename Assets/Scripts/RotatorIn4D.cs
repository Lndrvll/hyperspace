using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Engine4;
using Vector4 = Engine4.Vector4;
using Engine4.Rendering;
using System;


public class RotatorIn4D : MonoBehaviour
{
	Vector3 vec3;
    Vector3 newVec3;
	Euler4 euler;
	public Transform4 transform4;
    public float verticalAxeRotation = 0.0f;
    public float diagonalAxeRotation = 0.0f;
    public float horizontalAxeRotation = 0.0f;
    public float rotationSpeed = 1f;
	private bool lockCursor = true;
    void Update()
    {
		horizontalAxeRotation = Input.GetAxis("Mouse X") * rotationSpeed;
		verticalAxeRotation = Input.GetAxis("Mouse Y") * rotationSpeed;		
		vec3 = new Vector3(diagonalAxeRotation, horizontalAxeRotation, verticalAxeRotation);
		newVec3 = Vector3.Scale(vec3, new Vector3(2, 2, 2));

		if (Input.GetKeyDown(KeyCode.Tab))
		{
			lockCursor = !lockCursor;
		}
		if (lockCursor) 
		{
			Cursor.lockState = CursorLockMode.Locked;
		} else {
			Cursor.lockState = CursorLockMode.None;
		}
		if (Input.GetMouseButton(0))
		{
			transform.Rotate(0, horizontalAxeRotation, verticalAxeRotation);
		}
		if (Input.GetMouseButton(1))
		{
			RotateIn4D(vec3, newVec3);
		}

    }
	void RotateIn4D(Vector3 vec3, Vector3 newVec3)
	{
		euler = new Euler4(vec3, newVec3);
		transform4.Rotate(euler, Space4.World);
	}


}


