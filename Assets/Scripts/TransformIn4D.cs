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
    public float verticalAxeRotation = 0.0f;
    public float diagonalAxeRotation = 0.0f;
    public float horizontalAxeRotation = 0.0f;
    public float rotationSpeed = 10.0f;

    Vector3 vec3;
    Vector3 newVec3;

    Vector4 vecA4;
    Vector4 vecB4;
    Vector4 vecC4;
    Vector4 vecD4;

    Euler4 euler;

    Matrix4 matrix;

    private float myValue = 0f;
    private float click;
		private bool rightMouseButtonClicked = false;
		public bool lockCursor = true;

    void Update()
    {
			horizontalAxeRotation = Input.GetAxis("Mouse X") * rotationSpeed;

			verticalAxeRotation = Input.GetAxis("Mouse Y") * rotationSpeed;

			if (Input.GetKeyDown(KeyCode.Tab))
			{
				lockCursor = !lockCursor;
			}
 
			if (lockCursor) {
					Cursor.lockState = CursorLockMode.Locked;
			} else {
					Cursor.lockState = CursorLockMode.None;
			}
			
			if (Input.GetMouseButton(0))
			{
				RotateIn3D();
			}

			if (Input.GetMouseButton(1))
			{
				RotateIn4D();
			}

			Debug.Log("Euler4 value: " + euler.ToString());
			Debug.Log("MousePos value: " + Input.mousePosition);

    }
    void RotateIn3D()
    {

        Vector2 hub = new Vector2(Screen.width/2f, Screen.height/2f);

        if (Input.GetMouseButton(1)) 
        {
					Vector2 mousePos = Input.mousePosition;
					float mouseAngle = Vector2.Angle(Vector2.up, mousePos - hub);

					if (mousePos.x<hub.x)
					{
						mouseAngle = 360f - mouseAngle;
					}
					if (Input.GetMouseButtonDown(0))
					{
						click = mouseAngle;
					}
					float difference = mouseAngle - click;
					// To prevent error when going past zero
					if (difference>180f)
					{
						difference-=360f;
					}
					if (difference<-180f)
					{
						difference+=360f;
					}
					myValue += difference * rotationSpeed;
					click = mouseAngle;
					myValue = Mathf.Clamp(myValue, -0f, 360f);
        }

				diagonalAxeRotation = myValue * rotationSpeed;

        transform.Rotate(diagonalAxeRotation, horizontalAxeRotation, verticalAxeRotation);

    }

    void RotateIn4D()
    {
			vec3 = new Vector3(diagonalAxeRotation, horizontalAxeRotation, verticalAxeRotation);
			newVec3 = Vector3.Scale(vec3, new Vector3(2, 2, 2));

			euler = new Euler4(vec3, newVec3);

			transform4.Rotate(euler, Space4.World);
    }
}

