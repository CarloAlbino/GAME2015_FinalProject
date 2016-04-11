using UnityEngine;
using System.Collections;

public class Knifing : MonoBehaviour {

    public string AI;

	void OnTriggerStay(Collider other)
    {
        if(other.gameObject.tag==AI)
        {
            Debug.Log("Press E to Kill AI");
            if(Input.GetKey(KeyCode.E))
            {
                Destroy(other.transform.parent.gameObject);
            }
        }
    }
}
