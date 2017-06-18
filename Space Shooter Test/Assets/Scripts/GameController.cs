using UnityEngine;
using System.Collections;
using UnityEngine.UI;

public class GameController : MonoBehaviour {
	public GameObject[] troubles;//小行星障碍物
	public Vector3 spawnValues;//随机生成小行星的位置
	public int troublesCount;//每波小行星生成的数量
	public float spawnWait;
	public float startWait;
	public float waveWait;
	public Text scoreText;
	public Text gameoverText;
	public Text restartText;

	private float score;
	private bool gameover;
	private bool restart;

	// Use this for initialization
	void Start () {
		score = 0;
		gameoverText.text = "";
		restartText.text = "";
		gameover = false;
		restart = false;
		UpdateScore ();
		StartCoroutine (SpawnWave ());
	}

	void Update(){
		if(restart){
			if(Input.GetKeyDown(KeyCode.R)){
				Application.LoadLevel (Application.loadedLevel);//加载关卡，目前这个方法官方不建议使用，已过时
			}
		}
	}
	
	IEnumerator SpawnWave () {
		yield return new WaitForSeconds (startWait);//执行到这里时等待startWait时间

		while(true){
			for(int i = 0; i < troublesCount; i++){
				GameObject trouble = troubles[Random.Range(0, troubles.Length)];
				Vector3 spawnPosition = new Vector3 (Random.Range(-spawnValues.x, spawnValues.x), spawnValues.y, spawnValues.z);
				Instantiate (trouble, spawnPosition, Quaternion.identity);
				yield return new WaitForSeconds (spawnWait);//生成时间间隔
			}
			yield return new WaitForSeconds (waveWait);//每一波间隔
			if(gameover){
				restartText.text = "Press 'R' For Restart";
				restart = true;
				break;
			}
		}
	}
	//增加分数
	public void AddScore(int newScoreValues){
		score += newScoreValues;
		UpdateScore ();
	}

	//更新UI界面的计分显示
	void UpdateScore(){
		scoreText.text = "Score : " + score;
	}

	public void GameOver(){
		gameoverText.text = "Game Over!";
		gameover = true;
	}
}
