namespace Zombie;

public abstract class ZombieBuilder
{
    private ZombieComponent? product = null;

    public void BuildZombie()
    {
        product = new Zombie(50, ZombieType.Regular);
    }

    public abstract void BuildAccessory();

    public ZombieComponent GetProduct()
    {
        if (product == null)
        {
            throw new InvalidOperationException("Product has not been built yet");
        }
        return product;
    }
}