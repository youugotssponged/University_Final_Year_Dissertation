// REFERENCE BRACKEYS
using UnityEngine;

public class BallSpawner : MonoBehaviour
{
    ObjectPooler objectPooler;
    public static int BallSize;
    public GameObject BouncyBall;

    private void Awake()
    {
        objectPooler = ObjectPooler.Instance;
        BallSize = objectPooler.pools[0].size;
    }

    private void FixedUpdate()
    {
        objectPooler.SpawnFromPool("Ball", transform.position, Quaternion.identity);
    }

}
