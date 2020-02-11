using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class ReceiveResult : MonoBehaviour {
    public GameObject debugText;
    private VoiceActions va;
	// Use this for initialization
	void Start () {
        va = gameObject.GetComponent<VoiceActions>();
        //GameObject.Find("Text").GetComponent<Text>().text = "You need to be connected to Internet";
    }
	
    void onActivityResult(string recognizedText){
        char[] delimiterChars = {'~'};
        string[] result = recognizedText.Split(delimiterChars);

        debugText.GetComponent<Text>().text += recognizedText;
        foreach (string res in result)
        {
            try
            {
                va.actions[va.language.dLanguage[va.language.langToLearn][res.ToLower()]].Invoke(va.language.dLanguage[va.language.langToLearn][res.ToLower()]);
                //va.actions[res.ToLower()].Invoke(res.ToLower());
                break;
            }
            catch(KeyNotFoundException e)
            {
                try
                {
                    va.actions[va.language.dLanguage[va.language.langToLearn][res]].Invoke(va.language.dLanguage[va.language.langToLearn][res]);
                }
                catch(KeyNotFoundException f)
                {
                    Debug.Log(e.Message +"//"+ f.Message);
                } 
            }
        }
        

    }

	// Update is called once per frame
	void Update () {
		
	}
}
