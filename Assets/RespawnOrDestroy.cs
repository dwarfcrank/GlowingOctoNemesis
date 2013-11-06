using UnityEngine;
using System.Collections;

public class RespawnOrDestroy : MonoBehaviour {
	
	public GameObject player;
	public Health health;
	public int deaths;
	public SpawnAtCheckpoint spawnAtCheckpoint;
	
	// Use this for initialization
	void Start () {
		player = GameObject.FindGameObjectWithTag("Player");
		health = player.GetComponent<Health>();
		spawnAtCheckpoint = player.GetComponent<SpawnAtCheckpoint>();
		deaths = 0;
	}
	
	// Update is called once per frame
	void Update () {
		
		float curHealth = health.health;
		
		if (curHealth == 0) {
			incrementCounterByOne();		
		}	
	}
	
	void incrementCounterByOne() {
		deaths++;
	}
}
