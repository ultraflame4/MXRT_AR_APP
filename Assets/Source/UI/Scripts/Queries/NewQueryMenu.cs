using TMPro;
using UnityEngine;

public class NewQueryMenu : MonoBehaviour {
    public TMP_InputField inputTitle;
    public TMP_InputField inputDesc;
    public TMP_Dropdown inputType;
    public PopupMenuController popupMenuController;

    public void Show() {
        popupMenuController.Show();
    }

    public void CreateQuery() {
        popupMenuController.Close();
        
        var db = AppController.Instance.queriesDatabase;
        db.AddQuery(new QueriesDatabase.Query(inputTitle.text, inputDesc.text, inputType.options[inputType.value].text));
    }
}