using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class pointCounter : MonoBehaviour {

    Transform t;
    public int point;
    public TextMeshProUGUI text;
    public bool isPlay=false;

    private void Start()
    {
       t= gameObject.GetComponent<Transform>();
    }

    void Update () {
        text.text = point.ToString();
        point = (int)t.position.x / 2;
        if (point > PlayerPrefs.GetInt("HS", 0))
        {
            PlayerPrefs.SetInt("HS", point);
        }

        if(point>=1 && !isPlay)
        {
            isPlay = true;
            PlayerPrefs.SetInt("PlayNr",PlayerPrefs.GetInt("PlayNr",0)+1);
            
        }

    }
}
