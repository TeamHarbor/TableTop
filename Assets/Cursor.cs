using UnityEngine;
using System.Collections;

public class Cursor : MonoBehaviour {

	RaycastHit hit;
	Ray ray;

	// Use this for initialization
	void Start () {
		hit = new RaycastHit ();
	}
	
	// Update is called once per frame
	void Update () {
		ray = Camera.main.ScreenPointToRay (Input.mousePosition);
		if (Physics.Raycast (ray,out hit)) {
			transform.position = hit.point;
		}
	}
}
