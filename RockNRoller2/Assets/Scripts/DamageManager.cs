using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DamageManager : MonoBehaviour {

    [SerializeField]
    private int Damage = 5;

    private void OnCollisionEnter(Collision other)
    {
        HealthManager healthManager = other.gameObject.GetComponent<HealthManager>();

        if(healthManager != null)
        {
            healthManager.ChangeHealth (-Damage);
        }
    }

}
