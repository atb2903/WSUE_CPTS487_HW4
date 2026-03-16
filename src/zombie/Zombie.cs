namespace Zombie;

public class Zombie : ZombieComponent
{
    public Zombie(int health, ZombieType type) : base(health, type)
    {
    }

    public override void TakeDamage(int damage)
    {
        health -= damage;
        if (health <= 0)
        {
            Die();
        }
    }

    protected override void Die()
    {
        isAlive = false;
    }
}