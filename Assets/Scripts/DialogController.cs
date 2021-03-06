using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class DialogController : MonoBehaviour
{
  public static DialogController instance;
  public Text dialogText;
  public Text nameText;
  public GameObject dialogBox;
  public GameObject nameBox;

  public string[] dialogLines;

  public int currentLine;
  private bool justStarted;
  // Start is called before the first frame update
  void Start()
  {
    instance = this;
  }

  // Update is called once per frame
  void Update()
  {
    if (dialogBox.activeInHierarchy)
    {
      if (Input.GetButtonUp("Fire1"))
      {
        if (!justStarted)
        {
          currentLine++;

          if (currentLine >= dialogLines.Length)
          {
            dialogBox.SetActive(false);
            GameManager.instance.dialogActive = false;
          }
          else
          {
            checkIfName();
            dialogText.text = dialogLines[currentLine];
          }
        }else
        {
            
            justStarted = false;
        }

      }
    }
  }


  public void ShowDialog(string[] newDialogLines, bool haveName)
  {
    dialogLines = newDialogLines;
    currentLine = 0;

    checkIfName();

    dialogText.text = dialogLines[currentLine];
    dialogBox.SetActive(true);

    justStarted = true;

    nameBox.gameObject.SetActive(haveName);

    GameManager.instance.dialogActive = true;
  }


  public void checkIfName()
  {
    if(dialogLines[currentLine].StartsWith("name-"))
    {
      nameText.text = dialogLines[currentLine].Replace("name-", "");
      currentLine++;
    }
  }

}
