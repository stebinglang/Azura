using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GroundCheck : MonoBehaviour
{
    // Store transform of raycastOrigin object. Used for raycast in GroundCheckMethod()
    [SerializeField] private Transform rayCastOrigin;

    // Store playerFeet transform to allow us to adjust our player's position in GroundCheckMethod()
    [SerializeField] private Transform playerFeet;

    // LayerMask used in raycast to make raycast more performant
    // The raycast will ignore all objects outside of the layermask we select.
    [SerializeField] private LayerMask layerMask;

    // Store the hit information from our raycast, to use to update player's position
    private RaycastHit hit;

    // Update is called once per frame
    void Update()
    {
        // Do not need to run in FixedUpdate since this is not physics-based. 
        GroundCheckMethod();
    }

    // This method will use a raycast to check below the player. Use this ray hit info to update player position
    private void GroundCheckMethod()
    {
        // Store the raycast hit info. The raycast arguments are (origin of ray, direction of ray, length of ray, what layer mask to check against)
        if (Physics.Raycast(rayCastOrigin.position, Vector3.down, out hit, 100f, layerMask))
        {
            // Create temp vector3 to store playerFeet position
            Vector3 temp = playerFeet.position;

            // We get the y position of our raycast hit and set the y value of our temp vector3
            temp.y = hit.point.y;

            // We can now directly set our player's position by setting it to our temp vector3 value that we adjusted.
            playerFeet.position = temp;
        }
    }
}