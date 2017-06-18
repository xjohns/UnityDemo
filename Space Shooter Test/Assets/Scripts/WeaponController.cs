using UnityEngine;
using System.Collections;

public class WeaponController : MonoBehaviour {
	public GameObject shot;
	public Transform shotSpawn;
	public float fireRate;
	public float delay;
	// Use this for initialization
	void Start () {
		InvokeRepeating ("Fire", delay, fireRate);//在delay秒每隔fireRate时间调用一次Fire方法
	}
	void Fire(){
		Instantiate (shot, shotSpawn.position, shotSpawn.rotation);
		GetComponent<AudioSource> ().Play ();
	}
}
