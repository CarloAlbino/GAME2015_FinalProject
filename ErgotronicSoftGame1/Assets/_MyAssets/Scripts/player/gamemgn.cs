using UnityEngine;
using UnityEngine.UI;
using System.Collections;


public class gamemgn : MonoBehaviour {

    public Text key_text = null;
    public int Allkey;
    public int keyfound;
    public bool  GotAllkeys = false;
    // Use this for initialization
    void Start () {
	
	}
     void Keydisplay()
    {
        key_text.text = "key " + keyfound.ToString() + "/" + Allkey.ToString();


    }
     public void ADDKeyUi()
    {
        keyfound += 1;
        Debug.Log("add key");

    }
    public void ClearKeyUI()
    {
        keyfound = 0;


    }

    public bool  Complete()
    {

        return GotAllkeys;

    }
    // Update is called once per frame
    void Update () {
        Keydisplay();
        if (keyfound >= Allkey)
        {
            GotAllkeys = true;
        }
    }
}
