namespace Zombie;

public abstract class ZombieComponent(int health)
{
    private int health = health > 0 ? health : 1;

    public abstract void TakeDamage(int damage);
}