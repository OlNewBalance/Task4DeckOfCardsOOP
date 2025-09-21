namespace DeckOfCards;

public class Card
{
    internal int CardId { get; set; }
    private string Suit { get; set; }
    private string Rank { get; set; }

    public Card(string suit, string rank, int cardId)
    {
        Suit = suit ?? "Unknown";
        Rank = rank ?? "Unknown";
        CardId = cardId;
    }

    public override string ToString()
    {
        return $"ID: {CardId}, Масть: {Suit}, Ранг: {Rank}";
    }
}

public class DeckOfCards
{
    Player _player;
    public List<Card> _deckOfCards = new List<Card>();

    public DeckOfCards(Player player)
    {
        _player = player;
    }

    public void DealCardsToPlayer()
    {
        if (_deckOfCards.Count == 0)
        {
            Console.WriteLine("В колоде нет карт!");
            return;
        }

        // перемещаем все карты
        foreach (var card in _deckOfCards.ToList()) // создаём копию, чтобы можно было удалять
        {
            _player.PlayerCards.Add(card);
            _deckOfCards.Remove(card);
            Console.WriteLine($"Карта {card} перемещена в вашу колоду.");
        }

        Console.WriteLine("Все карты перемещены!");
    }

    public void AddCard(string suit, string rank, int cardId)
    {
        if (_deckOfCards.Any(c => c.CardId == cardId)) // проверяем по ID
        {
            Console.WriteLine($"Карта с ID {cardId} уже существует!");
            return;
        }
        var newCard = new Card(suit, rank, cardId);
        _deckOfCards.Add(newCard);
        Console.WriteLine($"Карта {newCard} добавлена.");
    }

}
