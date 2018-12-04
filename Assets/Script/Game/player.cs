using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class player : MonoBehaviour
{
    public float speed;
    public float upForce;
    public float leftForce;
    public float nowForce;
    public float startForce;

    [Space]
    public float difficulty;

    [Space]
    public Transform cTarget;

    public GameObject load;
    public GameObject ad;
    public GameObject pause;

    public skinData sData;

    [Space]
    public Slider s;
    public Button b;
    public GameObject dedScrean;

    Rigidbody2D r;
    Vector2 lastJump;

    bool continueInUse = false;
    bool jump = true;
    bool button = false;


    private void Start()
    {
        nowForce = startForce;

        lastJump = transform.position;

        SpriteRenderer spr = gameObject.GetComponent<SpriteRenderer>();

        float red = PlayerPrefs.GetFloat("r", 255);
        float green = PlayerPrefs.GetFloat("g", 0);
        float blue = PlayerPrefs.GetFloat("b", 0);

        spr.sprite = sData.skin[PlayerPrefs.GetInt("nr", 0)].sprites;
        spr.color = new Color(red, green, blue);

        r = gameObject.GetComponent<Rigidbody2D>();

        s.minValue = startForce/upForce;
    }



    void Update()
    {
        CameraTarget();



        float xPos = gameObject.GetComponent<Transform>().position.x;

        speed = xPos * difficulty + 1f;
        if (speed > 6)
        {
            speed = 6;
        }
        s.value = nowForce / upForce;


        if (nowForce > 20 * upForce)
        {
            ded();
        }


        if (Input.GetButtonDown("Fire1") && jump)
        {
            button = true;
        }

    }

    private void FixedUpdate()
    {
        if (jump)
        {
            nowForce += speed;

        }

        if (button)
        {
            lastJump = transform.position;
            button = false;
            jump = false;
            r.AddForce(new Vector2(leftForce, upForce * nowForce));
            nowForce = startForce;
        }

    }

    private void OnCollisionEnter2D(Collision2D collision)
    {
        jump = true;
    }

    public void ded()
    {
        Time.timeScale = 0;
        jump = false;
        nowForce = startForce;

        dedScrean.SetActive(true);
        ad.SendMessage("desAd");
        if (continueInUse)
        {
            b.interactable = false;
        }
    }

    void saveScore()
    {
        pointCounter p = gameObject.GetComponent<pointCounter>();
        PlayerPrefs.SetInt("SumaOfPt", PlayerPrefs.GetInt("SumaOfPt", 0) + p.point);
    }

    public void end()
    {
        saveScore();
        ad.SendMessage("desAd");
        Time.timeScale = 1;
        ad.SendMessage("loadlewel", "menu");
    }

    public void replay()
    {
        saveScore();
        Time.timeScale = 1;
        ad.SendMessage("loadlewel", "game");
    }

    public void CameraTarget()
    {
        if (cTarget != null)
        {
            if (jump)
            {
                cTarget.position = transform.position;
            }
            else
            {
                cTarget.position = new Vector2(transform.position.x, cTarget.position.y);
            }

        }
    }

    public void pasue()
    { 
        Time.timeScale = 0;
        pause.SetActive(true);
    }

    public void EndPause()
    {

        Time.timeScale = 1;
        pause.SetActive(false);
    }

    public void con()
    {
        Time.timeScale = 1;
        dedScrean.SetActive(false);
        button = false;
        r.velocity = Vector2.zero;
        nowForce = startForce;
        float x = ((int)(lastJump.x / 2))*2;
        transform.position=new Vector2(x,lastJump.y);

        ad.SendMessage("ShowBanner");

        jump = true;
        continueInUse = true;

        //pasue();
    }

}
