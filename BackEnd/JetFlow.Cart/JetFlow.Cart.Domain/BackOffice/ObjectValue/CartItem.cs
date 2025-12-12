using JetFlow.Cart.Domain.BackOffice.Entities.Contracts;
using JetFlow.Cart.Domain.BackOffice.Exceptions;

namespace JetFlow.Cart.Domain.BackOffice.ObjectValue;

public class CartItem : Entity
{
    public CartItem()
    {
        
    }
    public CartItem(int userId,int cartId,string name, string description, string imageUrl, decimal price, int quantity, int productId)
    {
        if (!IsValid(name, description, imageUrl, price,Quantity))
            throw new CartItemException();
        
        ProductId = productId;
        Name = name;
        Description = description;
        ImageUrl = imageUrl;
        Price = price;
        Quantity = quantity;
        IdCart = cartId;
        UserId= userId;
    }

    public int UserId { get; set; }
    public int IdCart { get; set; }
    public int ProductId { get; set; }
    public string Name { get; set; }
    public string Description { get; set; }
    public string ImageUrl { get; set; }
    public decimal Price { get; set; }
    public int Quantity { get; set; }

    public bool IsValid(string name, string description, string imageurl, decimal price,int quantity)
    {
        if (name.Length < 1 || string.IsNullOrWhiteSpace(name))
            return false;
        if (description.Length < 1 || string.IsNullOrWhiteSpace(description))
            return false;
        if (imageurl.Length < 1 || string.IsNullOrWhiteSpace(imageurl))
            return false;
        if (price < 0 || quantity < 0 )
            return false;
        return true;
    }

    public bool IsValid(CartItem item)
        => IsValid(item.Name, item.Description, item.ImageUrl, item.Price, item.Quantity);
}