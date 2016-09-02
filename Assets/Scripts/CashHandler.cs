using UnityEngine;
using System.Collections;
using UnityEngine.UI;

public class CashHandler : MonoBehaviour {

	public float totalCash;
	public float cps;
	public float tapValue;
	public float updateTime;
	public Text totalCashText;
	public Text cpsText;
	public bool minimumUpdateTime;
	public Button buySomething;
	public ShopHandler shopHandler;
	float counter;


	void Start () {
	}
		

	void Update () {
		CashSecond ();
		if (totalCash < 1)
			buySomething.interactable = false;
		else
			buySomething.interactable = true;

		if (minimumUpdateTime)
			updateTime = Time.deltaTime;
			cpsText.text = cps + " Cash/Sec";
			totalCashText.text = "$" + totalCash.ToString("F2");

		if (counter < updateTime)
			counter += Time.deltaTime;
		else {
			totalCash += cps * updateTime;
			counter = 0;}
	}


	public float ScreenTapped() {
		tapValue = 1;
		totalCash += tapValue;
		return tapValue;
	}


	public  void CashSecond(){
		cps = 0;
//		foreach(ShopHandler.Item item in ShopHandler.ShopItems) {
//			cps = cps + item.count * item.gain;}
	}


}