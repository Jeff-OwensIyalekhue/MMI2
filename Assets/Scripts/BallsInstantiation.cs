using System.Collections;
using System.Collections.Generic;
using UnityEngine;

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
    public GameObject myPrefab;
    
    public string[] prefabNames = {"Big String Ball.prefab", "Grey Fur Ball.prefab", "Leopard Fur Ball.prefab", "Wooden Ball.prefab", "Yellow Fabric Ball.prefab"};
    public GameObject[] prefabs;

    // This script will simply instantiate the Prefab when the game starts.
    void Start()
    {
        // load prefabs
        loadPrefabs();

        amountBalls = Random.Range(5,20);
        // Instantiate at position (0, 0, 0) and zero rotation.
        for (int i = 0; i < amountBalls; i++)
        {
            // pick random prefab
            int index = Random.Range(0, prefabs.Length - 1);
            GameObject prefab = prefabs[index];

            // render at random position
            float x = Random.Range(minX, maxX);
            float z = Random.Range(minZ, maxZ);
            float height = Random.Range(minY, maxY);
            GameObject ball = Instantiate(prefab, transform.position + new Vector3(x, height, z), Quaternion.identity);
            Rigidbody rb = ball.GetComponent<Rigidbody>();            
            rb.AddForce(Random.onUnitSphere * 10, ForceMode.Impulse);
        }

    }

    void loadPrefabs() {
        // init loaded prefabs array
        prefabs = new GameObject[prefabNames.Length];

        // load prefabs
        for (int i = 0; i < prefabNames.Length; i++)
        {
            string prefabName = prefabNames[i];
            GameObject prefab = Resources.Load("Assets/Prefab/" + prefabName) as GameObject;
            prefabs[i] = prefab;
        }
    }
}
