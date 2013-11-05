using UnityEngine;
using System.Collections;

public class GuiTest : MonoBehaviour {
	
	public GameObject player;
	public Health health;
	public float healthNow;
	public float healthMax;
	
	// Use this for initialization
	void Start () {
		player = GameObject.FindGameObjectWithTag("Player");
		health = player.GetComponent<Health>();
		healthNow = health.health;
		healthMax = health.maxHealth;
	}
	
	// Update is called once per frame
	void Update () {
		healthNow = (int)health.health;
		//healthMax = health.maxHealth;
	}

	void OnGUI () {
				
			//if (GUI.Button (new Rect (10,10,200,20), "Meet the flashing button")) {
			//	print ("You clicked me!");
			//}
			
			//name or sumthin
			GUI.Label (new Rect (10,369,201,30), "Das Player", "box");
		
			//health
			GUI.Label (new Rect (10,400,30,30), "HP: ", "box");
			GUI.Label (new Rect (41,400,170,30), healthNow + " / " + healthMax, "box"); 
				
			//ammo etc
			GUI.Label (new Rect (10,431,50,30), "AMMN: ", "box");
			GUI.Label (new Rect (61,431,150,30), "999" + " / " + "999", "box");
		
	}
}
