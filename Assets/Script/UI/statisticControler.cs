using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class statisticControler : MonoBehaviour {


    public parameter[] data;

	void Start ()
    {
        for (int i = 0; i < data.Length; i++)
        {
            TextMeshProUGUI now= data[i].o.GetComponent<TextMeshProUGUI>();
            if(PlayerPrefs.GetInt(data[i].s,-1)==-1)
            {
                now.text ="No data!";
            }
            else
            {
                now.text =PlayerPrefs.GetInt(data[i].s).ToString();
            }
            
        }
	}
	
    [System.Serializable]
    public class parameter
    {
        public GameObject o;
        public string s;
    }

}


