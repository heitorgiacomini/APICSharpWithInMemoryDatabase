namespace Infrastructure
{

    public class Singleton
    {
        public Guid Id { get; set; } = Guid.NewGuid();

        private static Singleton instance = null;
        private Singleton()
        {
        }
        public static Singleton Instance
        {
            get
            {
                if (instance == null)
                {
                    instance = new Singleton();
                }
                return instance;
            }
        }
    }
    //public  class Singleton
    //{
    //    private static Singleton instance;
    //    private Singleton()
    //    {
    //    }
    //    public static Singleton Getinstance()
    //    {
    //        if (instance == null)
    //        {
    //            instance = new Singleton();
    //            return instance;
    //        }
    //        else
    //        {
    //            return instance;
    //        }
    //    }
    //}


}
