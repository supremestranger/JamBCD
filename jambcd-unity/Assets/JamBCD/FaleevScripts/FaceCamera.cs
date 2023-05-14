using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FaceCamera : MonoBehaviour
{

    private void Update() {
        // Get the position of the main camera
        var cameraPosition = Camera.main.transform.position;

        // Set the object's rotation to face the main camera
        transform.LookAt(cameraPosition);

        // Rotate the object 90 degrees around its local x-axis
        transform.Rotate(0 , 180, 0);
    }
}
