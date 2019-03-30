using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraFollowScript : MonoBehaviour
{
    public Transform target;
    private Vector3 lastPosition;
    private Vector3 delta;
    // Start is called before the first frame update
    void Start()
    {
        lastPosition = target.position;
        if (target == null) Debug.LogError("Target for camera isn't set!");
    }

    // Update is called once per frame
    void Update()
    {
        delta = target.position - lastPosition;
    }

    void LateUpdate()
    {
        transform.position += delta;
        lastPosition = target.position;
    }
}
