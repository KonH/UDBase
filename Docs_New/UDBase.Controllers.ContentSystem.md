## `AssetBundleContentController`

Content loader, which used asset bundles as content source
```csharp
public class UDBase.Controllers.ContentSystem.AssetBundleContentController
    : ILogContext, IContent

```

Methods

| Type | Name | Summary | 
| --- | --- | --- | 
| `Boolean` | CanLoad(`ContentId` id) |  | 
| `void` | LoadAsync(`ContentId` id, `Action<T>` callback) |  | 


## `AssetBundleHelper`

Helper utility for AssetBundleContentController
```csharp
public class UDBase.Controllers.ContentSystem.AssetBundleHelper
    : MonoBehaviour, ILogContext

```

Properties

| Type | Name | Summary | 
| --- | --- | --- | 
| `Boolean` | Ready |  | 


Methods

| Type | Name | Summary | 
| --- | --- | --- | 
| `void` | Init(`ILog` log, `AssetBundleManager` manager, `String` streamingAssetsPath, `String` baseUrl) |  | 
| `IEnumerator` | InitializeManager(`AssetBundleManager` manager) |  | 
| `void` | InitializeSourceUrl() |  | 
| `IEnumerator` | LoadAsync(`String` assetBundleName, `String` assetName, `Action<T>` callback) |  | 
| `void` | StartLoadAsync(`String` assetBundleName, `String` assetName, `Action<T>` callback) |  | 
| `String` | ToString() |  | 


## `AssetBundleMode`

Asset bundle mode
```csharp
public enum UDBase.Controllers.ContentSystem.AssetBundleMode
    : Enum, IComparable, IConvertible, IFormattable

```

Enum

| Value | Name | Summary | 
| --- | --- | --- | 
| `0` | StreamingAssets | Load asset bundles from StreamingAssets directory | 
| `1` | WebServer | Load asset bundles from remote server | 


## `AudioClipHolder`

Specialized AudioClip content holder
```csharp
public class UDBase.Controllers.ContentSystem.AudioClipHolder
    : ContentHolder<AudioClip>, ISerializationCallbackReceiver

```

## `Content`

Helper methods for IContent
```csharp
public static class UDBase.Controllers.ContentSystem.Content

```

Static Methods

| Type | Name | Summary | 
| --- | --- | --- | 
| `String` | GetAssetType(`Object` asset) | Convert type of given asset to string | 
| `IContent` | GetLoaderFor(this `List<IContent>` loaders, `ContentId` contentId) | Gets the loader for given ContentId loading type | 
| `String` | GetTypeString(`Type` type) | Convert type instance to string | 


## `ContentConfig`

Set of content for Content Loaders in project
```csharp
public class UDBase.Controllers.ContentSystem.ContentConfig
    : ScriptableObject

```

Fields

| Type | Name | Summary | 
| --- | --- | --- | 
| `List<ContentId>` | Items |  | 


Methods

| Type | Name | Summary | 
| --- | --- | --- | 
| `void` | Add(`ContentId` contentId) |  | 
| `void` | Remove(`ContentId` contentId) |  | 


## `ContentConfigCache`

Content setup cache
```csharp
public class UDBase.Controllers.ContentSystem.ContentConfigCache
    : ScriptableObject

```

Fields

| Type | Name | Summary | 
| --- | --- | --- | 
| `List<ContentDescription>` | Items |  | 


Methods

| Type | Name | Summary | 
| --- | --- | --- | 
| `ContentDescription` | Add(`ContentId` contentId, `Object` asset = null) |  | 
| `ContentDescription` | GetOrCreate(`ContentId` contentId) |  | 
| `void` | Remove(`ContentId` contentId) |  | 


## `ContentDescription`

Content setup cache item
```csharp
public class UDBase.Controllers.ContentSystem.ContentDescription

```

Fields

| Type | Name | Summary | 
| --- | --- | --- | 
| `Object` | Asset |  | 
| `ContentId` | Id |  | 


## `ContentHolder<T>`

ContentId holder with type validation on changes.  It preventing from select incorrect item in inspector.
```csharp
public class UDBase.Controllers.ContentSystem.ContentHolder<T>
    : ISerializationCallbackReceiver

```

Fields

| Type | Name | Summary | 
| --- | --- | --- | 
| `ContentId` | Id |  | 


Methods

| Type | Name | Summary | 
| --- | --- | --- | 
| `Boolean` | IsValidId() |  | 
| `void` | OnAfterDeserialize() |  | 
| `void` | OnBeforeSerialize() |  | 


## `ContentId`

Content asset, which used is ContentConfig
```csharp
public class UDBase.Controllers.ContentSystem.ContentId
    : ScriptableObject

```

Fields

| Type | Name | Summary | 
| --- | --- | --- | 
| `Object` | Asset |  | 
| `String` | AssetName |  | 
| `String` | BundleName |  | 
| `ContentLoadType` | LoadType |  | 
| `String` | Type |  | 


Methods

| Type | Name | Summary | 
| --- | --- | --- | 
| `String` | ToString() |  | 


## `ContentLoader`

Simple content loader
```csharp
public class UDBase.Controllers.ContentSystem.ContentLoader
    : MonoBehaviour

```

Fields

| Type | Name | Summary | 
| --- | --- | --- | 
| `ContentId` | Id | ContentId to load | 
| `Boolean` | InstantiateOnStart | Need to load content on start? | 


Methods

| Type | Name | Summary | 
| --- | --- | --- | 
| `void` | Init(`List<IContent>` loaders) |  | 


## `ContentLoadType`

Content load type
```csharp
public enum UDBase.Controllers.ContentSystem.ContentLoadType
    : Enum, IComparable, IConvertible, IFormattable

```

Enum

| Value | Name | Summary | 
| --- | --- | --- | 
| `0` | None | Invalid loading type | 
| `1` | Direct | Load directly from project assets | 
| `2` | AssetBundle | Load from asset bundle | 


## `DirectContentController`

Content loader, which used project assets as source
```csharp
public class UDBase.Controllers.ContentSystem.DirectContentController
    : IContent

```

Methods

| Type | Name | Summary | 
| --- | --- | --- | 
| `Boolean` | CanLoad(`ContentId` id) |  | 
| `void` | LoadAsync(`ContentId` id, `Action<T>` callback) |  | 


## `GameObjectHolder`

Specialized GameObject content holder
```csharp
public class UDBase.Controllers.ContentSystem.GameObjectHolder
    : ContentHolder<GameObject>, ISerializationCallbackReceiver

```

## `IContent`

IContent is a set of methods which allows you to load content independend from its location and simply change it.  In Unity you can store your assets in Assets folder, assign it in Inspector fields and directly instantiate it when you want to.  But in this case all assets which you linked in inspector will be included in build and affect it size.    Unity provides useful feature to avoid it - AssetBundles.  When you build your assets in AssetBundles, you can load it from remote server and decrease build size.  But standard practices of AssetBundle usage contain some limitations -  you need to know asset bundle name and asset name to load it in string format.    So, if you rename your assets or change asset bundle for it and re-build AssetBundles,  you need to carefully track this changes.Also, you can't change way to load assets fast  (for example, made two builds with direct load assets and AssetBundles).  Of course, you can use StreamingAssets for bundles or some hacks for Resources folder,  but it is not convenient and second way is not recommended by Unity itself.    IContent provides you simple editor interface to assign assets and change its loading type on the fly.  After assigning your assets you can use links to it for loading it asynchronously.  It has some overhead if you load it directly from Assets folder, but allows you not to worry about how your assets were loaded.  Also, if you change asset name or bundle only you need to do - re-open config in which asset is assigned and changes applied automatically.    To work with it, you need to create ContentConfig using 'UDBase/Content/Add New Config' menu item,  assign your assets and set their loading type.  If you want to use AssetBundles, you need to assign asset bundle name for your assets in inspector.  You can use any UnityEngine.Object using IContent - GameObjects, AudioClips and so on.    Config contains a set of ContentId sub-assets, which can be assigned in Inspector.  You can have multiple Configs, as much as you want.  Also, you can change load type for all your configs using 'UDBase/Content/Set type for all' menu item.    IContent use pair of ContentConfig and ContentConfigCache.  ContentConfig contains runtime data, required to load your assets,  ContentConfigCache contains persistent links to assets.  Config and cache are not linked, so if you change load type to AssetBundle,  Config removes link to asset and it won't be included in build.    You can use additional load method - AssetBundleMode.StreamingAssets,  in it you need to place your bundles in StreamingAssets folder without platform folder.  For Asset Bundle support is used Unity's open source extension  https://bitbucket.org/Unity-Technologies/assetbundledemo with custom modifications https://bitbucket.org/KonH/assetbundledemo).
```csharp
public interface UDBase.Controllers.ContentSystem.IContent

```

Methods

| Type | Name | Summary | 
| --- | --- | --- | 
| `Boolean` | CanLoad(`ContentId` contentId) | Can given contentId be loaded using this instance of content loader? | 
| `void` | LoadAsync(`ContentId` id, `Action<T>` callback) |  | 


