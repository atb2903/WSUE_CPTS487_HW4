namespace Zombie;

public abstract class ZombieComponent(int health, ZombieType type)
{
    private int health = health > 0 ? health : 1;
    public ZombieType type = type;

    public abstract void TakeDamage(int damage);
    public ZombieType GetZombieType() => type;
}