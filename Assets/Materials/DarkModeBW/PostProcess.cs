using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PostProcess : MonoBehaviour
{
    private Material _material;
    public Shader _shader;

    // Start is called before the first frame update
    void Start()
    {
        _material = new Material(_shader);
    }

    private void OnRenderImage(RenderTexture src, RenderTexture dest) 
    {
        Graphics.Blit(src, dest, _material);
    }
    // Update is called once per frame
    void Update()
    {
        
    }
}
