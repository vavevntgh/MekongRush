using System.Collections;
using System.Collections.Generic;
using UnityEngine.UI;
using UnityEngine;
using UnityEngine.SceneManagement;

public class Menu : MonoBehaviour
{
    public GameObject play_Button , Exit_Button;
    public TMPro.TMP_Text score_Text ;
    private int bestScore ;

    // Start is called before the first frame update
    void Start()
    {
        play_Button.GetComponent<Button>().onClick.AddListener(delegate {PlayButton();});
        Exit_Button.GetComponent<Button>().onClick.AddListener(delegate {ExitButton();});
        score_Text.text = bestScore.ToString() ;
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    void GetBestScore(){
        bestScore = PlayerPrefs.GetInt("BestScore",0);
    }

    // * *
    // this fuction for Button Action 
    // * *
    void PlayButton(){
        SceneManager.LoadScene("SampleScene", LoadSceneMode.Single);
    }

    void ExitButton(){
        Application.Quit();
    }
}
