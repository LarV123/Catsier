using Catsier.Models;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Text;
using System.Windows.Input;

namespace Catsier.ViewModels {
	class SalesRecapViewModel : ViewModelBase{

		public ObservableCollection<Data> PenjualanHarian { get; set; }

		public ObservableCollection<Data> PenjualanBulanan { get; set; }

		public long PenjualanHariIni {
			get;set;
		}

		public long PenjualanBulanIni {
			get;set;
		}

		public long LabaHariIni {
			get;set;
		}

		public long LabaBulanIni {
			get;set;
		}

		public ICommand BackCommand {
			get {
				return new RelayCommand(x => Mediator.Invoke("Change View To Dashboard", null));
			}
		}

		public void UpdateData(TransactionRepository transactionRepo) {
			DateTime today = DateTime.Now;
			int todayNum = (int)today.DayOfWeek;
			int monthNum = today.Month;

			for (int i = 0; i < PenjualanHarian.Count; i++) {
				if(i <= todayNum) {
					SalesRecapDayCalculation cal = new SalesRecapDayCalculation(transactionRepo, today.AddDays(i-todayNum));
					PenjualanHarian[i].Value = cal.Result;
				} else {
					PenjualanHarian[i].Value = 0;
				}
			}
			OnPropertyChanged("PenjualanHarian");

			for(int i = 0; i < PenjualanBulanan.Count; i++) {
				if (i < monthNum) {
					SalesRecapMonthCalculation cal = new SalesRecapMonthCalculation(transactionRepo, today.AddMonths(i-monthNum+1));
					PenjualanBulanan[i].Value = cal.Result;
				} else {
					PenjualanBulanan[i].Value = 0;
				}
			}
			OnPropertyChanged("PenjualanBulanan");

			PenjualanHariIni = new SalesRecapDayCalculation(transactionRepo, today).Result;
			OnPropertyChanged("PenjualanHariIni");
			PenjualanBulanIni = new SalesRecapMonthCalculation(transactionRepo, today).Result;
			OnPropertyChanged("PenjualanBulanIni");
			LabaHariIni = new ProfitRecapDayCalculation(transactionRepo, today).Result;
			OnPropertyChanged("LabaHariIni");
			LabaBulanIni = new ProfitRecapMonthCalculation(transactionRepo, today).Result;
			OnPropertyChanged("LabaBulanIni");
		}

		public SalesRecapViewModel() {
			PenjualanHarian = new ObservableCollection<Data>();
			PenjualanHarian.Add(new Data("Minggu", 0));
			PenjualanHarian.Add(new Data("Senin", 0));
			PenjualanHarian.Add(new Data("Selasa", 0));
			PenjualanHarian.Add(new Data("Rabu", 0));
			PenjualanHarian.Add(new Data("Kamis", 0));
			PenjualanHarian.Add(new Data("Jumat", 0));
			PenjualanHarian.Add(new Data("Sabtu", 0));

			PenjualanBulanan = new ObservableCollection<Data>();
			PenjualanBulanan.Add(new Data("Jan", 0));
			PenjualanBulanan.Add(new Data("Feb", 0));
			PenjualanBulanan.Add(new Data("Mar", 0));
			PenjualanBulanan.Add(new Data("Apr", 0));
			PenjualanBulanan.Add(new Data("May", 0));
			PenjualanBulanan.Add(new Data("Jun", 0));
			PenjualanBulanan.Add(new Data("Jul", 0));
			PenjualanBulanan.Add(new Data("Aug", 0));
			PenjualanBulanan.Add(new Data("Sep", 0));
			PenjualanBulanan.Add(new Data("Okt", 0));
			PenjualanBulanan.Add(new Data("Nov", 0));
			PenjualanBulanan.Add(new Data("Des", 0));
		}

	}

	class Data {
		public string Key { get; set; }
		public long Value { get; set; }
		public Data(string key, long val) {
			Key = key;
			Value = val;
		}
	}

	class SalesRecapDayCalculation {
		public long Result { get; set; }
		public SalesRecapDayCalculation(TransactionRepository repo, DateTime dateTime) {
			Result = 0;
			Transaction[] transactions = repo.GetTransactions();
			foreach(Transaction transaction in transactions) {
				if(transaction.Tanggal.Date == dateTime.Date) {

					Result += CalculateTotal(transaction);
				}
			}
		}

		private long CalculateTotal(Transaction transaction) {
			long result = 0;
			foreach(TransactionItem item in transaction.items) {
				result += item.Total;
			}
			return result;
		}
	}

	class ProfitRecapDayCalculation {
		public long Result { get; set; }
		public ProfitRecapDayCalculation(TransactionRepository repo, DateTime dateTime) {
			Result = 0;
			Transaction[] transactions = repo.GetTransactions();
			foreach (Transaction transaction in transactions) {
				if (transaction.Tanggal.Date == dateTime.Date) {
					Result += CalculateTotalProfit(transaction);
				}
			}
		}

		private long CalculateTotalProfit(Transaction transaction) {
			long result = 0;
			foreach (TransactionItem item in transaction.items) {
				result += item.TotalProfit;
			}
			return result;
		}
	}

	class SalesRecapMonthCalculation {
		public long Result { get; set; }
		public SalesRecapMonthCalculation(TransactionRepository repo, DateTime dateTime) {
			Result = 0;
			Transaction[] transactions = repo.GetTransactions();
			foreach (Transaction transaction in transactions) {
				if (transaction.Tanggal.Year == dateTime.Year && transaction.Tanggal.Month == dateTime.Month) {
					Result += CalculateTotal(transaction);
				}
			}
		}

		private long CalculateTotal(Transaction transaction) {
			long result = 0;
			foreach (TransactionItem item in transaction.items) {
				result += item.Total;
			}
			return result;
		}
	}

	class ProfitRecapMonthCalculation {
		public long Result { get; set; }
		public ProfitRecapMonthCalculation(TransactionRepository repo, DateTime dateTime) {
			Result = 0;
			Transaction[] transactions = repo.GetTransactions();
			foreach (Transaction transaction in transactions) {
				if (transaction.Tanggal.Year == dateTime.Year && transaction.Tanggal.Month == dateTime.Month) {
					Result += CalculateTotalProfit(transaction);
				}
			}
		}

		private long CalculateTotalProfit(Transaction transaction) {
			long result = 0;
			foreach (TransactionItem item in transaction.items) {
				result += item.TotalProfit;
			}
			return result;
		}
	}
}
