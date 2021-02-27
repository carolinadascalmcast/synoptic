using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class GoalController : MonoBehaviour
{
    int score = 0;
    [SerializeField] Text playerScoreText;

    bool isWinner = false;

    // Start is called before the first frame update
    void Start()
    {
        playerScoreText.text = "Score: " + score.ToString();
    }

    private void OnCollisionEnter2D(Collision2D collision)
    {
        if(collision.gameObject.CompareTag("Football"))
        {
            Destroy(collision.gameObject);

            GetComponent<AudioSource>().Play();

            score++;
            playerScoreText.text = "Score: " + score.ToString();

            if(score>=20 && isWinner==false)
            {
                isWinner = true;
                StartCoroutine("LoadWinSceneRoutine");
            }

        }
    }

    IEnumerator LoadWinSceneRoutine()
    {
        yield return new WaitForSeconds(2f);
        SceneManager.LoadScene("Win");
    }
}
