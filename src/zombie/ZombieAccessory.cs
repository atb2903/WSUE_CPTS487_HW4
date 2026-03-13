namespace Zombie;

public class ZombieAccessory : ZombieComponent
{
    private ZombieComponent? child;
    public ZombieAccessory(int health) : base(health)
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
        // TODO: implement damage logic for the zombie accessory
    }
}