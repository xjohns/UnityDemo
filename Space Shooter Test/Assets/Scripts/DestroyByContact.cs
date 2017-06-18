using UnityEngine;
using System.Collections;

public class DestroyByContact : MonoBehaviour {
	public GameObject explosion;
	public GameObject playerExplosion;
	public GameController gameController;
	public int scoreValue;

	// Use this for initialization
	void Start () {
		GameObject gameControllerObject = GameObject.FindWithTag ("GameController");
		if(gameControllerObject != null){
			gameController = gameControllerObject.GetComponent<GameController> ();
		}
		if(gameController == null){
			Debug.Log ("Cannot find 'GameController'Scripts");
		}
	}
	
	// Update is called once per frame
	void Update () {
	
	}
	//碰撞的逻辑处理
	void OnTriggerEnter(Collider other){
		if(other.tag == "Boundary" || other.tag == "Enemy"){
			return;
		}
		if(other.tag == "Player"){
			Instantiate (playerExplosion, other.transform.position, other.transform.rotation);
			gameController.GameOver ();
		}
		if(explosion != null){
			Instantiate (explosion, transform.position, transform.rotation);
		}
		gameController.AddScore (scoreValue);
		Destroy (other.gameObject);
		Destroy (this.gameObject);
	}
}
