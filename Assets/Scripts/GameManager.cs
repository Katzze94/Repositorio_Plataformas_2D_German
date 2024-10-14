using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class GameManager : MonoBehaviour
{
    public static GameManager instance;
    private int coins = 0;

    private int star = 0;

    [SerializeField] Text _coinText;
    private bool isPaused;

    [SerializeField] GameObject _pauseCanvas;

     [SerializeField] Text _starText;
    //[SerializeField] Image[] countStars;

    


    void Awake()
    {
        if(instance != null && instance != this)  //singelton, sirve para acceder desde otro scripts, evita que haya mas de un gamemanager, y se puede acceder facilmente a todo lo que haya dentro
        {
            Destroy(gameObject);
        }
        else
        {
            instance = this;
        }

        

    }




    

    public void Pause()
    {
        if(!isPaused)
        {
            Time.timeScale = 0;
            isPaused = true;
            _pauseCanvas.SetActive(true);
        }
        else 
        {
            Time.timeScale = 1;
            isPaused = false;
            _pauseCanvas.SetActive(false);

        }
    }
    public void Addcoin()
    {
        coins++;  //esto añade 1 en 1 al valor inicial
        _coinText.text = coins.ToString();
    }

    public void Addstar()
    {
        star++;
        //_starText.text = star.ToString();
        

    }


}
