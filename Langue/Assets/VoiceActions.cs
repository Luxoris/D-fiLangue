using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System.Linq;
using System;
using UnityEngine.SceneManagement;

#if UNITY_STANDALONE_WIN || UNITY_EDITOR_WIN
using UnityEngine.Windows.Speech;
#endif

public class VoiceActions : MonoBehaviour
{
    #if UNITY_STANDALONE_WIN || UNITY_EDITOR_WIN
    private KeywordRecognizer keywordRecognizer;
#endif
    public language language;
    public Dictionary<string, Action<string>> actions = new Dictionary<string, Action<string>>();
    public Dictionary<string, Action<string>> actionsGlobales = new Dictionary<string, Action<string>>();
    public Dictionary<string, Action<string>> actionsSprites = new Dictionary<string, Action<string>>();
    public GameObject Character;
    public UIActionContainer UI_action;
    private void Start()
    {
        //language = transform.GetComponent<language>();
        //language.lang = "FR_fr";
        //language.langToLearn = "EN_us";        
    }

    public void ChargementActions(){
        Debug.Log("Chargement des actions");
        //ajout de la liste des actions
        AjoutActionsSprite();
        AjoutActionsGlobal();

        #if UNITY_STANDALONE_WIN || UNITY_EDITOR_WIN
        keywordRecognizer = new KeywordRecognizer(language.dLanguage[language.langToLearn].Keys.ToArray());
        keywordRecognizer.OnPhraseRecognized += RecognizedSpeech;
        keywordRecognizer.Start();
        #endif

        /*foreach(string action in actions.Keys)
        {
            string tmpTraduction="";
            string tmpAction="";

            int i = 0;
            foreach(string act in language.dLanguage[language.lang].Values)
            {
                if(act == action)
                {
                    tmpTraduction = language.dLanguage[language.lang].Keys.ToArray()[i];
                    break;
                }
                i++;
            }

            i = 0;
            foreach (string act2 in language.dLanguage[language.langToLearn].Values)
            {
                if (act2 == action)
                {
                    tmpAction = language.dLanguage[language.langToLearn].Keys.ToArray()[i];
                    break;
                }
                i++;
            }

            UI_action.AjoutUIAction(tmpTraduction, language.langToLearn, tmpAction);


        }*/
        
    }

    #if UNITY_STANDALONE_WIN || UNITY_EDITOR_WIN
    private void RecognizedSpeech(PhraseRecognizedEventArgs speech)
    {
        Debug.Log(speech.text);
        actions[language.dLanguage[language.langToLearn][speech.text]].Invoke(language.dLanguage[language.langToLearn][speech.text]);
    }
    #endif
    private void Quit(string s)
    {
        //SceneManager.LoadScene("Scene");
        Application.Quit();
        
    }

    private void Forward(string s)
    {
        Character.transform.Translate(0, 0, 0.05f);
    }

    private void Back(string s)
    {
        Character.transform.Translate(0, 0, -0.05f);
    }

    private void Up(string s)
    {
        Character.transform.Translate(0, 0.05f, 0);
    }

    private void Down(string s)
    {
        Character.transform.Translate(0, -0.05f, 0);
    }

    private void Left(string s)
    {
        Character.transform.Translate(-0.05f, 0, 0);
    }

    private void Right(string s)
    {
        Character.transform.Translate(0.05f, 0, 0);
    }

    private void TurnRight(string s)
    {
        Character.transform.Rotate(0, 30, 0);
    }

    private void TurnLeft(string s)
    {
        Character.transform.Rotate(0, -30, 0);
    }

    private void Grow(string s)
    {
        Character.transform.localScale = new Vector3(Character.transform.localScale.x + 150f, Character.transform.localScale.y + 150f, Character.transform.localScale.z + 150f);
    }

    private void Shrink(string s)
    {
        Character.transform.localScale = new Vector3(Character.transform.localScale.x - 150f, Character.transform.localScale.y - 150f, Character.transform.localScale.z - 150f);
    }

    #if UNITY_STANDALONE_WIN || UNITY_EDITOR_WIN
    private void OnDestroy()
    {
        if(keywordRecognizer != null)
        {
            keywordRecognizer.Stop();
            keywordRecognizer.Dispose();
        }
    }
    #endif

    private void ChangeSprite(String action)
    {
        Character.GetComponent<CharacterCustomization>().applySprite(action);
    }

    private void AjoutActionsGlobal()
    {
        actionsGlobales.Add("forward", Forward);
        actionsGlobales.Add("up", Up);
        actionsGlobales.Add("down", Down);
        actionsGlobales.Add("back", Back);
        actionsGlobales.Add("left", Left);
        actionsGlobales.Add("right", Right);
        actionsGlobales.Add("turn right", TurnRight);
        actionsGlobales.Add("turn left", TurnLeft);
        actionsGlobales.Add("grow", Grow);
        actionsGlobales.Add("shrink", Shrink);
        actionsGlobales.Add("quit", Quit);

        actionsGlobales.ToList().ForEach(x => actions.Add(x.Key, x.Value));
    }
    private void AjoutActionsSprite()
    {
        actionsSprites.Add("remove clothes", ChangeSprite);
        actionsSprites.Add("male", ChangeSprite);
        actionsSprites.Add("female", ChangeSprite);

        actionsSprites.Add("big ears", ChangeSprite);
        actionsSprites.Add("little ears", ChangeSprite);

        actionsSprites.Add("blue eyes", ChangeSprite);
        actionsSprites.Add("brown eyes", ChangeSprite);
        actionsSprites.Add("gray eyes", ChangeSprite);
        actionsSprites.Add("green eyes", ChangeSprite);
        actionsSprites.Add("orange eyes", ChangeSprite);
        actionsSprites.Add("purple eyes", ChangeSprite);
        actionsSprites.Add("red eyes", ChangeSprite);
        actionsSprites.Add("yellow eyes", ChangeSprite);

        actionsSprites.Add("big nose", ChangeSprite);
        actionsSprites.Add("button nose", ChangeSprite);
        actionsSprites.Add("little nose", ChangeSprite);

        actionsSprites.Add("black shoes", ChangeSprite);
        actionsSprites.Add("brown shoes", ChangeSprite);
        actionsSprites.Add("maroon shoes", ChangeSprite);

        actionsSprites.Add("black hair", ChangeSprite);
        actionsSprites.Add("blond hair", ChangeSprite);
        actionsSprites.Add("blue hair", ChangeSprite);
        actionsSprites.Add("brown hair", ChangeSprite);
        actionsSprites.Add("brunette hair", ChangeSprite);
        actionsSprites.Add("dark blond hair", ChangeSprite);
        actionsSprites.Add("gold hair", ChangeSprite);
        actionsSprites.Add("gray hair", ChangeSprite);
        actionsSprites.Add("green hair", ChangeSprite);
        actionsSprites.Add("pink hair", ChangeSprite);
        actionsSprites.Add("purple hair", ChangeSprite);
        actionsSprites.Add("redhead hair", ChangeSprite);
        actionsSprites.Add("white hair", ChangeSprite);

        actionsSprites.Add("magenta pants", ChangeSprite);
        actionsSprites.Add("red pants", ChangeSprite);
        actionsSprites.Add("skirt", ChangeSprite);
        actionsSprites.Add("teal pants", ChangeSprite);
        actionsSprites.Add("white pants", ChangeSprite);

        actionsSprites.Add("brown shirt", ChangeSprite);
        actionsSprites.Add("maroon shirt", ChangeSprite);
        actionsSprites.Add("teal shirt", ChangeSprite);
        actionsSprites.Add("white shirt", ChangeSprite);

        actionsSprites.ToList().ForEach(x => actions.Add(x.Key, x.Value));

    }
}
