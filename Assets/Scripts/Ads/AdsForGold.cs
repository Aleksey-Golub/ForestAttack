using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.Advertisements;

public class AdsForGold : MonoBehaviour, IUnityAdsListener
{
    [SerializeField] private GameObject startWatchingButtom;

    private string gameId = "3544550";
    private string myPlacementId = "rewardedVideo";
    private bool testMode = true;


    void Start()
    {
        Advertisement.AddListener(this);
        Advertisement.Initialize(gameId, testMode);

        startWatchingButtom.GetComponent<Button>().onClick.AddListener(() =>
        {
            Advertisement.Show(myPlacementId);
            startWatchingButtom.SetActive(false);
        });
    }

    public void OnUnityAdsDidFinish(string placementId, ShowResult showResult)
    {
        // логика начисления награды
        if (showResult == ShowResult.Finished)
        {
            Debug.Log("Вам начислено 100 монет!");
        }
        else if(showResult == ShowResult.Skipped)
        {

        }
        else if (showResult == ShowResult.Failed)
        {

        }
    }
    public void OnUnityAdsReady(string placementId)
    {
        if (placementId == myPlacementId)
        {
            startWatchingButtom.SetActive(true);
        }
    }

    public void OnUnityAdsDidStart(string placementId)
    {
        // Н. логика остановки игры при запуске рекламы
    }

    public void OnUnityAdsDidError(string message)
    {
        // реклама завершилась с ошибкой
    }
}
