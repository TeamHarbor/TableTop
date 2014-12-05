using UnityEngine;
using System.Collections;

public class DebugDeck : MonoBehaviour {

	public GameObject CardPrefab;
	public ArrayList CardImages;
	public Sprite DebugSprite;
	public ArrayList Cards;

	// Use this for initialization
	void Start () {
		//Initialize all cards into the deck
		GameObject _card;
		Card _cardScript;
		Vector3 _cardPos;

		for(int c = 0; c < 52; c++)
		{
			_card = (GameObject)Instantiate (CardPrefab);
			_card.transform.position += new Vector3(0,.04f*c,0);
			_card.transform.parent = transform;
			_card.name = "Card_" + c;
			_cardScript = _card.GetComponent<Card>();
			_cardScript.FaceTexture = DebugSprite;
			_cardScript.UpdateTexture = true;
		}
	}
	
	// Update is called once per frame
	void Update () {

	}
}
