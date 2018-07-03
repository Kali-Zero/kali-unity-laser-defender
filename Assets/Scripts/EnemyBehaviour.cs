using System.Collections;
using System.Collections.Generic;
using UnityEngine;

//Test
public class EnemyBehaviour : MonoBehaviour {
	public GameObject projectile;
	public float projectileSpeed = 10.0f;
	public float health = 150.0f;
	public float shotsPerSecond = 0.5f;

	public int enemyValue1 = 150;
	private ScoreKeeper scoreKeeper;

	public AudioClip enemyFireSound;
	public AudioClip enemyDestroyed;

	void Start(){
		scoreKeeper = GameObject.Find ("Score").GetComponent<ScoreKeeper> ();
	}

	void Update(){
		float probability = Time.deltaTime * shotsPerSecond;
		if(Random.value < probability){
			Fire ();
		}
	}

	void Fire(){
		GameObject missle = Instantiate (projectile, transform.position, Quaternion.identity) as GameObject;
		missle.GetComponent<Rigidbody2D>().velocity = new Vector2 (0, -projectileSpeed);
		AudioSource.PlayClipAtPoint (enemyFireSound, transform.position);
	}

	void OnTriggerEnter2D(Collider2D collider){
		Projectile missle = collider.gameObject.GetComponent<Projectile> ();
		if (missle) {
			health -= missle.getDamage();
			missle.Hit ();
			if (health <= 0) {
				EnemyDestroyed ();
			}
		}
	}

	void EnemyDestroyed(){
		AudioSource.PlayClipAtPoint (enemyDestroyed, transform.position);
		Destroy (gameObject);
		scoreKeeper.Score (enemyValue1);
	}
}
