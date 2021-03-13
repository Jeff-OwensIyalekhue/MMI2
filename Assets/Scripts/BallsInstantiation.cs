using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System.Threading.Tasks;

public class BallsInstantiation : MonoBehaviour
{
    [Range(1, 10)]
    public int amountBalls;
    public float minY;
    public float maxY;
    public float minX;
    public float maxX;
    public float minZ;
    public float maxZ;

    // Reference to the Prefab. Drag a Prefab into this field in the Inspector.
    public GameObject[] myPrefabs;
    public GameObject[] balls;

    // This script will simply instantiate the Prefab when the game starts.
    void Start()
    {
        this.balls = new GameObject[this.myPrefabs.Length];
        this.amountBalls = Random.Range(5,20);
        GameObject ballsContainer = GameObject.Find("BallsContainer").transform;

        // Instantiate at position (0, 0, 0) and zero rotation.
        for (int i = 0; i < this.amountBalls; i++)
        {
            // pick random prefab
            int index = Random.Range(0, this.myPrefabs.Length - 1);
            GameObject prefab = this.myPrefabs[index];

            // render at random position
            float x = Random.Range(minX, maxX);
            float z = Random.Range(minZ, maxZ);
            float height = Random.Range(minY, maxY);
            GameObject ball = Instantiate(prefab, transform.position + new Vector3(x, height, z), Quaternion.identity);
            Rigidbody rb = ball.GetComponent<Rigidbody>();
            ball.transform.parent = ballsContainer;
            rb.AddForce(Random.onUnitSphere * 10, ForceMode.Impulse);
            this.balls[i] = ball;
        }

        // destroy balls after end of session
        Task.Delay(1000).ContinueWith(t => destroyBalls(ballsContainer));
    }

    void destroyBalls(GameObject obj)
    {
        /*
        foreach(GameObject ball in this.balls)
            {
                Destroy(ball);
            }
            */
        Destroy(obj);
    }
}
