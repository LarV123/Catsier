using System;
using System.Collections.Generic;
using System.Text;

namespace Catsier.Models {
	class ProductRepository {

		private List<Product> products;

		public event Action OnProductListChange = ()=>{};

		public event Action<Product> OnNewProduct = (x) => { };
		public event Action<Product> OnDeleteProduct = (x) => { };

		public ProductRepository() {
			products = new List<Product>();
		}

		public bool AddProduct(Product newProduct) {
			Mediator.Invoke("Update Product Data");
			foreach(Product product in products) {
				if(product.Kode == newProduct.Kode) {
					return false;
				}
			}
			products.Add(newProduct);
			OnNewProduct(newProduct);
			OnProductListChange();
			return true;
		}

		public void RemoveProduct(Product product) {
			products.Remove(product);
			OnDeleteProduct(product);
			OnProductListChange();
		}

		public Product FindByCode(string kode) {
			return products.Find(x => { return x.Kode == kode; });
		}

		public void RemoveProduct(string kode) {
			RemoveProduct(FindByCode(kode));
			OnProductListChange();
		}

		public void UpdateData(string[] kode, string[] nama, string[] kategori, string[] satuan, long[] modal, long[] jual) {
			List<Product> nonUpdatedProduct = new List<Product>(products); //Product that stays in this list will be deleted
			for(int i = 0; i < kode.Length; i++) {
				Product product = FindByCode(kode[i]);
				if(product == null) {
					product = new Product(kode[i], nama[i], kategori[i], satuan[i], (uint)modal[i], (uint)jual[i]);
					products.Add(product);
				} else {
					product.Nama = nama[i];
					product.Kategori = kategori[i];
					product.Satuan = satuan[i];
					product.Modal = (uint)modal[i];
					product.Jual = (uint)jual[i];
					nonUpdatedProduct.Remove(product);
				}
			}
			foreach(Product product in nonUpdatedProduct) {
				products.Remove(product);
			}
			OnProductListChange();
		}

		public Product[] GetProducts() {
			return products.ToArray();
		}
	}
}
