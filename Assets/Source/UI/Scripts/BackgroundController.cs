using System.Linq;
using UnityEngine;

public class BackgroundController : MonoBehaviour {
    public IconButton[] btnAR;
    public GameObject background;

    private void Update() {
        background.SetActive(!btnAR.Any(x => x.active && x.gameObject.activeInHierarchy));
    }
}