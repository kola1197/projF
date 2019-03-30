using System.Collections;
using System.Collections.Generic;
using UnityEngine;


public class TreeFilter : MonoBehaviour
{
    public string treeTag = "Tree";

    private CameraFollowScript cameraFollow;
    private Vector3 worldSpacePoint;
    private Ray ray;
    private RaycastHit hit;
    private Camera mainCamera;
    private MeshRenderer lastTree, newTree;

    void Start()
    {
        mainCamera = Camera.main;
        cameraFollow = mainCamera.GetComponent<CameraFollowScript>();
    }
    // Update is called once per frame
    void Update()
    {
        worldSpacePoint = mainCamera.ViewportToWorldPoint(new Vector3(0.5F, 0.5F, 0));
        Physics.Raycast(worldSpacePoint, (cameraFollow.target.position - worldSpacePoint), out hit);
        if(hit.collider.tag == treeTag)
        {
            Debug.Log("I see a tree");
            newTree = hit.collider.gameObject.GetComponent<MeshRenderer>();
            Debug.Log(lastTree == null);
            if ((lastTree == null) || (lastTree != newTree))
            {
                if (lastTree != null) lastTree.enabled = true;
                lastTree = newTree;
                lastTree.enabled = false;
            }
        }
        else
        {
            if (lastTree != null)
            {
                lastTree.enabled = true;
                lastTree = null;
            }
        }

    }
}
