using System.Collections;
using System.Collections.Generic;
using UnityEngine.UI;

using UnityEngine;

public class UIManager : MonoBehaviour
{
    //handle to text
    [SerializeField]
    private Text _scoreText;
    [SerializeField]
    private Text _gameOverText;
    [SerializeField]
    private Sprite[] _livesSprites;
    [SerializeField]
    private Image _LivesImg;
    [SerializeField]
    private Text _restartText;
    private PlayerScript _player;
    private GameManager _gamemanager;
   //private bool _canRestart = false;
    // Start is called before the first frame update
    void Start()
    {
        _player = GameObject.Find("Player").GetComponent<PlayerScript>();
        _gamemanager = GameObject.Find("Game_Manager").GetComponent<GameManager>();
        _scoreText.text = "Score:" + 0;
        _gameOverText.gameObject.SetActive(false);
        
        if(_gamemanager == null)
        {
            Debug.Log("Game Manager is null");
        }

    }

    public void UpdateScoreUI(int playerScore)
    {
        _scoreText.text = "Score: " + playerScore.ToString();
    }

    public void UpdateLives(int currentLives)
    {
        _LivesImg.sprite = _livesSprites[currentLives];
        if(currentLives == 0)
        {
            GameOverSequence();

        }
    }
  

    void GameOverSequence()
    {
        _gamemanager.GameOver();
        _gameOverText.gameObject.SetActive(true);
        _restartText.gameObject.SetActive(true);
        StartCoroutine(GameOverFlickerRoutine());
        
    }
        IEnumerator GameOverFlickerRoutine()
    {
        while (true)
        {
            _gameOverText.text = "GAME OVER!";
            yield return new WaitForSeconds(0.5f);
            _gameOverText.text = " ";
            yield return new WaitForSeconds(0.5f);
        }
    }
}
