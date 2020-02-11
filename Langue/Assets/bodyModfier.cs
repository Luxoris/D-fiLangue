using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class bodyModfier : MonoBehaviour
{
    public string Path;
    public string Sexe;
    public string Body;
    public string imgFrame;


    // Start is called before the first frame update
    void Start()
    {
        Path = Application.dataPath + "/Resources/Sprite/";
        imgFrame = "0";
        Sexe = "";
        Body = "";

        setSexe("male");
    }

    public void setSexe(string sexe)
    {
        Sexe = sexe;
        string path = Path + "/body" + "/" + sexe + "/light";
        gameObject.GetComponent<SpriteRenderer>().sprite = Resources.Load(path, typeof(Sprite)) as Sprite;
        //gameObject.transform.FindChild()
    }
}
