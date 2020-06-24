using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Corrente : MonoBehaviour {

	public GameObject bola;
	public bool inverted;

	private Rigidbody2D bolaRB;
	private float intervalo, intensidade;

	private void Start ( ) {

		bolaRB = bola.GetComponent<Rigidbody2D> ( );
		intervalo = Random.Range ( 3, 6 );
		intensidade = Random.Range ( -600, -300 );

		StartCoroutine ( Chicotear ( ) );
	}

	IEnumerator Chicotear ( ) {
		bolaRB.AddForce ( new Vector2 ( intensidade, 0 ) );
		yield return new WaitForSeconds ( intervalo );
		StartCoroutine ( Chicotear ( ) );
	}

	private void FixedUpdate ( ) {
		if ( inverted ) bolaRB.AddForce ( new Vector2 ( 0, 1000 ) );
	}
}
