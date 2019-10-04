using Microsoft.VisualStudio.TestTools.UnitTesting;
using Products.Controllers;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Products.Entities;
using Products.Models;
using System.Web.Mvc;
using System.Data;

namespace Products.Controllers.Tests
{
    [TestClass()]
    public class ProductsControllerTests
    {
        [TestMethod()]
        public void Edit_Name()
        {
            using (ProductsController productsController = new ProductsController())
            using (ProductsContext productsContext = new ProductsContext())
            {
                var itemToEdit = productsContext.Products.FirstOrDefault();
                if (itemToEdit != null)
                {
                    itemToEdit.Name = "Old Item";
                    var result = productsController.Edit(itemToEdit);

                    Assert.IsNotNull(result);
                }
                else
                {
                    Assert.Fail();
                }
            }
        }

        [TestMethod()]
        public void Edit_Price()
        {
            using (ProductsController productsController = new ProductsController())
            using (ProductsContext productsContext = new ProductsContext())
            {
                var itemToEdit = productsContext.Products.FirstOrDefault();
                if (itemToEdit != null)
                {
                    itemToEdit.Price += 1m;
                    var result = productsController.Edit(itemToEdit);

                    Assert.IsNotNull(result);
                }
                else
                {
                    Assert.Fail();
                }
            }
        }

        [TestMethod()]
        public void Edit_Location()
        {
            using (ProductsController productsController = new ProductsController())
            using (ProductsContext productsContext = new ProductsContext())
            {
                var itemToEdit = productsContext.Products.FirstOrDefault();
                if (itemToEdit != null)
                {
                    itemToEdit.Location = "Games";
                    var result = productsController.Edit(itemToEdit);

                    Assert.IsNotNull(result);
                }
                else
                {
                    Assert.Fail();
                }
            }
        }

        [TestMethod()]
        public void CreateNew()
        {
            using (ProductsController productsController = new ProductsController())
            {
                string name = "New Product";
                decimal price = 1.99m;
                string location = "Home";
                Product newProduct = new Product()
                {
                    Name = name,
                    Price = price,
                    Location = location
                };

                var result = productsController.Create(newProduct);

                Assert.IsNotNull(result);
            }
        }

        [TestMethod()]
        public void DeleteExisting()
        {
            using (ProductsController productsController = new ProductsController())
            using (ProductsContext productsContext = new ProductsContext())
            {
                var itemToDelete = productsContext.Products.FirstOrDefault();
                if (itemToDelete != null)
                {
                    var result = productsController.Delete(itemToDelete.Id);

                    Assert.IsNotNull(result);
                }
                else
                {
                    Assert.Fail();
                }
            }
        }

        [TestMethod()]
        public void DetailsExisiting()
        {
            using (ProductsController productsController = new ProductsController())
            using (ProductsContext productsContext = new ProductsContext())
            {
                var itemToDelete = productsContext.Products.FirstOrDefault();
                if (itemToDelete != null)
                {
                    var result = productsController.Details(itemToDelete.Id);

                    Assert.IsNotNull(result);
                }
                else
                {
                    Assert.Fail();
                }
            }
        }
    }
}