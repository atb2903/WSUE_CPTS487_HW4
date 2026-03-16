namespace Zombie;

public abstract class ZombieBuilder
{
    private ZombieComponent? product = null;

    public void BuildZombie()
    {
        product = new Zombie(50);
    }

    public abstract void BuildAccessory();

    public ZombieComponent? GetProduct()
    {
        return product;
    }
}