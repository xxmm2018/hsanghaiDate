using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ViewControl : MonoBehaviour
{
    /// <summary>
    /// 围绕点
    /// </summary>
    private Vector3 Rotion_Transform;
    public float minDistance = 35, maxDistance = 65;
    public float angelSpeed = 5;
    float distance;
    RaycastHit hit;

    DianGui dian;
    void Start()
    {
        Rotion_Transform = GameObject.Find("huanjing").transform.position;
    }
    void Update()
    {
        Ctrl_Cam_Move();
        Cam_Ctrl_Rotation();
        ChooseTarget();
    }


    void ChooseTarget()
    {
        if (Input.GetMouseButtonDown(0))
        {
            Ray ray = Camera.main.ScreenPointToRay(Input.mousePosition);
            if (Physics.Raycast(ray, out hit))
            {
                if (null != hit.collider.gameObject)
                {
                    if (dian == hit.collider.GetComponent<DianGui>())
                        return;
                    if (null != dian)
                    {
                        dian.ShowHight(false);
                    }
                    dian = hit.collider.GetComponent<DianGui>();
                    dian.ShowHight(true);
                    JsManager.instance.SendToJs(dian.info);

                }

            }
            else
            {
                if (null != dian)
                {
                    dian.ShowHight(false);
                    dian = null;
                    CameraInfo info = new CameraInfo();
                    JsManager.instance.SendToJs(info);
                }

            }
        }

    }

    //镜头的远离和接近
    public void Ctrl_Cam_Move()
    {

        if (Input.GetAxis("Mouse ScrollWheel") > 0)
        {
            if (distance > maxDistance)
            {
                distance = maxDistance;
            }
            else
            {
                distance = Vector3.Distance(transform.position, Rotion_Transform);
            }
            IsInArea(true);
        }
        if (Input.GetAxis("Mouse ScrollWheel") < 0)
        {
            if (distance < minDistance)
            {
                distance = maxDistance;
            }
            else
            {
                distance = Vector3.Distance(transform.position, Rotion_Transform);
            }
            IsInArea(false);
        }
    }
    /// <summary>
    /// 视野放大缩小
    /// </summary>
    /// <param name="changeBig">
    /// true：放大
    /// flase：缩小
    /// </param>
    void IsInArea(bool changeBig)
    {
        if (distance >= minDistance && distance <= maxDistance)
        {
            transform.Translate(Vector3.forward * (changeBig ? 1 : -1f));
        }
    }
    //摄像机的旋转
    public void Cam_Ctrl_Rotation()
    {
        var mouse_x = Input.GetAxis("Mouse X");//获取鼠标X轴移动
        var mouse_y = -Input.GetAxis("Mouse Y");//获取鼠标Y轴移动
        if (Input.GetKey(KeyCode.Mouse0))
        {
            transform.RotateAround(Rotion_Transform, Vector3.up, mouse_x * angelSpeed);
            transform.RotateAround(Rotion_Transform, transform.right, mouse_y * angelSpeed);
        }
    }

}
