using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RotateObject : MonoBehaviour
{
    public float rotationSpeed = 30f;        // D�nme h�z� (derece/saniye)
    public Vector3 rotationAxis = Vector3.left; // D�nme ekseni (varsay�lan: yukar�)

    private void Update()
    {
        transform.Rotate(rotationAxis, rotationSpeed * Time.deltaTime);
    }
}
