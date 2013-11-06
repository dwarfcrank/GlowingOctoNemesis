using UnityEngine;
using System.Collections;

public class GuiTest : MonoBehaviour {
	
	public GameObject player;
	public Health health;
	public float healthNow;
	public float healthMax;
	public float healthbarLength;
	public GameObject respawnBehaviour;
	public RespawnOrDestroy rod;
	public int deaths;
	
	// Use this for initialization
	void Start () {
		player = GameObject.FindGameObjectWithTag("Player");
		health = player.GetComponent<Health>();
		healthNow = health.health;
		healthMax = health.maxHealth;
		healthbarLength = healthNow/healthMax;
		respawnBehaviour = GameObject.FindGameObjectWithTag("Respawn");
		rod = respawnBehaviour.GetComponent<RespawnOrDestroy>();
		deaths = rod.deaths;
		
	}
	
	// Update is called once per frame
	void Update () {
		healthNow = (int)health.health;
		deaths = rod.deaths;
		
		//170 would fill the entire hp bar "box", I've used a smaller value here so things wouldn't overlap.
		healthbarLength = (healthNow/healthMax)*166;	
	}

	void OnGUI () {
			
		// an example of a button for reference
		//if (GUI.Button (new Rect (10,10,200,20), "Meet the flashing button")) {
		//	print ("You clicked me!");
		//}
		
		//name or sumthin
		GUI.Label (new Rect (10,10,201,30), "Number of deaths: " + deaths, "box");
		
		GUI.Label (new Rect (10,369,201,30), "Das Player", "box");
			
		//health
		GUI.Label (new Rect (10,400,30,30), "HP: ", "box");
		GUI.Label (new Rect (41,400,170,30), "","box"); 
			
		//ammo etc
		GUI.Label (new Rect (10,431,50,30), "AMMN: ", "box");
		GUI.Label (new Rect (61,431,150,30), "999" + " / " + "999", "box");
	
		if (healthNow > 50) {
			GUI.color = Color.green;
		} else if (healthNow > 35) {
			GUI.color = Color.yellow;
		} else {
			GUI.color = Color.red;
		}
		
		GUI.Label(new Rect(43, 402, healthbarLength, 26), healthNow + "", "box");
		
	}
}
