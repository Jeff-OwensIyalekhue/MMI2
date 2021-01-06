using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BallsInstantiation : MonoBehaviour
{
    [Range(1, 10)]
    public int amountBalls = 10;
    public float minY;
    public float maxY;
    public float minX;
    public float maxX;
    public float minZ;
    public float maxZ;

    // Reference to the Prefab. Drag a Prefab into this field in the Inspector.
    public GameObject myPrefab;

    // This script will simply instantiate the Prefab when the game starts.
    void Start()
    {
        // Instantiate at position (0, 0, 0) and zero rotation.
        for (int i = 0; i < amountBalls; i++)
        {
            float x = Random.Range(minX, maxX);
            float z = Random.Range(minZ, maxZ);
            float height = Random.Range(minY, maxY);
            GameObject ball = Instantiate(myPrefab, transform.position + new Vector3(x, height, z), Quaternion.identity);
            Rigidbody rb = ball.GetComponent<Rigidbody>();            
            rb.AddForce(Random.onUnitSphere * 10, ForceMode.Impulse);
        }

    }
}
