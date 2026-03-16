namespace Zombie;

public class ZombieSpawner
{
    private ZombieBuilder builder;

    public ZombieComponent SpawnZombie(ZombieType type)
    {
        switch(type)
        {
            case ZombieType.Regular:
                builder = new RegularZombieBuilder();
                break;
            case ZombieType.Cone:
                builder = new ConeZombieBuilder();
                break;
            case ZombieType.Bucket:
                builder = new BucketZombieBuilder();
                break;
            case ZombieType.ScreenDoor:
                builder = new ScreenDoorZombieBuilder();
                break;
            default:
                throw new ArgumentException("Invalid zombie type");
                break;
        }

        builder.BuildZombie();
        builder.BuildAccessory();
        return builder.GetProduct();
    }
}