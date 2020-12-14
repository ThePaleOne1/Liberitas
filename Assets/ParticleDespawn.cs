using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ParticleDespawn : MonoBehaviour
{
    public float DespawnTimer = 3;
    void Start()
    {
        Invoke("Despawn", DespawnTimer);
    }

    void Despawn()
    {
        Destroy(this.gameObject);
    }
}
