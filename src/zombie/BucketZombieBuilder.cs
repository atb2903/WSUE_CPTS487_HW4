namespace Zombie;

public class BucketZombieBuilder : ZombieBuilder
{
    public override void BuildAccessory()
    {
        ZombieAccessory accessory = new ZombieAccessory(100, ZombieType.Bucket);

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