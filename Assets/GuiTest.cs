using UnityEngine;
using System.Collections;

public class GuiTest : MonoBehaviour {

    public GUIStyle style;

	private GameObject player;
	private Health health;
	private float healthNow;
	private float healthMax;
	private float healthbarLength;
	private string wave;
	private string kills;
	private GameEnv gameEnv;
    private AmmoQuiver quiver;
	private bool menuVisible;

	// Use this for initialization
	void Start () {
		menuVisible = false;
		player = GameObject.FindGameObjectWithTag("Player");
		health = player.GetComponent<Health>();
		healthNow = health.health;
		healthMax = health.maxHealth;
		healthbarLength = healthNow/healthMax;

        //This and line 39 are the ways you should probably be able to get stuff. gtg lol ebin xD
		GameObject go = GameObject.FindGameObjectWithTag("GameEnv");
		gameEnv = go.GetComponent<GameEnv>();

        quiver = GameObject.FindGameObjectWithTag("Player").GetComponent<AmmoQuiver>();

	}
	
	// Update is called once per frame
	void Update () {
		healthNow = (int)health.health;
		//170 would fill the entire hp bar "box", I've used a smaller value here so things wouldn't overlap.
		healthbarLength = (healthNow/healthMax)*166;

        //This should probably be in Start() ?
        //Anyway find a way to get a grip of the GameEnv class and it's functions.
		//gameEnv = GetComponent<GameEnv>();
		//Debug.Log (gameEnv == null);
		wave = gameEnv.GetCurrentWave().ToString();
		kills = gameEnv.GetKills().ToString();
		//Debug.Log (kills);

		//if user hits escape menu is shown and game is paused
		if (Input.GetKeyDown("escape")) 
		{
			//Console.log("esc");
			//Debug.Log("esc");
			menuVisible = !menuVisible;
			if(menuVisible)
			{
				Time.timeScale = 0;
			}
			else
			{
				Time.timeScale = 1;
			}
		}
	}
    /*
	private void findGameEnvStuff()
	{
        //go.GetComponent<
		GameEnv env = GetComponent<GameEnv>();
		env.GetCurrentWave();
		env.GetKills();
	}
    */
    private int findAmmoCountForCurrentWeapon()
    {
        return quiver.GetCurrentWeaponAmmoCount();
    }
	void OnGUI () {

        int ammo = findAmmoCountForCurrentWeapon();

		// an example of a button for reference
		//if (GUI.Button (new Rect (10,10,200,20), "Meet the flashing button")) {
		//	print ("You clicked me!");
		//}

		//Menu
		var menuLocX = (Screen.width / 2) - 100;
		var menuLocY = (Screen.height / 2) - 100;
		if (menuVisible) {
			GUI.Label(new Rect(menuLocX,menuLocY,200,200), "MENU", "box");
			if(GUI.Button(new Rect(menuLocX,menuLocY+50,200,50),"Continue"))
			{
				//Debug.Log("Continue");
				menuVisible = false;
				Time.timeScale = 1;
			}
			if(GUI.Button(new Rect(menuLocX,menuLocY+100,200,50),"Restart"))
			{
				//Debug.Log("Restart");
				Application.LoadLevel(Application.loadedLevel);
				menuVisible = false;
				Time.timeScale = 1;
			}
			if(GUI.Button(new Rect(menuLocX,menuLocY+150,200,50),"Exit"))
			{
				//Debug.Log("Exit");
				Application.Quit();
			}
		}

        var healthXoffset = 10;
        var healthYoffset = Screen.height - 30 - 10;
        var ammoXoffset = Screen.width - 201 - 10;
        var ammoYoffset = healthYoffset;
        
		//ammo etc
		GUI.Label (new Rect (ammoXoffset, ammoYoffset - 30, 201, 30), "weapon", "box");
		GUI.Label (new Rect(ammoXoffset, ammoYoffset, 50, 30), "AMMO ", "box");
		GUI.Label (new Rect(ammoXoffset + 50, ammoYoffset, 150, 30), ammo.ToString(), "box");
        //GUI.Label (new Rect(ammoXoffset + 50, ammoYoffset, 150, 30), "999" + " / " + "999", "box");
	
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

		GUI.Label(new Rect(healthXoffset, healthYoffset - 35, 50, 30), "Wave", "box");
		GUI.Label(new Rect(healthXoffset, healthYoffset - 70, 50, 30), "Kills", "box");
		
		GUI.Label(new Rect(healthXoffset + 30, healthYoffset - 35, 50, 30), wave, "box");
		//GUI.Label(new Rect(healthXoffset + 30, healthYoffset - 35, 50, 30), kills, "box");
		
		GUI.Label(new Rect(healthXoffset + 30, healthYoffset - 75, 50, 30), kills, "box");
	}

	/*
	 Gameobject go = GameObject.Find("name");
Class c = go.GetComponent<Class>();
c.function(paramaters);
c.var = data;
	 */
}
