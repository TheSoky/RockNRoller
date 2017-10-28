using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class HealthManager : MonoBehaviour
{
    public enum OnAllLivesGone {

        DefeatScreen,
        DestroyObject
    }

    [SerializeField]
    private int StartingHealth = 10;
    [SerializeField]
    private int NumberOfLives = 2;
    [SerializeField]
    private OnAllLivesGone onDeath = OnAllLivesGone.DestroyObject;
    [SerializeField]
    private Vector3 StartingPosition = Vector3.zero;
    [SerializeField]
    private GameObject ExplosionPrefab;
    [SerializeField]
    LevelManager Lm;
    private int health;
    private Rigidbody rb;

    private void Start()
    {
        StartingPosition = transform.position;
        health = StartingHealth;
        rb = GetComponent<Rigidbody>();
    }

    void Update ()
	{
		if (health <= 0.0f)
		{
            RemoveLive();
		}
        CheckHeight();    
	}

	public void ChangeHealth (int amount) {
        health += amount;
    }

	public void AddLives (int amount)
	{
		NumberOfLives += amount;
	}

	public void RemoveLive ()
	{
		NumberOfLives --;

        if(rb != null) {
            rb.velocity = Vector3.zero;
        }

        if (NumberOfLives > 0) {
            // restiraj vrijednosti i poziciju igraca
            health = StartingHealth;
            transform.position = StartingPosition;
        }
        else {
            switch (onDeath) {
                case OnAllLivesGone.DefeatScreen:
                    Lm.GameLost();
                    return;

                case OnAllLivesGone.DestroyObject:
                    Instantiate(ExplosionPrefab, transform.position, Quaternion.identity);
                    Destroy(gameObject);

                    return;

                default:
                    Instantiate(ExplosionPrefab, transform.position, Quaternion.identity);
                    Destroy(gameObject);
                    return;
            }
        }
    }

    void CheckHeight() {
        if (transform.position.y < -15) {
            RemoveLive();
        }
    }

    public float GetCurrentHealth() {
        return health;
    }

    public  int GetCurrentLives() {
        return NumberOfLives;
    }
}