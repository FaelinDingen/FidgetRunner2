using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MaskScript : MonoBehaviour {
    private void Start() {
        MeshRenderer meshRenderer = GetComponent<MeshRenderer>();
        Material[] materials = meshRenderer.materials;

        for (int i = 0; i < materials.Length; i++) {
            Material material = materials[i];
            material.renderQueue = 3002 + i;
        }
    }
}