using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

[CreateAssetMenu(fileName = "Level1", menuName = "Scene Data/Level")]
public class Level: ScriptableObject {
	[Header("Information")]
	public string levelName;

	[Header("Sounds")]
	public AudioClip music;

	[Header("Map")]
	public GameObject background;
	public GameObject turret;
}
