namespace Zombie;

public class ConeZombieBuilder : ZombieBuilder
{
    public override void BuildAccessory()
    {
        accessory = new ZombieAccessory(25);

        if (product != null)
        {
            accessory.addChild(product);
        }
        else
        {
            throw new InvalidOperationException("Zombie must be built before adding an accessory.");
        }
        
        product = accessory;
    }
}