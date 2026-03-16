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
        if(child == null)
        {
            throw new InvalidOperationException("Accessory must have a child to take damage..");
        }
        if(isAlive)
        {
            health -= damage;
            if (health <= 0)
            {
                child.TakeDamage(Math.Abs(health)); // Pass remaining damage to child and die
                health = 0; // Ensure health doesn't go negative
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
        if(child == null)
        {
            throw new InvalidOperationException("Accessory must have a child to check if alive.");
        }
        // Accessory acts acts a proxy for the child when dead
        return isAlive || child.IsAlive();
    }

    public override int GetHealth()
    {
        if(child == null)
        {
            throw new InvalidOperationException("Accessory must have a child to get health.");
        }
        return health + child.GetHealth(); // Total health is accessory's health plus child's health
    }

    protected override void Die()
    {
        if(child == null)
        {
            throw new InvalidOperationException("Accessory must have a child to die.");
        }
        // Accessory acts acts a proxy for the child when dead
        this.isAlive = false;
        this.type = child.GetZombieType();
    }
}