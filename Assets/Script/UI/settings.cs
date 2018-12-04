using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Audio;
using UnityEngine.UI;

public class settings : MonoBehaviour {

    public AudioMixer mixer;
    public Toggle checkbox;

    void Start()
    {
        if(PlayerPrefs.GetInt("fade",1)==0)
        {
            checkbox.isOn = false;
        }
        else
        {
            checkbox.isOn = true;
        }
        
    }

    public void music(float v)
    {
        mixer.SetFloat("v", v);
    }

    public void setFade(bool v)
    {
        if (v)
        {
            PlayerPrefs.SetInt("fade", 1);
        }
        else
        {
            PlayerPrefs.SetInt("fade", 0);
        }
       
    }

}
