namespace Zombie;

public abstract class ZombieComponent(int health, ZombieType type)
{
    private int health = health > 0 ? health : 1;
    private ZombieType type = type;
    private bool isAlive = true;

    public abstract void TakeDamage(int damage);
    public ZombieType GetZombieType() => type;
    public virtual bool IsAlive() => isAlive;
    private abstract void Die();
}