using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class hScore : MonoBehaviour {

	// Use this for initialization
	void Start ()
    {

        (gameObject.GetComponent<TextMeshProUGUI>() as TextMeshProUGUI).text= PlayerPrefs.GetInt("HS", 0).ToString();

    }
	

}
