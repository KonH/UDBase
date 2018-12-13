using System.ComponentModel;
using UnityEngine;

namespace UDBase.ViewModels {
	public abstract class BaseViewModel<T> : MonoBehaviour, INotifyPropertyChanged where T : INotifyPropertyChanged {
		protected T Model;
		
		public virtual void Init(T model) {
			Model = model;
		}

		protected void OnEnable() {
			Model.PropertyChanged += PropertyChanged;
		}

		protected void OnDisable() {
			Model.PropertyChanged -= PropertyChanged;
		}

		public event PropertyChangedEventHandler PropertyChanged;
	}
}