namespace Zombie;

public class ConeZombieBuilder : ZombieBuilder
{
    public override void BuildAccessory()
    {
        ZombieAccessory accessory = new ZombieAccessory(100);

        if (GetProduct() != null)
        {
            accessory.addChild(GetProduct()!);
        }
        else
        {
            throw new InvalidOperationException("Zombie must be built before adding an accessory.");
        }
        
        product = accessory;
    }
}