using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Enemy : MonoBehaviour {

  public GameObject ExplosionPrefab;
  public GameObject ScoreTextPrefab;
  public Rigidbody rb;
  private bool Dead = false;
  private float Speed;


  void Start() {
    rb = GetComponent<Rigidbody>();
    SetupEnemy();
    rb.AddForce(transform.right * Speed);
  }

  void SetupEnemy() {
    Speed = 100f + (GameController.control.Level * 10f);
  }

  void OnTriggerEnter(Collider collision) {
    if(
      (collision.gameObject.tag == "Projectile") ||
      (collision.gameObject.tag == "Boundary") ||
      (collision.gameObject.tag == "PlayerBase") ||
      (collision.gameObject.tag == "Player")
      )
    {
      if(!Dead){
        Dead = true;
        if(collision.gameObject.tag == "Boundary") {
          GameController.control.GameOver();
        }
        if(collision.gameObject.tag == "Projectile") {
          Instantiate(ScoreTextPrefab, transform.position, Quaternion.Euler(90,0,0));
          GameController.control.Score += 100f;
          GameController.control.UpdateHUD();
        }
        Instantiate(ExplosionPrefab, transform.position, transform.rotation);
        Destroy(gameObject);
      }
    }
  }
}
