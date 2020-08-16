using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Monetization;

public class Ads : MonoBehaviour
{
    public static Ads instance;
    private string store_id = "3735921";
    private string banner_ad = "ad1";
    private string video_ad = "video";
    private void Awake()
    {
        if(instance!=null)
        {
            Destroy(gameObject);

        }
        else
        {
            instance = this;
            DontDestroyOnLoad(gameObject);
        }
    }
    // Start is called before the first frame update
    void Start()
    {
        Monetization.Initialize(store_id, true);
    }

    // Update is called once per frame
    void Update()
    {
       /*if (Input.GetKeyDown(KeyCode.E))
        {
            if (Monetization.IsReady(video_ad))
            {
                ShowAdPlacementContent ad = null;
                ad = Monetization.GetPlacementContent(video_ad) as ShowAdPlacementContent;
                if (ad != null)
                    ad.Show();
            }
        }
        if (Input.GetKeyDown(KeyCode.T))
        {
            if (Monetization.IsReady(banner_ad))
            {
                ShowAdPlacementContent ad = null;
                ad = Monetization.GetPlacementContent(banner_ad) as ShowAdPlacementContent;
                if (ad != null)
                    ad.Show();
            }
        }*/
    }
    public void ShowVideoOrInterstitialAd()
    {

        if (Monetization.IsReady(video_ad))
        {
            ShowAdPlacementContent ad = null;
            ad = Monetization.GetPlacementContent(video_ad) as ShowAdPlacementContent;
            if (ad != null)
                ad.Show();
        }
    }
    public void ShowBannerAd()
    {
        if (Monetization.IsReady(banner_ad))
        {
            ShowAdPlacementContent ad = null;
            ad = Monetization.GetPlacementContent(banner_ad) as ShowAdPlacementContent;
            if (ad != null)
                ad.Show();
        }
    }
}
