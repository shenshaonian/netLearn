using System;
using System.Collections.Generic;
using System.Text;

namespace ConsoleApp1
{
    class DemoUtils
    {

    public static DemoDto getAgeNew(DateTime theBirthDay, DateTime dtNow, bool AgeChildMode)
    {
        dtNow = DateTime.Now;
        DemoDto ageOutputDto = new DemoDto();
        if (dtNow < theBirthDay)
        {
            return new DemoDto
            {
                Days = 1,
                Report_Age = "1天",
                Age = 1,
                AgeUnit = "天"
            };
        }

        string ageNew = getAgeNew2(theBirthDay, dtNow);
        ageOutputDto.Days = (int)(DateTime.Now.Date - theBirthDay.Date).TotalDays;
        ageOutputDto.Report_Age = ageNew;
        if (!(ageNew == ""))
        {
            if (ageNew.Contains("小时"))
            {
                string text = ageNew.Substring(0, ageNew.Length - 2);
                if (text != "")
                {
                    ageOutputDto.Age = int.Parse(text);
                }

                ageOutputDto.AgeUnit = "小时";
            }
            else
            {
                string text2 = ageNew.Substring(0, ageNew.Length - 1);
                string ageUnit = ageNew.Substring(ageNew.Length - 1, 1);
                if (text2 != "")
                {
                    ageOutputDto.Age = int.Parse(text2);
                }

                ageOutputDto.AgeUnit = ageUnit;
            }
        }

        if (AgeChildMode)
        {
            ageOutputDto.Report_Age = getAgeStrForCh(theBirthDay, dtNow);
        }

        return ageOutputDto;
    }
        public static string getAgeStrForCh(DateTime theBirthDay, DateTime dtNow)
        {
            try
            {
                if (theBirthDay > dtNow)
                {
                    return "";
                }

                theBirthDay = DateTime.Parse(theBirthDay.ToString("yyyy-MM-dd 00:00"));
                dtNow = DateTime.Parse(dtNow.ToString("yyyy-MM-dd 00:00"));
                int year = theBirthDay.Year;
                int year2 = dtNow.Year;
                int month = theBirthDay.Month;
                int month2 = dtNow.Month;
                int day = theBirthDay.Day;
                int day2 = dtNow.Day;
                if (year2 - year > 18 || (year2 - year == 18 && (month2 - month > 0 || (month2 - month == 0 && day2 - day >= 0))))
                {
                    if (month2 - month > 0 || (month2 - month == 0 && day2 - day >= 0))
                    {
                        return year2 - year + "岁";
                    }

                    return year2 - year - 1 + "岁";
                }

                string text = "";
                string str = "";
                string text2 = "";
                string text3 = "";
                if (year2 - year > 1 || (year2 - year == 1 && (month2 - month > 0 || (month2 - month == 0 && day2 - day >= 0))))
                {
                    if (month2 - month < 0 || (month2 - month == 0 && day2 - day < 0))
                    {
                        text = year2 - year - 1 + "岁";
                        str = ((month2 - month != 0) ? (12 + month2 - month + "月") : ((day2 - day < 0) ? "11月" : ""));
                    }
                    else
                    {
                        text = year2 - year + "岁";
                        if (month2 - month > 0)
                        {
                            str = month2 - month + "月";
                        }
                    }

                    return text + str;
                }

                TimeSpan timeSpan = dtNow - theBirthDay;
                if ((int)timeSpan.TotalDays < 31)
                {
                    if ((int)timeSpan.TotalDays == 0)
                    {
                        return "1天";
                    }

                    return (int)timeSpan.TotalDays + "天";
                }

                int num = 0;
                num = ((year2 - year <= 0) ? (month2 - month) : (12 + month2 - month));
                if (day2 - day < 0)
                {
                    num--;
                    int num2 = getMonthDay(theBirthDay) - theBirthDay.Date.Day + dtNow.Day;
                    text2 = num2 + "天";
                }
                else
                {
                    int num3 = dtNow.Day - theBirthDay.Date.Day;
                    text2 = num3 + "天";
                }

                str = num + "月";
                return str + text2;
            }
            catch
            {
            }

            return "";
        }

        private static string getAgeNew2(DateTime theBirthDay, DateTime dtNow)
    {
        try
        {
            theBirthDay = DateTime.Parse(theBirthDay.ToString("yyyy-MM-dd HH:mm"));
            dtNow = DateTime.Parse(dtNow.ToString("yyyy-MM-dd HH:mm"));
            if (theBirthDay > dtNow)
            {
                return "";
            }

            int year = theBirthDay.Year;
            int year2 = dtNow.Year;
            int month = theBirthDay.Month;
            int month2 = dtNow.Month;
            int day = theBirthDay.Day;
            int day2 = dtNow.Day;
            if (year2 - year > 18 || (year2 - year == 18 && (month2 - month > 0 || (month2 - month == 0 && day2 - day >= 0))))
            {
                if (month2 - month > 0 || (month2 - month == 0 && day2 - day >= 0))
                {
                    return year2 - year + "岁";
                }

                return year2 - year - 1 + "岁";
            }

            string text = "";
            string text2 = "";
            string text3 = "";
            if (year2 - year > 1 || (year2 - year == 1 && (month2 - month > 0 || (month2 - month == 0 && day2 - day >= 0))))
            {
                if (month2 - month < 0 || (month2 - month == 0 && day2 - day < 0))
                {
                    text = year2 - year - 1 + "岁";
                    text2 = ((month2 - month != 0) ? (12 + month2 - month + "月") : ((day2 - day < 0) ? "11M" : ""));
                }
                else
                {
                    text = year2 - year + "岁";
                    text2 = month2 - month + "月";
                }

                return text;
            }

            TimeSpan timeSpan = dtNow - theBirthDay;
            if ((int)timeSpan.TotalDays < 31)
            {
                if ((int)timeSpan.TotalDays == 0)
                {
                    if (timeSpan.TotalHours >= 1.0)
                    {
                        return timeSpan.TotalHours.ToString("N0") + "小时";
                    }

                    return "1天";
                }

                return (int)timeSpan.TotalDays + "天";
            }

            int num = 0;
            num = ((year2 - year <= 0) ? (month2 - month) : (12 + month2 - month));
            if (day2 - day < 0)
            {
                num--;
                int num2 = getMonthDay(theBirthDay) - theBirthDay.Date.Day + dtNow.Day;
                text3 = num2 + "天";
            }
            else
            {
                int num3 = dtNow.Day - theBirthDay.Date.Day;
                text3 = num3 + "天";
            }

            return num + "月";
        }
        catch
        {
        }

        return "";
    }


    private static int getMonthDay(DateTime dt)
        {
            int month = dt.Month;
            if (month == 1 || month == 3 || month == 5 || month == 7 || month == 8 || month == 10 || month == 12)
            {
                return 31;
            }

            if (month == 2)
            {
                int year = dt.Year;
                bool flag = false;
                if ((year % 4 == 0 && year % 100 != 0) || (year % 4 == 0 && year % 400 == 0))
                {
                    flag = true;
                }

                if (flag)
                {
                    return 29;
                }

                return 28;
            }

            return 30;
        }
    }

}
