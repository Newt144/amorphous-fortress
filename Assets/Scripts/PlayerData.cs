using UnityEngine;

/** This singleton globally provides all variables directly relevant to the player.
 * Any player stats, such as health, ammo, firerate, or consumables should be a 
 * public variable in this instance. Anything that modifies these stats, whether 
 * enemies or skills, should do so by referencing this class in a script of their own.
 */

public class PlayerData : MonoBehaviour {

    public static PlayerData Instance { get; private set; }

    public int health;
    public float fireRate;
    public float projectileSpeed;
    public float pierceCount;


	private void Awake()
	{
        // Singleton behavior prevents more than one instance of this class from
        // existing.
        if (Instance == null)
        {
            Instance = this;
            DontDestroyOnLoad(gameObject);
        }
        else
        {
            Destroy(gameObject);
        }
	}

	
}
