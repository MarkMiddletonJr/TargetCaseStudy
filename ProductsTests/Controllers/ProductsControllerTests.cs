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
        /// <summary>
        /// Returns a Product object with the edit made to the desired property. If property or value are passed as empty or null the methd will return "First Or Default".
        /// </summary>
        /// <param name="property">The property you want to change. Name, Price, or Location</param>
        /// <param name="value">The new value you of the property you want to set</param>
        /// <returns>A Product object</returns>
        public Product GetItem(string property, object value)
        {
            using (ProductsContext productsContext = new ProductsContext())
            {
                if (!string.IsNullOrWhiteSpace(property) && value != null)
                {
                    //Property and value are not null/empty. Return an edited item.
                    Product itemToEdit = productsContext.Products.FirstOrDefault();

                    if (itemToEdit != null)
                    {
                        itemToEdit.GetType().GetProperty(property).SetValue(itemToEdit, value, null);
                    }
                    return itemToEdit;
                }

                //if property or value are null/empty just return the first object, unedited.
                return productsContext.Products.FirstOrDefault();
            }
        }

        [TestMethod()]
        public void EditNameByObject()
        {
            using (ProductsController productsController = new ProductsController())
            {
                Assert.IsNotNull(productsController.Edit(GetItem("Name", "Item Name Changed")));
            }
        }

        [TestMethod()]
        public void EditPriceByObject()
        {
            using (ProductsController productsController = new ProductsController())
            {
                Assert.IsNotNull(productsController.Edit(GetItem("Price", 2.99m)));
            }
        }

        [TestMethod()]
        public void EditLocationByObject()
        {
            using (ProductsController productsController = new ProductsController())
            {
                Assert.IsNotNull(productsController.Edit(GetItem("Location", "Games")));
            }
        }

        [TestMethod()]
        public void EditNameByID()
        {
            using (ProductsController productsController = new ProductsController())
            {
                Assert.IsNotNull(productsController.Edit(GetItem("Name", "Item Name Changed by ID").Id));
            }
        }

        [TestMethod()]
        public void EditPriceByID()
        {
            using (ProductsController productsController = new ProductsController())
            {
                Assert.IsNotNull(productsController.Edit(GetItem("Price", 3.99m).Id));
            }
        }

        [TestMethod()]
        public void EditLocationByID()
        {
            using (ProductsController productsController = new ProductsController())
            {
                Assert.IsNotNull(productsController.Edit(GetItem("Location", "Hardware").Id));
            }
        }

        [TestMethod()]
        public void EditByIDNullCheck()
        {
            using (ProductsController productsController = new ProductsController())
            {
                //The ID '0' is not a valid item and will produce a null record in the controller.
                Assert.IsNotNull(productsController.Edit(0));
            }
        }

        [TestMethod()]
        public void CreateNew()
        {
            using (ProductsController productsController = new ProductsController())
            {
                Product newProduct = new Product()
                {
                    Name = "New Product",
                    Price = 1.99m,
                    Location = "Home"
                };

                var result = productsController.Create(newProduct);

                Assert.IsNotNull(result);
            }
        }

        [TestMethod()]
        public void Delete()
        {
            using (ProductsController productsController = new ProductsController())
            {
                Assert.IsNotNull(productsController.Delete(GetItem("", "").Id));
            }
        }

        [TestMethod()]
        public void DeleteNullCheck()
        {
            using (ProductsController productsController = new ProductsController())
            {
                //The ID '0' is not a valid item and will produce a null record in the controller.
                Assert.IsNotNull(productsController.Delete(0));
            }
        }

        [TestMethod()]
        public void DeleteConfirmed()
        {
            using (ProductsController productsController = new ProductsController())
            {
                Assert.IsNotNull(productsController.Delete(GetItem("","").Id));
            }
        }

        [TestMethod()]
        public void Details()
        {
            using (ProductsController productsController = new ProductsController())
            {
                Assert.IsNotNull(productsController.Details(GetItem("", "").Id));
            }
        }

        [TestMethod()]
        public void DetailsNullCheck()
        {
            using (ProductsController productsController = new ProductsController())
            {
                //The ID '0' is not a valid item and will produce a null record in the controller.
                Assert.IsNotNull(productsController.Details(0));
            }
        }

    }
}