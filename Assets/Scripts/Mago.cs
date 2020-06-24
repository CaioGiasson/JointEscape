using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class Mago : MonoBehaviour {

	public float velox;
	public GameObject gameOverUI;

	private bool acabou = false;

	private void Start ( ) {
		gameOverUI.SetActive ( false );
	}

	void Update ( ) {

		if ( acabou ) return;

		if ( Input.GetKey ( KeyCode.W ) && transform.position.y < 2.5 ) transform.position += new Vector3 ( 0, velox );
		if ( Input.GetKey ( KeyCode.A ) && transform.position.x > -7.5 ) transform.position += new Vector3 ( -velox, 0 );
		if ( Input.GetKey ( KeyCode.S ) && transform.position.y > -2.5 ) transform.position += new Vector3 ( 0, -velox );
		if ( Input.GetKey ( KeyCode.D ) && transform.position.x < 7.5 ) transform.position += new Vector3 ( velox, 0 );

	}

	private void OnCollisionEnter2D ( Collision2D collision ) {
		if ( collision.gameObject.CompareTag ( "corrente" ) ) Reiniciar ( );
	}

	private void OnTriggerEnter2D ( Collider2D collision ) {
		if ( collision.gameObject.CompareTag ( "Finish" ) ) GameOver ( );
	}

	public void Reiniciar ( ) {
		acabou = false;
		SceneManager.LoadScene ( SceneManager.GetActiveScene ( ).buildIndex );
	}

	void GameOver ( ) {
		acabou = true;
		gameOverUI.SetActive ( true );
	}
}
