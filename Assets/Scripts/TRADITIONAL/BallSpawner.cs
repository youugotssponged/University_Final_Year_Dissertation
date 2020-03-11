// REFERENCE BRACKEYS
using UnityEngine;

public class BallSpawner : MonoBehaviour
{
    ObjectPooler objectPooler;

    private void Start()
    {
        objectPooler = ObjectPooler.Instance;
    }

    private void FixedUpdate()
    {
        objectPooler.SpawnFromPool("Ball", transform.position, Quaternion.identity);
    }

}
