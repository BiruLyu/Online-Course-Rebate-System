using System;
using System.Collections;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Text;
using System.Text.RegularExpressions;


/// <summary>
/// ToolClass 的摘要说明。
/// </summary>
public class Tool
{
    /// <summary>
    ///防止SQL注入并返回安全SQL语句
    /// </summary>
    /// <param name="M_InPut">要处理的SQL语句</param>
    /// <returns></returns>
    public static string NoSqlInject(string M_InPut)
    {
        if (M_InPut == string.Empty)
            return string.Empty;
        M_InPut = Regex.Replace(M_InPut, @"\sand\s", string.Empty, RegexOptions.IgnoreCase);
        M_InPut = Regex.Replace(M_InPut, @"\slike\s", string.Empty, RegexOptions.IgnoreCase);
        M_InPut = Regex.Replace(M_InPut, @"drop\s", string.Empty, RegexOptions.IgnoreCase);
        M_InPut = Regex.Replace(M_InPut, @"select\s", string.Empty, RegexOptions.IgnoreCase);
        M_InPut = Regex.Replace(M_InPut, @"insert\s", string.Empty, RegexOptions.IgnoreCase);
        M_InPut = Regex.Replace(M_InPut, @"delete\s", string.Empty, RegexOptions.IgnoreCase);
        M_InPut = Regex.Replace(M_InPut, @"update\s[\s\S].*\sset", string.Empty, RegexOptions.IgnoreCase);
        M_InPut = Regex.Replace(M_InPut, @"create\s", string.Empty, RegexOptions.IgnoreCase);
        M_InPut = Regex.Replace(M_InPut, @"\stable", string.Empty, RegexOptions.IgnoreCase);
        M_InPut = Regex.Replace(M_InPut, @"\scount", string.Empty, RegexOptions.IgnoreCase);
        M_InPut = Regex.Replace(M_InPut, @"\smid", string.Empty, RegexOptions.IgnoreCase);
        M_InPut = Regex.Replace(M_InPut, @"backup\s", string.Empty, RegexOptions.IgnoreCase);
        M_InPut = Regex.Replace(M_InPut, @"\smaster", string.Empty, RegexOptions.IgnoreCase);
        M_InPut = Regex.Replace(M_InPut, @"\struncate", string.Empty, RegexOptions.IgnoreCase);
        M_InPut = Regex.Replace(M_InPut, @"\sdeclare", string.Empty, RegexOptions.IgnoreCase);
        M_InPut = Regex.Replace(M_InPut, @"[\s]*exec[\s]*", string.Empty, RegexOptions.IgnoreCase);
        M_InPut = Regex.Replace(M_InPut, @"[\s]*truncate", string.Empty, RegexOptions.IgnoreCase);
        M_InPut = M_InPut.Replace("'", string.Empty);
        M_InPut = M_InPut.Replace(";", string.Empty);
        M_InPut = M_InPut.Replace("<", string.Empty);
        M_InPut = M_InPut.Replace(">", string.Empty);
        M_InPut = M_InPut.Replace("--", string.Empty);
        M_InPut = M_InPut.Replace("=", string.Empty);
        return M_InPut;
    }
    public static string SqlUpdteInject(string M_InPut)
    {
        if (M_InPut == string.Empty)
            return string.Empty;
        M_InPut = M_InPut.Replace("'", string.Empty);
        M_InPut = M_InPut.Replace("-", string.Empty);
        M_InPut = M_InPut.Replace("%", string.Empty);
        M_InPut = M_InPut.Replace("=", string.Empty);
        return M_InPut;
    }
    public static string StripHTML(string strHtml)
    {
        string[] aryReg =
    {
      @"<script[^>]*?>.*?</script>", @"<(\/\s*)?!?((\w+:)?\w+)(\w+(\s*=?\s*(([""'])(\\[""'tbnr]|[^\7])*?\7|\w+)|.{0})|\s)*?(\/\s*)?>", @"([\r\n])[\s]+", @"&(quot|#34);", @"&(amp|#38);", @"&(lt|#60);", @"&(gt|#62);", @"&(nbsp|#160);", @"&(iexcl|#161);", @"&(cent|#162);", @"&(pound|#163);",  @"&(copy|#169);", @"&#(\d+);", @"-->", @"<!--.*\n"
    };

        string[] aryRep =
    {
      "", "", "", "\"", "&", "<", ">", "   ", "\xa1",  //chr(161),
      "\xa2",  //chr(162),
      "\xa3",  //chr(163),
      "\xa9",  //chr(169),
      "", "\r\n", ""
    };

        string newReg = aryReg[0];
        string strOutput = strHtml;
        for (int i = 0; i < aryReg.Length; i++)
        {
            Regex regex = new Regex(aryReg[i], RegexOptions.IgnoreCase);
            strOutput = regex.Replace(strOutput, aryRep[i]);
        }
        strOutput.Replace("<", "");
        strOutput.Replace(">", "");
        strOutput.Replace("\r\n", "");
        return strOutput;
    }
    /// <summary>
    /// 模糊查询
    /// </summary>
    /// <param name="M_InPut"></param>
    /// <returns></returns>
    public static string SqlLikeInject(string M_InPut)
    {
        if (M_InPut == string.Empty)
            return string.Empty;
        if (M_InPut.Length > 20)
            M_InPut = M_InPut.Substring(0, 20);
        M_InPut = M_InPut.Replace("'", string.Empty);
        M_InPut = M_InPut.Replace("[", "[[]");
        M_InPut = M_InPut.Replace("]", "[]]");
        M_InPut = M_InPut.Replace("_", "[_]");
        M_InPut = M_InPut.Replace("%", "[%]");
        M_InPut = M_InPut.Replace("=", "[=]");
        return M_InPut;
    }
    #region 取中文首字母
    /// <summary>
    /// 获得首字母
    /// </summary>
    /// <param name="paramChinese"></param>
    /// <returns></returns>
    public static string GetFirstLetter(string paramChinese)
    {
        StringBuilder st = new StringBuilder();
        int iLen = paramChinese.Length;

        for (int i = 0; i <= iLen - 1; i++)
        {
            st.Append(GetCharSpellCode(paramChinese.Substring(i, 1)));
        }

        return st.ToString();
    }

    /// <summary>    
    /// 得到一个汉字的拼音第一个字母，如果是一个英文字母则直接返回大写字母    
    /// </summary>    
    /// <param name="CnChar">单个汉字</param>    
    /// <returns>单个大写字母</returns>    
    private static string GetCharSpellCode(string paramChar)
    {
        long iCnChar;

        byte[] ZW = System.Text.Encoding.Default.GetBytes(paramChar);

        //如果是字母，则直接返回    
        if (ZW.Length == 1)
        {
            return paramChar.ToUpper();
        }
        else
        {
            // get the array of byte from the single char    
            int i1 = (short)(ZW[0]);
            int i2 = (short)(ZW[1]);
            iCnChar = i1 * 256 + i2;
        }

        //expresstion    
        //table of the constant list    
        // 'A'; //45217..45252    
        // 'B'; //45253..45760    
        // 'C'; //45761..46317    
        // 'D'; //46318..46825    
        // 'E'; //46826..47009    
        // 'F'; //47010..47296    
        // 'G'; //47297..47613    

        // 'H'; //47614..48118    
        // 'J'; //48119..49061    
        // 'K'; //49062..49323    
        // 'L'; //49324..49895    
        // 'M'; //49896..50370    
        // 'N'; //50371..50613    
        // 'O'; //50614..50621    
        // 'P'; //50622..50905    
        // 'Q'; //50906..51386    

        // 'R'; //51387..51445    
        // 'S'; //51446..52217    
        // 'T'; //52218..52697    
        //没有U,V    
        // 'W'; //52698..52979    
        // 'X'; //52980..53640    
        // 'Y'; //53689..54480    
        // 'Z'; //54481..55289    

        // iCnChar match the constant    
        if ((iCnChar >= 45217) && (iCnChar <= 45252))
        {
            return "A";
        }
        else if ((iCnChar >= 45253) && (iCnChar <= 45760))
        {
            return "B";
        }
        else if ((iCnChar >= 45761) && (iCnChar <= 46317))
        {
            return "C";
        }
        else if ((iCnChar >= 46318) && (iCnChar <= 46825))
        {
            return "D";
        }
        else if ((iCnChar >= 46826) && (iCnChar <= 47009))
        {
            return "E";
        }
        else if ((iCnChar >= 47010) && (iCnChar <= 47296))
        {
            return "F";
        }
        else if ((iCnChar >= 47297) && (iCnChar <= 47613))
        {
            return "G";
        }
        else if ((iCnChar >= 47614) && (iCnChar <= 48118))
        {
            return "H";
        }
        else if ((iCnChar >= 48119) && (iCnChar <= 49061))
        {
            return "J";
        }
        else if ((iCnChar >= 49062) && (iCnChar <= 49323))
        {
            return "K";
        }
        else if ((iCnChar >= 49324) && (iCnChar <= 49895))
        {
            return "L";
        }
        else if ((iCnChar >= 49896) && (iCnChar <= 50370))
        {
            return "M";
        }

        else if ((iCnChar >= 50371) && (iCnChar <= 50613))
        {
            return "N";
        }
        else if ((iCnChar >= 50614) && (iCnChar <= 50621))
        {
            return "O";
        }
        else if ((iCnChar >= 50622) && (iCnChar <= 50905))
        {
            return "P";
        }
        else if ((iCnChar >= 50906) && (iCnChar <= 51386))
        {
            return "Q";
        }
        else if ((iCnChar >= 51387) && (iCnChar <= 51445))
        {
            return "R";
        }
        else if ((iCnChar >= 51446) && (iCnChar <= 52217))
        {
            return "S";
        }
        else if ((iCnChar >= 52218) && (iCnChar <= 52697))
        {
            return "T";
        }
        else if ((iCnChar >= 52698) && (iCnChar <= 52979))
        {
            return "W";
        }
        else if ((iCnChar >= 52980) && (iCnChar <= 53688))
        {
            return "X";
        }
        else if ((iCnChar >= 53689) && (iCnChar <= 54480))
        {
            return "Y";
        }
        else if ((iCnChar >= 54481) && (iCnChar <= 55289))
        {
            return "Z";
        }
        else return ("?");
    }

    #endregion
    public static string ConvertToChinese(double x)
    {
        string s = x.ToString("#L#E#D#C#K#E#D#C#J#E#D#C#I#E#D#C#H#E#D#C#G#E#D#C#F#E#D#C#.0B0A");
        string d = Regex.Replace(s, @"((?<=-|^)[^1-9]*)|((?'z'0)[0A-E]*((?=[1-9])|(?'-z'(?=[F-L\.]|$))))|((?'b'[F-L])(?'z'0)[0A-L]*((?=[1-9])|(?'-z'(?=[\.]|$))))", "${b}${z}");
        return Regex.Replace(d, ".", delegate(Match m) { return "负元空零壹贰叁肆伍陆柒捌玖空空空空空空空分角拾佰仟萬億兆京垓秭穰"[m.Value[0] - '-'].ToString(); });
    }
    /// <summary>
    /// 定义一个方法用来输出标准的JSON格式数据
    /// </summary>
    public static string CreateJson(string info, string sta)
    {
        return "{\"info\":\"" + info + "\",\"sta\":\"" + sta + "\"}";
    }
    
}
