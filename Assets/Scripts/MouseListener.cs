using UnityEngine;
using System.Collections;

public class MouseListener : MonoBehaviour {

	public bool isQuitButton = false;

	void OnMouseEnter()
	{
		Debug.Log("jeeee hiiri tuli");
		renderer.material.color = Color.green;
	}

	void OnMouseExit()
	{
		Debug.Log("hiiri meni :(");
		renderer.material.color = Color.white;
	}

	void OnMouseUp()
	{
		if (isQuitButton) {
			Application.Quit ();
		} else {
			Application.LoadLevel("arena");
		}
	}
}
