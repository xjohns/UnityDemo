using UnityEngine;
using System.Collections;

[System.Serializable]
public class Boundary
{
	public float xMin, xMax, zMin, zMax;
}

public class PlayerController : MonoBehaviour {
	public float speed;
	public Boundary boundary;
	public GameObject shot;//子弹的预制体
	public Transform shotSpawn;//子弹生成的位置
	public float fireRate;//子弹的发射率

	private float nextFire;
	
	// Update is called once per frame
	void Update () {
		if (Input.GetButton ("Fire1") && Time.time > nextFire) {
			nextFire = Time.time + fireRate;
			Instantiate (shot, shotSpawn.position, shotSpawn.rotation);//实例化生成一枚子弹
			GetComponent<AudioSource>().Play();//生成子弹的时候播放音效
		}
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
