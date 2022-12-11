using Engine4;
using Engine4.Physics;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Example4Trigger : MonoBehaviour4
{
    // Start is called before the first frame update

    private void OnEnable()
    {
        GetComponent<Collider4>().callback += OnCollisionCallback;
    }
    private void OnDisable()
    {
        GetComponent<Collider4>().callback -= OnCollisionCallback;
    }

    // Update is called once per frame
    void OnCollisionCallback(CollisionHit4 hit)
    {
        Debug.Log(hit.other.name);        
    }
}
