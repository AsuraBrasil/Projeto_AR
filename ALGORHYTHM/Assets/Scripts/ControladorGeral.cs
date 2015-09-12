﻿using UnityEngine;
using UnityEngine.UI;
using System.Collections;

public class ControladorGeral : MonoBehaviour {

	public static ControladorGeral referencia = null;

	public GameObject myPlayer;
	public CriaTabuleiro tabuleiroAtual;
	public bool listaEmExecucao = false;
	public Text myLog;
	public int faseAtual;

	// Use this for initialization
	void Awake () {
		//Check if instance already exists
		if (referencia == null)		
			//if not, set instance to this
			referencia = this;		
		//If instance already exists and it's not this:
		else if (referencia != this)
			//Then destroy this. This enforces our singleton pattern, meaning there can only ever be one instance of a GameManager.
			Destroy(gameObject);  
		
		//Sets this to not be destroyed when reloading scene
		DontDestroyOnLoad(gameObject);
		//Call the InitGame function to initialize the first level 
		IniciaJogo();
	}

	public void PassouFase()
	{
		myLog.text +="\n<b>VOCE PASSOU DE FASE!!!</b>";
		//Aqui que ia aparecer a janela de pontuaçao!
	}

	void IniciaJogo ()
	{
		//?
	}

	
	// Update is called once per frame
	void Update () {
	
	}
}
