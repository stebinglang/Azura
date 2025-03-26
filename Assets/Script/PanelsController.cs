using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class MainPlane : MonoBehaviour
{
    public Button House1Btn;
    public Button House2Btn;
    public Button AboutBtn;
    public GameObject AboutExitController;
    GameObject aboutPanel;
    // Start is called before the first frame update
    void Start()
    {
        aboutPanel = transform.GetChild(2).gameObject;
        House1Btn.onClick.AddListener(
            delegate
            {
                SceneManager.LoadScene("2024 Summer Dr");
            });
        House2Btn.onClick.AddListener(
            delegate
            {
                SceneManager.LoadScene("579 Future Rd");
            });
        AboutBtn.onClick.AddListener(
            delegate
            {
                aboutPanel.SetActive(false);
            });
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.anyKey)
        {
            AboutExitController.SetActive(false);
        }
    }
}
