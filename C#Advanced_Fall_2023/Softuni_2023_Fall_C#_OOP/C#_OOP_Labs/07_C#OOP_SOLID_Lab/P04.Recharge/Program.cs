namespace P04.Recharge
{
    class Program
    {
        static void Main()
        {
            IWorker worker = new Employee("99999999999.....99999");
            worker.Work(5);
            IWorker worker2 = new Robot("Hehe Peshko", 2000);
            worker2.Work(10);
        }
    }
}
