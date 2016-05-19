using UnityEngine;
using System.Collections;
using System;
using UnityEngine.SceneManagement;
using UnityEngine.UI;
public class GameMenager : MonoBehaviour {

    [SerializeField]
    private GameObject[] players;
    [SerializeField]
    private Text[] playersCanvas;
    [SerializeField]
    private Text[] playersScore;
    public static bool selectPlayer;
    
    // Use this for initialization
    void OnEnable () {
        selectPlayer = false;
        foreach(Text t in playersScore)
        {
            t.text = "0";
        }
       
    }
	
	// Update is called once per frame
	void LateUpdate () {
      //  Debug.Log(GameData.actPlayer);
        if (selectPlayer)
        {
            if (GameData.trio)
                GameData.actPlayer = (GameData.actPlayer + 1) % 3;
            else
                GameData.actPlayer = (GameData.actPlayer + 1) % 2;
            selectPlayer = false;
            GameData.buttonsLock = false;
            SelectPlayer();
            
        }
        if (GameData.winMatch)
        {
            Debug.Log("win");
            GameData.arrowsLock = true;
            GameData.buttonsLock = true;
            StartCoroutine(NextMatch());
            GameData.winMatch = false;

        }


    }

    //  public void Restart()
    // {
    //     SceneManager.LoadScene(0);
    // }
    public void SetupBlindGame()
    {
        SetupStandardGame();
        GameData.blindMode = true;
        SelectPlayer();
    }
    public void SetupBlindTrioGame()
    {
        SetupStandardTrioGame();
        GameData.blindMode = true;
    }
    public void SetupStandardGame()
    {
        GameData.blindMode = false;
        SetupGameBasic(0);
        GameData.trio = false;
        AdsMenager.gamesCount = 0;
        AdsMenager.adsAtInt = 3;
        players[2].SetActive(false);
        
    }
    public void SetupStandardTrioGame()
    {
        GameData.blindMode = false;
        SetupGameBasic(0);
        GameData.trio = true;
        AdsMenager.gamesCount = 0;
        AdsMenager.adsAtInt = 2;
        players[2].SetActive(true);
    }
        

    public void SelectPlayer()
    {
       

        for (int i = 0; i < playersCanvas.Length; i++)
        {
            if(playersCanvas[i].gameObject.active)
            {  
                if(GameData.actPlayer == i)
                {
                    playersCanvas[i].color = Color.yellow;
                    playersScore[i].color = Color.yellow;
                }
                else
                {
                    playersCanvas[i].color = Color.white;
                    playersScore[i].color = Color.white;
                }
            }
        }
        
    }

    private void SetupGameBasic(int starPlayer)
    {
        GameData.startingPlayer = starPlayer;
        GameData.actPlayer = GameData.startingPlayer;
        GameData.clearBoard = true;
        GameData.arrowsLock = true;
        GameData.buttonsLock = false;
        GameData.winMatch = false;
        players[0].SetActive(true);
        players[1].SetActive(true);
        Debug.Log(GameData.actPlayer);
        RaysMenager.setRaysB = true;
        SelectPlayer();
    }

    private IEnumerator NextMatch()
    {
        playersScore[GameData.actPlayer].text = (Int32.Parse(playersScore[GameData.actPlayer].text) +1).ToString();
        if (GameData.blindMode)
        {
            Cube.rotateCube = true;
            yield return new WaitForSeconds(1f);
        }

        yield return new WaitForSeconds(2f);
        AdsMenager.gamesCount += 1;
        if (AdsMenager.adsAtInt == AdsMenager.gamesCount)
            StartCoroutine(AdsMenager.ShowAd());
        GameData.clearBoard = true;
        
        if (GameData.trio)
            SetupGameBasic((GameData.startingPlayer + 1) % 3);
        else
            SetupGameBasic((GameData.startingPlayer + 1) % 2);
        



    }
    
    
}
