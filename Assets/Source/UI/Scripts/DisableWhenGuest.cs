using UnityEngine;

/// <summary>
/// Disables the current game object if the user is a guest.
/// </summary>
public class DisableWhenGuest : MonoBehaviour
{
    [Tooltip("Disables this object if the user is a guest.")]
    public GameObject target;
    [Tooltip("If the user is a guest, this object will be enabled instead.")]
    public GameObject invertedTarget;
    private void Update()
    {
        target.SetActive(AppController.Instance.authState == AppController.LoginState.LOGGED_IN);
        invertedTarget?.SetActive(AppController.Instance.authState != AppController.LoginState.LOGGED_IN);


    }
}