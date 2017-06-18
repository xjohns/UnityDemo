using UnityEngine;
using System.Collections;

public class DestroyByBoundary : MonoBehaviour {
	//实现边界触发销毁游戏部件的功能
	void OnTriggerExit(Collider other){
		Destroy (other.gameObject);
	}
}
