using UnityEngine;
using System.Collections;

public class Card : MonoBehaviour {

	public Texture FaceTexture;

	private GameObject CardFace;
	private GameObject CardBack;

	private bool drag = false;
	private Vector3 dragPosition;

	// Use this for initialization
	void Start () {
		CardFace = GameObject.CreatePrimitive (PrimitiveType.Quad);
		CardFace.transform.localPosition = transform.localPosition;
		CardFace.transform.localRotation = transform.localRotation;
		CardFace.transform.localScale = new Vector3(3.5f,2.5f,1f);
		CardFace.renderer.material.mainTexture = FaceTexture;
		CardFace.transform.parent = transform;
		CardFace.name = "Face";
		Destroy (CardFace.collider);

		CardBack = GameObject.CreatePrimitive (PrimitiveType.Quad);
		CardBack.transform.localPosition = transform.localPosition;
		CardBack.transform.localRotation = transform.localRotation;
		CardBack.transform.localScale = new Vector3(3.5f,2.5f,1f);
		CardBack.transform.Rotate (new Vector3 (1, 0, 0), 180);
		CardBack.transform.parent = transform;
		CardBack.name = "Back";
		Destroy (CardBack.collider);

	}
	
	// Update is called once per frame
	void Update () {
		if (drag) {
			dragPosition = GameObject.Find ("Cursor").transform.position;
			dragPosition += new Vector3(0,5,0);
			transform.position = dragPosition;
		}
	}

	void OnMouseDown()
	{
		drag = true;
		rigidbody.useGravity = false;
	}

	void OnMouseUp()
	{
		drag = false;
		rigidbody.useGravity = true;
	}
}
