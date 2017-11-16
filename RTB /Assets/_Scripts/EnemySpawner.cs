using UnityEngine;
using System.Collections;

public class EnemySpawner : MonoBehaviour {

  public GameObject[] Enemies;
  public float SpawnRateA = 0f;
  public float SpawnRateB = 0f;

  void Start ()
  {
    StartCoroutine (Spawn());
  }

  IEnumerator Spawn()
  {
    while(true)
    {
      yield return new WaitForSeconds (Random.Range(SpawnRateA, SpawnRateB));
      for (int i = 0; i < 1; i++)
      {
        Instantiate(Enemies[Random.Range(0, Enemies.Length)], new Vector3(transform.position.x + 1.1f, transform.position.y, transform.position.z), Quaternion.identity);
      }
    }
  }

}
