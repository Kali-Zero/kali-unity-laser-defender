using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Projectile : MonoBehaviour {

	public float damage = 100.0f;

	public float getDamage(){
		return damage;
	}

	public void Hit(){
		Destroy (gameObject);
	}

}
