namespace Galaxies.Core.ModLoader
[AttributeUsage(AttributeTargets.Method)]
public class Inject : System.Attribute{
    public static enum MixinWay{
        HEAD,
        TAIL,
        RETURN
    }
    public object MixinClass;
    public MixinWay way;
    public Inject(string method, MixinWay way){
        this.MixinClass = MixinClass;
        this.way = way;
    }
}