using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PreRenderObj : MonoBehaviour
{
    private bool isTriggerObj = false;
    public Material MaterialErr;
    public Material MaterialSuccess;
    public MeshRenderer meshRender;
    public GameObject objectRender; 
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        if(!isTriggerObj){
            meshRender.material = MaterialSuccess;
        }
        else {
            meshRender.material = MaterialErr;
        }

        if (Input.GetButtonDown("Fire1") && !GameController.gameController.isExit && GameController.gameController.isHideMenu && !GameController.gameController.isEdit)
            renderObj();

        if (Input.GetButtonDown("QuitPreObj")) {
            GameController.gameController.isEdit = false;
            Destroy(gameObject);
        }
    }

    private void OnTriggerStay(Collider other) {
        if(other.tag == "Object") {
            isTriggerObj = true;
        }
    }

    private void OnTriggerExit(Collider other) {
        if(other.tag == "Object") {
            isTriggerObj = false;
        }
    }

    public void renderObj(){
        if(!isTriggerObj){
            Debug.Log("Pressed created obj button.");
            Instantiate(objectRender, this.gameObject.transform.position, Quaternion.identity);
        }
    }

    public void setPosition(float x, float y, float z) {
        this.gameObject.transform.position = new Vector3(x,y,z);
    }

}
