using System.Collections;
using UnityEngine;
using UnityEngine.Advertisements;
using UnityEngine.Monetization;



public class Ads : MonoBehaviour {

    public GameObject play;
    public GameObject loader;
    [Space]
    public GameObject Error;
    string scene = null;
    public bool testMode = false;
    bool bannerAd = false;


    void Start()
    {
        Monetization.Initialize(idGame,testMode);
        Advertisement.Initialize(idGame,testMode);
        //ShowBanner();
    }

    
    public void ShowBanner()
    {
        StartCoroutine(BannerWhenReady());
    }
    
    public void Show()
    {
        if (Monetization.IsReady("rewardedVideo"))
        {
            
            ShowAdPlacementContent ad = null;
            ad = Monetization.GetPlacementContent("rewardedVideo") as ShowAdPlacementContent;

            if (ad != null)
            {
                ad.Show(checkAd);
            }
            else
            {
                checkAd(UnityEngine.Monetization.ShowResult.Failed);
            }

        }
        else
        {
            checkAd(UnityEngine.Monetization.ShowResult.Failed);
        }
    }

    public void loadlewel(string s)
    {
        scene = s;
        if (Monetization.IsReady("video"))
        {
            ShowAdPlacementContent ad = null;
            ad = Monetization.GetPlacementContent("video") as ShowAdPlacementContent;

            if (ad != null)
            {
                ad.Show(afterAdLoad);
            }
            else
            {
                afterAdLoad(UnityEngine.Monetization.ShowResult.Failed);
            }
        }
        else
        {
            afterAdLoad(UnityEngine.Monetization.ShowResult.Failed);
        }

    }
    
    void afterAdLoad(UnityEngine.Monetization.ShowResult r)
    { 

        if (loader != null && scene != null)
        {
            loader.SendMessage("loadlewel", scene);
        }
    }

    void checkAd(UnityEngine.Monetization.ShowResult r)
    {
        switch (r)
        {
            case UnityEngine.Monetization.ShowResult.Finished:
                {
                    play.SendMessage("con");
                }
                break;
            case UnityEngine.Monetization.ShowResult.Skipped:
                {
                    Fail();
                }
                break;
            case UnityEngine.Monetization.ShowResult.Failed:
                {
                    Fail();
                }
                break;
        }
    }

    void Fail()
    {
        Error.SetActive(true);
    }



    IEnumerator BannerWhenReady()
    {
        bannerAd = true;
        while (!Advertisement.IsReady("baner"))
        {
            Debug.Log("Ad is Loading...");
            yield return new WaitForSeconds(2f);
        }
        if(bannerAd)
        {
            Advertisement.Banner.Show("baner");
        }
       

    }


    public void desAd()
    {
        bannerAd = false;
        Advertisement.Banner.Hide(true);
    }

}
