using UnityEngine;
using System.Collections;
using UnityEngine.UI;

public class dm_SafeZone : MonoBehaviour {
    [SerializeField] GameObject stealthVision; // the panel
    public float transparency;
    bool IsHiding = false;

	// Use this for initialization
	void Start () {
        transparency = Mathf.Clamp01(transparency);
	}
	
	// Update is called once per frame
	void Update () {
	    Debug.Log(Hiding);

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
            if (Input.GetKey(KeyCode.F) && !Hiding)
            {
                IsHiding = true;
                stealthVision.GetComponent<Image>().color = new Color(1, 1, 1, transparency);

                // TRIGGER ANIMATION
            }
            else if (!Input.GetKey(KeyCode.F) && Hiding)
            {
                IsHiding = false;
                stealthVision.GetComponent<Image>().color = new Color(1, 1, 1, 0);

                // TRIGGER ANIMATION
            }
        }
    }

    void OnTriggerExit(Collider other)
    {
        if (other.CompareTag("SafeZone"))
        {
            IsHiding = false;
            stealthVision.GetComponent<Image>().color = new Color(1, 1, 1, 0);

            // TRIGGER ANIMATION
        }
    }
}
