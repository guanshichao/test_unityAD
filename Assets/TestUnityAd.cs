using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Advertisements;
public class TestUnityAd : MonoBehaviour {
    private const string GAME_ID = "b055baa2-75b8-4c12-9ed6-3746cbc7de2f";

    private void OnGUI()
    {
        if (Button("Init"))
        {
            Advertisement.Initialize(GAME_ID);
        }
        GUILayout.Label("inited:"+Advertisement.isInitialized,"box");
        if (Button("chapin"))
        {
            Advertisement.Show("chapin_levelend");
        }

        if (Button("jili"))
        {
            Advertisement.Show("jili_levelend");
        }
    }

    private static bool Button(string p)
    {
        return GUILayout.Button(p, GUILayout.Width(100), GUILayout.Height(100));
    }
}
