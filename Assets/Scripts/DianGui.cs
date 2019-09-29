using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DianGui : MonoBehaviour
{
    public CameraInfo info;
    HighlightableObject ho;
    private Color color;
    // Use this for initialization
    void Start()
    {
        color = Color.red;
        ho = gameObject.AddComponent<HighlightableObject>();
    }

    public void ShowHight(bool state)
    {
        if (state)
        {
            ho.ConstantOnImmediate(color);
        }
        else
        {
            ho.ConstantOffImmediate();

        }
    }
}
[System.Serializable]
public class CameraInfo
{
    public string id;
}
