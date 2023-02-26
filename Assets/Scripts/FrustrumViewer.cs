using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Engine4;
using Engine4.Rendering;
using Vector4 = Engine4.Vector4;
using System;

public class FrustrumViewer : MonoBehaviour
{
    public GameObject viewer;
    private Viewer4 projectorCustom;
    private bool frustrumView = true;
    private void Start() 
    {
        projectorCustom = viewer.GetComponent<Viewer4>();
    }

    
    void Update() 
    {
        if (Input.GetKeyDown(KeyCode.Q))
        {
            frustrumView = !frustrumView;
        }
        if(frustrumView)
        {
            projectorCustom.Validate();
            projectorCustom.projection = ProjectionMode.CrossSection; 
        } else {
            projectorCustom.Validate();
            projectorCustom.projection = ProjectionMode.Frustum;
        }
    }

}
