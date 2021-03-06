using System;
using System.Collections;
using UnityEngine;
using UnityEngine.SceneManagement;

public class LevelLoader : MonoBehaviour {
	
	public static LevelLoader Instance { get; private set;}
	[SerializeField] private Animator transition;
	[SerializeField] private float transitionTime = 1f;

	private void Start() {
		Instance = this;
	}
	
	public void LoadLevel(string levelName) {
		StartCoroutine(_LoadLevel(levelName));
	}

	public void LoadLevelNow(string levelName) {
		SceneManager.LoadScene(levelName);
	}

	private IEnumerator _LoadLevel(string levelName) {
		transition.SetTrigger("FadeOut");
		yield return new WaitForSeconds(transitionTime);
		SceneManager.LoadScene(levelName);
	}
}
