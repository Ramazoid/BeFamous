using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Networking;

public class Loader : MonoBehaviour
{
    public string ServerURL = "http://dev-mob.bfa.games/hamsters//chests/lut_test";
    public string ImageURL = "http://92.43.187.41/BeFamous/items/";

    internal void LoadJSON(Action<string> parseChest)
    {
        StartCoroutine(GetRequestText(ServerURL, parseChest));
    }
    IEnumerator GetRequestText(string url, Action<string> parseChest)
    {
        using (UnityWebRequest req = UnityWebRequest.Get(url))
        {
            yield return req.SendWebRequest();

            switch (req.result)
            {
                case UnityWebRequest.Result.Success:
                    parseChest(req.downloadHandler.text);
                    break;
                default:
                    throw new Exception($"Server error at Url[{url}");
            }
        }
    }

    internal void LoadPNG(string url, Action<Texture2D> callback)
    {
        StartCoroutine(GetRequestPNG(url, callback));
    }
    IEnumerator GetRequestPNG(string url, Action<Texture2D> callback)
    {
        using (UnityWebRequest req = UnityWebRequestTexture.GetTexture(ImageURL + url))
        {
            yield return req.SendWebRequest();

            if (req.result == UnityWebRequest.Result.Success)
            {
                Texture2D result = DownloadHandlerTexture.GetContent(req);
                callback(result);
            }
            else
                throw new Exception($"Server error at Url[{url}");
        }
    }
}

