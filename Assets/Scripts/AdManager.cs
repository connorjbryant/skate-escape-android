using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System;
using UnityEngine.UI;
using GoogleMobileAds.Api;

public class AdManager : MonoBehaviour
{
    public Button button;
    public Button button2;
    public Button button3;

    private string APP_ID = "ca-app-pub-9500067308309897~4863487598";

    private BannerView bannerAD;
    private InterstitialAd interstitialAd;
    private RewardBasedVideoAd rewardVideoAd;

    // Start is called before the first frame update
    void Start()
    {
        //this is when you publish your app
        MobileAds.Initialize(APP_ID);

        RequestBanner();
        RequestInterstitial();
        RequestVideoAD();
    }

    // Update is called once per frame
    void RequestBanner()
    {
        string banner_ID = "ca-app-pub-9500067308309897/4972418369";
        bannerAD = new BannerView(banner_ID, AdSize.SmartBanner, AdPosition.Top);

        //FOR REAL APP
        AdRequest adRequest = new AdRequest.Builder().Build();

        //FOR TESTING
        //AdRequest adRequest = new AdRequest.Builder().AddTestDevice("33BE2250B43518CCDA7DE426D04EE231").Build();

        bannerAD.LoadAd(adRequest);


    }

    void RequestInterstitial()
    {
        string interstitial_ID = "ca-app-pub-9500067308309897/3659336695";
        interstitialAd = new InterstitialAd(interstitial_ID);

        //FOR REAL APP
        AdRequest adRequest = new AdRequest.Builder().Build();

        //FOR TESTING
        //AdRequest adRequest = new AdRequest.Builder().AddTestDevice("33BE2250B43518CCDA7DE426D04EE231").Build();

        bannerAD.LoadAd(adRequest);
    }

    void RequestVideoAD()
    {
        string video_ID = "ca-app-pub-9500067308309897/3334783508";
        rewardVideoAd = RewardBasedVideoAd.Instance;

        //FOR REAL APP
        AdRequest adRequest = new AdRequest.Builder().Build();

        //FOR TESTING
        //AdRequest adRequest = new AdRequest.Builder().AddTestDevice("33BE2250B43518CCDA7DE426D04EE231").Build();

        rewardVideoAd.LoadAd(adRequest, video_ID);
    }

    public void Display_Banner()
    {
        bannerAD.Show();
        PermanentUI.perm.coins += 10;
        PermanentUI.perm.coinsText.text = PermanentUI.perm.coins.ToString();
        GetComponent<Image>().color = Color.yellow;
    }

    public void Display_InterstitialAD()
    {
        if(interstitialAd.IsLoaded())
        {
            interstitialAd.Show();
            PermanentUI.perm.coins += 10;
            PermanentUI.perm.coinsText.text = PermanentUI.perm.coins.ToString();
            GetComponent<Image>().color = Color.yellow;
        }
    }

    public void Display_Reward_Video()
    {
        if(rewardVideoAd.IsLoaded())
        {
            rewardVideoAd.Show();
            PermanentUI.perm.coins += 10;
            PermanentUI.perm.coinsText.text = PermanentUI.perm.coins.ToString();
            GetComponent<Image>().color = Color.yellow;
        }
    }

    //Handle events
    public void HandleOnAdLoaded(object sender, EventArgs args)
    {
        //ad is loaded
        Display_Banner();
        PermanentUI.perm.coins += 10;
        PermanentUI.perm.coinsText.text = PermanentUI.perm.coins.ToString();
    }

    public void HandleOnAdFailedToLoad(object sender, AdFailedToLoadEventArgs args)
    {
        //ad failed to load load it again
        RequestBanner();
    }

    public void HandleOnAdOpened(object sender, EventArgs args)
    {
        MonoBehaviour.print("HandleAdOpened event received");
    }

    public void HandleOnAdClosed(object sender, EventArgs args)
    {
        MonoBehaviour.print("HandleAdClosed event received");
        PermanentUI.perm.coins += 10;
        PermanentUI.perm.coinsText.text = PermanentUI.perm.coins.ToString();
    }

    public void HandleOnAdLeavingApplication(object sender, EventArgs args)
    {
        MonoBehaviour.print("HandleAdLeavingApplication event received");
    }

    void HandleBannerADEvents(bool subscribe)
    {
        if (subscribe)
        {
            // Called when an ad request has successfully loaded.
            bannerAD.OnAdLoaded += HandleOnAdLoaded;
            // Called when an ad request failed to load.
            bannerAD.OnAdFailedToLoad += HandleOnAdFailedToLoad;
            // Called when an ad is shown.
            bannerAD.OnAdOpening += HandleOnAdOpened;
            // Called when the ad is closed.
            bannerAD.OnAdClosed += HandleOnAdClosed;
            // Called when the ad click caused the user to leave the application.
            bannerAD.OnAdLeavingApplication += HandleOnAdLeavingApplication;
        }
        else
        {
            // Called when an ad request has successfully loaded.
            bannerAD.OnAdLoaded -= HandleOnAdLoaded;
            // Called when an ad request failed to load.
            bannerAD.OnAdFailedToLoad -= HandleOnAdFailedToLoad;
            // Called when an ad is shown.
            bannerAD.OnAdOpening -= HandleOnAdOpened;
            // Called when the ad is closed.
            bannerAD.OnAdClosed -= HandleOnAdClosed;
            // Called when the ad click caused the user to leave the application.
            bannerAD.OnAdLeavingApplication -= HandleOnAdLeavingApplication;
        }
        

    }

    void OnEnable()
    {
        HandleBannerADEvents(true);
    }

    void OnDisable()
    {
        HandleBannerADEvents(false);
    }
}
