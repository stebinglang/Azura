using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class NewBehaviourScript : MonoBehaviour
{
    public Transform PlayerCamera;
    public float MaxDistance = 5;

    private bool opened = false;
    private Animator anim;


    public LayerMask layerMask;



    void Start()
    {
        layerMask = ~LayerMask.GetMask("IgnoreRaycast");
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetKeyDown(KeyCode.E) || Input.GetKeyDown(KeyCode.Mouse0))
        {
            
            Pressed();
        }

    }

    void Pressed()
    {
        
        RaycastHit doorhit;
        if (Physics.Raycast(PlayerCamera.transform.position, PlayerCamera.transform.forward, out doorhit, MaxDistance, layerMask))
        {
            
            //print("Hit object tag: " + doorhit.transform.tag);
            if (doorhit.transform.tag == "Door")
            {
                print("in2");
                anim = doorhit.transform.GetComponentInParent<Animator>();
                opened = !opened;
                anim.SetBool("Opened", !opened);
            }
        }
    }


}
