using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Engine4;
using Vector4 = Engine4.Vector4;
using Engine4.Rendering;
using System;


public class TransformIn4D : MonoBehaviour
{
    public Transform4 transform4;
		Vector3 vec3;
    Vector3 newVec3;
		Euler4 euler;
    public float verticalAxeRotation = 5.0f;
    public float diagonalAxeRotation = 5.0f;
    public float horizontalAxeRotation = 5.0f;
    public float rotationSpeed = 1f;
 
    private float myValue = 0f;
    private float click;
		private bool lockCursor = true;

		float lerpDuration = 5.0f;
    bool rotating;

    void Update()
    {
			horizontalAxeRotation = Input.GetAxis("Mouse X") * rotationSpeed;
			verticalAxeRotation = Input.GetAxis("Mouse Y") * rotationSpeed;		
			vec3 = new Vector3(diagonalAxeRotation, horizontalAxeRotation, verticalAxeRotation);
			newVec3 = Vector3.Scale(vec3, new Vector3(2, 2, 2));

			if (Input.GetKeyDown(KeyCode.Tab))
			{
					lockCursor = !lockCursor;
					rotating = true;
			}
 
			if (lockCursor) {
					Cursor.lockState = CursorLockMode.Locked;
			}	else {
					Cursor.lockState = CursorLockMode.None;
			}

			if (Input.GetMouseButton(0))
			{
				 transform.Rotate(0, horizontalAxeRotation, verticalAxeRotation);
				 rotating = true;
			}

			if (Input.GetMouseButton(1))
			{
					RotateIn4D(vec3, newVec3);
					rotating = true;
			}
			if (!Input.anyKey && !rotating)
			{
				StartCoroutine(AutoRotate());
			}

    }

		void RotateIn4D(Vector3 vec3, Vector3 newVec3)
		{
			euler = new Euler4(vec3, newVec3);
			transform4.Rotate(euler, Space4.World);
		}
}

/**
		IEnumerator AutoRotate()
		{
			rotating = true;
			float timeElapsed = 0;
			Quaternion startRotation = transform.rotation;
			Quaternion targetRotation = transform.rotation * Quaternion.Euler(0, 90, 0);
			while (timeElapsed < lerpDuration)
			{
					transform.rotation = Quaternion.Slerp(startRotation, targetRotation, timeElapsed / lerpDuration);
					timeElapsed += Time.deltaTime;
					yield return new WaitForSeconds(2);;
			}
			transform.rotation = targetRotation;
			/**

		}
		
}

