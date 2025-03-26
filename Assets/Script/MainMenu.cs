using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class MainInterface : MonoBehaviour
{
    Button StartBtn;
    Button SettingsBtn;
    Button AboutBtn;
    Button QuitBtn;
    GameObject panel;
    // Start is called before the first frame update
    void Start()
    {
        StartBtn = transform.GetChild(1).GetComponent<Button>();
        SettingsBtn = transform.GetChild(2).GetComponent<Button>();
        AboutBtn = transform.GetChild(3).GetComponent<Button>();
        QuitBtn = transform.GetChild(4).GetComponent<Button>();
        panel = transform.GetChild(5).gameObject;
        StartBtn.onClick.AddListener(
            delegate
            {
                PanelOpen(0);
            });
        SettingsBtn.onClick.AddListener(
            delegate
            {
                PanelOpen(1);
            });
        AboutBtn.onClick.AddListener(
            delegate
            {
                PanelOpen(2);
            });
        QuitBtn.onClick.AddListener(
            delegate
            {
                Application.Quit();
            });

    }


    void PanelOpen(int i)
    {
        int number = panel.transform.childCount;
        for (int j=0;j<number;j++)
        {
            panel.transform.GetChild(j).gameObject.SetActive(false);
        }
        panel.transform.GetChild(i).gameObject.SetActive(true);
    }

    // Update is called once per frame
    void Update()
    {

    }
}
