using System.Collections;
using System.Collections.Generic;
using System.Reflection;
using UnityEngine;

public enum Pattern { Linear, Wave };

public class Move : MonoBehaviour {
    [Range(0, 1)]
    public float speed;
    public Pattern pattern;

    MethodInfo patternMethod;
    Rigidbody2D rb;
    Vector3 playerPos;


	private void Awake()
	{
        patternMethod = this.GetType().GetMethod(pattern.ToString());
        rb = gameObject.GetComponent<Rigidbody2D>();
        playerPos = GameObject.Find("Fortress").transform.position;
	}

	private void FixedUpdate()
	{
        if (rb != null)
            rb.velocity = (Vector3)patternMethod.Invoke(this, null) * speed;
        else
            Debug.Log("No RB");
	}

    public Vector3 Linear()
    {
        Vector3 target = playerPos - transform.position;
        return target.normalized;
    }

    public Vector3 Wave()
    {
        Vector3 target = playerPos - transform.position;
        float timeAngle = Mathf.Abs((Time.time % 10 / 5) - 1) * 180;
        return Quaternion.AngleAxis(Mathf.Cos(timeAngle), Vector3.forward) * target;
    }
}
