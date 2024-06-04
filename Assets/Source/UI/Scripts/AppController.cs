using UnityEngine;



public class AppController : MonoBehaviour
{
    public enum LoginState
    {
        GUEST,
        LOGGED_IN,
    }
    public LoginState authState { get; private set; } = LoginState.GUEST;
    public static AppController Instance => _instance;


    public TabManager tabManager;
    public SearchMenuController searchMenu;

    private static AppController _instance;
    

    private void Awake()
    {
        if (_instance != null)
        {
            Debug.LogWarning($"AppController ({_instance}) already exists! This will cause problems!");
        }
        _instance = this;
    }

    public void Login()
    {
        authState = LoginState.LOGGED_IN;
        tabManager.ReloadTabs();
    }


    
    
    
    
    
}