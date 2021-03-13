using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BallsInstantiation : MonoBehaviour
{
  public static GameObject instance;
  [Range(1, 10)]
  public int minAmountBalls = 5;
  [Range(2, 25)]
  public int maxAmountBalls = 20;
  public static int amountBalls;
  public float minY;
  public float maxY;
  public float minX;
  public float maxX;
  public float minZ;
  public float maxZ;

  public Transform ballParent;

  // Reference to the Prefab. Drag a Prefab into this field in the Inspector.
  public GameObject[] myPrefabs;

  //public string[] prefabNames = {"Big String Ball.prefab", "Grey Fur Ball.prefab", "Leopard Fur Ball.prefab", "Wooden Ball.prefab", "Yellow Fabric Ball.prefab"};
  //public GameObject[] prefabs;

  private void Awake()
  {
    if (instance != null)
    {
      Destroy(instance.gameObject);
    }
    instance = this.gameObject;

  }

  // This script will simply instantiate the Prefab when the game starts.
  void Start()
  {
    // load prefabs
    //this.prefabs = loadPrefabs();

    amountBalls = Random.Range(minAmountBalls, maxAmountBalls);
    print("balls: " + amountBalls);
    // Instantiate at position (0, 0, 0) and zero rotation.
    for (int i = 0; i < amountBalls; i++)
    {
      // pick random prefab
      int index = Random.Range(0, this.myPrefabs.Length);
      GameObject prefab = this.myPrefabs[index];

      // render at random position
      float x = Random.Range(minX, maxX);
      float z = Random.Range(minZ, maxZ);
      float height = Random.Range(minY, maxY);
      GameObject ball = Instantiate(prefab, transform.position + new Vector3(x, height, z), Quaternion.identity);
      ball.transform.parent = ballParent;
      Rigidbody rb = ball.GetComponent<Rigidbody>();
      rb.AddForce(Random.Range(0f, 0.5f), Random.Range(5f, 7.5f), Random.Range(0f, 0.5f), ForceMode.Impulse);
    }

  }
}
