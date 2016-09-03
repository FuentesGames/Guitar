using UnityEngine;
using UnityEngine.UI;
using System.Collections;


public class BarScript : MonoBehaviour {

	private float FillAmmount;

	[SerializeField]
	private Image content;

	[SerializeField]
	private Text valueText;

	public float MaxValue { get; set; }

	public float Value
	{
		set
		{
		//	string[] tmp = valueText.text.Split ('l');
		//	valueText.text = tmp [0] + " " + value;
			valueText.text = "Next Upgrade at Level " +MaxValue;
			FillAmmount = Map (value, 0, MaxValue, 0, 1);
		}
	}




	// Use this for initialization
	void Start () {
	
	}
	
	// Update is called once per frame
	void Update () {

		HandleBar ();
	
	}

	private void HandleBar()
	{
			content.fillAmount = FillAmmount;
		}


	private float Map(float value, float inMin, float inMax, float outMin, float outMax){
		return (value - inMin) * (outMax - outMin) / (inMax - inMin) + outMin;

		//Current Level (78 - 0) * (1 - 0) / (230 - 0) + 0 
	}
}