using UnityEngine;
using System.Collections;


public class GameData : MonoBehaviour {

    //false=player1 true=palyer2
    public static int startingPlayer;
    public static int actPlayer;
    public static bool trio;
    public static bool arrowsLock;
    public static bool buttonsLock;
    public static bool winMatch;
    public static bool clearBoard;
    public static bool blindMode;
    public static string playerOneSign = "O";
    public static string playerTwoSign = "X";
    public static string playerThreeSign = "#";


    void OnEnable()
    {
    }

   // public enum GameMode {Standard};
 //   public static GameMode mode; 
    
    void Update()
    {
        if (clearBoard)
            StartCoroutine(Clear());
    }
    private IEnumerator Clear()
    {
        yield return new WaitForFixedUpdate();
        clearBoard = false;
    }
}
