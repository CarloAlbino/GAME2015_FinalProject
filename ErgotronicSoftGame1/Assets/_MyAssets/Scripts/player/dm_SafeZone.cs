using UnityEngine;
using System.Collections;

public class dm_SafeZone : MonoBehaviour {
    bool IsHiding = false;

	// Use this for initialization
	void Start () {
	
	}
	
	// Update is called once per frame
	void Update () {
	    Debug.Log(IsHiding);

        if (Input.GetKey(KeyCode.A))
            transform.Translate(Vector3.back*Time.deltaTime);

        if (Input.GetKey(KeyCode.D))
            transform.Translate(Vector3.forward*Time.deltaTime);
	}

    public bool Hiding
    {
        get
        {
            return IsHiding;
        }
    }

    void OnTriggerStay(Collider other)
    {
        if (other.CompareTag("SafeZone"))
        {
            if (Input.GetKey(KeyCode.F) && !IsHiding)
            {
                IsHiding = true;

                // TRIGGER ANIMATION
            }
            else if (!Input.GetKey(KeyCode.F) && IsHiding)
            {
                IsHiding = false;

                // TRIGGER ANIMATION
            }
        }
    }

    void OnTriggerExit(Collider other)
    {
        if (other.CompareTag("SafeZone"))
        {
            IsHiding = false;

            // TRIGGER ANIMATION
        }
    }
}
