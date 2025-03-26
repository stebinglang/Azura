using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Behavior : MonoBehaviour
{
    // 从视角摄像机向屏幕中间发射射线

    Camera MainCamera;                // 这是一个摄像机对象
    public Transform ScreenMidPos;             // 这是屏幕中央的点的坐标
    public GameObject game;
    public GameObject parentGame;
    public GameObject ui;
    public GameObject uiOpen;
    GameObject parent;
    GameObject uiObject;
    float time = 0;
    public LineRenderer lineRenderer;
    LineRenderer rendererXian;
    private float distance;
    int number = 0;//落点数量
    public int count = 0;//计数
    bool saveOpen=false;//保存开关
    bool openUIPlane;
    private void Start()
    {
        Cursor.visible = false;
        Cursor.lockState = CursorLockMode.Locked;
    }
    void Update()
    {
        /*if (Input.GetMouseButtonDown(0))
        {
            RayShot();              // 如果鼠标左键按下，则发射一条射线
        }*/

        if (Input.GetMouseButton(0)&&time <=0)
        {
            time = 1.0f;
            //2创建一个射线 从相机位置到鼠标点击的位置的方向上
            Ray ray = Camera.main.ScreenPointToRay(ScreenMidPos.position);
            //定义一个射线检测的保存对象
            RaycastHit hit;//hit保存射线发射后碰撞的信息
            if (Physics.Raycast(ray, out hit,300f)) //碰撞检测(射线，碰撞结果给hit，射线的长度100米)
            {
                count++;
                if (count >=3)
                {
                    count = 1;
                    if (saveOpen == false)
                    {
                        Destroy(parent);
                        Destroy(rendererXian.gameObject);
                        Destroy(uiObject);
                    }
                }
                Vector3 hitPos = hit.point;
                hitPos.x -= 0.3f;
                GameObject objectPosi = Instantiate(game, hitPos, transform.rotation);
                if (number ==0)
                {
                    GameObject parentObject = Instantiate(parentGame, transform.position, transform.rotation);
                    parent = parentObject;
                    LineRenderer line = Instantiate(lineRenderer, transform.position, transform.rotation);
                    rendererXian = line;
                }
                objectPosi.transform.parent = parent.transform;
                rendererXian.SetPosition(number, objectPosi.transform.position);
                if (number ==0)
                {
                    rendererXian.SetPosition(1, objectPosi.transform.position);
                }
                if (number ==1)
                {
                    Quaternion rota = transform.rotation;
                    //rota.y = 90;
                    GameObject uiPlane = Instantiate(ui, GetBetweenPoint(objectPosi.transform .position , parent.transform .GetChild (0).position), rota);
                    uiObject = uiPlane;
                    Vector3 uipos = uiPlane.transform.position;
                    uipos.y += 1;
                    uiPlane.transform.position = uipos;
                    uiPlane.transform.GetChild(0).GetComponent<Text>().text = "" + Vector3.Distance(objectPosi.transform.position, parent.transform.GetChild(0).position);
                }
                number++;
                if (number >=2)
                {
                    number = 0;
                }
                saveOpen = false;
            }



        }
        if (Input.GetKey(KeyCode.F) )
        {
            saveOpen = true;
        }
        if (Input.GetKeyDown(KeyCode.R) && time <= 0)
        {
            time = 1.0f;
            Ray ray = Camera.main.ScreenPointToRay(ScreenMidPos.position);
            //定义一个射线检测的保存对象
            RaycastHit hit;//hit保存射线发射后碰撞的信息
            if (Physics.Raycast(ray, out hit, 300f)) //碰撞检测(射线，碰撞结果给hit，射线的长度100米)
            {
                if (hit .transform .tag =="Finish")
                {
                    hit.transform.GetComponent<Architecture>().OpenActive();
                }

            }
        }
        if (Input.GetKeyDown(KeyCode.Escape) && time <= 0)
        {
            time = 1.0f;
            if (openUIPlane == false)
            {
                Cursor.visible = true;
                Cursor.lockState = CursorLockMode.None;
                openUIPlane = true;
            }
            else
            {
                Cursor.visible = false;
                Cursor.lockState = CursorLockMode.Locked;
                openUIPlane = false;
            }
            uiOpen.SetActive(openUIPlane);

        }
        time -= Time.deltaTime;
    }

    // private void RayShot()
    // {
    //     //从摄像机出发向屏幕中间发射射线！
    //     Ray OneShotRay = Camera.main.ScreenPointToRay(ScreenMidPos.position);          // 以屏幕中央点为原点，发射射线
    //     RaycastHit OnEnemy;
    //     if (Physics.Raycast(OneShotRay, out OnEnemy))                          // 如果射线碰到了物体
    //     {
    //         Debug.Log("射线发射成功");
    //         if (OnEnemy.transform.tag != "Player" )  // 如果碰到的不是地形和角色
    //         {
    //             Destroy(OnEnemy.transform.gameObject);                        // 销毁碰撞到的物体
    //             Debug.Log("销毁对方");
    //             if (ScreenMidPos != null)
    //             {
    //                 Debug.DrawLine(Camera.main.transform.position, ScreenMidPos.position, Color.red, 10000f);    // 画一条从摄像机出发，到屏幕中央点的射线
    //             }

    //         }

    //     }
    // }

    /// <summary>
    /// 获取两点之间距离一定百分比的一个点
    /// </summary>
    /// <param name="start">起始点</param>
    /// <param name="end">结束点</param>
    /// <param name="distance">起始点到目标点距离百分比</param>
    /// <returns></returns>
    private Vector3 GetBetweenPoint(Vector3 start, Vector3 end, float percent = 0.5f)
    {
        Vector3 normal = (end - start).normalized;
        float distance = Vector3.Distance(start, end);
        return normal * (distance * percent) + start;
    }

}