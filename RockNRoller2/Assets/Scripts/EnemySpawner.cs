using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemySpawner : MonoBehaviour {

    [SerializeField]
    private FollowTarget ObjectToSpawn;
    [SerializeField]
    private RandomValue IntervalValues;
    public bool IsActive = true;

    private Transform _player;

    private void Awake() {
        StartCoroutine(SpawnTimer());
    }

    private void SpawnEnemy() {
        GameObject objectClone = Instantiate(ObjectToSpawn.gameObject, transform.position, Quaternion.identity);
        objectClone.transform.SetParent(transform);

        _player = GameObject.FindWithTag("Player").transform;
        objectClone.GetComponent<FollowTarget>().SetTarget(_player);
    }

    private IEnumerator SpawnTimer() {
        while (IsActive) {
            yield return new WaitForSeconds(IntervalValues.RandomNumber());
            SpawnEnemy();
        }
    }
}
