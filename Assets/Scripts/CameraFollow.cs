using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraFollow : MonoBehaviour
{
    [Header("Camera Follow")]
    public Transform player;
    public float smoothSpeed;
    public Vector3 offset;

    [Header("Renderer Setting")]
    public string targetTag;
    public float activeDistance = 20f;
    private List<GameObject> objects = new List<GameObject>();
    private Camera mainCamera;
    private void Start()
    {
        transform.position = new Vector3(player.position.x + offset.x, transform.position.y, transform.position.z);
        mainCamera = Camera.main;
        GameObject[] taggedObject = GameObject.FindGameObjectsWithTag(targetTag);
        objects.AddRange(taggedObject);
    }
    private void LateUpdate()
    {
        UpdateCameraPosition();
    }
    private void Update()
    {
        Renderer();
    }
    void UpdateCameraPosition()
    {
        Vector3 targetPosition = new Vector3(player.position.x + offset.x, player.position.y + offset.y, transform.position.z);
        Vector3 smoothedPosition = Vector3.Lerp(transform.position, targetPosition, smoothSpeed * Time.deltaTime);
        transform.position = smoothedPosition;
    }
    void Renderer()
    {
        Vector3 cameraPosition = mainCamera.transform.position;

        foreach (GameObject obj in objects)
        {
            // Check if the object is within activation distance
            if (Vector3.Distance(obj.transform.position, cameraPosition) <= activeDistance)
            {
                obj.SetActive(true); // Activate the object
            }
            else
            {
                obj.SetActive(false); // Deactivate the object
            }
        }
    }
}
