using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public static class tests
{

    public static int ok(int type,int x)
    {
        switch (type)
        {
            case 1:
                {
                    if (PlayerPrefs.GetInt("PlayNr", 0) >= x)
                    {
                        return 1;
                    }
                    else
                    {
                        return 0;
                    }
                }

            case 2:
                {
                    if (PlayerPrefs.GetInt("HS", 0) > x)
                    {
                        return 1;
                    }
                    else
                    {
                        return 0;
                    }
                }
            case 3:
                {
                    if (PlayerPrefs.GetInt("SumaOfPt", 0) > x)
                    {
                        return 1;
                    }
                    else
                    {
                        return 0;
                    }
                }



            default:
                {
                    return 1;
                }


        }

    }

}
