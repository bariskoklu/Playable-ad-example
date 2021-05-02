using System.Collections;
using System.Collections.Generic;
using System.Runtime.InteropServices;
using UnityEngine;
using UnityEngine.UI;

public class GameOverMenuScript : MonoBehaviour
{
    [SerializeField]
    private Text gameOverText;

    //This plugin is from https://stackoverflow.com/questions/62348214/how-to-open-a-link-on-a-new-tab-using-webgl-c-through-unity
    [DllImport("__Internal")]
    private static extern void OpenNewTab(string url);

    public void ChangeGameOverMenuActive(bool status)
    {
        gameObject.SetActive(status);
    }
    public void GameOverButtonClick()
    {
#if !UNITY_EDITOR && UNITY_WEBGL
             OpenNewTab("https://play.google.com/store/apps/details?id=com.ketchapp.knifehit&hl=tr&gl=US");
#endif
    }
    public void ArrangeVictoryMenu()
    {
        gameOverText.text = "Congratulations! This level is finished. Continue to next level!";
    }
    public void ArrangeDefeatMenu()
    {
        gameOverText.text = "Game is over but it does not have to be that way. Continue to play?";
    }
}
