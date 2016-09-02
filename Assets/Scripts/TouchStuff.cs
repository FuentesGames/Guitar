using UnityEngine;
using System.Collections;
using UnityEngine.UI;

public class TouchStuff : MonoBehaviour {

	public CashHandler ch;

	public int maxFinger;
	int fingerCount;
	bool screenPressed;
	public GameObject notes;
	public GameObject plusCash;
	Vector3 worldPos;




	// Use this for initialization
	void Start () {

	}

	// Update is called once per frame
	void Update () {
		if(screenPressed) {

			fingerCount = 0;
			foreach (Touch touch in Input.touches) {
				if (touch.phase == TouchPhase.Began && fingerCount < maxFinger) {


					this.GetComponent<Animator> ().SetBool ("Tapped", true);

					worldPos = Camera.main.ScreenToWorldPoint (touch.position);
					worldPos.z = 0;


					Instantiate (notes, worldPos, Quaternion.Euler (0, 0, Random.Range (-25, 70)));
					GameObject plusbans =(GameObject) Instantiate (plusCash,worldPos,Quaternion.identity);
					plusbans.GetComponentInChildren<Text> ().text = "+" + ch.ScreenTapped ();


				}
				fingerCount++;
				screenPressed = false;
			}
		}

	}

	public void TappedFalse() {	
		this.GetComponent<Animator> ().SetBool ("Tapped", false);

	}

	public void checkFingers(){
		screenPressed = true;
	}


}