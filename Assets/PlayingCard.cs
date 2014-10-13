using UnityEngine;
using System.Collections;

public class PlayingCard : MonoBehaviour {

	public Texture FaceTexture;

	private GameObject CardFace;
	private GameObject CardBack;

	// Use this for initialization
	void Start () {
		CardFace = GameObject.CreatePrimitive (PrimitiveType.Quad);
		CardFace.transform.localPosition = transform.localPosition;
		CardFace.transform.localRotation = transform.localRotation;
		CardFace.transform.localScale = new Vector3(3.5f,2.5f,1f);
		//CardFace.transform.Rotate (new Vector3 (1, 0, 0), -90);
		CardFace.renderer.material.mainTexture = FaceTexture;
		CardFace.transform.parent = transform;

		CardBack = GameObject.CreatePrimitive (PrimitiveType.Quad);
		CardBack.transform.localPosition = transform.localPosition;
		CardBack.transform.localRotation = transform.localRotation;
		CardBack.transform.localScale = new Vector3(3.5f,2.5f,1f);
		CardBack.transform.Rotate (new Vector3 (1, 0, 0), 180);
		CardBack.transform.parent = transform;

	}
	
	// Update is called once per frame
	void Update () {
	
	}
}
