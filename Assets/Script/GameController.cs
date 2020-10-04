using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameController : MonoBehaviour
{
    public static GameController gameController;
    public Canvas Menu;
    public bool isHideMenu = true;
    public bool isLockedMouse = true;
    public bool isExit = false;
    public bool isEdit = false;
    // Start is called before the first frame update
    void Start()
    {
        Menu.enabled = false;
        if (gameController == null) 
			gameController = this.gameObject.GetComponent<GameController>();
    }

    // Update is called once per frame
    void Update()
    {
        if(isHideMenu) Menu.enabled = false;
        else Menu.enabled = true;

        if( Input.GetButtonDown("Menu")){
			isHideMenu = false;
		}
    }

    public void HideMenu() {
        if(!isExit){
            isHideMenu = true;
            isLockedMouse = true;
        }
    }

    public void turnOffEditMode(){
        isEdit = false;
        isLockedMouse = true;
        MouseLooker.mouseLooker.LockCursor(true);
    }

}
