using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Networking;
using UnityEngine.UI;
[RequireComponent(typeof(RawImage))]
public class Test : MonoBehaviour
{
    
    public RawImage img;
    public string imageurl = null;
    private void Awake()
    {
        img = GetComponent<RawImage>();
    }

    // Start is called before the first frame update
    void Start()
    {
        StartCoroutine(GetTexture(img));
    }

    IEnumerator GetTexture(RawImage img)
    {
       
        UnityWebRequest www = UnityWebRequestTexture.GetTexture(imageurl);
        yield return www.SendWebRequest();
        if (www.result != UnityWebRequest.Result.Success)
        {
            Debug.Log(www.error);
        }
        else
        {
            img.texture = ((DownloadHandlerTexture)www.downloadHandler).texture;
        }
    }
}