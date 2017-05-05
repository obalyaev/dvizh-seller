﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DvizhSeller.repositories
{
    class Cart
    {
        private List<entities.interfaces.CartElement> products = new List<entities.interfaces.CartElement>();

        public void Put(entities.interfaces.CartElement product, int count = 1)
        {
            foreach (entities.interfaces.CartElement existsProduct in GetElements())
            {
                if(existsProduct.GetId() == product.GetId())
                {
                    existsProduct.SetCartCount(existsProduct.GetCartCount() + count);

                    return;
                }
            }

            product.SetCartCount(count);
            products.Add(product);
        }

        public void Delete(entities.interfaces.CartElement product)
        {
            products.Remove(product);
        }

        public List<entities.interfaces.CartElement> GetElements()
        {
            return products;
        }

        public entities.interfaces.CartElement FindOne(int id)
        {
            return products.Find(x => x.GetId() == id);
        }

        public List<entities.interfaces.CartElement> FindByString(string str)
        {
            return products.FindAll(x => x.GetNameAndSku().ToLower().Contains(str.ToLower()));
        }

        public List<entities.interfaces.CartElement> FindByCategory(entities.Category category)
        {
            return products.FindAll(x => x.GetCategoryId() == category.GetId());
        }

        public List<entities.interfaces.CartElement> FindByCategoryId(int categoryId)
        {
            return products.FindAll(x => x.GetCategoryId() == categoryId);
        }

        public int GetCount()
        {
            int count = 0;

            foreach(entities.interfaces.CartElement product in GetElements()) {
                count += product.GetCartCount();
            }

            return count;
        }

        public double GetTotal()
        {
            double total = 0;

            foreach (entities.interfaces.CartElement product in GetElements())
            {
                total += product.GetPrice() * product.GetCartCount();
            }

            return total;
        }
    }
}
