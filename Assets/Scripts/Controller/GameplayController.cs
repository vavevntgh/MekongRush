using System.Collections;
using System.Collections.Generic;
using UnityEngine.UI;
using UnityEngine;
using UnityEngine.SceneManagement;

enum PlayerStatus
{   
    Playing , 
    Win , 
    Lose
}

public class GameplayController : MonoBehaviour
{   
    public GameObject Player ;
    public Transform SpawnPosition ;
    [Space]    
    internal PlayerStatus _status ;
    internal PlayerStatus status {
        get
        {
            return _status ;
        }
        set
        {
            _status = value ;
            switch (value )
            {
                case PlayerStatus.Lose :  
                case PlayerStatus.Win : 
                    SetEndScreen(value);                
                break;
            }
        }
    }

    // Hub
    public TMPro.TMP_Text time_Text , Score_Text ;
    // Canvas
    public GameObject hub_Canva , endScreen_Canva , playagain_Button , menu_Button ;
    public TMPro.TMP_Text status_Text , score_Text ;
 
    public float timeStart ;
    [HideInInspector] public float timeleft ;
    [HideInInspector] public int score ;

    // Start is called before the first frame update
    void Start()
    {
        SetGameStart();
        
        playagain_Button.GetComponent<Button>().onClick.AddListener(delegate {SetGameStart();});
        menu_Button.GetComponent<Button>().onClick.AddListener(delegate {MenuButton();});
    }

    // Update is called once per frame
    void Update()
    {
        switch (status)
        {
            case PlayerStatus.Playing :

            
                if (timeleft > 0)
                {
                    timeleft -= Time.deltaTime;
                    time_Text.text = TimeFormat(((int)timeleft));
                    Score_Text.text = score.ToString() ;

                }else{
                    status = PlayerStatus.Lose;
                }
                
                
            break;
        }
    }

    void SetGameStart(){
        status = PlayerStatus.Playing ;
        timeleft = timeStart ;
        score = 0 ;
        Player.transform.localPosition = SpawnPosition.transform.position ;
        Player.transform.localRotation = SpawnPosition.transform.rotation ;
        hub_Canva.SetActive(true);
        endScreen_Canva.SetActive(false);
    } 
    void SetEndScreen(PlayerStatus s){
        hub_Canva.SetActive(false);
        endScreen_Canva.SetActive(true);

        Score_Text.text = score.ToString() ;
        switch (s)
        {
            case PlayerStatus.Lose : 
                status_Text.text = "You Die !!" ;                
                Debug.Log("Die");
            break;
            case PlayerStatus.Win : 
                status_Text.text = "you Win" ;
                Debug.Log("Win");
            break;
        }

        if(score > PlayerPrefs.GetInt("BestScore",0)){
            PlayerPrefs.SetInt("BestScore",score);
        }

    }

    void MenuButton(){
        SceneManager.LoadScene("menu", LoadSceneMode.Single);
    }

    public string TimeFormat(int timesec)
    {
        string timeStr = "";
        string minutes = Mathf.Floor(timesec / 60).ToString();
        string seconds = (timesec % 60).ToString("0");

        if (timesec < 60)
        {
            timeStr = string.Format("{0} Seconds", seconds);
        }
        else if (timesec % 60 == 0)
        {
            timeStr = string.Format("{0} Minutes ", minutes);
        }
        else
        {
            timeStr = string.Format("{0} Minutes {1} Seconds", minutes, seconds);
        }

        return timeStr;
    }



}
