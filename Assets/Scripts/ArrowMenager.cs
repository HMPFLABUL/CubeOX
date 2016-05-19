using UnityEngine;
using System.Collections;
using UnityEngine.UI;

public class ArrowMenager : MonoBehaviour {

    private Button arrow;
    
    void OnEnable()
    {
        arrow = this.gameObject.GetComponent<Button>();
        
       
        arrow.onClick.AddListener(() => { OnClick(); });
    }

    void Update () {
        if (GameData.arrowsLock)
            arrow.interactable = false;
        else
            arrow.interactable = true;
    }

    public void OnClick()
    {
        GameData.arrowsLock = true;
        Invoke("OnClickAfterRotate",0.5f);
       

    }
    public void OnClickAfterRotate()
    {
        
        RaysMenager.checkWin = true;
        
    }

   
}
