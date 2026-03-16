namespace Zombie;

public abstract class ZombieComponent(int health, ZombieType type)
{
    protected int health = health > 0 ? health : 1;
    protected ZombieType type = type;
    protected bool isAlive = true;

    public abstract void TakeDamage(int damage);
    public ZombieType GetZombieType() => type;
    public virtual bool IsAlive() => isAlive;
    protected abstract void Die();
}