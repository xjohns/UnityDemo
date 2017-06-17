using UnityEngine;
using System.Collections;

public class PlayerController : MonoBehaviour {
	[System.Serializable]
	public class Boundary
	{
		public float xMin;
		public float xMax;
		public float zMin;
		public float zMax;
	}
	public float speed;
	public Boundary boundary;

	// Use this for initialization
	void Start () {
	
	}
	
	// Update is called once per frame
	void Update () {
	
	}

	void FixedUpdate(){
		float moveHorizontal = Input.GetAxis ("Horizontal");
		float moveVertical = Input.GetAxis ("Vertical");
		Vector3 movement = new Vector3 (moveHorizontal, 0.0f, moveVertical);
		//获取刚体速度的方法
		GetComponent<Rigidbody> ().velocity = movement * speed;
		//界定飞行范围
		GetComponent<Rigidbody> ().position = new Vector3 (Mathf.Clamp (GetComponent<Rigidbody> ().position.x, boundary.xMin, boundary.xMax), 0.0f, Mathf.Clamp (GetComponent<Rigidbody> ().position.z, boundary.zMin, boundary.zMax));
	}
}
