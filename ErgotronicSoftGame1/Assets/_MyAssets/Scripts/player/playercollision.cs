using UnityEngine;
using System.Collections;

public class playercollision : MonoBehaviour {

    public GameObject gamemgn = null;

	// Use this for initialization
	void Start () {
            

    }

    void OnTriggerStay( Collider other)
    {
        if (Input.GetKey(KeyCode.E))
       {
            Debug.Log(" You see a key");

            if (other.tag == "Key")
            {
            Debug.Log(" You got a key");
            Destroy(other.gameObject);
                gamemgn.GetComponent<gamemgn>().ADDKeyUi(); 
            }
        }
    }
	// Update is called once per frame
	void Update () {
	
	}
}
