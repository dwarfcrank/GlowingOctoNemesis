using UnityEngine;
using System.Collections;

public class GuiTest : MonoBehaviour {

    public GUIStyle style;

	private GameObject player;
	private Health health;
	private float healthNow;
	private float healthMax;
	private float healthbarLength;
	
	// Use this for initialization
	void Start () {
		player = GameObject.FindGameObjectWithTag("Player");
		health = player.GetComponent<Health>();
		healthNow = health.health;
		healthMax = health.maxHealth;
		healthbarLength = healthNow/healthMax;
	}
	
	// Update is called once per frame
	void Update () {
		healthNow = (int)health.health;
		//170 would fill the entire hp bar "box", I've used a smaller value here so things wouldn't overlap.
		healthbarLength = (healthNow/healthMax)*166;	
	}

	void OnGUI () {
			
		// an example of a button for reference
		//if (GUI.Button (new Rect (10,10,200,20), "Meet the flashing button")) {
		//	print ("You clicked me!");
		//}
		
        var healthXoffset = 10;
        var healthYoffset = Screen.height - 30 - 10;
        var ammoXoffset = Screen.width - 201 - 10;
        var ammoYoffset = healthYoffset;
        
		//ammo etc
		GUI.Label (new Rect (ammoXoffset, ammoYoffset - 30, 201, 30), "weapon", "box");
		GUI.Label (new Rect(ammoXoffset, ammoYoffset, 50, 30), "AMMO ", "box");
		GUI.Label (new Rect(ammoXoffset + 50, ammoYoffset, 150, 30), "999" + " / " + "999", "box");
	
		if (healthNow > 50) {
			GUI.backgroundColor = Color.green;
		} else if (healthNow > 35) {
			GUI.backgroundColor = Color.yellow;
		} else {
			GUI.backgroundColor = Color.red;
		}
		
		//health
		GUI.Label (new Rect (healthXoffset, healthYoffset, 30, 30), "HP", "box");
		GUI.Label (new Rect (healthXoffset + 30 + 1, healthYoffset, 170,30), "","box");
		GUI.Label(new Rect(healthXoffset + 30 + 3, healthYoffset + 2, healthbarLength, 26), healthNow + "", "box");
		
	}
}
