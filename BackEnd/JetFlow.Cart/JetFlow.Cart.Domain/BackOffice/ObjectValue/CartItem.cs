using JetFlow.Cart.Domain.BackOffice.Entities.Contracts;
using JetFlow.Cart.Domain.BackOffice.Exceptions;

namespace JetFlow.Cart.Domain.BackOffice.ObjectValue;

public class CartItem : Entity
{
    protected  CartItem()
    {
        
    }
    public CartItem(string name, string description, string imageUrl, decimal price)
    {
        if (!IsValid(name, description, imageUrl, price))
            throw new CartItemException();
        
        Name = name;
        Description = description;
        ImageUrl = imageUrl;
        Price = price;
    }

    public string Name { get; set; }
    public string Description { get; set; }
    public string ImageUrl { get; set; }
    public decimal Price { get; set; }

    public bool IsValid(string name, string description, string imageurl, decimal price)
    {
        if (name.Length < 1 || string.IsNullOrWhiteSpace(name))
            return false;
        if (description.Length < 1 || string.IsNullOrWhiteSpace(description))
            return false;
        if (imageurl.Length < 1 || string.IsNullOrWhiteSpace(imageurl))
            return false;
        if (price < 0)
            return false;
        return true;
    }
}