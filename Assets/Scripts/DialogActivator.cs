using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DialogActivator : MonoBehaviour
{

    public string[] dialog;

    private bool inDialogRange;
    private bool lookAt;

    public bool isPerson = true;

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        if(inDialogRange && Input.GetButtonDown("Fire1") && !DialogController.instance.dialogBox.activeInHierarchy)
        {
            DialogController.instance.ShowDialog(dialog, isPerson);
        }
    }

    private void OnTriggerEnter2D(Collider2D other) {
        if(other.tag == "Player")
        {
            inDialogRange = true;
            
        }
    }

    private void OnTriggerExit2D(Collider2D other) {
        if(other.tag == "Player")
        {
            inDialogRange = false;
        }
    }
}
