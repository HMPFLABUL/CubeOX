using UnityEngine;
using System.Collections;
using System.Collections.Generic;
using UnityEngine.UI;

public class RaysMenager : MonoBehaviour {
    [SerializeField]
    private GameObject TopRays;
    [SerializeField]
    private GameObject RightRays;
    [SerializeField]
    private GameObject LeftRays;
    [SerializeField]
    private GameObject TopRaysB;
    [SerializeField]
    private GameObject RightRaysB;
    [SerializeField]
    private GameObject LeftRaysB;

    private RayCheck[] topRayA;
    private List<Text> topTexts;
    private RayCheck[] rightRayA;
    private List<Text> rightTexts;
    private RayCheck[] leftRayA;
    private List<Text> leftTexts;

    public static bool checkWin;
    public static bool setRaysB;
    // Use this for initialization
    void OnEnable () {
        checkWin = false;
        setRaysB = false;
        
        //Debug.Log(GetWin());
	}
	
	// Update is called once per frame
	void Update () {
        if (checkWin)
        {
            GetWin();
            checkWin = false;
        }
        if (setRaysB)
        {
            SetRays();
            setRaysB = false;
        }
        

    }
    bool CheckWin(List<Text> t)
    {
        bool win = false;
        // GetTexts();
        if (t[0].text == t[4].text && t[0].text == t[8].text && t[0].text != " ")
        {
            win = true;
            ReturnWinner(t[0].text);
            t[0].color = Color.red;
            t[4].color = Color.red;
            t[8].color = Color.red;
            return win;

        }
        if (t[2].text == t[4].text && t[2].text == t[6].text && t[2].text != " ")
        {
            win = true;
            ReturnWinner(t[2].text);
            t[2].color = Color.red;
            t[4].color = Color.red;
            t[6].color = Color.red;
            return win;
        }
        if (!win)
        {
            for (int i = 0; i <= 6; i += 3)
            {
                if (t[i].text == t[i + 1].text && t[i].text == t[i + 2].text && t[i].text != " ")
                {
                    win = true;
                    ReturnWinner(t[i].text);
                    t[i].color = Color.red;
                    t[i + 1].color = Color.red;
                    t[i + 2].color = Color.red;
                    return win;
                }
            }
        }
        if (!win)
        {
            for (int i = 0; i <= 2; i++)
            {
                if (t[i].text == t[i + 3].text && t[i].text == t[i + 6].text && t[i].text != " ")
                {
                    ReturnWinner(t[i].text);
                    win = true;
                    t[i].color = Color.red;
                    t[i + 3].color = Color.red;
                    t[i + 6].color = Color.red;
                    return win;
                }
            }
        }
       

        return win;
    }
    void GetText(List<Text> t,RayCheck[] ray)
    {
        t.Clear();
        foreach (RayCheck h in ray)
        {

            RaycastHit hit = h.CastRay();
            t.Add(hit.collider.gameObject.GetComponentInChildren<Text>());

            //  Debug.Log(topTexts[topTexts.Count - 1].text);

        }
    }
    public void GetWin()
    {

        GetText(topTexts, topRayA);
        GameData.winMatch = CheckWin(topTexts);
        if (!GameData.winMatch)
        {
            GetText(leftTexts, leftRayA);
            GameData.winMatch = CheckWin(leftTexts);
        }
        if (!GameData.winMatch)
        {
            GetText(rightTexts, rightRayA);
            GameData.winMatch = CheckWin(rightTexts);
        }
        
        if(!GameData.winMatch)
            GameMenager.selectPlayer = true;
    }
    
    private void SetRays()
    {
        if (!GameData.blindMode)
        {
            topRayA = TopRays.GetComponentsInChildren<RayCheck>();
            rightRayA = RightRays.GetComponentsInChildren<RayCheck>();
            leftRayA = LeftRays.GetComponentsInChildren<RayCheck>();
        }
        else
        {
            topRayA = TopRaysB.GetComponentsInChildren<RayCheck>();
            rightRayA = RightRaysB.GetComponentsInChildren<RayCheck>();
            leftRayA = LeftRaysB.GetComponentsInChildren<RayCheck>();
        }

        topTexts = new List<Text>();
        rightTexts = new List<Text>();
        leftTexts = new List<Text>();
    }

    private void ReturnWinner(string s)
    {
        if (s == GameData.playerOneSign)
            GameData.actPlayer = 0;
        else if (s == GameData.playerTwoSign)
            GameData.actPlayer = 1;
        else if (s == GameData.playerThreeSign)
            GameData.actPlayer = 2;
        else
            Debug.Log("badShitHappend");
    }
}
