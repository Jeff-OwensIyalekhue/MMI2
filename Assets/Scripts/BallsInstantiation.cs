using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BallsInstantiation : MonoBehaviour
{
       // Reference to the Prefab. Drag a Prefab into this field in the Inspector.
    public GameObject myPrefab;

    // This script will simply instantiate the Prefab when the game starts.
    void Start()
    {   
        int count = 10;
        // Instantiate at position (0, 0, 0) and zero rotation.
        for (int i = 0; i < count; i++)
        {
            int x = Random.Range(-1,1);
            int z = Random.Range(-1,1);
            int height = Random.Range(5,15);
            Instantiate(myPrefab, new Vector3(x, height, z), Quaternion.identity);
        }
        
    }
}
