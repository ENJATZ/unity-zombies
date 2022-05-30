using System.Collections;
using System.Collections.Generic;
using UnityEngine.SceneManagement;
using UnityEngine;
using TMPro;

public class SceneLoader : MonoBehaviour
{
    private GameObject InstructionsMenu;
    private GameObject ButtonsMenu;
    private GameObject SettingsMenu;
    private GameObject YouDiedMenu;
    private GameObject ScoreboardMenu;

    void Start()
    {
        FetchMenus();
    }
    void FetchMenus()
    {
        ButtonsMenu = FindInActiveObjectByName("ButtonsMenu");
        InstructionsMenu = FindInActiveObjectByName("InstructionsMenu");
        SettingsMenu = FindInActiveObjectByName("SettingsMenu");
        YouDiedMenu = FindInActiveObjectByName("YouDiedMenu");
        ScoreboardMenu = FindInActiveObjectByName("LeaderBoardMenu");
    }
    public void LoadScene(int level)
    {
        SceneManager.LoadScene(level);
    }
    public void ExitGame()
    {
        Application.Quit();
    }
    public void GoToInstructionsMenu()
    {
        ButtonsMenu.SetActive(false);
        SettingsMenu.SetActive(false);
        InstructionsMenu.SetActive(true);
        YouDiedMenu.SetActive(false);
        ScoreboardMenu.SetActive(false);

    }
    public void GoToButtonsMenu()
    {
        ButtonsMenu.SetActive(true);
        SettingsMenu.SetActive(false);
        InstructionsMenu.SetActive(false);
        YouDiedMenu.SetActive(false);
        ScoreboardMenu.SetActive(false);
    }
    public void GoToSettingsMenu()
    {
        ButtonsMenu.SetActive(false);
        SettingsMenu.SetActive(true);
        InstructionsMenu.SetActive(false);
        YouDiedMenu.SetActive(false);
        ScoreboardMenu.SetActive(false);
    }
    public void GoToScoreboardMenu()
    {
        ButtonsMenu.SetActive(false);
        SettingsMenu.SetActive(false);
        InstructionsMenu.SetActive(false);
        YouDiedMenu.SetActive(false);
        ScoreboardMenu.SetActive(true);
    }
    public void PlayerDied(int score)
    {
        var callback = SceneManager.LoadSceneAsync(0, LoadSceneMode.Single);
        callback.completed += (x) =>
        {
            Cursor.lockState = CursorLockMode.None;
            Cursor.lockState = CursorLockMode.Confined;
            Cursor.visible = true;
            GoToYouDiedMenu(score);
        };

    }
    public void GoToYouDiedMenu(int score)
    {
        FetchMenus(); // pentru refetch la game objects
        ButtonsMenu.SetActive(false);
        SettingsMenu.SetActive(false);
        InstructionsMenu.SetActive(false);
        ScoreboardMenu.SetActive(false);
        YouDiedMenu.SetActive(true);
        TextMeshProUGUI YourScoreText = GameObject.Find("YourScoreText").GetComponent<TextMeshProUGUI>();
        GlobalVariables.score = score;
        YourScoreText.SetText("Your score: {0}", score);
    }
    private GameObject FindInActiveObjectByName(string name)
    {
        Transform[] objs = Resources.FindObjectsOfTypeAll<Transform>() as Transform[];
        for (int i = 0; i < objs.Length; i++)
        {
            if (objs[i].hideFlags == HideFlags.None)
            {
                if (objs[i].name == name)
                {
                    return objs[i].gameObject;
                }
            }
        }
        return null;
    }

}
