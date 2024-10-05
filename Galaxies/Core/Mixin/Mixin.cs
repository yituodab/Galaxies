namespace Galaxies.Core.ModLoader
[AttributeUsage(AttributeTargets.Class)]
public class Mixin : System.Attribute{
    public object MixinClass;
    public Mixin(string ) where T : class{
        this.MixinClass = MixinClass;
        foreach(var type in Assembly.GetExecutingAssembly().GetExportedTypes()){
            
        }
    }
}