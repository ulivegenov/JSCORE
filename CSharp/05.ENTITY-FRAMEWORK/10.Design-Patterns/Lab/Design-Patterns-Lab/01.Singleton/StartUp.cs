namespace Singleton
{
    public class StartUp
    {
        public static void Main()
        {
            // Count of instance calling check
            var db = SingletonDataContainer.Instance;
            var db2 = SingletonDataContainer.Instance;
            var db3 = SingletonDataContainer.Instance;
            var db4 = SingletonDataContainer.Instance;
        }
    }
}
