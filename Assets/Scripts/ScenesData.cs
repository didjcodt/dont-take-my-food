using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

[CreateAssetMenu(fileName = "SceneDB", menuName = "Scene Data/Database")]
public class ScenesData: ScriptableObject {
	public int CurrentLevel = 1;

	public void LoadLevel(int index) {
		CurrentLevel = index;
		SceneManager.LoadSceneAsync("Level" + index.ToString());
	}

	public void NextLevel() {
		LoadLevel(++CurrentLevel);
	}

	public void RestartLevel() {
		LoadLevel(CurrentLevel);
	}

	public void NewGame() {
		LoadLevel(1);
	}

	public void MainMenu() {
		SceneManager.LoadSceneAsync("Main Menu");
	}

	public void PauseMenu() {
		SceneManager.LoadSceneAsync("Pause Menu");
	}
}
