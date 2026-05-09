using Godot;
using System;

public partial class Player : CharacterBody2D
{
    [Export] public int Speed = 200;

    public override void _PhysicsProcess(double delta)
    {
        Vector2 direction = Vector2.Zero;

        if (Input.IsActionPressed("andar_para_direita")) direction.X += 1;
        if (Input.IsActionPressed("andar_para_esquerda")) direction.X -= 1;
        if (Input.IsActionPressed("agachar")) direction.Y += 1;
        if (Input.IsActionPressed("pular")) direction.Y -= 1;

        // Normaliza para manter velocidade constante em diagonais
        if (direction != Vector2.Zero)
            direction = direction.Normalized();

        Velocity = direction * Speed;
        MoveAndSlide();
    }
}