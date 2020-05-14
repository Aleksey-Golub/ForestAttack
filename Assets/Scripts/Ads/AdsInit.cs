using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Advertisements;

public class AdsInit : MonoBehaviour
{
    private string gameId = "3544550"; // Id игры в кабиненте Unity в Settings->ProjectSettings отдельно для AppStore и GooglePlay
    private bool testMode = true;

    private void Start()
    {
        Advertisement.Initialize(gameId, testMode);
        StartCoroutine(ShowBannerWhenReady());
    }

    IEnumerator ShowBannerWhenReady()
    {
        while (!Advertisement.IsReady("DownBanner"))    // string placementId
        {
            yield return new WaitForSeconds(0.5f);
        }

        Advertisement.Banner.SetPosition(BannerPosition.BOTTOM_CENTER); 

        Advertisement.Banner.Show("DownBanner");    // string placementId, ро умолчанию вверху слева
    }
}
