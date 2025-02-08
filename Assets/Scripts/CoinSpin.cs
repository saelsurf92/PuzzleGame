using UnityEngine;

public class RotateObject : MonoBehaviour
{
    public float rotationSpeed = 175f; // Speed of rotation

void Update()
{
    transform.Rotate(rotationSpeed * Time.deltaTime, 0, 0); 
}
}
