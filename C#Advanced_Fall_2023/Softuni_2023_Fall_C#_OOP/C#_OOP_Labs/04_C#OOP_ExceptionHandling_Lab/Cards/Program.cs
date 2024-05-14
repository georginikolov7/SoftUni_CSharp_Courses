

namespace Cards;
class Card
{
    private readonly List<string> validFaces;
    private readonly Dictionary<string, string> validSuits;
    private string face;
    private string suit;

    public Card(string face, string suitLetter)
    {
        validFaces = new()
        {
            "2",
            "3",
            "4",
            "5",
            "6",
            "7",
            "8",
            "9",
            "10",
            "J",
            "Q",
            "K",
            "A"
        };
        validSuits = new()
        {
             {"S", "\u2660" },
             {"H", "\u2665" },
             {"D", "\u2666" },
             {"C", "\u2663" }
        };
        Face = face;
        Suit = suitLetter;
    }

    public string Face
    {
        get { return face; }
        set
        {
            if (!validFaces.Contains(value))
            {
                ThrowCardException();
            }
            face = value;
        }
    }

    public string Suit
    {
        get { return suit; }
        set
        {
            if (!validSuits.ContainsKey(value))
            {
                ThrowCardException();
            }
            suit = validSuits[value];
        }
    }
    public override string ToString()
    {
        return $"[{Face}{Suit}]";
    }
    private void ThrowCardException()
    {
        throw new ArgumentException("Invalid card!");
    }
}

public class Program
{
    static void Main()
    {
        Console.OutputEncoding = System.Text.Encoding.UTF8;
        List<Card> cards = new();
        string[] cardsInput = Console.ReadLine().Split(", ", StringSplitOptions.RemoveEmptyEntries);
        foreach (string item in cardsInput)
        {
            try
            {
                string[] cardParams = item.Split(' ', StringSplitOptions.RemoveEmptyEntries);
                Card card = new Card(cardParams[0], cardParams[1]);
                cards.Add(card);
            }
            catch (ArgumentException ex)
            {
                Console.WriteLine(ex.Message);
            }
        }
        foreach (var card in cards)
        {
            Console.Write(card + " ");
        }
    }
}
