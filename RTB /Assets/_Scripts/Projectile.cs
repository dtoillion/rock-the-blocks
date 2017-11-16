using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Projectile : MonoBehaviour {

  public float Speed = 250f;
  private Rigidbody rb;
  AudioSource LaserAudio;
  public GameObject ExplosionPrefab;

  private void Awake ()
  {
    rb = GetComponent<Rigidbody>();
    LaserAudio = GetComponent<AudioSource>();
  }

  private void Start ()
  {
    LaserAudio.pitch = (Random.Range(0.6f, 1.2f));
    rb.AddForce(transform.forward * Speed);
  }

  void OnTriggerEnter(Collider collision) {
    if((collision.gameObject.tag == "Enemy") || (collision.gameObject.tag == "Boundary") || (collision.gameObject.tag == "Projectile") || (collision.gameObject.tag == "EnemyBase"))
    {
      Instantiate(ExplosionPrefab, transform.position, transform.rotation);
      Destroy(gameObject);
    }
  }

}
