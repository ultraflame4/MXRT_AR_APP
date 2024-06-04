using UnityEngine;

/// <summary>
/// Disables the current game object if the user is a guest.
/// </summary>
public class DisableWhenGuest : MonoBehaviour
{
    public GameObject target;
    private void Update()
    {
        target.SetActive(AppController.Instance.authState == AppController.LoginState.LOGGED_IN);
    }
}