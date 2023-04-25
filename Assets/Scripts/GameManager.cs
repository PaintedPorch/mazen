using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;
using UnityEngine.SceneManagement;

public class GameManager : MonoBehaviour
{
    PlayerController playerController;
    [SerializeField] TextMeshProUGUI gameOverText;
    [SerializeField] Button restartButton;
    [SerializeField] Image gameOverMenuBg;
    // Start is called before the first frame update
    void Start()
    {
        playerController = GameObject.Find("Player").GetComponent<PlayerController>();
        gameOverText.gameObject.SetActive(false);
        restartButton.gameObject.SetActive(false);
        gameOverMenuBg.gameObject.SetActive(false);
    }

    // Update is called once per frame
    void Update()
    {
        GameOver();
    }

    void GameOver() {
        if (playerController.gameOver) {
            StartCoroutine(GameOverScreenDelay());
            gameOverText.gameObject.SetActive(true);
            restartButton.gameObject.SetActive(true);
            gameOverMenuBg.gameObject.SetActive(true);
        }
    }

    public void RestartGame() {
        SceneManager.LoadScene(SceneManager.GetActiveScene().name);
    }

    IEnumerator GameOverScreenDelay() {
        yield return new WaitForSeconds(2);
    }
}
