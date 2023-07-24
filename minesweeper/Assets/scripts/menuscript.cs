using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;
using UnityEngine.SceneManagement;

public class menuscript : MonoBehaviour
{
    public TMP_Dropdown modedropdown;
    public modeSO modeval;
    public void playgame(){
        modeval.Value = (modedropdown.value+1);
        SceneManager.LoadScene("main");
    }
}
