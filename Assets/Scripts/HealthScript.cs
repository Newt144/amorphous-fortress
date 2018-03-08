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
        BulletBehavior projectile   = collision.gameObject.GetComponent<BulletBehavior>();
        HealthScript colliderHealth = collision.gameObject.GetComponent<HealthScript>();
        print(gameObject.name + " collided with " + collision.gameObject.name);
        if(projectile != null)
        {
            if(projectile.isEnemyShot != isEnemy)
            {
                print(gameObject.name + " was just hit for " + projectile.dmg + " damage!");
                current_hp -= projectile.dmg;
                print(gameObject.name + "'s current hp: " + current_hp);
            }
        } else if(colliderHealth.isEnemy){
            // Bullet's hp acts as the "pierce" stat
            print(gameObject.name + " collided, taking off 1 pierce");
            current_hp--;
        }

        // Delete the object when hp is 0 or less.
        if (current_hp <= 0)
        {
            print("Delete " + gameObject.name);
            Destroy(gameObject);
        }
    }
}
