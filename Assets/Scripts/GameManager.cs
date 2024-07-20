using UnityEngine;
using UnityEngine.UI;

public class GameManager : MonoBehaviour
{
    private Player player;
    private Spawner spawner;

    public Text scoreText;
    public GameObject playButton;
    public GameObject gameOver;
    public int score { get; private set; }

    private void Awake()
    {
        Application.targetFrameRate = 60;

        player = FindObjectOfType<Player>();
        spawner = FindObjectOfType<Spawner>();

        Pause();
    }

    public void Play()
    {
 	    PlayGameStartSound();

        score = 0;
        scoreText.text = score.ToString();

        playButton.SetActive(false);
        gameOver.SetActive(false);

        Time.timeScale = 1f;
        player.enabled = true;

        Pipes[] pipes = FindObjectsOfType<Pipes>();

        for (int i = 0; i < pipes.Length; i++) {
            Destroy(pipes[i].gameObject);
        }
    }

    public void GameOver()
    {

        playButton.SetActive(true);
        gameOver.SetActive(true);
        PlayGameOverSound();
        Pause();
    }
    
    private void PlayGameStartSound()
    {
        int i = (int)Random.Range(0,100) % 2;
        SoundManager.PlaySound("gamestart0"+i);
    }


    private void PlayGameOverSound()
    {
        int i = (int)Random.Range(0,100) % 3;
        SoundManager.PlaySound("gameover0"+i);
    }


    public void Pause()
    {
        Time.timeScale = 0f;
        player.enabled = false;
    }

    public void IncreaseScore()
    {
        score++;
        scoreText.text = score.ToString();
    }

}