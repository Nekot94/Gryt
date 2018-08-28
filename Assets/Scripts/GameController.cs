using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class GameController : MonoBehaviour
{
    public static GameController instance;
    public Text scoreText;
    public GameObject endText;
    public int scores;
    
	void Start ()
	{
        instance = this;
	}
	
    public void ChangeScores(int scores)
    {
        this.scores += scores;
        scoreText.text = "Очки: " + this.scores;
    }

    public void Lose()
    {
        endText.SetActive(true);
        StartCoroutine(Restart());
    }

    IEnumerator Restart()
    {
        yield return new WaitForSeconds(4);
        SceneManager.LoadScene(SceneManager.GetActiveScene().name);
    }
}
