using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class tornadoScript : MonoBehaviour
{
   

    // Disables gravity on all rigidbodies entering this collider.
    void OnTriggerEnter(Collider other)
    {
        if (other.attachedRigidbody)
            other.attachedRigidbody.useGravity = false;
    }
}


