using System;
using UnityEngine;
using UnityEngine.SceneManagement;

public class CollisionHandler : MonoBehaviour
{
    [SerializeField] float nextLevelDelay = 1f;
    [SerializeField] AudioClip success;
    [SerializeField] AudioClip crash;
    [SerializeField] ParticleSystem successParticles;
    [SerializeField] ParticleSystem crashParticles;
    private AudioSource audioSource;
    
    private bool isTransitioning = false;
    private bool isCollisionDisabled = false;

    private void Start()
    {
        audioSource = GetComponent<AudioSource>();
    }

    private void Update()
    {
        DebugKeys();
    }

    private void DebugKeys()
    {
        if (Input.GetKeyDown(KeyCode.L))
        {
            LoadNextLevel();
        }
        else if (Input.GetKeyDown(KeyCode.C))
        {
            // if its enabled disable it vice versa everytime it is called
            //  A TOGGLE
            isCollisionDisabled = !isCollisionDisabled;
        }
    }

    private void OnCollisionEnter(Collision other)
    {
        // if were transitioning or if collision is disabled then return
        if (isTransitioning || isCollisionDisabled)
        {
            return;
        }

        string tagName = other.gameObject.tag;
        
        switch (tagName)
        {
            case "Friendly":
                //Debug.Log("This thing is Friendly");
                break;
            case "Finish":
                StartSuccessSequence();
                break;
            default:
                StartCrashSequence();
                break;
        }
    }

    private void StartSuccessSequence()
    {
        isTransitioning = true;
        
        //Stop previous audio
        audioSource.Stop();
        audioSource.PlayOneShot(success);    
        
        // Add particle effect upon landing
        successParticles.Play();
        
        GetComponent<Movement>().enabled = false;
        Invoke("LoadNextLevel", nextLevelDelay);
    }

    private void StartCrashSequence()
    {
        isTransitioning = true;
        
        //Stop previous audio
        Debug.Log("Stopping audio");
        audioSource.Stop();
        audioSource.PlayOneShot(crash);  
        
        // Add particle effect upon crash
        crashParticles.Play();
        
        GetComponent<Movement>().enabled = false;
        Invoke("ReloadLevel", nextLevelDelay);
    }

    private void LoadNextLevel()
    {
        int currentSceneIndex = SceneManager.GetActiveScene().buildIndex;
        int nextSceneIndex = currentSceneIndex + 1;
        if (nextSceneIndex == SceneManager.sceneCountInBuildSettings)
        {
            nextSceneIndex = 0;
        }
        
        SceneManager.LoadScene(nextSceneIndex);
    }

    private void ReloadLevel()
    {
        int currentSceneIndex = SceneManager.GetActiveScene().buildIndex;
        SceneManager.LoadScene(currentSceneIndex);
    }
}
