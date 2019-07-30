using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Advertisements;
public class TestUnityAd : MonoBehaviour, IUnityAdsListener
{
#if UNITY_IOS
    private const string GAME_ID = "3220341";
#elif UNITY_ANDROID
    private const string GAME_ID = "3220340";
#else
    private const string GAME_ID = "";
#endif
    private void Awake()
    {
        Advertisement.AddListener(this);
    }

    private void OnGUI()
    {
        if (Button("Init"))
        {
            Advertisement.Initialize(GAME_ID,true);
        }
        GUILayout.Label("inited:"+Advertisement.isInitialized,"box");
        if (!Advertisement.isInitialized)
        {
            return;
        }
        GUILayout.Label("isShowing" + Advertisement.isShowing);
        GUILayout.Label("chapin"+Advertisement.GetPlacementState("chapin_levelend"));
        GUILayout.Label("jili" + Advertisement.GetPlacementState("jili_levelend"));
        if (Button("load chapin"))
        {
            Advertisement.Load("chapin_levelend");
        }
        if (Button("load jili"))
        {
            Advertisement.Load("jili_levelend");
        }
        if (Button("chapin"))
        {
            Advertisement.Show("chapin_levelend");
        }

        if (Button("jili"))
        {
            Advertisement.Show("jili_levelend");
        }
        if (Button("test www"))
        {
            StartCoroutine(testURL("www.baidu.com"));
        }
    }
    private IEnumerator testURL(string url)
    {
        WWW w = new WWW(url);
        yield return w;
        Debug.Log(w.text);
    }
    private static bool Button(string p)
    {
        return GUILayout.Button(p, GUILayout.Width(100), GUILayout.Height(100));
    }

    void IUnityAdsListener.OnUnityAdsReady(string placementId)
    {
        Debug.Log("-->>OnUnityAdsReady:" + placementId);
    }

    void IUnityAdsListener.OnUnityAdsDidError(string message)
    {
        Debug.Log("-->>OnUnityAdsDidError:" + message);
    }

    void IUnityAdsListener.OnUnityAdsDidStart(string placementId)
    {
        Debug.Log("-->>OnUnityAdsDidStart:" + placementId);
    }

    void IUnityAdsListener.OnUnityAdsDidFinish(string placementId, ShowResult showResult)
    {
        Debug.Log("-->>OnUnityAdsDidFinish:" + placementId);
    }
}
