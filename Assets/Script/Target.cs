using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Target : MonoBehaviour
{
    public static Target target;
    private bool isTriggerObject = false;
    public GameObject PreObj = null;
    public Collider SelectObject = null;

    public InputField inputX;
    public InputField inputY;
    public InputField inputZ;
    public InputField inputRotate;
    // Start is called before the first frame update
    void Start()
    {
        inputRotate.enabled = false;
        inputX.enabled = true;
        inputY.enabled = true;
        inputZ.enabled = true;
        inputX.text = inputY.text= inputZ.text = "0";
        if (target == null) 
			target = this.gameObject.GetComponent<Target>();
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetButtonDown("Destroy") && SelectObject != null) {
            Destroy(SelectObject.gameObject);
        }

        if (Input.GetButtonDown("Edit")) {
            if(PreObj) {
                GameController.gameController.isEdit = true;
                MouseLooker.mouseLooker.LockCursor(false);
                GameController.gameController.isLockedMouse = false;
                inputRotate.enabled = false;
                inputX.enabled = true;
                inputY.enabled = true;
                inputZ.enabled = true;
            } else if(SelectObject) {
                GameController.gameController.isEdit = true;
                MouseLooker.mouseLooker.LockCursor(false);
                GameController.gameController.isLockedMouse = false;
                inputRotate.enabled = true;
                inputX.enabled = false;
                inputY.enabled = false;
                inputZ.enabled = false;
            }
        }

        if (GameController.gameController.isEdit) {
            float x = float.Parse(inputX.text);
            float y = float.Parse(inputY.text);
            float z = float.Parse(inputZ.text);
            if(PreObj) {
                PreObj.GetComponent<PreRenderObj>().setPosition(x,y,z);
                this.transform.position = new Vector3(x,y,z);
            }
        }

        if(PreObj) {
            inputX.text = PreObj.transform.position.x.ToString();
            inputY.text = PreObj.transform.position.y.ToString();
            inputZ.text = PreObj.transform.position.z.ToString();
        }else {
            inputX.text = inputY.text= inputZ.text = "0";
        }
    }

    private void OnTriggerStay(Collider other) {
        if (Input.GetButtonDown("Fire1") && PreObj == null && other.tag == "Object") {
            print("select object");
            SelectObject = other;
            // change material selected
        }
    }

    public void renderPreObj(GameObject preObj) {
        SelectObject = null;
        PreObj = Instantiate(preObj, transform.position, Quaternion.identity);
        PreObj.transform.parent =  Camera.main.transform;
        GameController.gameController.HideMenu();
    }

    public void ResetSelectObj() {
        print("reset select");
        SelectObject = null;
        // thay doi material
    }

    public void renderObjectFromEdit(){
        if(PreObj) {
            PreObj.GetComponent<PreRenderObj>().renderObj();
        }
        else if(SelectObject) {
            float rotate = float.Parse(inputRotate.text);
            if(0<= rotate && rotate <= 360){
                SelectObject.gameObject.transform.Rotate(0,rotate,0);
            }
        }
    }
}
