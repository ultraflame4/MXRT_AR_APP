using System.Collections;
using TMPro;
using UnityEngine;

public class EnterCodeMenu : MonoBehaviour
{
    public TextMeshProUGUI errText;
    public TMP_InputField inputField;
    public PopupMenuController popupMenuController;
    public string correctCode = "111111";

    Coroutine coroutine = null;

    IEnumerator hideErrorText()
    {
        yield return new WaitForSeconds(1f);
        errText.text = "";
    }

    public void SubmitCode()
    {
        if (inputField.text == correctCode)
        {
            popupMenuController.Close();
            AppController.Instance.Login();
            return;
        }
        errText.text = "Incorrect code!";
        if (coroutine != null)
        {
            StopCoroutine(coroutine);
        }
        coroutine = StartCoroutine(hideErrorText());
    }
}