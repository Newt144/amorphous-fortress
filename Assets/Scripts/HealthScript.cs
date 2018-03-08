using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class HealthScript : MonoBehaviour {
    public float max_hp = 2;
    public float current_hp;
    public bool isEnemy = true;

    // Initialize values
    private void Start()
    {
        current_hp = max_hp;
    }
    /**
     * This script will first get a collider and first decide if it will harm them.
     * In the case if it does, hp will be subtracted from the projectile's damage.
     * When hp reaches 0 or less, the object this script is attached to will die.
     */
    private void OnTriggerEnter2D(Collider2D collision)
    {
        BulletBehavior projectile = collision.gameObject.GetComponent<BulletBehavior>();

        if(projectile != null)
        {
            if(projectile.isEnemyShot != isEnemy)
            {
                current_hp -= projectile.dmg;

                if (current_hp <= 0)
                    Destroy(gameObject);
            }
        }

    }
}
