using UnityEngine;
using System.Collections;

public class playercollision : MonoBehaviour {

    public int keycounter;
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
                keycounter += 1;
            }
        }
    }
	// Update is called once per frame
	void Update () {
	
	}
}
