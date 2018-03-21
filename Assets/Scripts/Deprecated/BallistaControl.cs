using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BallistaControl : MonoBehaviour {

    // This holds changable values for the skill tree later
    public class projectileInfo
    {
        public UnityEngine.Object objType;
        public float dmg;
        public Vector2 speed;
        public Vector2 direction;
        public int timeAlive;
        public float max_hp;

        public projectileInfo() { }

        public projectileInfo(projectileInfo info)
        {
            this.objType    = info.objType;
            this.dmg        = info.dmg;
            this.speed      = info.speed;
            this.direction  = info.direction;
            this.timeAlive  = info.timeAlive;
        }

    }

    public GameObject bulletControl;
    Vector3 mousePosition;
    public Quaternion rot;
    public Vector3 direction;
    // The ballista itself remembers the stats of the projectile, so it is easier
    // to modify the projectile and just have the ballista create copies of it.
    public static projectileInfo ballistaProjectiles;
    

    private void Start()
    {
        //bulletControl = Resources.Load("Prefabs/Bullet") as GameObject;
        // Default values, may be removed later
        ballistaProjectiles             = new projectileInfo();
        ballistaProjectiles.objType     = new GameObject("Bullet");
        ballistaProjectiles.dmg         = 1;
        ballistaProjectiles.speed       = new Vector2(1, 1);
        ballistaProjectiles.direction   = new Vector2(rot.x, rot.y);
        ballistaProjectiles.timeAlive   = 20;
        ballistaProjectiles.max_hp      = 1;
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
		rot = Quaternion.LookRotation(transform.position - mousePosition, Vector3.forward ); // Calculate the rotation angle
        direction = new Vector3(Input.GetAxis("Horizontal"), Input.GetAxis("Vertical"), 0.0f);
		//print("Z rot angle: " + rot.eulerAngles.z + ", Z rot: " + rot.z);
		transform.rotation = rot;

        // Setting the projectile direction to align with the pointed angle
        ballistaProjectiles.direction = new Vector2(rot.x, rot.y);


		// Since we only worry about the z rotation, x and y stays at 0. 2D top-down woooo.
		transform.eulerAngles = new Vector3(0, 0,transform.eulerAngles.z); // Do not rotate on x and y

        //============================= SHOTS SHOTS SHOTS =====================================
        if (Input.GetMouseButtonDown(0))
        {
            createProjectile();
        }
    }

    /**
     * This will create a instance of the projectile prefab with the remembered stats.
     */
    public void createProjectile()
    {
        
        bulletControl.GetComponent<BulletBehavior>().dmg           = ballistaProjectiles.dmg;
        bulletControl.GetComponent<BulletBehavior>().timeAlive     = ballistaProjectiles.timeAlive;
        bulletControl.GetComponent<ProjectileMovement>().speed     = ballistaProjectiles.speed;
        bulletControl.GetComponent<ProjectileMovement>().direction = ballistaProjectiles.direction;
        bulletControl.GetComponent<HealthScript>().max_hp          = ballistaProjectiles.max_hp;

        //GameObject bulletPrefab = (GameObject)Instantiate(Resources.Load("Bullet")) ;
        Instantiate(bulletControl, direction, rot);
    }
}
