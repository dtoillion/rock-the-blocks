using System.Collections;
using System.Collections.Generic;
using UnityEngine.SceneManagement;
using UnityEngine.UI;
using UnityEngine;

public class GameController : MonoBehaviour {

  public static GameController control;

  public GameObject GameOverMenuCanvas;

  public GameObject RailMount;

  public float PlayerBases;
  public GameObject PlayerBase;
  private Vector3 PlayerBasePosition;

  public GameObject EnemyBase;
  private Vector3 EnemyBasePosition;

  public float Level;
  public GameObject LevelUpExplosionPrefab;
  public Text LevelText;

  public float Score;
  public Text ScoreText;

  void Awake () {
    control = this;
  }

  void Start () {
    SetupGame ();
  }

  void SetupGame () {
    PlayerBasePosition = new Vector3(14f, 0, 6F);
    EnemyBasePosition = new Vector3(14f, 0, 6F);
    StartCoroutine (SpawnPlayerBases());
  }

  IEnumerator SpawnPlayerBases()
  {
    for (int i = 0; i < PlayerBases; i++)
    {
      yield return new WaitForSeconds(0.2f);
      PlayerBasePosition = new Vector3(14f, 0, (6f - (i * 2.4f)));
      Instantiate(PlayerBase, PlayerBasePosition, Quaternion.identity);
    }

    yield return new WaitForSeconds(0.2f);
    Instantiate(RailMount, new Vector3(11f, 0f, 0f), Quaternion.identity);

    yield return new WaitForSeconds(0.2f);
    ScoreText.text = Score.ToString();

    yield return new WaitForSeconds(0.2f);
    LevelText.text = "Level " + Level.ToString();

    StartCoroutine(SpawnEnemyBases());
  }

  IEnumerator SpawnEnemyBases()
  {
    for (int i = 0; i < 6f; i++)
    {
      yield return new WaitForSeconds(0.2f);
      EnemyBasePosition = new Vector3(-14f, 0, (6f - (i * 2.4f)));
      Instantiate(EnemyBase, EnemyBasePosition, Quaternion.identity);
    }
  }

  public void UpdateHUD () {
    ScoreText.text = Score.ToString();
    LevelText.text = "Level " + Level.ToString();
    if(PlayerBases <= 0)
      GameOver();
  }

  public void EnemyChecker() {
    StartCoroutine(CheckForEnemyBases());
  }

  IEnumerator CheckForEnemyBases ()
  {
    for (int i = 0; i < 1; i++)
    {
      yield return new WaitForSeconds(0.1f);
      if(GameObject.FindGameObjectsWithTag("EnemyBase").Length <= 0f)
        NextLevel();
    }
  }

  void NextLevel() {
    Level += 1f;
    LevelText.text = "Level " + Level.ToString();
    Instantiate(LevelUpExplosionPrefab, new Vector3(0, 7f, 9f), Quaternion.identity);
    StartCoroutine(SpawnEnemyBases());
  }

  public void ResetGame () {
    GameOverMenuCanvas.SetActive(false);
    SceneManager.LoadScene("Level01");
  }

  IEnumerator GameOverCR () {
    yield return new WaitForSeconds(0.5f);
    GameOverMenuCanvas.SetActive(true);
    Time.timeScale = 0;
  }

  public void GameOver () {
    StartCoroutine(GameOverCR());
  }

}
