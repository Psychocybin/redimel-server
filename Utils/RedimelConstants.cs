using AutoMapper;
using redimel_server.Models.Domain;
using redimel_server.Models.Enums;

namespace redimel_server.Utils
{
    public static class RedimelConstants
    {
        public const string CREATESOLDIER = "Soldier";
        public const string CREATEHUNTER = "Hunter";
        public const string CREATEMERCENARY = "Mercenary";
        public const string CREATEGLADIATOR = "Gladiator";
        public const string CREATEPIRATE = "Pirate";
        public const string CREATEMONSTERSLAYER = "MonsterSlayer";
        public const string CREATEACROBAT = "Acrobat";
        public const string CREATEMERCHANT = "Merchant";
        public const string CREATETHIEF = "Thief";
        public const string CREATEMISSIONARY = "Missionary";
        public const string CREATEMAGICIAN = "Magician";
        public const string CREATELIBRARIAN = "Librarian";
        public const string CREATEKNIGHT = "Knight";
        public const string CREATESAVAGE = "Savage";
        public const string CREATEROBBER = "Robber";
        public const string STARTLOCATION = "redmagtowlib001";
        public const int TIMECOUNTER = 1;
        public const int TEAMGAME = 0;
        public const int IMPORTANTINFORMATION = 0;
        public const int SLAINMONSTERS = 0;
        public const int MORALS = 0;
        public const int COVER = 0;
        public const int TEMPORARYPOINTS = 0;
        public const OrderOfBattle ORDEROFBATTLE = OrderOfBattle.None;
    }
}
