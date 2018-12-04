using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class skinButton : MonoBehaviour {

    public int nr;
    public GameObject o;


    public void setNumber(int v)
    {
        nr = v;
    }

    void Start()
    {
        o = GameObject.Find("skinCon");
        Button btn = gameObject.GetComponent<Button>();
        btn.onClick.AddListener(TaskOnClick);
    }

    void TaskOnClick()
    {
        o.SendMessage("button", nr);
    }

}
