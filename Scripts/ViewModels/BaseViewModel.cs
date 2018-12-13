using System.ComponentModel;
using UnityEngine;

namespace UDBase.ViewModels {
	public abstract class BaseViewModel<T> : MonoBehaviour, INotifyPropertyChanged where T : INotifyPropertyChanged {
		protected T Model;
		
		public virtual void Init(T model) {
			Model = model;
		}

		protected void OnEnable() {
			Model.PropertyChanged += OnPropertyChanged;
		}

		protected void OnDisable() {
			Model.PropertyChanged -= OnPropertyChanged;
		}

		public event PropertyChangedEventHandler PropertyChanged;

		protected void OnPropertyChanged(object sender, PropertyChangedEventArgs args) {
			PropertyChanged?.Invoke(sender, args);
		}
	}
}