namespace DeckOfCards;

// Судя по всему, основная проблема была в том, что я использовал словарь, когда можно было более удобно использовать List

public class Card
{
    public int CardId { get; set; }
    public string Suit { get; set; }
    public string Rank { get; set; }

    public Card(string suit, string rank, int cardId)
    {
        Suit = suit ?? "Unknown";
        Rank = rank ?? "Unknown";
        CardId = cardId;
    }

    public override string ToString() // Подсказка чата
    {
        return $"ID: {CardId}, Масть: {Suit}, Ранг: {Rank}";
    }
}

public class DeckOfCards
{
    public Dictionary<int, Card> deckOfCards = new Dictionary<int, Card>();

    public void CardReplacer()
    {
        // Создаем копию ключей, так как нельзя изменять коллекцию во время итерации
        var cardIds = deckOfCards.Keys.ToList();
    
        foreach (int cardId in cardIds)
        {
            if (deckOfCards.TryGetValue(cardId, out Card card))
            {
                _playerDeckOfCards.Add(cardId, card);
                deckOfCards.Remove(cardId);
                Console.WriteLine($"Карта {card} перемещена в вашу колоду.");
            }
        }
    
        Console.WriteLine("Все карты перемещены!");
    }

    public void AddCard(string suit, string rank, int cardId) // Подсказка чата - до этого я сам написал этот мет -
        // - од, но там получилась полнейшая жопа, и он мне его исправил, проблема была в томЮ что я что-то там напутал -
        // - из-за чего, карты не выводились в консоль.
    {
        if (!deckOfCards.ContainsKey(cardId))
        {
            var newCard = new Card(suit, rank, cardId);
            deckOfCards.Add(cardId, newCard);
            Console.WriteLine($"Карта {newCard} добавлена.");
        }
        else
        {
            Console.WriteLine($"Карта с ID {cardId} уже существует!");
        }
    }
    public Dictionary<int, Card> _playerDeckOfCards = new Dictionary<int, Card>();
    public void PrintCards() // Также, изначально сделал, но с проёбом, чат подправил этот метод.
        {
            if (_playerDeckOfCards.Count > 0)
            {
                foreach (var cardEntry in _playerDeckOfCards)
                {
                    Console.WriteLine($"Ваши карты: {cardEntry.Value}");
                }
            }
            else
            {
                Console.WriteLine("В колоде нет карт!");
            }
        }
}
