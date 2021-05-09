using Catsier.Models;
using System;
using System.Collections.Generic;
using System.Text;

namespace Catsier.Database {
	class ProductDBContext {

		private ProductRepository productRepo;
		private DBConnection dbConnection;
		private AddNewProductCommand newProductCommand;
		private UpdateProductRepositoryCommand updateProductCommand;
		private EditProductCommand editProductCommand;
		private DeleteProductCommand deleteProductCommand;

		public ProductDBContext(ProductRepository productRepo, DBConnection dbConnection) {
			this.productRepo = productRepo;
			this.dbConnection = dbConnection;
			newProductCommand = new AddNewProductCommand(dbConnection);
			updateProductCommand = new UpdateProductRepositoryCommand(productRepo, dbConnection);
			editProductCommand = new EditProductCommand(dbConnection);
			deleteProductCommand = new DeleteProductCommand(dbConnection);
			productRepo.OnNewProduct += OnNewProduct;
			productRepo.OnDeleteProduct += DeleteProduct;
			Mediator.Subscribe("Update Product Data", UpdateProductRepository);
			Mediator.Subscribe("Update Product", EditProduct);
		}

		public void OnNewProduct(Product product) {
			newProductCommand.Execute(product.Kode, product.Nama, product.Kategori, product.Satuan, product.Modal, product.Jual);
		}

		public void UpdateProductRepository(object o) {
			updateProductCommand.Execute();
		}

		public void EditProduct(object o) {
			Product product = (Product)o;
			editProductCommand.Execute(product.Kode, product.Nama, product.Kategori, product.Satuan, product.Modal, product.Jual);
		}

		public void DeleteProduct(Product product) {
			deleteProductCommand.Execute(product);
		}

	}
}
