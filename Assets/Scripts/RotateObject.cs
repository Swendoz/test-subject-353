using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RotateObject : MonoBehaviour
{
    public float rotationSpeed = 30f;        // Dönme hýzý (derece/saniye)
    public Vector3 rotationAxis = Vector3.left; // Dönme ekseni (varsayýlan: yukarý)

    private void Update()
    {
        transform.Rotate(rotationAxis, rotationSpeed * Time.deltaTime);
    }
}
