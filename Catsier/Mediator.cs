using System;
using System.Collections.Generic;
using System.Text;

namespace Catsier {
	public delegate void MediatorFunc(object param);
	class Mediator {
		private static Dictionary<string, List<MediatorFunc>> actionsDictionary = new Dictionary<string, List<MediatorFunc>>();
		public static void Subscribe(string name, MediatorFunc action) {
			if (actionsDictionary.ContainsKey(name)) {
				actionsDictionary[name].Add(action);
			} else {
				List<MediatorFunc> listOfActions = new List<MediatorFunc>();
				listOfActions.Add(action);
				actionsDictionary.Add(name, listOfActions);
			}
		}
		public static void Unsubscribe(string name, MediatorFunc action) {
			if (actionsDictionary.ContainsKey(name)) {
				actionsDictionary[name].Remove(action);
			}
		}
		public static void Invoke(string name, object param) {
			if (actionsDictionary.ContainsKey(name)) {
				List<MediatorFunc> funcs = actionsDictionary[name];
				foreach(MediatorFunc func in funcs) {
					func(param);
				}
			}
		}

		public static void Invoke(string name) {
			Invoke(name, null);
		}
	}
}
