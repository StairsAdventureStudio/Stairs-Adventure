using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class link : MonoBehaviour {

	// Use this for initialization
	public void OpenLink(string url)
    {
        Application.OpenURL(url);
    }
}
