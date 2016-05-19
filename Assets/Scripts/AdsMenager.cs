using UnityEngine;
using System.Collections;
using UnityEngine.Advertisements;

public class AdsMenager : MonoBehaviour {

    public static int gamesCount;
    public static int adsAtInt;
    
    // Use this for initialization
    void Start () {
        gamesCount = 0;
        Advertisement.Initialize("1064612", true);
	}
	
	// Update is called once per frame
	void Update () {
        
    }
    public static IEnumerator ShowAd()
    {
        Debug.Log("ad");
        float curTimeScale = Time.timeScale;
        Time.timeScale = 0;
        if(Advertisement.IsReady())
            Advertisement.Show();
        while (Advertisement.isShowing)
        {
            yield return null;
        }
        gamesCount = 0;
        adsAtInt += 1;
        yield return null;
        Time.timeScale = curTimeScale;
    }
    public void GoToMenu()
    {
        if (gamesCount + 1 == adsAtInt)
            StartCoroutine(ShowAd());
    }



    public void OpenTwitter()
    {
        Application.OpenURL("https://twitter.com/_hmpflbl");
    }
    public void OpenFacebook()
    {
       Application.OpenURL("https://www.facebook.com/hmpflabul/");
    }
}
