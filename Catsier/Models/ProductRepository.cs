using System;
using System.Collections.Generic;
using System.Text;

namespace Catsier.Models {
	class ProductRepository {

		private List<Product> products;

		public event Action OnProductListChange = ()=>{};

		public ProductRepository() {
			products = new List<Product>();
		}

		public bool AddProduct(Product newProduct) {
			foreach(Product product in products) {
				if(product.Kode == newProduct.Kode) {
					return false;
				}
			}
			products.Add(newProduct);
			OnProductListChange();
			return true;
		}

		public void RemoveProduct(Product product) {
			products.Remove(product);
			OnProductListChange();
		}

		public Product FindByCode(string kode) {
			return products.Find(x => { return x.Kode == kode; });
		}

		public void RemoveProduct(string kode) {
			for(int i = 0; i < products.Count; i++) {
				if(products[i].Kode == kode) {
					products.RemoveAt(i);
					break;
				}
			}
			OnProductListChange();
		}

		public Product[] GetProducts() {
			return products.ToArray();
		}
	}
}
