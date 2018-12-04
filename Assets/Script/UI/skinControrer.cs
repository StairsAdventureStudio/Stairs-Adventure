using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;

public class skinControrer : MonoBehaviour {

    public skinData data;
    public int nr;
    public Image i;
    public GameObject o;
    
    public TextMeshProUGUI opis;
    public GameObject buttonO;
    public GameObject backButtonO;

    public Transform startPosT;
    public Vector2 move;
    public Transform parent;

    private void Start()
    {
        nr=PlayerPrefs.GetInt("nr",0);
        controlSkin(nr);
        spawn(startPosT.position);

    }

    public void spawn(Vector2 sPos)
    {
        
        Vector2 lastPos = sPos;
        int x = 0;

        foreach(skinData.skins iD in data.skin)
        {
            Instantiate(backButtonO, lastPos, Quaternion.identity).GetComponent<Transform>().SetParent(parent); 
            GameObject now = Instantiate(buttonO, lastPos, Quaternion.identity);
            now.GetComponent<Transform>().SetParent(parent);
            lastPos += move;
            Image img = now.GetComponent<Image>();
            now.SendMessage("setNumber",x);
            img.sprite = iD.sprites;
            img.color = new Color(iD.colors.r, iD.colors.g, iD.colors.b);
            x++;
        }

    }

    public void button(int v)
    {
        Debug.Log(v);
        nr = v;

        controlSkin(nr);

    }

    public void Desplay()
    {
        i.color = new Color(data.skin[nr].colors.r, data.skin[nr].colors.g, data.skin[nr].colors.b);
        i.sprite = data.skin[nr].sprites;
    }

    public void controlSkin(int index)
    {
        if (tests.ok(data.skin[index].testIndex, data.skin[index].testValue) == 1)
        {
            PlayerPrefs.SetInt("nr", index);
            PlayerPrefs.SetFloat("r", data.skin[index].colors.r);
            PlayerPrefs.SetFloat("g", data.skin[index].colors.g);
            PlayerPrefs.SetFloat("b", data.skin[index].colors.b);
            opis.text = "";
            o.SetActive(false);
        }
        else
        {
            o.SetActive(true);
            opis.text = data.skin[index].opis;
        }
        Desplay();
    }


}
