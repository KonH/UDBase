using UDBase.Utils;
using UDBase.Common;
using UDBase.Controllers.UTime;
using UDBase.Controllers.LogSystem;
using UDBase.Controllers.UserSystem;
using UDBase.Controllers.SaveSystem;
using UDBase.Controllers.EventSystem;
using UDBase.Controllers.SceneSystem;
using UDBase.Controllers.AudioSystem;
using UDBase.Controllers.SoundSystem;
using UDBase.Controllers.MusicSystem;
using UDBase.Controllers.LogSystem.UI;
using UDBase.Controllers.ConfigSystem;
using UDBase.Controllers.ContentSystem;
using UDBase.Controllers.LeaderboardSystem;
using UDBase.Controllers.LocalizationSystem;
using Zenject;

namespace UDBase.Installers {
    public abstract class UDBaseInstaller : MonoInstaller {

		protected BuildType _buildType;

		[Inject]
		public virtual void Init([InjectOptional]BuildType buildType) {
			_buildType = buildType;
		}

		public void AddEmptyLogger() {
			Container.Bind<ILog>().To<EmptyLog>().AsSingle();
		}

		public void AddUnityLogger() {
			Container.Bind<ILog>().To<UnityLog>().AsSingle();
		}

		public void AddVisualLogger(VisualLogHandler.Settings settings) {
			Container.BindInstance(settings);
			Container.Bind<VisualLogHandler>().FromComponentInNewPrefabResource(settings.PrefabName).AsSingle();
			Container.Bind<ILog>().To<VisualLog>().AsSingle();
		}

		public void AddNetUtils() {
			Container.Bind<NetUtils>().ToSelf().AsSingle();
			Container.Bind<WebClient>().ToSelf().AsTransient();
		}

        public void AddEvents() {
            Container.Bind<IEvent>().To<EventController>().AsSingle();
        }

        public void AddDirectSceneLoader() {
            Container.Bind<IScene>().To<DirectSceneLoader>().AsSingle();
        }

        public void AddAsyncSceneLoader(AsyncSceneLoader.Settings settings) {
            Container.Bind<AsyncLoadHelper>().FromNewComponentOnNewGameObject().AsSingle();
            Container.BindInstance(settings);
            Container.Bind<IScene>().To<AsyncSceneLoader>().AsSingle();
        }

        public void AddDirectContentLoader() {
            Container.Bind<IContent>().To<DirectContentController>().AsSingle();
        }

        public void AddBundleContentLoader(AssetBundleContentController.Settings settings) {
            Container.Bind<AssetBundleHelper>().FromNewComponentOnNewGameObject().AsSingle();
            Container.BindInstance(settings);
            Container.Bind<IContent>().To<AssetBundleContentController>().AsSingle();
        }

		public void AddLocalLeaderboard() {
			Container.Bind<ILeaderboard>().To<LocalLeaderboard>().AsSingle();
		}

        public void AddWebLeaderboards(WebLeaderboard.Settings settings) {
            Container.BindInstance(settings);
            Container.Bind<ILeaderboard>().To<WebLeaderboard>().AsSingle();
        }

        public void AddAudio(AudioController.Settings settings) {
            Container.BindInstance(settings);
            Container.Bind<IAudio>().To<AudioController>().AsSingle();
        }

        public void AddSaveAudio(SaveAudioController.Settings settings) {
            Container.BindInstance(settings);
            Container.Bind<IAudio>().To<SaveAudioController>().AsSingle();
        }

        public void AddSound(SoundUtility.Settings settings) {
            Container.BindInstance(settings);
            Container.Bind<SoundUtility>().FromNewComponentOnNewGameObject().AsSingle();
            Container.Bind<ISound>().To<SoundController>().AsSingle().NonLazy();
        }

        public void AddMusic() {
            Container.Bind<IMusic>().To<MusicController>().AsSingle().NonLazy();
        }

        public void AddSaveUser() {
            Container.Bind<IUser>().To<SaveUser>().AsSingle();
        }

        public void AddJsonConfig(Config.JsonSettings settings) {
            Container.BindInstance(settings);
            Container.Bind<IConfig>().To<FsJsonResourcesConfig>().AsSingle();
        }

        public void AddInMemorySave() {
            Container.Bind<ISave>().To<InMemorySave>().AsSingle();
        }

        public void AddJsonSave(Save.JsonSettings settings) {
            Container.BindInstance(settings);
            Container.Bind<ISave>().To<FsJsonDataSave>().AsSingle();
        }

        public void AddLocalTime() {
            Container.Bind<ITime>().To<LocalTime>().AsSingle();
        }

        public void AddNetworkTime(NetworkTime.Settings settings) {
            Container.BindInstance(settings);
            Container.Bind<ITime>().To<NetworkTime>().AsSingle();
        }

		public void AddSingleFileLocalizationParser(SingleLocaleParser.Settings settings) {
			Container.BindInstance(settings);
			Container.Bind<ILocaleParser>().To<SingleLocaleParser>().AsSingle();
			
		}

		public void AddLocalization(Localization.Settings settings) {
			Container.BindInstance(settings);
			Container.Bind<ILocalization>().To<Localization>().AsSingle();
		}

		public void AddSaveLocalization(Localization.Settings settings) {
			Container.BindInstance(settings);
			Container.Bind<ILocalization>().To<SaveLocalization>().AsSingle();
		}
    }
}