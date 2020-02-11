using System.Collections;
using System.Collections.Generic;
using UnityEngine.UI;
using UnityEngine;

public class UIActionContainer : MonoBehaviour
{
    public GameObject item_actions;
    public GameObject VoiceActions;
    public GameObject sw;

    private List<GameObject> l_uiActions= new List<GameObject>();
    private float Pos_x;
    private float Tmp_Pos_x;

    private bool isScorllViewCreated;
    private GameObject scrollView;
    private GameObject UI_Content;

    // Start is called before the first frame update
    void Start()
    {
        scrollView = GameObject.Find("Scroll View");
        UI_Content = scrollView.transform.Find("Viewport").transform.Find("Content").gameObject;
        l_uiActions = new List<GameObject>();
        //UI_Content.GetComponent<RectTransform>().anchoredPosition = new Vector3(UI_Content.GetComponent<RectTransform>().anchoredPosition.x, 0f);
    }

    public void VideUIActions()
    {
        Pos_x = 0;
        Tmp_Pos_x = 0;
        foreach(GameObject go in l_uiActions)
        {
            Destroy(go);

        }
        l_uiActions.Clear();
        UI_Content.GetComponent<RectTransform>().sizeDelta = new Vector2(0f, UI_Content.GetComponent<RectTransform>().sizeDelta.y);

        //Destroy(scrollView);
        //isScorllViewCreated = false;
    }

    public void AjoutUIAction(string traduction, string langue, string action, float offset_x = 0f)
    {
        Vector3 monVecteur = new Vector3(0, 0, 0);
        if (!isScorllViewCreated)
        {
            scrollView = GameObject.Find("Scroll View");
            UI_Content = scrollView.transform.Find("Viewport").transform.Find("Content").gameObject;
            /*scrollView = Instantiate(sw, monVecteur, Quaternion.identity, transform.parent.transform);
            scrollView.GetComponent<RectTransform>().offsetMin = new Vector2(0, 200);
            scrollView.GetComponent<RectTransform>().offsetMax = new Vector2(0, 400);
            
            UI_Content.GetComponent<RectTransform>().anchoredPosition = new Vector3(UI_Content.GetComponent<RectTransform>().anchoredPosition.x, 0f);
            scrollView.GetComponent<RectTransform>().localPosition = new Vector3(scrollView.GetComponent<RectTransform>().localPosition.x,scrollView.GetComponent<RectTransform>().localPosition.y, 0);*/
            isScorllViewCreated = true;
        }
        float width;

        //ajout du message        
        GameObject newUIAction = Instantiate(item_actions, monVecteur, Quaternion.identity, UI_Content.transform);
        RectTransform t = newUIAction.GetComponent<RectTransform>();

        l_uiActions.Add(newUIAction);
        //float posX = ((-t.offsetMin.x + t.offsetMax.x) * 0.5f);
        float posY = -((-t.offsetMin.y + t.offsetMax.y) * 0.5f);
        //newUIAction.GetComponentInChildren<Text>().text = Message;
        newUIAction.transform.Find("traduction").GetComponent<Text>().text = traduction;
        newUIAction.transform.Find("action").GetComponent<Text>().text = action;
        newUIAction.transform.Find("synthese").GetComponent<Button>().onClick.AddListener(delegate { VoiceActions.GetComponent<AudioSynthesis>().syntheseVocale(action,langue); });

        /*//augmentation de la taille du message en fonction de la taille du text.
        height = LayoutUtility.GetPreferredHeight(newUIAction.transform.GetChild(0).GetComponent<RectTransform>());
        height += 16;*/

        width = newUIAction.GetComponent<RectTransform>().sizeDelta.x;
        //newUIAction.GetComponent<RectTransform>().sizeDelta = new Vector2(newUIAction.GetComponent<RectTransform>().sizeDelta.x, height);


        //augmente la taille du content
        this.AgrandirContent(((width + 8)));

        //incrémentation de la taille pos Y de l'instance

        this.Pos_x += this.Tmp_Pos_x + ((width + 8) / 2) + offset_x;
        this.Tmp_Pos_x = ((width + 8) / 2);

        //modifie position message
        newUIAction.GetComponent<RectTransform>().anchoredPosition = new Vector3(this.Pos_x, posY, 0);
        newUIAction.GetComponent<RectTransform>().localPosition = new Vector3(newUIAction.GetComponent<RectTransform>().localPosition.x, newUIAction.GetComponent<RectTransform>().localPosition.y, 1);
    }


    public void AgrandirContent(float valeur)
    {
        UI_Content.GetComponent<RectTransform>().sizeDelta = new Vector2(UI_Content.GetComponent<RectTransform>().sizeDelta.x + valeur, UI_Content.GetComponent<RectTransform>().sizeDelta.y);
        //UI_Content.GetComponent<RectTransform>().anchoredPosition = new Vector3(UI_Content.GetComponent<RectTransform>().anchoredPosition.x, UI_Content.GetComponent<RectTransform>().anchoredPosition.y);
    }
}