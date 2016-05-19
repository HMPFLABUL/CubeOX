using UnityEngine;
using System.Collections;

public class RayCheck : MonoBehaviour {

	// Use this for initialization
	void Start () {
        
	}
	
	// Update is called once per frame
	void Update () {
      //  CastRay();
    }

    public RaycastHit CastRay()
    {
        RaycastHit hit;
        Physics.Raycast(transform.position, transform.forward,out hit);
        Debug.DrawRay(transform.position, transform.forward, Color.green);
        return hit;
    }
}
