﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Explosion : MonoBehaviour {

  public float Lifetime = 3f;
  AudioSource explosionAudio;

  void Start ()
  {
    explosionAudio = GetComponent<AudioSource>();
    explosionAudio.pitch = (Random.Range(0.5f, 1f));
    Destroy(gameObject, Lifetime);
  }

}
