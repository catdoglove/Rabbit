﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using GoogleMobileAds.Api;

public class ShowAdmob : MonoBehaviour
{
    //보상형 전면 광고
    private RewardedInterstitialAd rewardedInterstitialAd;
    AdRequest request;
    //영상
    private RewardedAd rewardedAd;
    string adUnitIdvideo;


    public GameObject GM;

    // Start is called before the first frame update
    private BannerView bannerView;
    void Start()
    {
        //리워드
#if UNITY_ANDROID
        adUnitIdvideo = "ca-app-pub-9179569099191885/8977258271"; // 바꿈테스트 ca-app-pub-3940256099942544/5224354917
#elif UNITY_IPHONE
            adUnitIdvideo = "ca-app-pub-3940256099942544/1712485313";
#else
        adUnitIdvideo = "unexpected_platform";
#endif

        this.rewardedAd = new RewardedAd(adUnitIdvideo);

        // Called when the user should be rewarded for watching a video.
        this.rewardedAd.OnUserEarnedReward += HandleUserEarnedReward;
        // Called when the ad is closed.
        this.rewardedAd.OnAdClosed += HandleRewardBasedVideoClosed;

        RequestRewardedVideo();
        
        // Initialize the Google Mobile Ads SDK.
        MobileAds.Initialize(initStatus => { });

        this.RequestBanner();

    }

    private void OnDisable()
    {
        rewardedAd.OnUserEarnedReward -= HandleUserEarnedReward;
        rewardedAd.OnAdClosed -= HandleRewardBasedVideoClosed;
    }


    //동영상
    private void RequestRewardedVideo()
    {
        // Create an empty ad request.
        request = new AdRequest.Builder().Build();
        // Load the rewarded video ad with the request.
        this.rewardedAd.LoadAd(request);
    }

    //시청보상
    public void HandleUserEarnedReward(object sender, Reward args)
    {
        GM.GetComponent<subTextgame>().SetData();
        PlayerPrefs.SetInt("martialCount",  PlayerPrefs.GetInt("martialCount", 0) + PlayerPrefs.GetInt("martialCount", 0));
        GM.GetComponent<subTextgame>().doubleReward();
        PlayerPrefs.Save();
        //PlayerPrefs.SetInt("blad", 1);

    }

    //동영상닫음
    private void HandleRewardBasedVideoClosed(object sender, System.EventArgs args)
    {
        RequestRewardedVideo();
        //blackimg.SetActive(false);
        //Toast_obj.SetActive(true);
        //PlayerPrefs.SetInt("adrunout", 0);
        //Toast_txt.text = "Number of Talk was restored to 5.";
        //StartCoroutine("ToastImgFadeOut");
    }

    //동영상 시청
    public void showAdmobVideo()
    {
        if (this.rewardedAd.IsLoaded())
        {
            //blackimg.SetActive(true);
            this.rewardedAd.Show();
        }
        else
        {
            GM.GetComponent<subTextgame>().AdToast();
        }
    }



    private void RequestBanner()
    {
#if UNITY_ANDROID
        string adUnitId = "ca-app-pub-3940256099942544/6300978111";
#elif UNITY_IPHONE
            string adUnitId = "ca-app-pub-3940256099942544/2934735716";
#else
            string adUnitId = "unexpected_platform";
#endif

        // Clean up banner before reusing
        if (bannerView != null)
        {
            bannerView.Destroy();
        }

        // Create a 320x50 banner at the top of the screen.
        this.bannerView = new BannerView(adUnitId, AdSize.SmartBanner, AdPosition.Bottom);


        // Create an empty ad request.
        AdRequest request = new AdRequest.Builder().Build();

        // Load the banner with the request.
        this.bannerView.LoadAd(request);
    }
    public void DestroyBannerAd()
    {
        if (bannerView != null)
        {
            bannerView.Destroy();
        }
    }
}
