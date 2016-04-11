using UnityEngine;
using System.Collections;

public class ca_DetectPlayer : MonoBehaviour {
    
    private ca_WaypointList patrolScript;

    public float chaseLength = 10.0f;

    private Coroutine chaseCount;

    public float rayLength = 10.0f;

    private Ray[] ray;
    private RaycastHit[] hit;
    private int layerMask = 1 << 8;

	// Use this for initialization
	void Start () 
    {
        patrolScript = GetComponent<ca_WaypointList>();
        ray = new Ray[7];
        hit = new RaycastHit[7];
	}
	
	// Update is called once per frame
	void Update () 
    {
        DetectionFan();
        if(Player.Get.Hiding())
        {
            if (chaseCount != null)
            {
                StopCoroutine(chaseCount);
            }
            patrolScript.SetPartol(true);
        }
	}

    private void DetectionFan()
    {
        // Drawing rays in editor
        Debug.DrawRay(transform.position, transform.forward * rayLength * 2.0f, Color.blue);
        Debug.DrawRay(transform.position, (transform.forward + transform.right) * rayLength, Color.blue);
        Debug.DrawRay(transform.position, (transform.forward - transform.right) * rayLength, Color.blue);
        Debug.DrawRay(transform.position, (transform.forward + transform.forward + transform.right) * rayLength, Color.blue);
        Debug.DrawRay(transform.position, (transform.forward + transform.forward - transform.right) * rayLength, Color.blue);
        Debug.DrawRay(transform.position, (transform.forward + transform.forward + transform.right * 0.5f) * rayLength, Color.blue);
        Debug.DrawRay(transform.position, (transform.forward + transform.forward - transform.right * 0.5f) * rayLength, Color.blue);

        // Creating the rays for raycast
        ray[0] = new Ray(transform.position, transform.forward * rayLength * 2.0f);
        ray[1] = new Ray(transform.position, (transform.forward + transform.right) * rayLength);
        ray[2] = new Ray(transform.position, (transform.forward - transform.right) * rayLength);
        ray[3] = new Ray(transform.position, (transform.forward + transform.forward + transform.right) * rayLength);
        ray[4] = new Ray(transform.position, (transform.forward + transform.forward - transform.right) * rayLength);
        ray[5] = new Ray(transform.position, (transform.forward + transform.forward + transform.right * 0.5f) * rayLength);
        ray[6] = new Ray(transform.position, (transform.forward + transform.forward - transform.right * 0.5f) * rayLength);

        // Raycasting
        for(int i = 0; i < ray.Length; i++)
        {
           if(Physics.Raycast(ray[i], out hit[i], rayLength, layerMask))
           {
               if (hit[i].collider.CompareTag("Player"))
               {
                   patrolScript.SetPlayerTarget(hit[i].transform);
                   patrolScript.SetPartol(false);
                   if (chaseCount != null)
                       StopCoroutine(chaseCount);
                   chaseCount = StartCoroutine(Chase());
               }
           }
        }
    }

    private IEnumerator Chase()
    {
        yield return new WaitForSeconds(chaseLength);
        patrolScript.SetPartol(true);
    }
}
