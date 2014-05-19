using UnityEngine;
using System.Collections;

public class Webcam : MonoBehaviour 
{

	public MeshRenderer[] UseWebcamTexture;
	private WebCamTexture webcamTexture;

	// Use this for initialization
	void Start () 
	{
		WebCamDevice[] devices = WebCamTexture.devices;
		webcamTexture = new WebCamTexture();
		print ("devices: " + devices.Length);
		if (devices.Length > 1)
		{
			webcamTexture.deviceName = devices [1].name;
		}
		else
		{
			webcamTexture.deviceName = devices [0].name;
		}

		foreach(MeshRenderer r in UseWebcamTexture)
		{
			r.material.mainTexture = webcamTexture;
		}
		renderer.material.mainTexture = webcamTexture;
		webcamTexture.Play();
	}

	void OnGUI()
	{
		if (webcamTexture.isPlaying)
		{
			//GUI.Box (new Rect (200, 10, 100, 170), "Menu");
			if (GUILayout.Button("Pause"))
			{
				webcamTexture.Pause();
			}
			if (GUILayout.Button("Stop"))
			{
				webcamTexture.Stop();
			}
		}
		else
		{
			if (GUILayout.Button("Play"))
			{
				webcamTexture.Play();
			}
		}
	}
}