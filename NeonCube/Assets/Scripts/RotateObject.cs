using UnityEngine;
using System.Collections.Generic;

public class RotateObject : MonoBehaviour
{
    public Transform objectToRotate;
    public Vector3 rotationAxis = Vector3.up; // Ось вращения по умолчанию
    public float rotationDegrees = 90f;
    public float rotationTime = 1f;
    public List<GameObject> objectsToDisableDuringRotation;

    private bool isRotating = false;
    private Quaternion startRotation;
    private Quaternion targetRotation;
    private float rotationTimer = 0f;

    void Update()
    {
        if (isRotating)
        {
            rotationTimer += Time.deltaTime;
            float t = Mathf.Clamp01(rotationTimer / rotationTime);
            objectToRotate.rotation = Quaternion.Lerp(startRotation, targetRotation, t);

            if (rotationTimer >= rotationTime)
            {
                isRotating = false;
                EnableObjects();
            }
        }
    }

    public void RotateObjectInDirection()
    {
        if (!isRotating)
        {
            startRotation = objectToRotate.rotation;
            targetRotation = Quaternion.AngleAxis(rotationDegrees, rotationAxis) * startRotation;
            rotationTimer = 0f;
            isRotating = true;
            DisableObjects();
        }
    }

    void DisableObjects()
    {
        foreach (GameObject obj in objectsToDisableDuringRotation)
        {
            obj.SetActive(false);
        }
    }

    void EnableObjects()
    {
        foreach (GameObject obj in objectsToDisableDuringRotation)
        {
            obj.SetActive(true);
        }
    }
}
