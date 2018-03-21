using System.Collections;
using System.Collections.Generic;
using UnityEngine;

/** Causes the gameObject to rotate towards the player's cursor at a given speed. 
 * Useful for turrets and anything else which should always turn to face the cursor.
 */

public class FaceCursor : MonoBehaviour {

    // Turn speed still appears to be near instant at half maximum, without being truly instant.
    [Range(0.001f, 0.5f)]
    public float rotateSpeed;

	private void FixedUpdate()
	{
        // mousePosition gives pixel coordinates, with (0, 0) at the bottom left
        // of the screen. These must be translated to world coordinates before
        // an accurate direction vector between the two points can be determined.
        Vector3 cursorPos = Camera.main.ScreenToWorldPoint(Input.mousePosition);

        // Everything is converted to Vector2 in order to flatten the z components to 0.
        Vector2 toCursor = cursorPos - transform.position;

        // This limits the rotation possible in one frame, and therefore the 
        // maximum turn speed.
        float angle = Mathf.Clamp(Vector2.SignedAngle(transform.up, toCursor), 
                                  rotateSpeed * -360, rotateSpeed * 360);
        transform.Rotate(Vector3.forward, angle);
	}
}
