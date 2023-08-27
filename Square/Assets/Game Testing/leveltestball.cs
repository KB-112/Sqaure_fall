using System.Collections;
using UnityEngine;
using System;

using UnityEngine.UI;


public class leveltestball : MonoBehaviour
{

    [Header("BOOLEAN")]
    public bool stopball = false;
    bool check = false;

    [Header("DEFAULT VALUE")]
    [SerializeField] private int multiplier = 1;
    [SerializeField] private float storedposition;
    private float storedScaleBallTime;
    [SerializeField] private float timeTracker = 0f;


    [Header("USER INPUT")]
    [SerializeField] private float startPosition;
    [SerializeField] private float sizeIncreaseAmount, sizeIncreaseDuration;
    [SerializeField] private float travelDuration;
    public GameObject bar;
    public GameObject rball;
    public GameObject Score_text;


    [Header("REFRENCE SCRIPT")]
    public SpriteRenderer barPathSize;
    public CameraMOvement cameraMOvement;
    public DestroyParticleSystem destroyparticleSystem;
    public ObstaclesController[] obstaclesControllers;
    public Red_square rSquare;
    public points score;
    public SoundSystem soundController;
    public static RedBall Instance { get; private set; }

    public int deathCount = 0;
    public int noOfTimesBallSpawnAfterDeath;



    public float speed;
    public float distance = 0f;
    public float durationLeft;
    public float targetDistance = 0f;
    bool shouldTranslate = true;
    public Button startButton;
    public GameObject taptoshoot;
    public GameObject PLayer;
    public ParticleSystem[] bullett_ribbon;

    public PauseGame Pgame;
    public Button buyrevival;
    bool spentquantacoins = false;


    public PauseGame pgame;

    public Button Quitbtn;
    void Start()
    {
        deathCount = 0;
        buyrevival.onClick.AddListener(continuegame);
        Quitbtn.onClick.AddListener(quitgame);
    }

    public void callbutton()
    {

        startButton.enabled = false;
        taptoshoot.SetActive(false);

        StartCoroutine(MOve());
        StartCoroutine(IncreaseSizeCoroutine());
        barPathSize.size = new Vector2(2 * Math.Abs(startPosition - 0.25f - transform.localScale.x / 2), 0.48f);  //bar length dependency accorrding to ball coordinates 
        bar.transform.position = new Vector2(0, -startPosition);


    }


    private void Update()
    {

        if (stopball) return;
        if (!shouldTranslate)
        {


            if (Input.GetMouseButtonDown(0))
            {
                multiplier *= -1;
                check = true;
                BallMovement();
                travelDuration = 1.3f;
                soundController.move();                                        //Ball Controller
            }
            else
            {
                check = false;
                travelDuration = 1.3f;
                BallMovement();
            }
        }
    }

    public void BallMovement()
    {
        timeTracker += Time.deltaTime * multiplier * (1 / travelDuration);
        timeTracker = Mathf.Clamp01(timeTracker);
        if (check)
        {
            storedposition = 1 / storedposition;
            Debug.Log(storedposition);
            storedposition = Mathf.Lerp(startPosition, -startPosition, timeTracker);                               //Ball Input Controller
        }
        else if (!check)
        {
            storedposition = Mathf.Lerp(startPosition, -startPosition, timeTracker);
        }
        transform.position = new Vector2(storedposition, -startPosition);


        if (timeTracker == 1)
        {

            multiplier *= -1;
            soundController.rebound();
        }

        else if (timeTracker == 0)
        {

            multiplier *= -1;
            soundController.rebound();
        }


    }



    private IEnumerator MOve()
    {
        bullett_ribbon[0].Play();
        bullett_ribbon[1].Play();

        while (distance < targetDistance && shouldTranslate)
        {
            transform.Translate(Vector3.down * speed * Time.deltaTime);
            distance += speed * Time.deltaTime;
            yield return null;  // Wait for the next frame
        }



        // Move left
        float elapsedTime = 0f;
        Vector3 originalPosition = transform.position;
        Vector3 targetPosition = originalPosition + Vector3.left * speed; // Move 5 units to the left
        while (elapsedTime < durationLeft) // Duration of the leftward movement
        {
            transform.position = Vector3.Lerp(originalPosition, targetPosition, elapsedTime / 1f);
            elapsedTime += Time.deltaTime;
            yield return null;  // Wait for the next frame
            PLayer.SetActive(false);
        }

        shouldTranslate = false;  // Stop the translation

    }

    private IEnumerator IncreaseSizeCoroutine()
    {



        float originalSize = transform.localScale.x;
        float targetSize = originalSize + sizeIncreaseAmount;
        float elapsedTime = 0f;
        while (elapsedTime < sizeIncreaseDuration)                                                                   //Ball Size Controller
        {

            elapsedTime += Time.deltaTime;
            storedScaleBallTime = Mathf.Clamp01(elapsedTime / sizeIncreaseDuration);
            transform.localScale = Vector3.one * Mathf.Lerp(originalSize, targetSize, storedScaleBallTime);
            yield return null;
        }

    }

    public void OnTriggerEnter2D(Collider2D collision)
    {

        if (collision.gameObject.layer == LayerMask.NameToLayer("redSquare"))
        {
            score.UpdateScore();
            Destroy(collision.gameObject);
            soundController.point();
        }
        if (collision.gameObject.layer == LayerMask.NameToLayer("Obstacles"))
        {

            Debug.Log("destroy happen");



            if (collision.gameObject)
            {
                soundController.explode();


                Pgame.PauseScreen();

                if (spentquantacoins)
                {
                    DeathCounter();

                    return;
                }
                else
                {


                    StartCoroutine(EndGameCOntroller());

                }



            }

        }

    }

    void quitgame()
    {
        StartCoroutine(EndGameCOntroller());
    }



    void DeathCounter()
    {
        deathCount++;
        PlayerPrefs.SetInt("DeathCount", deathCount);
        Debug.Log("Death COunt " + deathCount);


        if (deathCount <= 2)
        {
            Time.timeScale = 0;



        }
        else
        {
            Pgame.UnpauseScreen();

            deathCount = 0; // Reset deathCount back to 0

        }
    }

    IEnumerator EndGameCOntroller()
    {

        yield return new WaitForSeconds(0);

        stopball = true;


        for (int i = 0; i < obstaclesControllers.Length; i++)
        {
            obstaclesControllers[i].shouldMove = true;
        }


        SpriteRenderer spriteRenderer = this.gameObject.GetComponent<SpriteRenderer>();
        spriteRenderer.enabled = false;

        CircleCollider2D collider = GetComponent<CircleCollider2D>();
        collider.enabled = false;



        destroyparticleSystem.UnpauseParticleSystem();
        bullett_ribbon[0].Stop();
        bullett_ribbon[1].Stop();






        yield return new WaitForSeconds(0.5f);
        Debug.Log("Flag initiation Successfull");
        destroyparticleSystem.NonActive();
        yield return new WaitForSeconds(0.5f);
        cameraMOvement.ball_collision_successful = true;

    }

    void continuegame()
    {
        spentquantacoins = true;

    }
}
