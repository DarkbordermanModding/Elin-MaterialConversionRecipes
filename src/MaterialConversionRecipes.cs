using System;
using System.Collections.Generic;


public class MaterialConversionRecipes
{
  public class DefaultRecipeRowData{
    public string factory = "Smelter";  // Which crafting table
    public string type = "Resource"; // Resource to inherit item material, FixedResource to set fixed material
    public int sp = 1;  // stamina cost
    public int time = 5;  // turn cost
    public string[] ing1 = new string[]{"ore"};  // ingrident 1
    public string[] ing2 = new string[]{""};  // ingrident 2
    public string[] ing3 = new string[]{""};  // ingrident 3
    public string thing = "ingot";  // output thing
    public string num = "1";  // output count
    public string[] tag = new string[] { "known" };  // default shown
  }

  public static void Main()
  {
    SourceManager sources = Core.Instance.sources;
    // Make all recipes known
    foreach (SourceRecipe.Row recipe in sources.recipes.rows){
      if(Array.IndexOf(recipe.tag, "known") == -1){
        Array.Resize(ref recipe.tag, recipe.tag.Length + 1);
        recipe.tag[recipe.tag.Length - 1] = "known";
      }
    }
    // Add material conversion recipes
    List<DefaultRecipeRowData> rows = new List<DefaultRecipeRowData>
    {
      // All stuff to ore
      new DefaultRecipeRowData{factory="Smelter", ing1=new []{"scrap"}, thing="ore"},
      new DefaultRecipeRowData{factory="Smelter", ing1=new []{"log"}, thing="ore"},
      new DefaultRecipeRowData{factory="Smelter", ing1=new []{"rock"}, thing="ore"},
      new DefaultRecipeRowData{factory="Smelter", ing1=new []{"texture"}, thing="ore"},
      new DefaultRecipeRowData{factory="Smelter", ing1=new []{"grass"}, thing="ore"},
      new DefaultRecipeRowData{factory="Smelter", ing1=new []{"chunk"}, thing="ore"},
      new DefaultRecipeRowData{factory="Smelter", ing1=new []{"fragment"}, thing="ore"},
      // Ore to something else
      new DefaultRecipeRowData{factory="Spinner", ing1=new []{"ore"}, thing="thread"},
      new DefaultRecipeRowData{factory="SawMill", ing1=new []{"ore"}, thing="plank"},
      new DefaultRecipeRowData{factory="GemCutter", ing1=new []{"ore"}, thing="gem"},
    };
    int counter = 1000000;
    foreach (DefaultRecipeRowData row in rows){
      sources.recipes.rows.Add(new SourceRecipe.Row(){
        id=counter,
        factory=row.factory,
        type=row.type,
        thing=row.thing,
        num=row.num,
        sp=row.sp,
        time=row.time,
        ing1=row.ing1,
        ing2=row.ing2,
        ing3=row.ing3,
        tag=row.tag,
      });
      counter += 1;
    }
  }
}
