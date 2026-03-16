namespace Zombie;

public class ScreenDoorZombieBuilder : ZombieBuilder
{
    public override void BuildAccessory()
    {
        ZombieAccessory accessory = new ZombieAccessory(25, ZombieType.ScreenDoor);

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