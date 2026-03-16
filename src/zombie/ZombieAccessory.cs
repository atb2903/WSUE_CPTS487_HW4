namespace Zombie;

public class ZombieAccessory : ZombieComponent
{
    private ZombieComponent? child;
    public ZombieAccessory(int health, ZombieType type) : base(health, type)
    {
        child = null;
    }

    public void addChild(ZombieComponent component)
    {
        child = component;
    }

    public void removeChild()
    {
        child = null;
    }

    public ZombieComponent? getChild()
    {
        return child;
    }

    public override void TakeDamage(int damage)
    {
        if(isAlive)
        {
            health -= damage;
            if (health <= 0)
            {
                child.TakeDamage(health); // Pass remaining damage to child and die
                Die();
            }
        }
        else
        {
            child.TakeDamage(damage); // Pass damage to child if accessory is already dead
        }
    }

    public override bool IsAlive()
    {
        return isAlive || child.IsAlive();
    }

    private override void Die()
    {
        this.isAlive = false;
        this.ZombieType = child.GetZombieType();
    }
}