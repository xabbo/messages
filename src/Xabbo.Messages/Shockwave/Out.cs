// Generated for the Shockwave client version 42 from the Sulek API (https://sulek.dev/).

using System.Runtime.CompilerServices;

namespace Xabbo.Messages.Shockwave;

/// <summary>
/// Generated for the Shockwave client version 42 from the <a href="https://sulek.dev/">Sulek API</a>.
/// </summary>
public static class Out {
    private static Identifier _([CallerMemberName]string? name = null)
    {
        ArgumentNullException.ThrowIfNull(name, nameof(name));
        return new Identifier(ClientType.Shockwave, Direction.Out, name);
    }

#pragma warning disable CS1591 // Missing XML comment for publicly visible type or member

    public static readonly Identifier AC = _();
    public static readonly Identifier ACTIVATE_AVATAR_EFFECT = _();
    public static readonly Identifier ADDSTRIPITEM = _();
    public static readonly Identifier ADD_FAVORITE_ROOM = _();
    public static readonly Identifier ADD_JUKEBOX_DISC = _();
    public static readonly Identifier APPROVEEMAIL = _();
    public static readonly Identifier APPROVE_PASSWORD = _();
    public static readonly Identifier APPROVE_PET_NAME = _();
    public static readonly Identifier ASSIGNRIGHTS = _();
    public static readonly Identifier BTCKS = _();
    public static readonly Identifier BURN_SONG = _();
    public static readonly Identifier CARRYDRINK = _();
    public static readonly Identifier CARRYITEM = _();
    public static readonly Identifier CHANGESHRT = _();
    public static readonly Identifier CHANGEWORLD = _();
    public static readonly Identifier CHAT = _();
    public static readonly Identifier CLOSE_CALL = _();
    public static readonly Identifier CLOSE_UIMAKOPPI = _();
    public static readonly Identifier COPPA_REG_CHECKTIME = _();
    public static readonly Identifier COPPA_REG_GETREALTIME = _();
    public static readonly Identifier CREATECALLWITHREPORTING = _();
    public static readonly Identifier CRYFORHELP = _();
    public static readonly Identifier DANCE = _();
    public static readonly Identifier DELETEFLAT = _();
    public static readonly Identifier DELETEGAME = _();
    public static readonly Identifier DELETE_PENDING_CALLS_FOR_HELP = _();
    public static readonly Identifier DELETE_SONG = _();
    public static readonly Identifier DEL_FAVORITE_ROOM = _();
    public static readonly Identifier DICE_OFF = _();
    public static readonly Identifier DOORGOIN = _();
    public static readonly Identifier EDIT_SONG = _();
    public static readonly Identifier EJECT_SOUND_PACKAGE = _();
    public static readonly Identifier ENTER_ONEWAY_DOOR = _();
    public static readonly Identifier FLATPROPBYITEM = _();
    public static readonly Identifier FOLLOW_FRIEND = _();
    public static readonly Identifier FRIENDLIST_ACCEPTFRIEND = _();
    public static readonly Identifier FRIENDLIST_DECLINEFRIEND = _();
    public static readonly Identifier FRIENDLIST_FRIENDREQUEST = _();
    public static readonly Identifier FRIENDLIST_GETFRIENDREQUESTS = _();
    public static readonly Identifier FRIENDLIST_GETOFFLINEFRIENDS = _();
    public static readonly Identifier FRIENDLIST_INIT = _();
    public static readonly Identifier FRIENDLIST_REMOVEFRIEND = _();
    public static readonly Identifier FRIENDLIST_UPDATE = _();
    public static readonly Identifier GAMEEVENT = _();
    public static readonly Identifier GAMEPARAMETERVALUES = _();
    public static readonly Identifier GAME_CHAT = _();
    public static readonly Identifier GDATE = _();
    public static readonly Identifier GENERATEKEY = _();
    public static readonly Identifier GETAVAILABLEBADGES = _();
    public static readonly Identifier GETAVAILABLESETS = _();
    public static readonly Identifier GETDOORFLAT = _();
    public static readonly Identifier GETFLATCAT = _();
    public static readonly Identifier GETFLATINFO = _();
    public static readonly Identifier GETFVRF = _();
    public static readonly Identifier GETINSTANCELIST = _();
    public static readonly Identifier GETINTERST = _();
    public static readonly Identifier GETPARENTCHAIN = _();
    public static readonly Identifier GETPETSTAT = _();
    public static readonly Identifier GETROOMAD = _();
    public static readonly Identifier GETSPACENODEUSERS = _();
    public static readonly Identifier GETSTRIP = _();
    public static readonly Identifier GETUSERCREDITLOG = _();
    public static readonly Identifier GETUSERFLATCATS = _();
    public static readonly Identifier GET_ALIAS_LIST = _();
    public static readonly Identifier GET_CATALOG_INDEX = _();
    public static readonly Identifier GET_CATALOG_PAGE = _();
    public static readonly Identifier GET_CFH_CATEGORIES = _();
    public static readonly Identifier GET_CREDITS = _();
    public static readonly Identifier GET_FURNI_REVISIONS = _();
    public static readonly Identifier GET_JUKEBOX_DISCS = _();
    public static readonly Identifier GET_PASSWORD = _();
    public static readonly Identifier GET_PENDING_CALLS_FOR_HELP = _();
    public static readonly Identifier GET_PLAY_LIST = _();
    public static readonly Identifier GET_RECYCLER_PRIZES = _();
    public static readonly Identifier GET_RECYCLER_STATUS = _();
    public static readonly Identifier GET_SESSION_PARAMETERS = _();
    public static readonly Identifier GET_SONG_INFO = _();
    public static readonly Identifier GET_SONG_LIST = _();
    public static readonly Identifier GET_SOUND_SETTING = _();
    public static readonly Identifier GET_USER_SONG_DISCS = _();
    public static readonly Identifier GOAWAY = _();
    public static readonly Identifier GOTOFLAT = _();
    public static readonly Identifier GOVIADOOR = _();
    public static readonly Identifier G_HMAP = _();
    public static readonly Identifier G_IDATA = _();
    public static readonly Identifier G_ITEMS = _();
    public static readonly Identifier G_OBJS = _();
    public static readonly Identifier G_STAT = _();
    public static readonly Identifier G_USRS = _();
    public static readonly Identifier IG_ACCEPT_INVITE_REQUEST = _();
    public static readonly Identifier IG_CANCEL_GAME = _();
    public static readonly Identifier IG_CHANGE_PARAMETERS = _();
    public static readonly Identifier IG_CHECK_DIRECTORY_STATUS = _();
    public static readonly Identifier IG_CREATE_GAME = _();
    public static readonly Identifier IG_DECLINE_INVITE_REQUEST = _();
    public static readonly Identifier IG_EXIT_GAME = _();
    public static readonly Identifier IG_GET_CREATE_GAME_INFO = _();
    public static readonly Identifier IG_GET_GAME_LIST = _();
    public static readonly Identifier IG_GET_LEVEL_HALL_OF_FAME = _();
    public static readonly Identifier IG_INVITE_USER = _();
    public static readonly Identifier IG_JOIN_GAME = _();
    public static readonly Identifier IG_KICK_USER = _();
    public static readonly Identifier IG_LEAVE_GAME = _();
    public static readonly Identifier IG_LIST_POSSIBLE_INVITEES = _();
    public static readonly Identifier IG_LOAD_STAGE_READY = _();
    public static readonly Identifier IG_PLAY_AGAIN = _();
    public static readonly Identifier IG_ROOM_GAME_STATUS = _();
    public static readonly Identifier IG_START_GAME = _();
    public static readonly Identifier IG_START_OBSERVING_GAME = _();
    public static readonly Identifier IG_STOP_OBSERVING_GAME = _();
    public static readonly Identifier IIM = _();
    public static readonly Identifier INFORETRIEVE = _();
    public static readonly Identifier INITIATECREATEGAME = _();
    public static readonly Identifier INITIATEJOINGAME = _();
    public static readonly Identifier INIT_CRYPTO = _();
    public static readonly Identifier INSERT_SOUND_PACKAGE = _();
    public static readonly Identifier INTODOOR = _();
    public static readonly Identifier JOINPARAMETERVALUES = _();
    public static readonly Identifier JUKEBOX_PLAYLIST_ADD = _();
    public static readonly Identifier JUMPPERF = _();
    public static readonly Identifier JUMPSTART = _();
    public static readonly Identifier KICKPLAYER = _();
    public static readonly Identifier KICKUSER = _();
    public static readonly Identifier LANGCHECK = _();
    public static readonly Identifier LEAVEGAME = _();
    public static readonly Identifier LETUSERIN = _();
    public static readonly Identifier LEVELEDITORCOMMAND = _();
    public static readonly Identifier LOOKTO = _();
    public static readonly Identifier MESSAGETOCALLER = _();
    public static readonly Identifier MESSENGER_ASSIGNPERSMSG = _();
    public static readonly Identifier MESSENGER_C_CLICK = _();
    public static readonly Identifier MESSENGER_C_READ = _();
    public static readonly Identifier MESSENGER_GETMESSAGES = _();
    public static readonly Identifier MESSENGER_HABBOSEARCH = _();
    public static readonly Identifier MESSENGER_REPORTMESSAGE = _();
    public static readonly Identifier MESSENGER_SENDMSG = _();
    public static readonly Identifier MODERATIONACTION = _();
    public static readonly Identifier MOVE = _();
    public static readonly Identifier MOVEITEM = _();
    public static readonly Identifier MOVESTUFF = _();
    public static readonly Identifier MSG_ACCEPT_TUTOR_INVITATION = _();
    public static readonly Identifier MSG_PLAYER_INPUT = _();
    public static readonly Identifier MSG_REJECT_TUTOR_INVITATION = _();
    public static readonly Identifier NAVIGATE = _();
    public static readonly Identifier NEW_SONG = _();
    public static readonly Identifier OBSERVEINSTANCE = _();
    public static readonly Identifier PARENT_EMAIL_REQUIRED = _();
    public static readonly Identifier PICK_CRYFORHELP = _();
    public static readonly Identifier PLACESTUFF = _();
    public static readonly Identifier POLL_ANSWER = _();
    public static readonly Identifier POLL_REJECT = _();
    public static readonly Identifier POLL_START = _();
    public static readonly Identifier PONG = _();
    public static readonly Identifier PRESENTOPEN = _();
    public static readonly Identifier PTM = _();
    public static readonly Identifier PURCHASE_AND_WEAR = _();
    public static readonly Identifier PURCHASE_FROM_CATALOG = _();
    public static readonly Identifier QUIT = _();
    public static readonly Identifier RECYCLE_ITEMS = _();
    public static readonly Identifier REDEEM_VOUCHER = _();
    public static readonly Identifier REFRESHFIGURE = _();
    public static readonly Identifier REGISTER = _();
    public static readonly Identifier REJOINGAME = _();
    public static readonly Identifier REMOVEALLRIGHTS = _();
    public static readonly Identifier REMOVEITEM = _();
    public static readonly Identifier REMOVERIGHTS = _();
    public static readonly Identifier REMOVESTUFF = _();
    public static readonly Identifier REMOVE_JUKEBOX_DISC = _();
    public static readonly Identifier REQUESTFULLSTATUSUPDATE = _();
    public static readonly Identifier REQUESTFULLSTATUSUPDATE_2 = _();
    public static readonly Identifier RESET_JUKEBOX = _();
    public static readonly Identifier RESPECT_USER = _();
    public static readonly Identifier ROOMBAN = _();
    public static readonly Identifier SAVE_SONG_EDIT = _();
    public static readonly Identifier SAVE_SONG_NEW = _();
    public static readonly Identifier SBUSYF = _();
    public static readonly Identifier SCR_BUY = _();
    public static readonly Identifier SCR_GET_USER_INFO = _();
    public static readonly Identifier SECRETKEY = _();
    public static readonly Identifier SEND_PARENT_EMAIL = _();
    public static readonly Identifier SETBADGE = _();
    public static readonly Identifier SETFLATCAT = _();
    public static readonly Identifier SETFLATINFO = _();
    public static readonly Identifier SETITEMDATA = _();
    public static readonly Identifier SETITEMSTATE = _();
    public static readonly Identifier SETSTUFFDATA = _();
    public static readonly Identifier SET_SOUND_SETTING = _();
    public static readonly Identifier SHOUT = _();
    public static readonly Identifier SIGN = _();
    public static readonly Identifier SONG_EDIT_CLOSE = _();
    public static readonly Identifier SPLASH_POSITION = _();
    public static readonly Identifier SRCHF = _();
    public static readonly Identifier STARTGAME = _();
    public static readonly Identifier STOP = _();
    public static readonly Identifier SUBMIT_GDPR_REQUEST = _();
    public static readonly Identifier SUSERF = _();
    public static readonly Identifier SWIMSUIT = _();
    public static readonly Identifier THROW_DICE = _();
    public static readonly Identifier TOTP_EMAIL_REQUIRED = _();
    public static readonly Identifier TRADE_ACCEPT = _();
    public static readonly Identifier TRADE_ADDITEM = _();
    public static readonly Identifier TRADE_CLOSE = _();
    public static readonly Identifier TRADE_OPEN = _();
    public static readonly Identifier TRADE_UNACCEPT = _();
    public static readonly Identifier TRYBUS = _();
    public static readonly Identifier TRYFLAT = _();
    public static readonly Identifier TRY_LOGIN = _();
    public static readonly Identifier UNIQUEID = _();
    public static readonly Identifier UNOBSERVEINSTANCE = _();
    public static readonly Identifier UPDATE = _();
    public static readonly Identifier UPDATEFLAT = _();
    public static readonly Identifier UPDATE_ACCOUNT = _();
    public static readonly Identifier UPDATE_PLAY_LIST = _();
    public static readonly Identifier USEITEM = _();
    public static readonly Identifier USE_AVATAR_EFFECT = _();
    public static readonly Identifier VALIDATE_PARENT_EMAIL = _();
    public static readonly Identifier VERSIONCHECK = _();
    public static readonly Identifier VOTE = _();
    public static readonly Identifier WATCHGAME = _();
    public static readonly Identifier WAVE = _();
    public static readonly Identifier WHISPER = _();

#pragma warning restore CS1591 // Missing XML comment for publicly visible type or member
}
