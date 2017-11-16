using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Gun : MonoBehaviour {

  public GameObject Bullet;
  public float FireRate;
  private float NextFire;

  void Update () {
    if(Input.GetKey(KeyCode.Mouse0) && Time.time > NextFire) {
      NextFire = Time.time + FireRate;
      Instantiate(Bullet, transform.position, transform.rotation);
    }
  }

}
