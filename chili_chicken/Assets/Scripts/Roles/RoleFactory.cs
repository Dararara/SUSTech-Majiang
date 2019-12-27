using System.Collections;
using System.Collections.Generic;

    public class RoleFactory
    {
        private static Role role = null;
        public static Role defaultFactory()
        {
            role = new Role();
            return role;
        }
    public static Role Computer_GuyFactory()
    {
        role = new Computer_Guy();
        return role;
    }
    public static Role getRolebyType(int type)
    {
        switch (type)
        {
            
            case 1:
                return LolitaFactory();
            case 2:
                return GeniusFactory();
            case 3:
                return Computer_GuyFactory();
            case 4:
                return Master_of_SportsFactory();
            case 5:
                return Young_ArtistFactory();
            case 6:
                return Liver_EmperorFactory();

            default:
                return defaultFactory();
        }
    }
    public static string GetRoleNameByType(int type)
    {
        switch (type)
        {
            case 1:
                return "学妹";
            case 2:
                return "天才";
            case 3:
                return "计算机大佬";
            case 4:
                return "运动健将";
            case 5:
                return "文艺青年";
            case 6:
                return "肝帝";
            default:
                return "我也不知道是啥";
        }
    }
    public static Role LolitaFactory()
        {
            role = new Lolita();
            return role;
        }
        public static Role Young_ArtistFactory()
        {
            role = new Young_Artist();
            return role;
        }
        public static Role Liver_EmperorFactory()
        {
            role = new Liver_Emperor();
            return role;
        }
        public static Role Master_of_SportsFactory()
        {
            role = new Master_of_Sports();
            return role;
        }
        public static Role GeniusFactory()
        {
            role = new Genius();
            return role;
        }
    }

