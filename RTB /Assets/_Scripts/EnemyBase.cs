using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyBase : MonoBehaviour {

  private float Health = 4f;
  public GameObject ExplosionPrefab;
  public GameObject ScoreTextPrefab;
  private bool Dead = false;

  void OnTriggerEnter(Collider collision) {
    if(collision.gameObject.tag == "Projectile")
    {
      Health -= 1f;
      transform.localScale -= new Vector3(0.2F, 0.2F, 0.2F);
      Instantiate(ExplosionPrefab, transform.position, transform.rotation);
      if((!Dead) && (Health <= 0)) {
        Dead = true;
        GameController.control.Score += 500f;
        GameController.control.UpdateHUD();
        GameController.control.EnemyChecker();
        Instantiate(ScoreTextPrefab, transform.position, Quaternion.Euler(90,0,0));
        Destroy(gameObject);
      }
    }
  }

}
