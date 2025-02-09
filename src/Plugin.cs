using BepInEx;


[BepInPlugin("dbm.materialconversionrecipes", "Material Conversion Recipes", "1.0.0.0")]
public class Mod_ProcessRecipe : BaseUnityPlugin
{
  public void OnStartCore()
  {
    MaterialConversionRecipes.Main();
  }
}
