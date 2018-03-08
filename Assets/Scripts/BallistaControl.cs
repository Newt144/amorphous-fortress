using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BallistaControl : MonoBehaviour {
	Vector3 mousePosition;

	void Start () { 
		
	}

	void Update () {
		// Thanks to: https://forum.unity.com/threads/2d-sprite-look-at-mouse.211601/
		// I spent a whole hour on this oh boy
		//============================== Mouse Rotation =======================================
		mousePosition = Input.mousePosition; // Obtain the local mouse position
		mousePosition = Camera.main.ScreenToWorldPoint(mousePosition); // Obtain the global mouse position

		//transform.LookAt(new Vector3(mousePosition.x, mousePosition.y, transform.position.x));
		/**
		 * According to https://docs.unity3d.com/ScriptReference/Quaternion.LookRotation.html, LookRotation
		 * will calculate a rotation with specifically with which direction to look in in the first parameter,
		 * and which direction is up in the second parameter. The direction to look in is the difference of
		 * its current position to the absolute global mouse position. In this case, this calculation will 
		 * return the relative position between the target and its current position. The reason that it calculates
		 * the relative position is because since the ballista never moves, it will be the origin, otherwise you 
		 * will get some funky rotations.
		 */
		Quaternion rot = Quaternion.LookRotation(transform.position - mousePosition, Vector3.forward ); // Calculate the rotation angle
		print("rot: " + rot.eulerAngles);
		transform.rotation = rot;

		// Since we only worry about the z rotation, x and y stays at 0. 2D top-down woooo.
		transform.eulerAngles = new Vector3(0, 0,transform.eulerAngles.z); // Do not rotate on x and y
	}   
}
