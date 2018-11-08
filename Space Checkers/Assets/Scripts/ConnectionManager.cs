﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Quobject.SocketIoClientDotNet.Client;
using UnityEngine.SceneManagement;
using Newtonsoft.Json;


public class ConnectionManager : MonoBehaviour {
	public static ConnectionManager instance;
	public Socket socket;
	private string url = "http://localhost:5000";
	void Awake () 
	{
		if (instance == null)
		{
			instance = this;
		}
		else if (instance != null)
		{
			Destroy (gameObject);
		}
		DontDestroyOnLoad(gameObject);
	}
	void Start () 
	{
		socket = IO.Socket(url);
		socket.On(Socket.EVENT_CONNECT, () =>
		{
			Debug.Log("Conectado al servidor");
		});
		socket.On("loginCliente", (datos) =>
		{
			Debug.Log("login existoso");
			string datosJugador = datos.ToString();
			Debug.Log(datosJugador);
			Jugador.instance = JsonConvert.DeserializeObject<Jugador>(datosJugador);
			Debug.Log(Jugador.instance.Username);
		});		
	}
	
	// Update is called once per frame
	void Update () {
		
	}
}
