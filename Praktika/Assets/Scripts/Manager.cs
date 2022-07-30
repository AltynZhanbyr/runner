using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class Manager : MonoBehaviour
{
    public Text PointText;
    public Text ExitText;
    public Text EndPointText;
    public Button EndButton;
    public Text EndButtonText;
    public Text EndText;
    public GameObject Puller;
    public PlayerMove Player;
    [SerializeField] private AudioSource audio;

    public float Points;

    void Start()
    {
        Points = 0;
        PointText.text = Points.ToString();
        EndText.enabled = false;
    }

    void Update()
    {
        if (!EndText.enabled)
            Pointer();
    }

    public void EndGame() 
    {
        Puller.SetActive(false);
        Player.Animator.enabled = false;
        Player.GetComponent<Rigidbody2D>().isKinematic = true;
        EndText.enabled = true;
        EndButtonText.enabled = true;
        EndButton.enabled = true;
        EndPointText.enabled = true;
        PointText.enabled = false;
        ExitText.enabled = true;
        audio.Pause();
    }
    public void Retry() 
    {
        SceneManager.LoadScene(0);
    }
    public void Pointer() 
    {
        Points += Time.deltaTime * 2;
        PointText.text = Mathf.Round(Points).ToString();
        EndPointText.text = PointText.text;
    }
    public void Quit() 
    {
        Application.Quit();
    }
}
