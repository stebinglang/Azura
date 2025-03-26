using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CubeBox : MonoBehaviour
{
    public GameObject text;
    Transform player;
    public Transform location;
    Transform pos1;
    Transform pos2;
    bool open;
    // Start is called before the first frame update
    void Start()
    {
        text = GameObject.FindGameObjectWithTag("UI").transform.GetChild(0).gameObject;
        pos1 = transform.GetChild(0);
        pos2 = transform.GetChild(1);
        location = pos1;

    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetKeyDown(KeyCode.E) && player != null)
        {
            player.position = location.position;
            text.SetActive(false);
            player = null;
            if (open ==false )
            {
                open = true;
                location = pos2;
            }
            else
            {
                open = false;
                location = pos1;
            }
        }

    }
    private void OnTriggerEnter(Collider other)
    {
        if (other .tag =="Player")
        {
            text.SetActive(true);
            player = other.transform;
        }
        
    }

    private void OnTriggerStay(Collider other)
    {

    }

    private void OnTriggerExit(Collider other)
    {
        if (other.tag == "Player")
        {
            text.SetActive(false);
            player = null;
        }

    }

}
