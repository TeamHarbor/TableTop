using UnityEngine;
using System.Collections;

public class Card : MonoBehaviour {

	public Texture FaceTexture;
	public Texture BackTexture;
	public bool UpdateTexture = true;

	private GameObject CardFace;
	private GameObject CardBack;

	private Shader SolidShader = Shader.Find ("Diffuse");
	private Shader TransparentShader = Shader.Find ("Transparent/Diffuse");

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

		
		CardBack.renderer.material.color = new Color(1,1,1,0.5f);
		CardFace.renderer.material.color = new Color(1,1,1,0.5f);
		CardBack.renderer.material.shader = SolidShader;
		CardFace.renderer.material.shader = SolidShader;

	}
	
	// Update is called once per frame
	void Update () {
		if (drag) {
			dragPosition = GameObject.Find ("Cursor").transform.position;
			dragPosition += new Vector3(0,5,0);
			transform.position = dragPosition;
			
			if (Input.GetMouseButton (1)) 
			{
				transform.Rotate (new Vector3(0,180,0));
			}
		}

		if (UpdateTexture) 
		{
			CardBack.renderer.material.mainTexture = BackTexture;
			CardFace.renderer.material.mainTexture = FaceTexture;
			UpdateTexture = false;
		}
	}

	void OnMouseDown()
	{
		drag = true;
		rigidbody.useGravity = false;
		CardBack.renderer.material.shader = TransparentShader;
		CardFace.renderer.material.shader = TransparentShader;
	}

	void OnMouseUp()
	{
		drag = false;
		rigidbody.useGravity = true;
		CardBack.renderer.material.shader = SolidShader;
		CardFace.renderer.material.shader = SolidShader;
		rigidbody.velocity = Vector3.zero;
	}
}
