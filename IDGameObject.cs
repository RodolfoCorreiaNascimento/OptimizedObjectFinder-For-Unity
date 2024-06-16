// Example to populate you ID of GameObjects in the scene you should have a Singleton
using UnityEngine;

public class IDGameObject : Singleton<IDGameObject>
{
    // Campos privados com valores constantes
    private const int player = 121;
    private const int ball = 32;
    private const int projectile = 43;
    private const int tank = 4;

    // Propriedades públicas apenas com getter para acessar os valores constantes
    public int Player => player;
    public int Ball => ball;
    public int Projectile => projectile;
    public int Tank => tank;
}
