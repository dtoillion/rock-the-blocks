using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RotateToMouser : MonoBehaviour {

  void FixedUpdate ()
  {
    RotateToMouse ();
  }

  void RotateToMouse () {
    Vector3 v3T = Input.mousePosition;
    v3T.z = Mathf.Abs(Camera.main.transform.position.y - transform.position.y);
    v3T = Camera.main.ScreenToWorldPoint(v3T);
    transform.LookAt(v3T);
  }
}
