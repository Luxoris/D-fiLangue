using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System.Linq;

public class CharacterCustomization : MonoBehaviour
{
    public UIActionContainer UIAContainer;
    public Sprite f_body;
    public Sprite m_body;
    public List<Sprite> f_ears;
    public List<Sprite> m_ears;
    public List<Sprite> f_eyes;
    public List<Sprite> m_eyes;
    public List<Sprite> f_nose;
    public List<Sprite> m_nose;
    public List<Sprite> f_feet;
    public List<Sprite> m_feet;
    public List<Sprite> f_hair;
    public List<Sprite> m_hair;
    public List<Sprite> f_legs;
    public List<Sprite> m_legs;
    public List<Sprite> f_torso;
    public List<Sprite> m_torso;
    private List<Sprite> bodies;

    public Dictionary<string, Sprite> f_sprite;
    public Dictionary<string, Sprite> m_sprite;
    private bool male;


    private language l;



    // Start is called before the first frame update
    void Start()
    {
        bodies = new List<Sprite>();
        bodies.Add(f_body);
        bodies.Add(m_body);

        l = GameObject.Find("VoiceActions").GetComponent<language>();
        male = true;
        m_sprite = new Dictionary<string, Sprite>();
        m_sprite.Add("female", f_body);
        m_sprite.Add("male", m_body);
        m_sprite.Add("big ears", m_ears[0]);
        m_sprite.Add("little ears", m_ears[1]);

        m_sprite.Add("blue eyes", m_eyes[0]);
        m_sprite.Add("brown eyes", m_eyes[1]);
        m_sprite.Add("gray eyes", m_eyes[2]);
        m_sprite.Add("green eyes", m_eyes[3]);
        m_sprite.Add("orange eyes", m_eyes[4]);
        m_sprite.Add("purple eyes", m_eyes[5]);
        m_sprite.Add("red eyes", m_eyes[6]);
        m_sprite.Add("yellow eyes", m_eyes[7]);

        m_sprite.Add("big nose", m_nose[0]);
        m_sprite.Add("button nose", m_nose[1]);
        m_sprite.Add("little nose", m_nose[2]);

        m_sprite.Add("black shoes", m_feet[0]);
        m_sprite.Add("brown shoes", m_feet[1]);
        m_sprite.Add("maroon shoes", m_feet[2]);

        m_sprite.Add("black hair", m_hair[0]);
        m_sprite.Add("blond hair", m_hair[1]);
        m_sprite.Add("blue hair", m_hair[2]);
        m_sprite.Add("brown hair", m_hair[3]);
        m_sprite.Add("brunette hair", m_hair[4]);
        m_sprite.Add("dark blond hair", m_hair[5]);
        m_sprite.Add("gold hair", m_hair[6]);
        m_sprite.Add("gray hair", m_hair[7]);
        m_sprite.Add("green hair", m_hair[8]);
        m_sprite.Add("pink hair", m_hair[9]);
        m_sprite.Add("purple hair", m_hair[10]);
        m_sprite.Add("redhead hair", m_hair[11]);
        m_sprite.Add("white hair", m_hair[12]);

        m_sprite.Add("magenta pants", m_legs[0]);
        m_sprite.Add("red pants", m_legs[1]);
        m_sprite.Add("skirt", m_legs[2]);
        m_sprite.Add("teal pants", m_legs[3]);
        m_sprite.Add("white pants", m_legs[4]);

        m_sprite.Add("brown shirt", m_torso[0]);
        m_sprite.Add("maroon shirt", m_torso[1]);
        m_sprite.Add("teal shirt", m_torso[2]);
        m_sprite.Add("white shirt", m_torso[3]);


        f_sprite = new Dictionary<string, Sprite>();
        f_sprite.Add("big ears", f_ears[0]);
        f_sprite.Add("little ears", f_ears[1]);

        f_sprite.Add("blue eyes", f_eyes[0]);
        f_sprite.Add("brown eyes", f_eyes[1]);
        f_sprite.Add("gray eyes", f_eyes[2]);
        f_sprite.Add("green eyes", f_eyes[3]);
        f_sprite.Add("orange eyes", f_eyes[4]);
        f_sprite.Add("purple eyes", f_eyes[5]);
        f_sprite.Add("red eyes", f_eyes[6]);
        f_sprite.Add("yellow eyes", f_eyes[7]);

        f_sprite.Add("big nose", f_nose[0]);
        f_sprite.Add("button nose", f_nose[1]);
        f_sprite.Add("little nose", f_nose[2]);

        f_sprite.Add("black shoes", f_feet[0]);
        f_sprite.Add("brown shoes", f_feet[1]);
        f_sprite.Add("maroon shoes", f_feet[2]);

        f_sprite.Add("black hair", f_hair[0]);
        f_sprite.Add("blond hair", f_hair[1]);
        f_sprite.Add("blue hair", f_hair[2]);
        f_sprite.Add("brown hair", f_hair[3]);
        f_sprite.Add("brunette hair", f_hair[4]);
        f_sprite.Add("dark blond hair", f_hair[5]);
        f_sprite.Add("gold hair", f_hair[6]);
        f_sprite.Add("gray hair", f_hair[7]);
        f_sprite.Add("green hair", f_hair[8]);
        f_sprite.Add("pink hair", f_hair[9]);
        f_sprite.Add("purple hair", f_hair[10]);
        f_sprite.Add("redhead hair", f_hair[11]);
        f_sprite.Add("white hair", f_hair[12]);

        f_sprite.Add("magenta pants", f_legs[0]);
        f_sprite.Add("red pants", f_legs[1]);
        f_sprite.Add("skirt", f_legs[2]);
        f_sprite.Add("teal pants", f_legs[3]);
        f_sprite.Add("white pants", f_legs[4]);

        f_sprite.Add("brown shirt", f_torso[0]);
        f_sprite.Add("maroon shirt", f_torso[1]);
        f_sprite.Add("teal shirt", f_torso[2]);
        f_sprite.Add("white shirt", f_torso[3]);


    }

    private void Update()
    {
        if (Input.touchCount == 1 || Input.GetMouseButtonDown(0) || Input.GetMouseButtonDown(1))
        {
            Vector3 wp = new Vector3();
            if (Input.touchCount == 1)
            {
                wp = Camera.main.ScreenToWorldPoint(Input.GetTouch(0).position);
            }
            if (Input.GetMouseButtonDown(0)|| Input.GetMouseButtonDown(1))
            {
                wp = Camera.main.ScreenToWorldPoint(Input.mousePosition);
            }

            Vector2 touchPos = new Vector2(wp.x, wp.y);
            if (transform.Find("body").GetComponent<BoxCollider2D>().OverlapPoint(touchPos))
            {
                UIAContainer.VideUIActions();
                if(transform.Find("body").GetComponent<SpriteRenderer>().sprite==m_body|| transform.Find("body").GetComponent<SpriteRenderer>().sprite == f_body)
                {
                    if (transform.Find("ears").GetComponent<BoxCollider2D>().OverlapPoint(touchPos) || transform.Find("ears").GetComponents<BoxCollider2D>()[1].OverlapPoint(touchPos))
                    {
                        addSpriteUI(m_ears, UIAContainer);
                    }
                    else if (transform.Find("nose").GetComponent<BoxCollider2D>().OverlapPoint(touchPos))
                    {
                        addSpriteUI(m_nose, UIAContainer);

                    }
                    else if (transform.Find("eyes").GetComponent<BoxCollider2D>().OverlapPoint(touchPos))
                    {
                        addSpriteUI(m_eyes, UIAContainer);
                    }
                    else if (transform.Find("hair").GetComponent<BoxCollider2D>().OverlapPoint(touchPos))
                    {
                        addSpriteUI(m_hair, UIAContainer);
                    }
                    else if (transform.Find("feet").GetComponent<BoxCollider2D>().OverlapPoint(touchPos))
                    {
                        addSpriteUI(m_feet, UIAContainer);
                    }
                    else if (transform.Find("legs").GetComponent<BoxCollider2D>().OverlapPoint(touchPos))
                    {
                        addSpriteUI(m_legs, UIAContainer);
                    }
                    else if (transform.Find("torso").GetComponent<BoxCollider2D>().OverlapPoint(touchPos))
                    {
                        addSpriteUI(m_torso, UIAContainer);
                    }
                    else
                    {
                        addSpriteUI(bodies, UIAContainer);
                    }

                }
                else
                {
                    addSpriteUI(bodies, UIAContainer);
                }
            }
            else if (!GameObject.Find("Scroll View").GetComponent<Collider2D>().OverlapPoint(touchPos)){
                /*UIAContainer.VideUIActions();
                //ajout des actions globales
                foreach (string action in GameObject.Find("VoiceActions").GetComponent<VoiceActions>().actionsGlobales.Keys)
                {
                    string tmpTraduction = "";
                    string tmpAction = "";

                    int i = 0;
                    foreach (string act in l.dLanguage[l.lang].Values)
                    {
                        if (act == action)
                        {
                            tmpTraduction = l.dLanguage[l.lang].Keys.ToArray()[i];
                            break;
                        }
                        i++;
                    }

                    i = 0;
                    foreach (string act2 in l.dLanguage[l.langToLearn].Values)
                    {
                        if (act2 == action)
                        {
                            tmpAction = l.dLanguage[l.langToLearn].Keys.ToArray()[i];
                            break;
                        }
                        i++;
                    }

                    UIAContainer.AjoutUIAction(tmpTraduction, l.langToLearn, tmpAction);
                }*/
            }
        }
    }

    public void applySprite(string action)
    {
        if(action == "remove clothes")
        {
            transform.Find("body").GetComponent<SpriteRenderer>().sprite = null;
            transform.Find("ears").GetComponent<SpriteRenderer>().sprite = null;
            transform.Find("eyes").GetComponent<SpriteRenderer>().sprite = null;
            transform.Find("nose").GetComponent<SpriteRenderer>().sprite = null;
            transform.Find("feet").GetComponent<SpriteRenderer>().sprite = null;
            transform.Find("hair").GetComponent<SpriteRenderer>().sprite = null;
            transform.Find("legs").GetComponent<SpriteRenderer>().sprite = null;
            transform.Find("torso").GetComponent<SpriteRenderer>().sprite = null;
        }else if (action == "male")
        {
            transform.Find("body").GetComponent<SpriteRenderer>().sprite = m_body;
            male = true;
            transform.Find("ears").GetComponent<SpriteRenderer>().sprite = null;
            transform.Find("eyes").GetComponent<SpriteRenderer>().sprite = null;
            transform.Find("nose").GetComponent<SpriteRenderer>().sprite = null;
            transform.Find("feet").GetComponent<SpriteRenderer>().sprite = null;
            transform.Find("hair").GetComponent<SpriteRenderer>().sprite = null;
            transform.Find("legs").GetComponent<SpriteRenderer>().sprite = null;
            transform.Find("torso").GetComponent<SpriteRenderer>().sprite = null;
        }else if (action == "female")
        {
            transform.Find("body").GetComponent<SpriteRenderer>().sprite = f_body;
            male = false;
            transform.Find("ears").GetComponent<SpriteRenderer>().sprite = null;
            transform.Find("eyes").GetComponent<SpriteRenderer>().sprite = null;
            transform.Find("nose").GetComponent<SpriteRenderer>().sprite = null;
            transform.Find("feet").GetComponent<SpriteRenderer>().sprite = null;
            transform.Find("hair").GetComponent<SpriteRenderer>().sprite = null;
            transform.Find("legs").GetComponent<SpriteRenderer>().sprite = null;
            transform.Find("torso").GetComponent<SpriteRenderer>().sprite = null;
        }else if (male)
        {

            //ears
            foreach(Sprite s in m_ears)
            {
                if (m_sprite[action] == s)
                {
                    transform.Find("ears").GetComponent<SpriteRenderer>().sprite = m_sprite[action];
                }
            }

            //eyes
            foreach (Sprite s in m_eyes)
            {
                if (m_sprite[action] == s)
                {
                    transform.Find("eyes").GetComponent<SpriteRenderer>().sprite = m_sprite[action];
                }
            }


            //nose
            foreach (Sprite s in m_nose)
            {
                if (m_sprite[action] == s)
                {
                    transform.Find("nose").GetComponent<SpriteRenderer>().sprite = m_sprite[action];
                }
            }


            //feet
            foreach (Sprite s in m_feet)
            {
                if (m_sprite[action] == s)
                {
                    transform.Find("feet").GetComponent<SpriteRenderer>().sprite = m_sprite[action];
                }
            }

            //hair
            foreach (Sprite s in m_hair)
            {
                if (m_sprite[action] == s)
                {
                    transform.Find("hair").GetComponent<SpriteRenderer>().sprite = m_sprite[action];
                }
            }


            //legs
            foreach (Sprite s in m_legs)
            {
                if (m_sprite[action] == s)
                {
                    transform.Find("legs").GetComponent<SpriteRenderer>().sprite = m_sprite[action];
                }
            }


            //torso
            foreach (Sprite s in m_torso)
            {
                if (m_sprite[action] == s)
                {
                    transform.Find("torso").GetComponent<SpriteRenderer>().sprite = m_sprite[action];
                }
            }



        }
        else
        {

            //ears
            foreach (Sprite s in f_ears)
            {
                if (f_sprite[action] == s)
                {
                    transform.Find("ears").GetComponent<SpriteRenderer>().sprite = f_sprite[action];
                }
            }

            //eyes
            foreach (Sprite s in f_eyes)
            {
                if (f_sprite[action] == s)
                {
                    transform.Find("eyes").GetComponent<SpriteRenderer>().sprite = f_sprite[action];
                }
            }


            //nose
            foreach (Sprite s in f_nose)
            {
                if (f_sprite[action] == s)
                {
                    transform.Find("nose").GetComponent<SpriteRenderer>().sprite = f_sprite[action];
                }
            }


            //feet
            foreach (Sprite s in f_feet)
            {
                if (f_sprite[action] == s)
                {
                    transform.Find("feet").GetComponent<SpriteRenderer>().sprite = f_sprite[action];
                }
            }

            //hair
            foreach (Sprite s in f_hair)
            {
                if (f_sprite[action] == s)
                {
                    transform.Find("hair").GetComponent<SpriteRenderer>().sprite = f_sprite[action];
                }
            }


            //legs
            foreach (Sprite s in f_legs)
            {
                if (f_sprite[action] == s)
                {
                    transform.Find("legs").GetComponent<SpriteRenderer>().sprite = f_sprite[action];
                }
            }


            //torso
            foreach (Sprite s in f_torso)
            {
                if (f_sprite[action] == s)
                {
                    transform.Find("torso").GetComponent<SpriteRenderer>().sprite = f_sprite[action];
                }
            }

        }
    }

    public void addSpriteUI(List<Sprite> LSprite, UIActionContainer UI_action)
    {
        foreach (Sprite s in LSprite)
        {
            string tmpTraduction = "";
            string tmpAction = "";
            string action = "";
            int i = 0;
            foreach(Sprite s2 in m_sprite.Values)
            {
                if (s == s2)
                {
                    action = m_sprite.Keys.ToArray()[i];
                    break;
                }
                i++;
            }


            i = 0;
            foreach (string act in l.dLanguage[l.lang].Values)
            {
                if (act == action)
                {
                    tmpTraduction = l.dLanguage[l.lang].Keys.ToArray()[i];
                    break;
                }
                i++;
            }

            i = 0;
            foreach (string act2 in l.dLanguage[l.langToLearn].Values)
            {
                if (act2 == action)
                {
                    tmpAction = l.dLanguage[l.langToLearn].Keys.ToArray()[i];
                    break;
                }
                i++;
            }

            UI_action.AjoutUIAction(tmpTraduction, l.langToLearn, tmpAction);
        }
    }

}
