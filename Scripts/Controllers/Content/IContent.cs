using System;

namespace UDBase.Controllers.ContentSystem {

	/// <summary>
	/// IContent is a set of methods which allows you to load content independend from its location and simply change it.
	/// In Unity you can store your assets in Assets folder, assign it in Inspector fields and directly instantiate it when you want to. 
	/// But in this case all assets which you linked in inspector will be included in build and affect it size.
	/// 
	/// Unity provides useful feature to avoid it - AssetBundles.
	/// When you build your assets in AssetBundles, you can load it from remote server and decrease build size.
	/// But standard practices of AssetBundle usage contain some limitations -
	/// you need to know asset bundle name and asset name to load it in string format.
	/// 
	/// So, if you rename your assets or change asset bundle for it and re-build AssetBundles,
	/// you need to carefully track this changes.Also, you can't change way to load assets fast
	/// (for example, made two builds with direct load assets and AssetBundles).
	/// Of course, you can use StreamingAssets for bundles or some hacks for Resources folder,
	/// but it is not convenient and second way is not recommended by Unity itself. 
	/// 
	/// IContent provides you simple editor interface to assign assets and change its loading type on the fly.
	/// After assigning your assets you can use links to it for loading it asynchronously.
	/// It has some overhead if you load it directly from Assets folder, but allows you not to worry about how your assets were loaded.
	/// Also, if you change asset name or bundle only you need to do - re-open config in which asset is assigned and changes applied automatically.
	/// 
	/// To work with it, you need to create ContentConfig using 'UDBase/Content/Add New Config' menu item,
	/// assign your assets and set their loading type. 
	/// If you want to use AssetBundles, you need to assign asset bundle name for your assets in inspector.
	/// You can use any UnityEngine.Object using IContent - GameObjects, AudioClips and so on.
	/// 
	/// Config contains a set of ContentId sub-assets, which can be assigned in Inspector.
	/// You can have multiple Configs, as much as you want.
	/// Also, you can change load type for all your configs using 'UDBase/Content/Set type for all' menu item.
	/// 
	/// IContent use pair of ContentConfig and ContentConfigCache. 
	/// ContentConfig contains runtime data, required to load your assets,
	/// ContentConfigCache contains persistent links to assets.
	/// Config and cache are not linked, so if you change load type to AssetBundle,
	/// Config removes link to asset and it won't be included in build.
	/// 
	/// You can use additional load method - AssetBundleMode.StreamingAssets,
	/// in it you need to place your bundles in StreamingAssets folder without platform folder.
	/// For Asset Bundle support is used Unity's open source extension 
	/// https://bitbucket.org/Unity-Technologies/assetbundledemo with custom modifications https://bitbucket.org/KonH/assetbundledemo).
	/// </summary>
	public interface IContent {

		/// <summary>
		/// Can given contentId be loaded using this instance of content loader?
		/// </summary>
		bool CanLoad(ContentId contentId);

		/// <summary>
		/// Start loading object referenced by ContentId asynchroniosly, return it in callback
		/// </summary>
		void LoadAsync<T>(ContentId id, Action<T> callback) where T:UnityEngine.Object;
	}
}
