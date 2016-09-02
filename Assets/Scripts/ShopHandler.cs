using UnityEngine;
using UnityEngine.UI;
using UnityEngine.Events;
using System.Collections;

public class ShopHandler : MonoBehaviour {

	public CashHandler cHandler;
	public Sprite one;
	public Sprite two;
	public Sprite three;
	public Sprite four;
	public Sprite five;

	[System.Serializable]
	public class Item{
		public string name;
		public Sprite image;
		public float cost;
		public float gain;
		public float count;
		public float progress;
		public Button.ButtonClickedEvent btnClicked; }
	
	public GameObject[] buttonItems;
	public Item[] ShopItems;
	public GameObject button;
	int counter;




	// Use this for initialization
	void Start (){
		buttonItems= new GameObject[ShopItems.Length];
		counter = 0;
		foreach (Item i in ShopItems) {
			GameObject btn = (GameObject)Instantiate (button);
			buttonItems [counter] = btn;
			ItemScript scp = btn.GetComponent<ItemScript> ();
			scp.name.text = i.name;
			scp.cost.text = "Cost: $" + i.cost.ToString ("F2");
			scp.count.text = i.count.ToString ();
			scp.gain.text = "CPS: $" + i.gain.ToString ("F2");
			scp.progress = 0f;
			Item thisItem = i;
			scp.thisButton.onClick.AddListener (() => Purchase (thisItem));
			btn.transform.SetParent (this.transform);
			counter++; }
	}


	void Purchase (Item bought)
	{
		GameObject thePlayer = GameObject.Find ("CashHandlerObject");
		CashHandler CH = thePlayer.GetComponent<CashHandler> ();
		CH.totalCash -= bought.cost;
		bought.count++;
		bought.cost = bought.cost * 2.1f;
		UpdateItems();
		cHandler.CashSecond ();
		//START Change the Picture - Working
		counter = 0;
		foreach (Item i in ShopItems) {
			ItemScript scp = buttonItems[counter].GetComponent<ItemScript> ();
			scp.count.text = i.count.ToString ();
			if (i.count == 1)
				scp.icon.sprite = one;
			if (i.count == 2)
				scp.icon.sprite = two;
			if (i.count == 3)
				scp.icon.sprite = three;
			if (i.count == 4)
				scp.icon.sprite = four;
			if (i.count == 5)
				scp.icon.sprite = five;
			counter++;			}
		//END Change the Picture - Working
	}


	void UpdateItems(){

		counter = 0;
		foreach (Item i in ShopItems) {
			ItemScript scp = buttonItems[counter].GetComponent<ItemScript> ();
			scp.name.text = i.name;
			scp.cost.text = "Cost: " + i.cost.ToString ("F2");
			scp.count.text = i.count.ToString ();
			scp.gain.text = "CPS: " + i.gain.ToString ("F2");
			scp.progress = i.progress;
			counter++; }
	}


	// Update is called once per frame
	void Update () {
		counter = 0;
		foreach (Item i in ShopItems) {
			if (i.cost > cHandler.totalCash)
				buttonItems [counter].GetComponent<Button> ().interactable = false;
			else
				buttonItems [counter].GetComponent<Button> ().interactable = true;
			counter++;		}
	}


}