using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ObjectSpawner : MonoBehaviour {

    [SerializeField]
    private RandomValue IntervalValues;
    [SerializeField]
    private GameObject ObjectToSpawn;
    public bool IsActive = true;

    private void Awake() {
        StartCoroutine(SpawnTimer());
    }

    private void SpawnObject() {
        GameObject objectClone = Instantiate(ObjectToSpawn, transform.position, Quaternion.identity);
        objectClone.transform.SetParent(transform);
    }

    private IEnumerator SpawnTimer() {
        while (IsActive) {
            yield return new WaitForSeconds(IntervalValues.RandomNumber());
            SpawnObject();
        }
    }
}
