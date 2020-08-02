
using UnityEngine;
using AppodealAds.Unity.Api;
using AppodealAds.Unity.Common;

public class AppManager : MonoBehaviour, IInterstitialAdListener, INonSkippableVideoAdListener
{
    private const string APP_KEY = "4de183cdb2fab1a5c652004528df9ec47ef3894bd5ae881d";
    private void Start()
    {
        Initialize(true);
    }

    private void Initialize(bool isTesting)
    {
        Appodeal.setTesting(isTesting);
        Appodeal.muteVideosIfCallsMuted(true);
        Appodeal.initialize(APP_KEY, Appodeal.INTERSTITIAL | Appodeal.NON_SKIPPABLE_VIDEO);
    }

    public void ShowImInterstitial()
    {
        if (Appodeal.isLoaded(Appodeal.INTERSTITIAL))
            Appodeal.show(Appodeal.INTERSTITIAL);
    }
    public void ShowImNonSkipable()
    {
        if (Appodeal.isLoaded(Appodeal.NON_SKIPPABLE_VIDEO))
            Appodeal.show(Appodeal.NON_SKIPPABLE_VIDEO);
    }
#region Interstittial
    public void onInterstitialLoaded(bool isPrecache)
    {
        //загружена межстраничная реклама
    }

    public void onInterstitialFailedToLoad()
    {
        //ошибка при загрузке межстр рекламы
    }

    public void onInterstitialShowFailed()
    {
        //ошибка показа межстраничной рекламы
    }

    public void onInterstitialShown()
    {
        //меж страничная реклама показана
    }

    public void onInterstitialClosed()
    {
        //межстраничная реклама закрыта
    }

    public void onInterstitialClicked()
    {
        //клик по межстраничной рекламе
    }

    public void onInterstitialExpired()
    {
        //межстраничная реклама закончилась
    }
#endregion
#region Reward
    public void onNonSkippableVideoLoaded(bool isPrecache)
    {
    }

    public void onNonSkippableVideoFailedToLoad()
    {
    }

    public void onNonSkippableVideoShowFailed()
    {
    }

    public void onNonSkippableVideoShown()
    {
    }

    public void onNonSkippableVideoFinished()
    {
    }

    public void onNonSkippableVideoClosed(bool finished)
    {
    }

    public void onNonSkippableVideoExpired()
    {
    }
#endregion
}