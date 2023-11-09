namespace SpencerMansionIncident.DefaultGamePrefs;

public static class Prefs
{
	public static readonly GameMode.ModeGamePref[] Defaults =
		new GameMode.ModeGamePref[] {
			new(EnumGamePrefs.GameName              , GamePrefs.EnumType.String, "SpencerMansionIncident1"),
			new(EnumGamePrefs.GameNameClient        , GamePrefs.EnumType.String, "SpencerMansionIncident1"),
			new(EnumGamePrefs.GameWorld             , GamePrefs.EnumType.String, "Spencer Mansion Incident"),
			new(EnumGamePrefs.ServerMaxPlayerCount  , GamePrefs.EnumType.Int   , 1),
			new(EnumGamePrefs.ServerVisibility      , GamePrefs.EnumType.Int   , 0),
			new(EnumGamePrefs.ZombieMoveNight       , GamePrefs.EnumType.Int   , 0),
			new(EnumGamePrefs.GameDifficulty        , GamePrefs.EnumType.Int   , 0),
			new(EnumGamePrefs.ServerPort            , GamePrefs.EnumType.Int   , 26900)
	};

	public static readonly GameMode.ModeGamePref[] Overrides =
		new GameMode.ModeGamePref[] {
			new(EnumGamePrefs.AirDropFrequency,         GamePrefs.EnumType.Int,    0),
			new(EnumGamePrefs.AirDropMarker,            GamePrefs.EnumType.Bool,   false),
			new(EnumGamePrefs.AllowSpawnNearBackpack,   GamePrefs.EnumType.Bool,   true),
			new(EnumGamePrefs.AutopilotMode,            GamePrefs.EnumType.Int,    0),
			new(EnumGamePrefs.BedrollDeadZoneSize,      GamePrefs.EnumType.Int,    15),
			new(EnumGamePrefs.BedrollExpiryTime,        GamePrefs.EnumType.Int,    45),
			new(EnumGamePrefs.BlockDamageAI,            GamePrefs.EnumType.Int,    100),
			new(EnumGamePrefs.BlockDamageAIBM,          GamePrefs.EnumType.Int,    100),
			new(EnumGamePrefs.BlockDamagePlayer,        GamePrefs.EnumType.Int,    100),
			new(EnumGamePrefs.BloodMoonEnemyCount,      GamePrefs.EnumType.Int,    8),
			new(EnumGamePrefs.BloodMoonFrequency,       GamePrefs.EnumType.Int,    0),
			new(EnumGamePrefs.BloodMoonRange,           GamePrefs.EnumType.Int,    0),
			new(EnumGamePrefs.BloodMoonWarning,         GamePrefs.EnumType.Int,    8),
			new(EnumGamePrefs.BuildCreate,              GamePrefs.EnumType.Bool,   false),
			new(EnumGamePrefs.CreativeMenuEnabled,      GamePrefs.EnumType.Bool,   false),
			new(EnumGamePrefs.DayCount,                 GamePrefs.EnumType.Int,    3),
			new(EnumGamePrefs.DayLightLength,           GamePrefs.EnumType.Int,    0),
			new(EnumGamePrefs.DayNightLength,           GamePrefs.EnumType.Int,    120),
			new(EnumGamePrefs.DeathPenalty,             GamePrefs.EnumType.Int,    2),
			new(EnumGamePrefs.DebugMenuEnabled,         GamePrefs.EnumType.Bool,   false),
			new(EnumGamePrefs.DebugMenuShowTasks,       GamePrefs.EnumType.Bool,   false),
			new(EnumGamePrefs.DebugStopEnemiesMoving,   GamePrefs.EnumType.Bool,   false),
			new(EnumGamePrefs.DropOnDeath,              GamePrefs.EnumType.Int,    1),
			new(EnumGamePrefs.DropOnQuit,               GamePrefs.EnumType.Int,    0),
			new(EnumGamePrefs.EACEnabled,               GamePrefs.EnumType.Bool,   false),
			new(EnumGamePrefs.EnableMapRendering,       GamePrefs.EnumType.Bool,   false),
			new(EnumGamePrefs.EnemyDifficulty,          GamePrefs.EnumType.Int,    0),
			new(EnumGamePrefs.EnemySpawnMode,           GamePrefs.EnumType.Bool,   true),
			new(EnumGamePrefs.GameMode,                 GamePrefs.EnumType.String, "GameModeSurvival"),
			new(EnumGamePrefs.GameWorld,                GamePrefs.EnumType.String, "Spencer Mansion Incident"),
			new(EnumGamePrefs.ZombieMove,               GamePrefs.EnumType.Int,    2),
			new(EnumGamePrefs.PersistentPlayerProfiles, GamePrefs.EnumType.Bool,   false),
			new(EnumGamePrefs.ZombieBMMove,             GamePrefs.EnumType.Int,    3),
			new(EnumGamePrefs.ZombieFeralMove,          GamePrefs.EnumType.Int,    3),
			new(EnumGamePrefs.ZombieFeralSense,         GamePrefs.EnumType.Int,    0),
			new(EnumGamePrefs.ZombieMove,               GamePrefs.EnumType.Int,    3),
			new(EnumGamePrefs.ServerMaxPlayerCount,     GamePrefs.EnumType.Int,    1),
			new(EnumGamePrefs.ServerVisibility,         GamePrefs.EnumType.Int,    0)
		};
}