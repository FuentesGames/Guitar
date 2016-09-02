using UnityEngine;
using System.Collections;

public class Player : MonoBehaviour {

	[SerializeField]
	private Stat level;

	private void Awake()
	{
		level.Initalize ();
	}
	
	// Update is called once per frame
	void Update () 
	{
		if (Input.GetKeyDown(KeyCode.Q))
			{
				level.CurrentVal -= 10;
			}
		if (Input.GetKeyDown (KeyCode.Y))
			{
				level.CurrentVal += 10;
			}

	}
}
