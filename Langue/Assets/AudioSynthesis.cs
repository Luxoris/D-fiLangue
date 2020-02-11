using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Networking;
using UnityEngine.UI;

public class AudioSynthesis : MonoBehaviour
{
    public AudioSource _audio;
    private UnityWebRequest uwr;
    private WWW URL;
    private bool isPlayingSound=false;
    private bool isDownloadingSound=false;
    private string tmpSoundPath;
    private Button btn;

    public void syntheseVocale(string text, string langue)
    {
        Debug.Log("Début de la synthèse vocale");
        tmpSoundPath = Application.persistentDataPath + "/" + text +"&"+ langue + ".mp3";
        //GameObject.Find("Debug").GetComponent<Text>().text += tmpSoundPath;
        if (!System.IO.File.Exists(tmpSoundPath)){
            //GameObject.Find("Debug").GetComponent<Text>().text += "Téléchargement du son.";
            StartCoroutine(DownloadTheAudio(text, langue));
            isDownloadingSound = true;
        }
        else
        {
            StartCoroutine(LoadAudio(tmpSoundPath));
            //GameObject.Find("Debug").GetComponent<Text>().text += "Chargement du son depuis la mémoire interne.";
        }
        
    }
    
    IEnumerator DownloadTheAudio(string text, string langue)
    {
        string url = "https://translate.google.com/translate_tts?ie=UTF-8&total=1&idx=0&textlen=32&client=tw-ob&q="+text+"&tl="+langue;
        uwr = new UnityWebRequest(url, UnityWebRequest.kHttpVerbGET);
        string path = tmpSoundPath;
        uwr.downloadHandler = new DownloadHandlerFile(path);
        yield return uwr.SendWebRequest();
        if (uwr.isNetworkError || uwr.isHttpError)
            Debug.LogError(uwr.error);
        else
            Debug.Log("File successfully downloaded and saved to " + path);
    }

    IEnumerator LoadAudio(string path)
    {
        #if UNITY_ANDROID
        URL = new WWW("file://"+path);
        #endif
        #if UNITY_STANDALONE_WIN || UNITY_EDITOR_WIN
        URL = new WWW("file:///" + path);
        #endif

        yield return URL;

        _audio.clip = URL.GetAudioClip(false, true, AudioType.MPEG);
       
        Debug.Log("Play the audio file from path :" + path);
        //GameObject.Find("Debug").GetComponent<Text>().text += "Chargement reussie, lecture :";
        isPlayingSound = true;
    }

    private void Update()
    {
        if ( isDownloadingSound &&  uwr.isDone)
        {
            //GameObject.Find("Debug").GetComponent<Text>().text += "Chargement du son après téléchargement.";
            StartCoroutine(LoadAudio(tmpSoundPath));
            isDownloadingSound = false;
        }
        if( isPlayingSound && URL.isDone)
        {
            _audio.Play();
            isPlayingSound = false;
        }
    }


    public void TaskOnClick()
    {
        //GameObject.Find("Debug").GetComponent<Text>().text += "Clique";
        syntheseVocale("Croquette est un kangourou.", "FR_fr");
        
    }
}
