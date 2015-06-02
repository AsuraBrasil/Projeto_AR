﻿using UnityEngine;
using System.Collections;
using System.Collections.Generic;

public class CarregaJogo : MonoBehaviour {

	
	public GameObject gameManager;          //GameManager prefab to instantiate.
	public GameObject myPlayer;
	public Vector2 posicaoPlayer;
	public Vector2 posicaoObjetivo;

	private CriaTabuleiro tabuleiroScript;
	private bool passouFase = false;
	private int score = 150;

	void Awake ()
	{
		//Check if a GameManager has already been assigned to static variable GameManager.instance or if it's still null
		if (ControladorGeral.referencia == null)			
			//Instantiate gameManager prefab
			Instantiate(gameManager);

		//Get a component reference to the attached BoardManager script
		tabuleiroScript = GetComponent<CriaTabuleiro>();
		tabuleiroScript.GeraMapa();

		Vector3 tempPosInicial = new Vector3 ();

		foreach(List<Tile> tileCols in tabuleiroScript.mapaGerado)
		{
			foreach(Tile tile in tileCols)
			{
				if(tile.posicaoTabuleiro == posicaoPlayer)
				{
					tempPosInicial = tile.transform.position;
					tempPosInicial.y = 1.3f;
				}
			}
		}

		ControladorGeral.referencia.myPlayer = (GameObject)Instantiate(myPlayer, tempPosInicial/*new Vector3 (-5.5f, 1.3f, 4.5f)*/, Quaternion.identity);
		ControladorGeral.referencia.myPlayer.GetComponent<Player>().posicaoTabuleiro = posicaoPlayer;
		ControladorGeral.referencia.tabuleiroAtual = tabuleiroScript;

	}

	//Verifica Objetivo
	void Update()
	{
		if(ControladorGeral.referencia.myPlayer.GetComponent<Player>().posicaoTabuleiro == posicaoObjetivo && !passouFase)
		{
			score -= 15*CreateProgramList.referencia.programList.Count;

			Debug.Log ("VOCE PASSOU DE FASE!!!");
			Debug.Log ("SEU SCORE FOI: " + score.ToString());
			passouFase = true;
		}
	}

}