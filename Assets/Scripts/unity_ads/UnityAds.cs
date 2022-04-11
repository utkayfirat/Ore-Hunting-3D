using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Advertisements;

public class UnityAds : MonoBehaviour, IUnityAdsInitializationListener, IUnityAdsLoadListener
{
    private string gameId = "4699203";
    private bool testMode = false;
    private string video_placementID = "Rewarded_Android";

    void Start(){
        Advertisement.Initialize(gameId,testMode);
        LoadAds();
    }

    public void LoadAds(){
        Advertisement.Load(gameId, this);
    }

    public void OnUnityAdsAdLoaded(string adUnitId){
       Debug.Log("Ad Loaded: " + adUnitId);

        if (adUnitId.Equals(gameId)){
            Debug.Log("ON UNITY ADS AD ON UNITY ADS AD ON UNITY ADS AD ON UNITY ADS AD ON UNITY ADS AD ON UNITY ADS AD ON UNITY ADS AD ON UNITY ADS AD ");
        }

    }

    public void OnUnityAdsShowComplete(string adUnitId, UnityAdsShowCompletionState showCompletionState)
    {
        if (adUnitId.Equals(gameId) && showCompletionState.Equals(UnityAdsShowCompletionState.COMPLETED))
        {
            Debug.Log("Unity Ads Rewarded Ad Completed");
            // Grant a reward.

            // Load another ad:
            Advertisement.Load(gameId, this);
        }
    }


    public void OnUnityAdsFailedToLoad(string adUnitId, UnityAdsLoadError error, string message){
        Debug.Log($"Error loading Ad Unit {adUnitId}: {error.ToString()} - {message}");
    }

    public void OnUnityAdsShowFailure(string adUnitId, UnityAdsShowError error, string message){
        Debug.Log($"Error showing Ad Unit {adUnitId}: {error.ToString()} - {message}");
    }

    public void OnUnityAdsShowStart(string adUnitId) { }
    public void OnUnityAdsShowClick(string adUnitId) { }


    public void OnInitializationFailed(UnityAdsInitializationError error, string message){
        Debug.Log($"Unity Ads Initialization Failed: {error.ToString()} - {message}");
    }

    public void OnInitializationComplete(){
        Debug.Log("Unity Ads initialization complete.");
    }

    public void ShowVideoAd(){
        if(Advertisement.IsReady(video_placementID)){
            Advertisement.Show(video_placementID);
        }else{
            Debug.Log("Ads no ready");
        }
    }

    


}
