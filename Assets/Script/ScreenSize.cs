// using System.Collections;
// using System.Collections.Generic;
// using UnityEngine;
// using UnityEngine.UI;

// public class ScreenSize : MonoBehaviour
// {
//     public Toggle t0;
//     public Toggle t1;
//     public Toggle t2;
//     public Toggle t3;

//     public Button btn;
//     // Start is called before the first frame update
//     void Start()
//     {
//         btn.onClick.AddListener(
//             delegate
//             {
//                 if (t0.isOn == true)
//                 {
//                     Screen.SetResolution(1920, 1080, false);
//                 }

//                 if (t1.isOn == true)
//                 {
//                     Screen.SetResolution(1920, 1080, false);
//                 }

//                 if (t2.isOn == true)
//                 {
//                     Screen.SetResolution(1600, 1200, false);
//                 }

//                 if (t3.isOn == true)
//                 {
//                     Screen.SetResolution(800, 600, false);
//                 }

//             });
//     }

//     // Update is called once per frame
//     void Update()
//     {

//     }
// }

using UnityEngine;
using UnityEngine.UI;

public class ScreenSize : MonoBehaviour
{
    public Toggle t0;
    public Toggle t1;
    public Toggle t2;
    public Toggle t3;

    public Button btn;

    private Resolution fullScreenResolution;

    void Start()
    {
        // Store the original full screen resolution
        fullScreenResolution = Screen.currentResolution;
        btn.onClick.AddListener(ApplyScreenSettings);
    }

    void ApplyScreenSettings()
    {
        if (t0.isOn)
        {
            Screen.SetResolution(fullScreenResolution.width, fullScreenResolution.height, true);
        }
        else if (t1.isOn)
        {
            Screen.SetResolution(1920, 1080, false);
        }
        else if (t2.isOn)
        {
            Screen.SetResolution(1600, 1200, false);
        }
        else if (t3.isOn)
        {
            Screen.SetResolution(800, 600, false);
        }
    }

}
