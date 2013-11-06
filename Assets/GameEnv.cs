using UnityEngine;
using System.Collections;

public class GameEnv : MonoBehaviour {

	// Use this for initialization
	void Start () {
        var enemies = GameObject.FindGameObjectsWithTag("Enemy");

        foreach (var enemy in enemies)
        {
            enemy.SetActive(true);
        }
	}
	
	// Update is called once per frame
	void Update () {
	
	}
}
