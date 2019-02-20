using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public static class Attributes {
    public static string status;
    public static string nickname = "";
    public static string team;
    public static string scar = "burner scripté";
    public static string room = "Default";
    public static string map;
    public static int redscore = 0;
    public static int bluescore = 0;

    public static bool Check(string team) { return !(team == "red" ? redscore >= 5 : bluescore >=5); }
    public static bool increment(string te)
    {
        if (te == "red")
            bluescore++;
        else
            redscore++;
        return true;
    }
    public static string getred()
    {
        return redscore.ToString();
    }
    public static string getblue()
    {
        return bluescore.ToString();
    }


}
