using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class Player : MonoBehaviour
{
    public bool gameOver = false;

    public int maxFill = 20;
    public int minFill = 0;
    public int currentFill;
    public Text gameOverText;
    public Text endText;
    public int scoreAmount;

    public GameObject timer;

    //not sure about
    public GameObject textDisplay;
    public int secondsLeft = 12;
    public bool takingAway = false;

    public AudioClip winSound;
    public AudioClip loseSound;
    public AudioClip tapSound;
    public FillBar fillBar;

    public ParticleSystem shine;

    AudioSource audioSource;

    // Start is called before the first frame update
    void Start()
    {
        // not sure
        textDisplay.GetComponent<Text>().text = "00:" + secondsLeft;
        gameOverText.text = "Dance Moves Done: " + scoreAmount.ToString();
        scoreAmount = 0;
        currentFill = minFill;
        fillBar.SetMaxFill(maxFill);

        audioSource = GetComponent<AudioSource>();
    }

    // Update is called once per frame
    void Update()
    {
        // not sure about
        if (takingAway == false && secondsLeft > 0)
        {
            StartCoroutine(TimerTake());
        }


        gameOverText.text = "Dance Moves Done: " + scoreAmount.ToString();

        if (scoreAmount == 20)
        {
            endText.text = "You Win! Game by Fernando D Villegas. Press R to restart";
            Destroy(timer);
            Destroy(textDisplay);
            PlaySound(winSound);
            gameOver = true;
            
        }
        if (secondsLeft == 0)
        {
            endText.text = "You Lose! Game by Fernando D Villegas. Press R to restart";
            PlaySound(loseSound);
            gameOver = true;
           
            
        }

        if (Input.GetKey(KeyCode.R))

        {

            if (gameOver == true)

            {

                SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex); // this loads the currently active scene

            }

        }

        if (Input.GetKeyDown(KeyCode.Space))
        {
            DanceFill(1);
        }

        if (Input.GetKey("escape"))
        {
            Application.Quit();
        }

    }

    IEnumerator TimerTake()
    {
        takingAway = true;
        yield return new WaitForSeconds(1);
        secondsLeft -= 1;
        if (secondsLeft < 10)
        {
            textDisplay.GetComponent<Text>().text = "00:0" + secondsLeft;
        }
        else
        {
            textDisplay.GetComponent<Text>().text = "00:" + secondsLeft;
        }
        takingAway = false;
    }


    void DanceFill(int heal)
    {
        currentFill += heal;
        PlaySound(tapSound);
        shine.Play();
        scoreAmount +=1;

        fillBar.SetFill(currentFill);
    }

    public void PlaySound(AudioClip clip)
    {
        audioSource.PlayOneShot(clip);
    }

}
