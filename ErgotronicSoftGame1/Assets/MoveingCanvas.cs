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
        Debug.Log("moveinput"+moveinput.GetComponent<Rigidbody>().velocity.magnitude);
        if (Input.GetKey (KeyCode.UpArrow)|| Input.GetKey(KeyCode.DownArrow)|| Input.GetKey(KeyCode.RightArrow)|| Input.GetKey(KeyCode.LeftArrow) ||Input.GetKey(KeyCode.Space))
       {
            Debug.Log(" it works");
            if (CanSwicth == true)
            {
                transform.Translate(Vector3.up * speed * Time.deltaTime);
            }
            else
            {
                transform.Translate(-Vector3.up * speed * Time.deltaTime);
            }
        }


        Debug.Log("moveinput : " + moveinput.GetComponent<Rigidbody>().velocity.magnitude);
    }
}
