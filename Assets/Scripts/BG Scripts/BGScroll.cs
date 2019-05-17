using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BGScroll : MonoBehaviour {

    public float scroll_speed = 0.3f;

    private MeshRenderer mesh_Renderer;
    Vector2 save_offset;

    // Use this for initialization
    void Awake () {
        mesh_Renderer = GetComponent<MeshRenderer>();
        save_offset = mesh_Renderer.sharedMaterial.GetTextureOffset("_MainTex");
    }
	
	// Update is called once per frame
	void Update () {
        Scroll();
    }

    void Scroll()
    {
        Vector2 offset = mesh_Renderer.sharedMaterial.GetTextureOffset("_MainTex");
        offset.y += Time.deltaTime * scroll_speed;
        mesh_Renderer.sharedMaterial.SetTextureOffset("_MainTex", offset);

    }
    // Cette fonction est appelée quand le comportement est désactivé ou inactif
    private void OnDisable()
    {
        //je remet la valeur par défaut 
        mesh_Renderer.sharedMaterial.SetTextureOffset("_MainTex", save_offset);

    }
}
