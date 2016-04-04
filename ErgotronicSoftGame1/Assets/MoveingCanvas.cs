using UnityEngine;
using System.Collections;

public class MoveingCanvas : MonoBehaviour {
    public GameObject moveinput;  
    public float time;
    public float speed;
    bool CanSwicth = false;
    IEnumerator changeDirection()
    {
       yield return new WaitForSeconds(time);
        CanSwicth = !CanSwicth;
        StartCoroutine(changeDirection());
    }
	// Use this for initialization
	void Start () {
        StartCoroutine(changeDirection());
    }
	
	// Update is called once per frame
	void Update ()
    {
        if (moveinput.GetComponent<Rigidbody>().velocity.magnitude > 00.1f)
        {

            if (CanSwicth == true)
            {
                transform.Translate(Vector3.up * speed * Time.deltaTime);
            }
            else
            {
                transform.Translate(-Vector3.up * speed * Time.deltaTime);
            }
        }
	}
}
