using UnityEngine;
using System.Collections;

public class AddShaderToCamera : MonoBehaviour {

    public Shader shader;
    public Camera cam;

	// Use this for initialization
	void Start () {
        cam.SetReplacementShader(shader, "");
	}
}
