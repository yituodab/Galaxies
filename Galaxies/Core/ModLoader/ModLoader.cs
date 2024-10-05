namespace Galaxies.Core.ModLoader;
public class ModLoader{
    
    public static List<Assembly> Load(string path){
        try
        {
        	var files = Directory.GetFiles(path, "*.dll");
        	List<Assembly> dlls = new List<Assembly>();
        	foreach (var location in files){
            	Assembly dll = Assembly.LoadFile(location);
            	dlls.Add(dll);
        	}
			return dlls;
        }
        catch(Exception e){
            Logger.writeToConsole(Logger.LogType.ERROR, e);
        }
        return null;
    }
    public static Dictionary<string, GalaxiasMod> Read(List<Assembly> dlls){
        Dictionary<string, GalaxiasMod> mods = new Dictionary<string, GalaxiasMod>();
        if(dlls != null){
        	foreach (Assembly dll in dlls){
            	object ModMain;
            	GalaxiasMod mod;
            	foreach (Type type in dll.GetExportedTypes()){
                	if(type.GetProperties() != null){
            			foreach (var attribute in type.GetProperties()){
                	    	if(attribute is Mod){
                	        	ModMain = dll.CreateInstance(type.FullName);
                        		mod = new GalaxiasMod(attribute.modid,attribute.version);
                                mods.Add(attribute.modid, mod);
                	    	}
                		}
                	}
            	}
        	}
            return mods;
        }
        return null;
    }
}