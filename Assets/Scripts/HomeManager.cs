using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class HomeManager : MonoBehaviour {

    private List<DianGui> dianGuis = new List<DianGui>();
	// Use this for initialization
	void Start () {
        for (int i = 0; i < transform.childCount; i++)
        {
            DianGui gui = transform.GetChild(i).GetComponent<DianGui>();
            gui.info.id = transform.name.Replace("fangjian","")+"_"+(i+1);
        }
	}

}
