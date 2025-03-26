using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class InterfacePlane : MonoBehaviour
{
    public Button btn1;
    public Button btn2;
    public Button btn3;

    // Start is called before the first frame update
    void Start()
    {
        btn1.onClick.AddListener(
            delegate
            {
                Cursor.visible = false;
                Cursor.lockState = CursorLockMode.Locked;
            });
        btn2.onClick.AddListener(
            delegate
            {
                SceneManager.LoadScene("Main Menu");
            });
        btn3.onClick.AddListener(
            delegate
            {
                Application.Quit();
            });
    }

    // Update is called once per frame
    void Update()
    {

    }
}
