using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class echoSkin : MonoBehaviour {

    public skinData sData;

    private void Start()
    { 
        SpriteRenderer spr = gameObject.GetComponent<SpriteRenderer>();

        float red = PlayerPrefs.GetFloat("r", 255);
        float green = PlayerPrefs.GetFloat("g", 0);
        float blue = PlayerPrefs.GetFloat("b", 0);

        spr.sprite = sData.skin[PlayerPrefs.GetInt("nr", 0)].sprites;
        spr.color = new Color(red, green, blue);
    }
}
