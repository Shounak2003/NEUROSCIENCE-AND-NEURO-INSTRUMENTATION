using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using EasyUI.Dialogs;

public class PopUp : MonoBehaviour
{

    public GameObject Object;
    // Start is called before the first frame update
    void Start()
    {
        
    }

        private void OnTriggerEnter(Collider other)
    {
        Debug.Log("Collided");
        //Object.SetActive(true);
        ConfirmDialogUI.Instance
        .SetTitle("Message")
        .SetMessage("Hello World:")
        .SetButtonsColor(DialogButtonColor.Magenta)
        .SetFadeDuration(.4f)
        .Show();
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
