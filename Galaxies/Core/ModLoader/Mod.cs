namespace Galaxies.Core.ModLoader
[AttributeUsage(AttributeTargets.Class)]
public class Mod : System.Attribute{
    public string modid;
    public string version;
    public Mod(string modid,string version){
        this.modid = modid;
        this.version = version;
    }
}