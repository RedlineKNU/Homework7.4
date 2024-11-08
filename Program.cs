namespace DecoratorExample
{
    public interface Tree
    {
        void Display();
    }

    public class ChristmasTree : Tree
    {
        public void Display()
        {
            Console.WriteLine("This is a simple Christmas tree.");
        }
    }

    public abstract class TreeDecorator : Tree
    {
        protected Tree decoratedTree;

        public TreeDecorator(Tree tree)
        {
            decoratedTree = tree;
        }

        public virtual void Display()
        {
            decoratedTree.Display();
        }
    }

    // Декоратор, що додає ялинкові прикраси
    public class OrnamentsDecorator : TreeDecorator
    {
        public OrnamentsDecorator(Tree tree) : base(tree) { }

        public override void Display()
        {
            base.Display();
            AddOrnaments();
        }

        private void AddOrnaments()
        {
            Console.WriteLine("The tree is now decorated with ornaments.");
        }
    }

    // Декоратор, що додає гірлянду
    public class LightsDecorator : TreeDecorator
    {
        public LightsDecorator(Tree tree) : base(tree) { }

        public override void Display()
        {
            base.Display();
            AddLights();
        }

        private void AddLights()
        {
            Console.WriteLine("The tree is now glowing with lights.");
        }
    }

    public class Program
    {
        public static void Main(string[] args)
        {
            // Створюємо ялинку
            Tree tree = new ChristmasTree();
            Console.WriteLine("Simple tree:");
            tree.Display();

            // Додаємо прикраси
            Console.WriteLine("\nTree with ornaments:");
            Tree ornamentedTree = new OrnamentsDecorator(tree);
            ornamentedTree.Display();

            // Додаємо гірлянду
            Console.WriteLine("\nTree with lights:");
            Tree litTree = new LightsDecorator(tree);
            litTree.Display();

            // Додаємо і прикраси, і гірлянду
            Console.WriteLine("\nTree with ornaments and lights:");
            Tree fullyDecoratedTree = new LightsDecorator(new OrnamentsDecorator(tree));
            fullyDecoratedTree.Display();
        }
    }
}
