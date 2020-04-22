using UnityEngine;
using System.Collections;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class GameManager : MonoBehaviour
{
    [SerializeField]
    Transform UIPanel;

    [SerializeField]
    Text timeText;

    private int DNAValue = 10;
    public Text DNA;
    //public int peopleEaten;
    //public int eatenCivs;
    bool evolve;
    bool isPaused;
	private GameManager gm;
    void Start()
    {
		gm = this;
        UIPanel.gameObject.SetActive(false);
        isPaused = false;
        // DNA = GetComponent<Text>();
    }
    void Update()
    {
        timeText.text = "Time Since Startup: " + Time.timeSinceLevelLoad;

        if (Input.GetKeyDown(KeyCode.Escape) && !isPaused)
            Pause();
        else if (Input.GetKeyDown(KeyCode.Escape) && isPaused)
            UnPause();

        DNA.text = "Food needed:" + gm.getDNAValue();

    }
    public void Pause()
    {
        isPaused = true;
        UIPanel.gameObject.SetActive(true);
        Time.timeScale = 0f;
    }
    public void UnPause()
    {
        isPaused = false;
        UIPanel.gameObject.SetActive(false);
        Time.timeScale = 1f;
    }

    public void QuitGame()
    {
        Application.Quit();
    }
    public void Restart()
    {
        SceneManager.LoadScene(0);
    }
    public void setDNAValue(int n)
    {
       n = DNAValue;
    }
    public int getDNAValue()
    {
        return DNAValue;
    }
    public void subtractDNAValue()
    {
       DNAValue--;
    }
}