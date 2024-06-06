using TMPro;
using UnityEngine;

public class NewQueryMenu : MonoBehaviour {
    public TMP_InputField inputTitle;
    public TMP_InputField inputDesc;
    public TMP_Dropdown inputType;
    private PopupMenuController popupMenuController;

    private void Start() {
        popupMenuController = GetComponent<PopupMenuController>();
    }

    public void CreateQuery() {
        popupMenuController.Close();
        
        var db = AppController.Instance.queriesDatabase;
        db.queries.Add(new QueriesDatabase.Query(inputTitle.text, inputDesc.text, inputType.options[inputType.value].text));
    }
}