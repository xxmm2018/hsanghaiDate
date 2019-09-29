using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Experimental;

public class JsManager : MonoBehaviour
{
    public static JsManager instance;

    private void Awake()
    {
        instance = this;
    }
    /// <summary>
    /// 事件接收
    /// </summary>
    /// <param name="_name"></param>
    public void ReceiveFromJs(string _name)
    {

    }

    public void SendToJs(CameraInfo info)
    {
        Application.ExternalCall("DateUnity3D", JsonUtility.ToJson(info));
    }
}

