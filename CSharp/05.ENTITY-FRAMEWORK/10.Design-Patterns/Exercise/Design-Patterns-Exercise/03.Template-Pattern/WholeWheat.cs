namespace Template_Pattern
{
    using System;

    internal class WholeWheat : Bread
    {
        public override void MixIngredients()
        {
            Console.WriteLine("Gathering Ingredients for WholeWheat Bread.");
        }

        public override void Bake()
        {
            Console.WriteLine("Baking the WholeWheat Bread. (15 minutes)");
        }
    }
}
