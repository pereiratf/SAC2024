using Godot;
using System;

public partial class jogador : Area2D
{
	private int area_quadrado = 64;
	private Vector2 direcao;
	private RayCast2D ray;

	// Called when the node enters the scene tree for the first time.
	public override void _Ready()
	{
		ray = GetNode<RayCast2D>("RayCast2D");
	}

	public void Movimento() {
		direcao = new Vector2(0,0);
		if (Input.IsActionJustPressed("direita")) {
			direcao = new Vector2(1,0);
		} //if
		if (Input.IsActionJustPressed("esquerda")) {
			direcao = new Vector2(-1,0);
		} //if
		if (Input.IsActionJustPressed("cima")) {
			direcao = new Vector2(0,-1);
		} //if
		if (Input.IsActionJustPressed("baixo")) {
			direcao = new Vector2(0,1);
		} //if

		//teste se pode mover
		ray.TargetPosition = direcao * area_quadrado;
		ray.ForceRaycastUpdate();
		if (!ray.IsColliding()) {
			Position += direcao * area_quadrado;
		}
		

	}

	//Quando o jogo percebe que uma tecla foi pressionada, ele chama a função movimento
	//para verificar se foi um movimento válido
	public override void _UnhandledInput(InputEvent @event) {
		if (@event is InputEventKey eventKey) {
			if(eventKey.Pressed) {
				Movimento();
			}
		}
	}



}
