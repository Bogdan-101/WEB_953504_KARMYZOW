using System.Collections.Generic;
using System.Linq;

public class Cart
{
    public Dictionary<int, CartItem> Items { get; set; }
    public Cart()
    {
        Items = new Dictionary<int, CartItem>();
    }
    /// <summary> 
    /// Количество объектов в корзине 
    /// </summary> 
    public int Count
    {
        get
        {
            return Items.Sum(item => item.Value.Quantity);
        }
    }
    /// <summary> 
    /// Количество калорий 
    /// </summary> 
    public int Rating
    {
        get
        {
            return Items.Sum(item => item.Value.Quantity * item.Value.Game.Rating);
        }
    }

    /// <summary> 
    /// Добавление в корзину 
    /// </summary> 
    /// <param name="game">добавляемый объект</param> 
    public virtual void AddToCart(Game game)
    {
        // если объект есть в корзине 
        // то увеличить количество 
        if (Items.ContainsKey(game.Id))
            Items[game.Id].Quantity++;
        // иначе - добавить объект в корзину 
        else
            Items.Add(game.Id, new CartItem
            {
                Game = game,
                Quantity = 1
            });
    }

    /// <summary> 
    /// Удалить объект из корзины 
    /// </summary> 
    /// <param name="id">id удаляемого объекта</param> 
    public virtual void RemoveFromCart(int id)
    {
        Items.Remove(id);
    }

    /// <summary> 
    /// Очистить корзину 
    /// </summary> 
    public virtual void ClearAll()
    {
        Items.Clear();
    }
}

/// <summary> 
/// Клас описывает одну позицию в корзине 
/// </summary> 
public class CartItem
{
    public Game Game { get; set; }
    public int Quantity { get; set; }
}