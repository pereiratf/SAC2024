using Godot;
using System;

public partial class caixa : Area2D
{
	private RayCast2D ray;

	// Called when the node enters the scene tree for the first time.
	public override void _Ready()
	{
		ray = GetNode<RayCast2D>("RayCast2D");
	}

	public bool Empurrar(Vector2 direcao, int area_quadrado) {
		ray.TargetPosition = direcao * area_quadrado;
		ray.ForceRaycastUpdate();
		if (!ray.IsColliding()) {
			Position += direcao * area_quadrado;
			return true;
		} else {
			return false;
		}
		
	}
}
