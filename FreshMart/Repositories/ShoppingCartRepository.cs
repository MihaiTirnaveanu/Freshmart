﻿using FreshMart.Data;
using FreshMart.Models;
using FreshMart.Repositories.Interfaces;

namespace FreshMart.Repositories
{
    public class ShoppingCartRepository : IShoppingCartRepository
    {
        private SupermarketContext _context;
        public ShoppingCartRepository(SupermarketContext context)
        {
            _context = context;

        }
        public IEnumerable<ShoppingCart> GetAll()
        {
            return _context.ShoppingCarts.ToList();
        }

        public ShoppingCart GetById(int id)
        {
            return _context.ShoppingCarts.FirstOrDefault(c => c.Id == id);
        }

        public bool ShoppingCartExists(int id)
        {
            return _context.ShoppingCarts.Any(c => c.Id == id);
        }

        public void Create(ShoppingCart shoppingCart)
        {
            _context.ShoppingCarts.Add(shoppingCart);
        }

        public void Delete(ShoppingCart shoppingCart)
        {
            _context.Remove(shoppingCart);
        }

        public void Update(ShoppingCart category)
        {
            _context.Update(category);
        }

        public void Save()
        {
            _context.SaveChanges();
        }

        public ShoppingCart GetByUserId(string userId) {
           return _context.ShoppingCarts.FirstOrDefault(cart => cart.UserId == userId);
        }
    }
}
