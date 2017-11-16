using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RailMount : MonoBehaviour {

  private float MoveValue;
  private Rigidbody rb;

  public GameObject ExplosionPrefab;

  private void Start () {
    rb = GetComponent<Rigidbody>();
  }

  private void Update () {
    MoveValue = Input.GetAxis("Vertical");
  }

  private void FixedUpdate () {
    rb.MovePosition(transform.position + transform.forward * MoveValue * Time.deltaTime * 20f);
  }

  void OnTriggerEnter(Collider collision) {
    if(collision.gameObject.tag == "Enemy") {
      Instantiate(ExplosionPrefab, transform.position, Quaternion.Euler(0,0,0));
      GameController.control.GameOver();
      Destroy(gameObject);
    }
  }

}
