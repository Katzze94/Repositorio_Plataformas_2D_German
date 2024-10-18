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

    private Animator _pausePanelAnimator;
    private bool _pauseAnimation;

    


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

        _pausePanelAnimator=_pauseCanvas.GetComponentInChildren<Animator>();

        

    }




    

    public void Pause()
    {
        if(!isPaused && !_pauseAnimation)
        {
            isPaused = true;
            Time.timeScale = 0;
            _pauseCanvas.SetActive(true);
        }
        else if(isPaused && !_pauseAnimation)
        {
          _pauseAnimation = true;
          StartCoroutine(ClosePauseAnimation());

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

    IEnumerator ClosePauseAnimation()
    {
        _pausePanelAnimator.SetBool("Close", true);

        yield return new WaitForSecondsRealtime(0.20f);

        Time.timeScale = 1;
        _pauseCanvas.SetActive(false);

        isPaused = false;
        _pauseAnimation = false;
    }


}
