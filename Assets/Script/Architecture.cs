using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Architecture : MonoBehaviour
{
    public GameObject game;
    bool open = false;

    private void Start()
    {
        game = transform.GetChild(0).gameObject;
        game.SetActive(false);
    }

    public void OpenActive()
    {
        if (open==false)
        {
            open = true;
        }
        else
        {
            open = false;
        }
        game.SetActive(open);
    }
}
