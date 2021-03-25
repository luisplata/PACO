using System;
using System.Collections;
using System.Collections.Generic;
using System.Threading.Tasks;
using UnityEngine;
using UnityEngine.Networking;
using UnityEngine.SocialPlatforms.Impl;

public class ConectionRestBellseboss
{
    public delegate void CallbackToResponse(string response); // declare delegate type
 
    protected CallbackToResponse callback; // to store the function
    public static IEnumerator GetRequest(string uri, CallbackToResponse callback)
    {
        using (UnityWebRequest webRequest = UnityWebRequest.Get(uri))
        {
            // Request and wait for the desired page.
            yield return webRequest.SendWebRequest();

            string[] pages = uri.Split('/');
            int page = pages.Length - 1;

            if (webRequest.isNetworkError)
            {
                throw new RestUtilsException($"The conexion from {uri} failed; error {webRequest.error}");
            }
            else
            {
                callback(webRequest.downloadHandler.text);
            }
        }
    }
    public static IEnumerator Upload(string uri, List<FiledForPost> parameters,Action callback)
    {
        WWWForm form = new WWWForm();
        foreach (var param in parameters)
        {
            form.AddField(param.Name, param.Value);
        }
        
        using (UnityWebRequest www = UnityWebRequest.Post(uri, form))
        {
            yield return www.SendWebRequest();

            if (www.isNetworkError || www.isHttpError)
            {
                throw new RestUtilsException($"The conexion from {uri} failed; error {www.error}");
            }
            else
            {
                callback?.Invoke();
            }
        }
    }
}