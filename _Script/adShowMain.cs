using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using GoogleMobileAds.Api;

public class adShowMain : MonoBehaviour
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
        PlayerPrefs.SetInt("hearti", 3);
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
            GM.GetComponent<MainBtnEvt>().CloseAds();
        }
        else
        {
            GM.GetComponent<MainBtnEvt>().AdToast();
        }
    }
}
