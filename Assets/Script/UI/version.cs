using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class version : MonoBehaviour {

	
	void Start () {

        (gameObject.GetComponent<TextMeshProUGUI>() as TextMeshProUGUI).text = "v "+Application.version.ToString();
        
    }
	
	
}
