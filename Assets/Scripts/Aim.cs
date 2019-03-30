using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Aim : MonoBehaviour
{
    private Camera mainCamera;
    private Vector3 forwardVector;
    private Vector3 worldSpacePoint;
    private Ray ray;
    private RaycastHit hit;

    void Start()
    {
        mainCamera = Camera.main;
    }
    // Start is called before the first frame update
    public void FaceForwardDirection(Vector2 mousePosition)
    {
        ray = mainCamera.ScreenPointToRay(mousePosition);
        Physics.Raycast(ray, out hit);
        worldSpacePoint = hit.point;
        Vector3 lookingDirection = -worldSpacePoint + transform.position;
        forwardVector = new Vector3(lookingDirection.x, 0, lookingDirection.z);
        
    }

    // Update is called once per frame
    void Update()
    {
        transform.forward = forwardVector.normalized;
    }
}
