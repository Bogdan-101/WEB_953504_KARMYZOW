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
    /// ���������� �������� � ������� 
    /// </summary> 
    public int Count
    {
        get
        {
            return Items.Sum(item => item.Value.Quantity);
        }
    }
    /// <summary> 
    /// ���������� ������� 
    /// </summary> 
    public int Rating
    {
        get
        {
            return Items.Sum(item => item.Value.Quantity * item.Value.Game.Rating);
        }
    }

    /// <summary> 
    /// ���������� � ������� 
    /// </summary> 
    /// <param name="game">����������� ������</param> 
    public virtual void AddToCart(Game game)
    {
        // ���� ������ ���� � ������� 
        // �� ��������� ���������� 
        if (Items.ContainsKey(game.Id))
            Items[game.Id].Quantity++;
        // ����� - �������� ������ � ������� 
        else
            Items.Add(game.Id, new CartItem
            {
                Game = game,
                Quantity = 1
            });
    }

    /// <summary> 
    /// ������� ������ �� ������� 
    /// </summary> 
    /// <param name="id">id ���������� �������</param> 
    public virtual void RemoveFromCart(int id)
    {
        Items.Remove(id);
    }

    /// <summary> 
    /// �������� ������� 
    /// </summary> 
    public virtual void ClearAll()
    {
        Items.Clear();
    }
}

/// <summary> 
/// ���� ��������� ���� ������� � ������� 
/// </summary> 
public class CartItem
{
    public Game Game { get; set; }
    public int Quantity { get; set; }
}