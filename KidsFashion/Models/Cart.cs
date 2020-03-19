using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace KidsFashion.Models
{
    public class Cart
    {
        public Dictionary<int, CartItem> Items { get; set; }
        public double TotalPrice => Items.Values.Sum(i => i.ProductPrice * i.Quantity);

        public Cart()
        {
            Items = new Dictionary<int, CartItem>();
        }

        public void Add(Product product, int quantity, Boolean isUpate)
        {
            var cartItem = new CartItem()
            {
                ProductId = product.Id,
                ProductName = product.Name,
                ProductThumbnail = product.Thumbnail,
                ProductPrice = product.Price,
                Quantity = quantity
            };

            var existKey = Items.ContainsKey(product.Id);
            if (!isUpate && existKey)
            {
                var existingItem = Items[product.Id];
                cartItem.Quantity += existingItem.Quantity;
            }

            if (existKey)
            {
                Items[product.Id] = cartItem;
            }
            else
            {
                Items.Add(product.Id, cartItem);
            }
        }

        public void Add(Product product)
        {
            Add(product, 1, false);
        }

        public void Update(Product product, int quantity)
        {
            Add(product, 1, true);

        }

        public void Remove(int productId) 
        {
            if (Items.ContainsKey(productId))
            {
                Items.Remove(productId);
            }

        }

        public void Clear()
        {
            Items.Clear();
        }

    }

    public class CartItem
    {
        public int ProductId { get; set; } 
        public string ProductName { get; set; } 
        public string ProductThumbnail { get; set; } 
        public double ProductPrice { get; set; } 
        public double TotalItemPrice => ProductPrice * Quantity;
        public int Quantity { get; set; } 
    }
}