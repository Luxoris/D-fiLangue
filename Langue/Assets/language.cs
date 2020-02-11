using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using System.Linq;

public class language : MonoBehaviour
{

    public Dictionary<string, Dictionary<string, string>> dLanguage;
    Dictionary<string, string> en;
    Dictionary<string, string> fr;
    Dictionary<string, string> de;
    public string lang;
    public string langToLearn;
    public GameObject c_langue;
    public GameObject c_game;
    public Dropdown dp_langue;
    public Dropdown dp_langueToLearn;

    //https://gist.github.com/grimmdev/979877fcdc943267e44c

    // Start is called before the first frame update
    void Start()
    {
        en = new Dictionary<string, string>();
        fr = new Dictionary<string, string>();
        de = new Dictionary<string, string>();

        addEN();
        addFR();
        addDE();

        dLanguage = new Dictionary<string, Dictionary<string, string>>();
        dLanguage.Add("fr_FR", fr);
        dLanguage.Add("en_US", en);
        dLanguage.Add("de_DE", de);

    }

    public void setLanguage()
    {   if(dp_langueToLearn.value!= dp_langue.value)
        {
            lang = dLanguage.Keys.ToArray()[dp_langue.value];
            langToLearn = dLanguage.Keys.ToArray()[dp_langueToLearn.value];
            c_langue.SetActive(false);
            c_game.SetActive(true);
            gameObject.GetComponent<VoiceActions>().ChargementActions();
        }
        
    }
    void addEN()
    {
        en.Add("forward", "forward");
        en.Add("up", "up");
        en.Add("down", "down");
        en.Add("back", "back");
        en.Add("left", "left");
        en.Add("right", "right");
        en.Add("turn right", "turn right");
        en.Add("turn left", "turn left");
        en.Add("grow", "grow");
        en.Add("shrink", "shrink");
        en.Add("quit", "quit");
        en.Add("remove clothes", "remove clothes");

        en.Add("man", "male");
        en.Add("woman", "female");
        en.Add("round ears", "big ears");
        en.Add("pointy ears", "little ears");
        en.Add("blue eyes", "blue eyes");
        en.Add("brown eyes", "brown eyes");
        en.Add("gray eyes", "gray eyes");
        en.Add("green eyes", "green eyes");
        en.Add("orange eyes", "orange eyes");
        en.Add("purple eyes", "purple eyes");
        en.Add("red eyes", "red eyes");
        en.Add("yellow eyes", "yellow eyes");
        en.Add("big nose", "big nose");
        en.Add("little nose", "button nose");
        en.Add("medium nose", "little nose");
        en.Add("black shoes", "black shoes");
        en.Add("brown shoes", "brown shoes");
        en.Add("maroon shoes", "maroon shoes");
        en.Add("black hair", "black hair");
        en.Add("blond hair", "blond hair");
        en.Add("blue hair", "blue hair");
        en.Add("brown hair", "brown hair");
        en.Add("brunette hair", "brunette hair");
        en.Add("dark blond hair", "dark blond hair");
        en.Add("gold hair", "gold hair");
        en.Add("gray hair", "gray hair");
        en.Add("green hair", "green hair");
        en.Add("pink hair", "pink hair");
        en.Add("purple hair", "purple hair");
        en.Add("redhead", "redhead hair");
        en.Add("white hair", "white hair");
        en.Add("magenta pants", "magenta pants");
        en.Add("red pants", "red pants");
        en.Add("skirt", "skirt");
        en.Add("blue pants", "teal pants");
        en.Add("white pants", "white pants");
        en.Add("brown shirt", "brown shirt");
        en.Add("maroon shirt", "maroon shirt");
        en.Add("blue shirt", "teal shirt");
        en.Add("white shirt", "white shirt");
    }

    void addFR()
    {
        fr.Add("devant", "forward");
        fr.Add("haut", "up");
        fr.Add("bas", "down");
        fr.Add("derriere", "back");
        fr.Add("gauche", "left");
        fr.Add("droite", "right");
        fr.Add("tourne à droite", "turn right");
        fr.Add("tourne à gauche", "turn left");
        fr.Add("rétrécir", "shrink");
        fr.Add("grandir", "grow");
        fr.Add("quitter", "quit");
        fr.Add("enlever les vêtements", "remove clothes");
        fr.Add("enlever les vêtements.", "remove clothes");

        fr.Add("homme", "male");
        fr.Add("femme", "female");
        fr.Add("oreilles rondes", "big ears");
        fr.Add("oreilles pointues", "little ears");
        fr.Add("yeux bleus", "blue eyes");
        fr.Add("yeux bruns", "brown eyes");
        fr.Add("yeux gris", "gray eyes");
        fr.Add("yeux verts", "green eyes");
        fr.Add("yeux oranges", "orange eyes");
        fr.Add("yeux violets", "purple eyes");
        fr.Add("yeux rouges", "red eyes");
        fr.Add("yeux jaunes", "yellow eyes");
        fr.Add("gros nez", "big nose");
        fr.Add("petit nez", "button nose");
        fr.Add("nez moyen", "little nose");
        fr.Add("chausssures noires", "black shoes");
        fr.Add("chaussures brunes", "brown shoes");
        fr.Add("chaussures marrons", "maroon shoes");
        fr.Add("cheveux noirs", "black hair");
        fr.Add("cheveux blonds", "blond hair");
        fr.Add("cheveux bleus", "blue hair");
        fr.Add("cheveux bruns", "brown hair");
        fr.Add("cheveux châtains", "brunette hair");
        fr.Add("cheveux blonds foncés", "dark blond hair");
        fr.Add("cheveux dorés", "gold hair");
        fr.Add("cheveux gris", "gray hair");
        fr.Add("cheveux verts", "green hair");
        fr.Add("cheveux roses", "pink hair");
        fr.Add("cheveux violets", "purple hair");
        fr.Add("cheveux roux", "redhead hair");
        fr.Add("cheveux blancs", "white hair");
        fr.Add("pantalon magenta", "magenta pants");
        fr.Add("pantalon rouge", "red pants");
        fr.Add("jupe", "skirt");
        fr.Add("pantalon bleu", "teal pants");
        fr.Add("pantalon blanc", "white pants");
        fr.Add("chemise brune", "brown shirt");
        fr.Add("chemise marron", "maroon shirt");
        fr.Add("chemise bleue", "teal shirt");
        fr.Add("chemise blanche", "white shirt");
    }

    void addDE()
    {
        de.Add("davor", "forward");
        de.Add("oben", "up");
        de.Add("unten", "down");
        de.Add("dahinter", "back");
        de.Add("links", "left");
        de.Add("rechts", "right");
        de.Add("biegen Sie rechts ab", "turn right");
        de.Add("biegen Sie links ab", "turn left");
        de.Add("schrumpfen", "shrink");
        de.Add("wachsen", "grow");
        de.Add("Verlassen", "quit");
        de.Add("Kleidung entfernen", "remove clothes");
        
        de.Add("Mann", "male");
        de.Add("Frau", "female");
        de.Add("runde Ohren", "big ears");
        de.Add("spitze Ohren", "little ears");
        de.Add("blaue Augen", "blue eyes");
        de.Add("braune Augen", "brown eyes");
        de.Add("graue Augen", "gray eyes");
        de.Add("grüne Augen", "green eyes");
        de.Add("orange Augen", "orange eyes");
        de.Add("lila Augen", "purple eyes");
        de.Add("rote Augen", "red eyes");
        de.Add("gelbe Augen", "yellow eyes");
        de.Add("große Nase", "big nose");
        de.Add("kleine Nase", "button nose");
        de.Add("mittlere Nase", "little nose");
        de.Add("schwarze Schuhe", "black shoes");
        de.Add("braune Schuhe", "brown shoes");
        de.Add("kastanienbraune Schuhe", "maroon shoes");
        de.Add("schwarzes Haar", "black hair");
        de.Add("blondes Haar", "blond hair");
        de.Add("blaues Haar", "blue hair");
        de.Add("braunes Haar", "brown hair");
        de.Add("hellbraunes Haar", "brunette hair");
        de.Add("dunkelblondes Haar", "dark blond hair");
        de.Add("goldenes Haar", "gold hair");
        de.Add("graues Haar", "gray hair");
        de.Add("grünes Haar", "green hair");
        de.Add("rosa Haar", "pink hair");
        de.Add("lila Haar", "purple hair");
        de.Add("rotes Haar", "redhead hair");
        de.Add("weißes Haar", "white hair");
        de.Add("Magenta Hosen", "magenta pants");
        de.Add("Rote Hosen", "red pants");
        de.Add("Rock", "skirt");
        de.Add("blaue Hosen", "teal pants");
        de.Add("weiße Hosen", "white pants");
        de.Add("braunes Hemd", "brown shirt");
        de.Add("kastanienbraunes Hemd", "maroon shirt");
        de.Add("blaues Hemd", "teal shirt");
        de.Add("weißes Hemd", "white shirt");
    }


}
