namespace P06_StoreBoxes
{
    internal class Program
    {
        static void Main(string[] args)
        {
            List<Box> boxes = new List<Box>();
            string input;
            while ((input = Console.ReadLine()) != "end")
            {
                string[] arguments = input.Split();
                string serialNum = arguments[0];
                string itemName= arguments[1];
                int itemQuantity = int.Parse(arguments[2]);
                decimal itemPrice= decimal.Parse(arguments[3]);
                Item currItem=new Item(itemName,itemPrice);
                Box currentBox=new Box(serialNum,currItem,itemQuantity);
                boxes.Add(currentBox);
            }
            
            foreach (Box box in boxes.OrderByDescending(x=>x.PriceForABox))
            {
                PrintBox(box);
            }
        }

        static void PrintBox(Box box)
        {
            Console.WriteLine(box.SerialNumber);
            Console.WriteLine($"-- {box.Item.Name} - ${box.Item.Price:f2}: {box.ItemQuantity}");
            Console.WriteLine($"-- ${box.PriceForABox:f2}");
        }
    }
    public class Item
    {
        public Item(string name, decimal price)
        {
            Name = name;
            Price = price;
        }

        public string Name { get; set; }
        public decimal Price { get; set; }

    }
    public class Box
    {
        public Box(string serialNumber,Item item,int quantity)
        {
            SerialNumber = serialNumber;
            Item = item;
            ItemQuantity = quantity;
        }
        public string SerialNumber { get; set; }
        public Item Item { get; set; }
        public int ItemQuantity { get; set; }
        public decimal PriceForABox => Item.Price * ItemQuantity;
       

    }

}