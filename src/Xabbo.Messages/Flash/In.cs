// Generated for the Flash client version WIN63-202408051224-787955622 from the Sulek API (https://sulek.dev/).

using System.Runtime.CompilerServices;

namespace Xabbo.Messages.Flash;

/// <summary>
/// Generated for the Flash client version WIN63-202408051224-787955622 from the <a href="https://sulek.dev/">Sulek API</a>.
/// </summary>
public static class In {
    private static Identifier _([CallerMemberName]string? name = null)
    {
        ArgumentNullException.ThrowIfNull(name, nameof(name));
        return new Identifier(ClientType.Flash, Direction.In, name);
    }
    public static readonly Identifier AcceptFriendResult = _();
    public static readonly Identifier AccountPreferences = _();
    public static readonly Identifier AccountSafetyLockStatusChange = _();
    public static readonly Identifier Achievement = _();
    public static readonly Identifier AchievementResolutionCompleted = _();
    public static readonly Identifier AchievementResolutionProgress = _();
    public static readonly Identifier AchievementResolutions = _();
    public static readonly Identifier Achievements = _();
    public static readonly Identifier AchievementsScore = _();
    public static readonly Identifier ActivityPoints = _();
    public static readonly Identifier ApproveName = _();
    public static readonly Identifier AreaHide = _();
    public static readonly Identifier AuthenticationOK = _();
    public static readonly Identifier AvailabilityStatus = _();
    public static readonly Identifier AvatarEffect = _();
    public static readonly Identifier AvatarEffectActivated = _();
    public static readonly Identifier AvatarEffectAdded = _();
    public static readonly Identifier AvatarEffectExpired = _();
    public static readonly Identifier AvatarEffectSelected = _();
    public static readonly Identifier AvatarEffects = _();
    public static readonly Identifier BadgePointLimits = _();
    public static readonly Identifier BadgeReceived = _();
    public static readonly Identifier Badges = _();
    public static readonly Identifier BannedUsersFromRoom = _();
    public static readonly Identifier BonusRareInfo = _();
    public static readonly Identifier BotAddedToInventory = _();
    public static readonly Identifier BotCommandConfiguration = _();
    public static readonly Identifier BotError = _();
    public static readonly Identifier BotForceOpenContextMenu = _();
    public static readonly Identifier BotInventory = _();
    public static readonly Identifier BotRemovedFromInventory = _();
    public static readonly Identifier BotSkillListUpdate = _();
    public static readonly Identifier BuildersClubFurniCount = _();
    public static readonly Identifier BuildersClubPlacementWarning = _();
    public static readonly Identifier BuildersClubSubscriptionStatus = _();
    public static readonly Identifier BundleDiscountRuleset = _();
    public static readonly Identifier CallForHelpDisabledNotify = _();
    public static readonly Identifier CallForHelpPendingCalls = _();
    public static readonly Identifier CallForHelpPendingCallsDeleted = _();
    public static readonly Identifier CallForHelpReply = _();
    public static readonly Identifier CallForHelpResult = _();
    public static readonly Identifier CameraPublishStatus = _();
    public static readonly Identifier CameraPurchaseOK = _();
    public static readonly Identifier CameraStorageUrl = _();
    public static readonly Identifier CampaignCalendarData = _();
    public static readonly Identifier CampaignCalendarDoorOpened = _();
    public static readonly Identifier CanCreateRoom = _();
    public static readonly Identifier CanCreateRoomEvent = _();
    public static readonly Identifier CancelMysteryBoxWait = _();
    public static readonly Identifier CantConnect = _();
    public static readonly Identifier CarryObject = _();
    public static readonly Identifier CatalogIndex = _();
    public static readonly Identifier CatalogPage = _();
    public static readonly Identifier CatalogPageWithEarliestExpiry = _();
    public static readonly Identifier CatalogPublished = _();
    public static readonly Identifier CategoriesWithVisitorCount = _();
    public static readonly Identifier CfhChatlog = _();
    public static readonly Identifier CfhSanction = _();
    public static readonly Identifier CfhTopicsInit = _();
    public static readonly Identifier ChangeEmailResult = _();
    public static readonly Identifier ChangeUserNameResult = _();
    public static readonly Identifier Chat = _();
    public static readonly Identifier ChatReviewSessionDetached = _();
    public static readonly Identifier ChatReviewSessionOfferedToGuide = _();
    public static readonly Identifier ChatReviewSessionResults = _();
    public static readonly Identifier ChatReviewSessionStarted = _();
    public static readonly Identifier ChatReviewSessionVotingStatus = _();
    public static readonly Identifier CheckUserNameResult = _();
    public static readonly Identifier CitizenshipVipOfferPromoEnabled = _();
    public static readonly Identifier CloseConnection = _();
    public static readonly Identifier ClubGiftInfo = _();
    public static readonly Identifier ClubGiftNotification = _();
    public static readonly Identifier ClubGiftSelected = _();
    public static readonly Identifier CollectableMintableItemTypes = _();
    public static readonly Identifier CollectibleMintTokenCount = _();
    public static readonly Identifier CollectibleMintTokenOffers = _();
    public static readonly Identifier CollectibleMintableItemResult = _();
    public static readonly Identifier CollectibleMintingEnabled = _();
    public static readonly Identifier CollectibleWalletAddresses = _();
    public static readonly Identifier CommunityGoalHallOfFame = _();
    public static readonly Identifier CommunityGoalProgress = _();
    public static readonly Identifier CommunityVoteReceived = _();
    public static readonly Identifier CompetitionEntrySubmitResult = _();
    public static readonly Identifier CompetitionRoomsData = _();
    public static readonly Identifier CompetitionStatus = _();
    public static readonly Identifier CompetitionVotingInfo = _();
    public static readonly Identifier CompleteDiffieHandshake = _();
    public static readonly Identifier ConcurrentUsersGoalProgress = _();
    public static readonly Identifier ConfirmBreedingRequest = _();
    public static readonly Identifier ConfirmBreedingResult = _();
    public static readonly Identifier ConsoleMessageHistory = _();
    public static readonly Identifier ConvertedRoomId = _();
    public static readonly Identifier CraftableProducts = _();
    public static readonly Identifier CraftingRecipe = _();
    public static readonly Identifier CraftingRecipesAvailable = _();
    public static readonly Identifier CraftingResult = _();
    public static readonly Identifier CreditBalance = _();
    public static readonly Identifier CreditVaultStatus = _();
    public static readonly Identifier CurrentTimingCode = _();
    public static readonly Identifier CustomStackingHeightUpdate = _();
    public static readonly Identifier CustomUserNotification = _();
    public static readonly Identifier Dance = _();
    public static readonly Identifier DiceValue = _();
    public static readonly Identifier DisconnectReason = _();
    public static readonly Identifier Doorbell = _();
    public static readonly Identifier ElementPointer = _();
    public static readonly Identifier EmailStatusResult = _();
    public static readonly Identifier EmeraldBalance = _();
    public static readonly Identifier EpicPopup = _();
    public static readonly Identifier ErrorReport = _();
    public static readonly Identifier Expression = _();
    public static readonly Identifier ExtendedProfile = _();
    public static readonly Identifier ExtendedProfileChanged = _();
    public static readonly Identifier FavoriteMembershipUpdate = _();
    public static readonly Identifier FavouriteChanged = _();
    public static readonly Identifier Favourites = _();
    public static readonly Identifier FigureSetIds = _();
    public static readonly Identifier FigureUpdate = _();
    public static readonly Identifier FindFriendsProcessResult = _();
    public static readonly Identifier FlatAccessDenied = _();
    public static readonly Identifier FlatAccessible = _();
    public static readonly Identifier FlatControllerAdded = _();
    public static readonly Identifier FlatControllerRemoved = _();
    public static readonly Identifier FlatControllers = _();
    public static readonly Identifier FlatCreated = _();
    public static readonly Identifier FloodControl = _();
    public static readonly Identifier FloorHeightMap = _();
    public static readonly Identifier FollowFriendFailed = _();
    public static readonly Identifier ForumData = _();
    public static readonly Identifier ForumThreads = _();
    public static readonly Identifier ForumsList = _();
    public static readonly Identifier FriendFurniCancelLock = _();
    public static readonly Identifier FriendFurniOtherLockConfirmed = _();
    public static readonly Identifier FriendFurniStartConfirmation = _();
    public static readonly Identifier FriendListFragment = _();
    public static readonly Identifier FriendListUpdate = _();
    public static readonly Identifier FriendNotification = _();
    public static readonly Identifier FriendRequests = _();
    public static readonly Identifier FurniList = _();
    public static readonly Identifier FurniListAddOrUpdate = _();
    public static readonly Identifier FurniListInvalidate = _();
    public static readonly Identifier FurniListRemove = _();
    public static readonly Identifier FurniRentOrBuyoutOffer = _();
    public static readonly Identifier FurnitureAliases = _();
    public static readonly Identifier Game2AccountGameStatus = _();
    public static readonly Identifier Game2ArenaEntered = _();
    public static readonly Identifier Game2EnterArena = _();
    public static readonly Identifier Game2EnterArenaFailed = _();
    public static readonly Identifier Game2FriendsLeaderboard = _();
    public static readonly Identifier Game2FullGameStatus = _();
    public static readonly Identifier Game2GameCancelled = _();
    public static readonly Identifier Game2GameChatFromPlayer = _();
    public static readonly Identifier Game2GameCreated = _();
    public static readonly Identifier Game2GameDirectoryStatus = _();
    public static readonly Identifier Game2GameEnding = _();
    public static readonly Identifier Game2GameLongData = _();
    public static readonly Identifier Game2GameRejoin = _();
    public static readonly Identifier Game2GameStarted = _();
    public static readonly Identifier Game2GameStatus = _();
    public static readonly Identifier Game2InArenaQueue = _();
    public static readonly Identifier Game2JoiningGameFailed = _();
    public static readonly Identifier Game2PlayerExitedGameArena = _();
    public static readonly Identifier Game2PlayerRematches = _();
    public static readonly Identifier Game2StageEnding = _();
    public static readonly Identifier Game2StageLoad = _();
    public static readonly Identifier Game2StageRunning = _();
    public static readonly Identifier Game2StageStarting = _();
    public static readonly Identifier Game2StageStillLoading = _();
    public static readonly Identifier Game2StartCounter = _();
    public static readonly Identifier Game2StartingGameFailed = _();
    public static readonly Identifier Game2StopCounter = _();
    public static readonly Identifier Game2TotalGroupLeaderboard = _();
    public static readonly Identifier Game2TotalLeaderboard = _();
    public static readonly Identifier Game2UserBlocked = _();
    public static readonly Identifier Game2UserJoinedGame = _();
    public static readonly Identifier Game2UserLeftGame = _();
    public static readonly Identifier Game2WeeklyFriendsLeaderboard = _();
    public static readonly Identifier Game2WeeklyGroupLeaderboard = _();
    public static readonly Identifier Game2WeeklyLeaderboard = _();
    public static readonly Identifier GamePlayerValue = _();
    public static readonly Identifier GenericError = _();
    public static readonly Identifier GetGuestRoomResult = _();
    public static readonly Identifier GiftReceiverNotFound = _();
    public static readonly Identifier GiftWrappingConfiguration = _();
    public static readonly Identifier GoToBreedingNestFailure = _();
    public static readonly Identifier GotMysteryBoxPrize = _();
    public static readonly Identifier GroupDetailsChanged = _();
    public static readonly Identifier GroupMembershipRequested = _();
    public static readonly Identifier GuestRoomSearchResult = _();
    public static readonly Identifier GuideOnDutyStatus = _();
    public static readonly Identifier GuideReportingStatus = _();
    public static readonly Identifier GuideSessionAttached = _();
    public static readonly Identifier GuideSessionDetached = _();
    public static readonly Identifier GuideSessionEnded = _();
    public static readonly Identifier GuideSessionError = _();
    public static readonly Identifier GuideSessionInvitedToGuideRoom = _();
    public static readonly Identifier GuideSessionMessage = _();
    public static readonly Identifier GuideSessionPartnerIsTyping = _();
    public static readonly Identifier GuideSessionRequesterRoom = _();
    public static readonly Identifier GuideSessionStarted = _();
    public static readonly Identifier GuideTicketCreationResult = _();
    public static readonly Identifier GuideTicketResolution = _();
    public static readonly Identifier GuildCreated = _();
    public static readonly Identifier GuildCreationInfo = _();
    public static readonly Identifier GuildEditFailed = _();
    public static readonly Identifier GuildEditInfo = _();
    public static readonly Identifier GuildEditorData = _();
    public static readonly Identifier GuildFurniContextMenuInfo = _();
    public static readonly Identifier GuildMemberFurniCountInHQ = _();
    public static readonly Identifier GuildMemberMgmtFailed = _();
    public static readonly Identifier GuildMembers = _();
    public static readonly Identifier GuildMembershipRejected = _();
    public static readonly Identifier GuildMembershipUpdated = _();
    public static readonly Identifier GuildMemberships = _();
    public static readonly Identifier HabboAchievementNotification = _();
    public static readonly Identifier HabboActivityPointNotification = _();
    public static readonly Identifier HabboBroadcast = _();
    public static readonly Identifier HabboClubExtendOffer = _();
    public static readonly Identifier HabboClubOffers = _();
    public static readonly Identifier HabboGroupBadges = _();
    public static readonly Identifier HabboGroupDeactivated = _();
    public static readonly Identifier HabboGroupDetails = _();
    public static readonly Identifier HabboGroupJoinFailed = _();
    public static readonly Identifier HabboSearchResult = _();
    public static readonly Identifier HabboUserBadges = _();
    public static readonly Identifier HandItemReceived = _();
    public static readonly Identifier HanditemConfiguration = _();
    public static readonly Identifier HeightMap = _();
    public static readonly Identifier HeightMapUpdate = _();
    public static readonly Identifier HotLooks = _();
    public static readonly Identifier IdentityAccounts = _();
    public static readonly Identifier IgnoreResult = _();
    public static readonly Identifier IgnoredUsers = _();
    public static readonly Identifier InClientLink = _();
    public static readonly Identifier IncomeRewardClaimResponse = _();
    public static readonly Identifier IncomeRewardStatus = _();
    public static readonly Identifier InfoFeedEnable = _();
    public static readonly Identifier InfoHotelClosed = _();
    public static readonly Identifier InfoHotelClosing = _();
    public static readonly Identifier InitCamera = _();
    public static readonly Identifier InitDiffieHandshake = _();
    public static readonly Identifier InstantMessageError = _();
    public static readonly Identifier Interstitial = _();
    public static readonly Identifier IsBadgeRequestFulfilled = _();
    public static readonly Identifier IsFirstLoginOfDay = _();
    public static readonly Identifier IsUserPartOfCompetition = _();
    public static readonly Identifier IssueCloseNotification = _();
    public static readonly Identifier IssueDeleted = _();
    public static readonly Identifier IssueInfo = _();
    public static readonly Identifier IssuePickFailed = _();
    public static readonly Identifier ItemAdd = _();
    public static readonly Identifier ItemDataUpdate = _();
    public static readonly Identifier ItemRemove = _();
    public static readonly Identifier ItemStateUpdate = _();
    public static readonly Identifier ItemUpdate = _();
    public static readonly Identifier Items = _();
    public static readonly Identifier ItemsStateUpdate = _();
    public static readonly Identifier JukeboxPlayListFull = _();
    public static readonly Identifier JukeboxSongDisks = _();
    public static readonly Identifier LatencyPingResponse = _();
    public static readonly Identifier LimitedEditionSoldOut = _();
    public static readonly Identifier LimitedOfferAppearingNext = _();
    public static readonly Identifier LoginFailedHotelClosed = _();
    public static readonly Identifier MOTDNotification = _();
    public static readonly Identifier MaintenanceStatus = _();
    public static readonly Identifier MarketPlaceOffers = _();
    public static readonly Identifier MarketPlaceOwnOffers = _();
    public static readonly Identifier MarketplaceBuyOfferResult = _();
    public static readonly Identifier MarketplaceCanMakeOfferResult = _();
    public static readonly Identifier MarketplaceCancelOfferResult = _();
    public static readonly Identifier MarketplaceConfiguration = _();
    public static readonly Identifier MarketplaceItemStats = _();
    public static readonly Identifier MarketplaceMakeOfferResult = _();
    public static readonly Identifier MessengerError = _();
    public static readonly Identifier MessengerInit = _();
    public static readonly Identifier MiniMailNew = _();
    public static readonly Identifier MiniMailUnreadCount = _();
    public static readonly Identifier Moderator = _();
    public static readonly Identifier ModeratorActionResult = _();
    public static readonly Identifier ModeratorCaution = _();
    public static readonly Identifier ModeratorInit = _();
    public static readonly Identifier ModeratorRoomInfo = _();
    public static readonly Identifier ModeratorToolPreferences = _();
    public static readonly Identifier ModeratorUserInfo = _();
    public static readonly Identifier MuteAllInRoom = _();
    public static readonly Identifier MysteryBoxKeys = _();
    public static readonly Identifier NavigatorCollapsedCategories = _();
    public static readonly Identifier NavigatorLiftedRooms = _();
    public static readonly Identifier NavigatorMetaData = _();
    public static readonly Identifier NavigatorSavedSearches = _();
    public static readonly Identifier NavigatorSearchResultBlocks = _();
    public static readonly Identifier NavigatorSettings = _();
    public static readonly Identifier NestBreedingSuccess = _();
    public static readonly Identifier NewConsole = _();
    public static readonly Identifier NewFriendRequest = _();
    public static readonly Identifier NewNavigatorPreferences = _();
    public static readonly Identifier NewUserExperienceGiftOffer = _();
    public static readonly Identifier NewUserExperienceNotComplete = _();
    public static readonly Identifier NftBonusItemClaimResult = _();
    public static readonly Identifier NftCollections = _();
    public static readonly Identifier NftCollectionsScore = _();
    public static readonly Identifier NftRewardItemClaimResult = _();
    public static readonly Identifier NftTransferAssetsResult = _();
    public static readonly Identifier NftTransferFee = _();
    public static readonly Identifier NoOwnedRoomsAlert = _();
    public static readonly Identifier NoSuchFlat = _();
    public static readonly Identifier NoobnessLevel = _();
    public static readonly Identifier NotEnoughBalance = _();
    public static readonly Identifier NotificationDialog = _();
    public static readonly Identifier NowPlaying = _();
    public static readonly Identifier ObjectAdd = _();
    public static readonly Identifier ObjectDataUpdate = _();
    public static readonly Identifier ObjectRemove = _();
    public static readonly Identifier ObjectRemoveConfirm = _();
    public static readonly Identifier ObjectRemoveMultiple = _();
    public static readonly Identifier ObjectUpdate = _();
    public static readonly Identifier Objects = _();
    public static readonly Identifier ObjectsDataUpdate = _();
    public static readonly Identifier OfferRewardDelivered = _();
    public static readonly Identifier OfficialRooms = _();
    public static readonly Identifier OfficialSongId = _();
    public static readonly Identifier OneWayDoorStatus = _();
    public static readonly Identifier Open = _();
    public static readonly Identifier OpenConnection = _();
    public static readonly Identifier OpenPetPackageRequested = _();
    public static readonly Identifier OpenPetPackageResult = _();
    public static readonly Identifier PerkAllowances = _();
    public static readonly Identifier PetAddedToInventory = _();
    public static readonly Identifier PetBreeding = _();
    public static readonly Identifier PetBreedingResult = _();
    public static readonly Identifier PetCommands = _();
    public static readonly Identifier PetExperience = _();
    public static readonly Identifier PetFigureUpdate = _();
    public static readonly Identifier PetInfo = _();
    public static readonly Identifier PetInventory = _();
    public static readonly Identifier PetLevelNotification = _();
    public static readonly Identifier PetLevelUpdate = _();
    public static readonly Identifier PetPlacingError = _();
    public static readonly Identifier PetReceived = _();
    public static readonly Identifier PetRemovedFromInventory = _();
    public static readonly Identifier PetRespectFailed = _();
    public static readonly Identifier PetRespectNotification = _();
    public static readonly Identifier PetStatusUpdate = _();
    public static readonly Identifier PetSupplementedNotification = _();
    public static readonly Identifier PhoneCollectionState = _();
    public static readonly Identifier Ping = _();
    public static readonly Identifier PlayList = _();
    public static readonly Identifier PlayListSongAdded = _();
    public static readonly Identifier PollContents = _();
    public static readonly Identifier PollError = _();
    public static readonly Identifier PollOffer = _();
    public static readonly Identifier PopularRoomTagsResult = _();
    public static readonly Identifier PostItPlaced = _();
    public static readonly Identifier PostMessage = _();
    public static readonly Identifier PostThread = _();
    public static readonly Identifier PresentOpened = _();
    public static readonly Identifier ProductOffer = _();
    public static readonly Identifier PromoArticles = _();
    public static readonly Identifier PurchaseError = _();
    public static readonly Identifier PurchaseNotAllowed = _();
    public static readonly Identifier PurchaseOK = _();
    public static readonly Identifier Quest = _();
    public static readonly Identifier QuestCancelled = _();
    public static readonly Identifier QuestCompleted = _();
    public static readonly Identifier QuestDaily = _();
    public static readonly Identifier Question = _();
    public static readonly Identifier QuestionAnswered = _();
    public static readonly Identifier QuestionFinished = _();
    public static readonly Identifier Quests = _();
    public static readonly Identifier QuizData = _();
    public static readonly Identifier QuizResults = _();
    public static readonly Identifier RelationshipStatusInfo = _();
    public static readonly Identifier RemainingMutePeriod = _();
    public static readonly Identifier RentableSpaceRentFailed = _();
    public static readonly Identifier RentableSpaceRentOk = _();
    public static readonly Identifier RentableSpaceStatus = _();
    public static readonly Identifier RequestSpamWallPostIt = _();
    public static readonly Identifier RespectNotification = _();
    public static readonly Identifier RestoreClient = _();
    public static readonly Identifier RoomAdError = _();
    public static readonly Identifier RoomAdPurchaseInfo = _();
    public static readonly Identifier RoomChatSettings = _();
    public static readonly Identifier RoomChatlog = _();
    public static readonly Identifier RoomDimmerPresets = _();
    public static readonly Identifier RoomEntryInfo = _();
    public static readonly Identifier RoomEntryTile = _();
    public static readonly Identifier RoomEvent = _();
    public static readonly Identifier RoomEventCancel = _();
    public static readonly Identifier RoomFilterSettings = _();
    public static readonly Identifier RoomForward = _();
    public static readonly Identifier RoomInfoUpdated = _();
    public static readonly Identifier RoomInvite = _();
    public static readonly Identifier RoomInviteError = _();
    public static readonly Identifier RoomMessageNotification = _();
    public static readonly Identifier RoomOccupiedTiles = _();
    public static readonly Identifier RoomProperty = _();
    public static readonly Identifier RoomQueueStatus = _();
    public static readonly Identifier RoomRating = _();
    public static readonly Identifier RoomReady = _();
    public static readonly Identifier RoomSettingsData = _();
    public static readonly Identifier RoomSettingsError = _();
    public static readonly Identifier RoomSettingsSaveError = _();
    public static readonly Identifier RoomSettingsSaved = _();
    public static readonly Identifier RoomVisits = _();
    public static readonly Identifier RoomVisualizationSettings = _();
    public static readonly Identifier SanctionStatus = _();
    public static readonly Identifier ScrSendKickbackInfo = _();
    public static readonly Identifier ScrSendUserInfo = _();
    public static readonly Identifier SeasonalCalendarDailyOffer = _();
    public static readonly Identifier SeasonalQuests = _();
    public static readonly Identifier SecondsUntil = _();
    public static readonly Identifier SelectInitialRoom = _();
    public static readonly Identifier SellablePetPalettes = _();
    public static readonly Identifier Shout = _();
    public static readonly Identifier ShowEnforceRoomCategoryDialog = _();
    public static readonly Identifier ShowMysteryBoxWait = _();
    public static readonly Identifier SilverBalance = _();
    public static readonly Identifier Sleep = _();
    public static readonly Identifier SlideObjectBundle = _();
    public static readonly Identifier SnowWarGameTokens = _();
    public static readonly Identifier SpecialRoomEffect = _();
    public static readonly Identifier TalentLevelUp = _();
    public static readonly Identifier TalentTrack = _();
    public static readonly Identifier TalentTrackLevel = _();
    public static readonly Identifier TargetedOffer = _();
    public static readonly Identifier TargetedOfferNotFound = _();
    public static readonly Identifier ThreadMessages = _();
    public static readonly Identifier ThumbnailStatus = _();
    public static readonly Identifier TradeOpenFailed = _();
    public static readonly Identifier TradeSilverFee = _();
    public static readonly Identifier TradeSilverSet = _();
    public static readonly Identifier TradingAccept = _();
    public static readonly Identifier TradingClose = _();
    public static readonly Identifier TradingCompleted = _();
    public static readonly Identifier TradingConfirmation = _();
    public static readonly Identifier TradingItemList = _();
    public static readonly Identifier TradingNotOpen = _();
    public static readonly Identifier TradingOpen = _();
    public static readonly Identifier TradingOtherNotAllowed = _();
    public static readonly Identifier TradingYouAreNotAllowed = _();
    public static readonly Identifier TraxSongInfo = _();
    public static readonly Identifier TryPhoneNumberResult = _();
    public static readonly Identifier TryVerificationCodeResult = _();
    public static readonly Identifier UniqueMachineID = _();
    public static readonly Identifier UnreadForumsCount = _();
    public static readonly Identifier UnseenItems = _();
    public static readonly Identifier UpdateMessage = _();
    public static readonly Identifier UpdateThread = _();
    public static readonly Identifier UseObject = _();
    public static readonly Identifier UserBanned = _();
    public static readonly Identifier UserChange = _();
    public static readonly Identifier UserChatlog = _();
    public static readonly Identifier UserClassification = _();
    public static readonly Identifier UserEventCats = _();
    public static readonly Identifier UserFlatCats = _();
    public static readonly Identifier UserNameChanged = _();
    public static readonly Identifier UserNftChatStyles = _();
    public static readonly Identifier UserNftWardrobe = _();
    public static readonly Identifier UserNftWardrobeSelection = _();
    public static readonly Identifier UserObject = _();
    public static readonly Identifier UserRemove = _();
    public static readonly Identifier UserRights = _();
    public static readonly Identifier UserSongDisksInventory = _();
    public static readonly Identifier UserTyping = _();
    public static readonly Identifier UserUnbannedFromRoom = _();
    public static readonly Identifier UserUpdate = _();
    public static readonly Identifier Users = _();
    public static readonly Identifier VoucherRedeemError = _();
    public static readonly Identifier VoucherRedeemOk = _();
    public static readonly Identifier Wardrobe = _();
    public static readonly Identifier Whisper = _();
    public static readonly Identifier WiredAllVariableHolders = _();
    public static readonly Identifier WiredAllVariablesDiffs = _();
    public static readonly Identifier WiredAllVariablesHash = _();
    public static readonly Identifier WiredErrorLogs = _();
    public static readonly Identifier WiredFurniAction = _();
    public static readonly Identifier WiredFurniAddon = _();
    public static readonly Identifier WiredFurniCondition = _();
    public static readonly Identifier WiredFurniSelector = _();
    public static readonly Identifier WiredFurniTrigger = _();
    public static readonly Identifier WiredFurniVariable = _();
    public static readonly Identifier WiredMenuError = _();
    public static readonly Identifier WiredMovements = _();
    public static readonly Identifier WiredPermissions = _();
    public static readonly Identifier WiredRewardResult = _();
    public static readonly Identifier WiredRoomSettings = _();
    public static readonly Identifier WiredRoomStats = _();
    public static readonly Identifier WiredSaveSuccess = _();
    public static readonly Identifier WiredValidationError = _();
    public static readonly Identifier WiredVariablesForObject = _();
    public static readonly Identifier YouAreController = _();
    public static readonly Identifier YouAreNotController = _();
    public static readonly Identifier YouAreNotSpectator = _();
    public static readonly Identifier YouAreOwner = _();
    public static readonly Identifier YouArePlayingGame = _();
    public static readonly Identifier YouAreSpectator = _();
    public static readonly Identifier YoutubeControlVideo = _();
    public static readonly Identifier YoutubeDisplayPlaylists = _();
    public static readonly Identifier YoutubeDisplayVideo = _();
}
