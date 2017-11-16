using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EscapeMenu : MonoBehaviour {

  public GameObject EscapeMenuCanvas;
  private bool Paused;

  void Awake ()
  {
    EscapeMenuCanvas.SetActive(false);
    Paused = false;
    Time.timeScale = 1;
  }

  public void PauseGame ()
  {
    if(!Paused)
    {
      Paused = true;
      Time.timeScale = 0;
      EscapeMenuCanvas.gameObject.SetActive(true);
    } else {
      Paused = false;
      Time.timeScale = 1;
      EscapeMenuCanvas.gameObject.SetActive(false);
    }
  }

  void Update ()
  {
    if(Input.GetKeyDown("escape"))
    {
      PauseGame ();
    }

  }
}
