using UnityEngine;

public class InterestPoint : MonoBehaviour {
    
    public MeshRenderer meshRenderer {get; private set;}
    private Material mat;

    

    private void Awake() {
        meshRenderer = GetComponent<MeshRenderer>();
        mat = new Material(meshRenderer.material);
        meshRenderer.material = mat;
    }

    
    
}