using UnityEngine;
using UnityWeld.Binding;

namespace UDBase.ViewModels {
	public abstract class BaseListViewModel<TModel, TViewModel> : MonoBehaviour where TModel : class where TViewModel : class {
		[Binding] public ObservableList<TViewModel> Items { get; set; } = null;

		protected ObservableList<TModel> ModelItems;

		public void Init(ObservableList<TModel> items) {
			ModelItems = items;
			Items = new ObservableList<TViewModel>();
			foreach ( var item in ModelItems ) {
				Items.Add(CreateView(item));
			}
		}

		protected void OnEnable() {
			ModelItems.CollectionChanged += OnCollectionChanged;
		}

		protected void OnDisable() {
			if ( ModelItems != null ) {
				ModelItems.CollectionChanged -= OnCollectionChanged;
			}
		}

		void OnCollectionChanged(object sender, NotifyCollectionChangedEventArgs e) {
			switch ( e.Action ) {
				case NotifyCollectionChangedAction.Add: {
					Items.Insert(e.NewStartingIndex, CreateView(e.NewItems[0] as TModel));
				}
					break;

				case NotifyCollectionChangedAction.Remove: {
					Items.RemoveAt(e.OldStartingIndex);
				}
					break;

				case NotifyCollectionChangedAction.Reset: {
					Items.Clear();
				}
					break;
			}
		}

		protected abstract TViewModel CreateView(TModel model);
	}
}