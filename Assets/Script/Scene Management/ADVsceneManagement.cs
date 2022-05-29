using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;
using UnityEngine.EventSystems;

public class ADVsceneManagement : MonoBehaviour
{
    public Button Pause_Button;
    public Button Inventory;
    public Button Resume;
    public Button Quit;

    [SerializeField] public GameObject panelPause;



public void Pause_btn(){

    panelPause.SetActive(true);
     Time.timeScale = 0;


}

public void Resume_btn(){
    panelPause.SetActive(false);
     Time.timeScale = 1;
}

// void quit_btn(int numScene){
//     SceneManager.LoadScene(numScene);
// }

}
