using BWJS.AppCode;
using Microsoft.Win32;
using System;
using System.Collections.Generic;
using System.Drawing;
using System.Drawing.Imaging;
using System.IO;
using System.Linq;
using System.Security;
using System.Text;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using UtilityHelper;

namespace BWJS.WebApp.Test
{
    public enum BrowserEmulationVersion
    {
        Default = 0,
        Version7 = 7000,
        Version8 = 8000,
        Version8Standards = 8888,
        Version9 = 9000,
        Version9Standards = 9999,
        Version10 = 10000,
        Version10Standards = 10001,
        Version11 = 11000,
        Version11Edge = 11001
    }

    public partial class ceshi20171229 : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!Page.IsPostBack)
            {
                int ieversion = GetInternetExplorerMajorVersion();
                Response.Write("ieversion=" + ieversion + "<br />");

                BrowserEmulationVersion browserEmulationVersion = GetBrowserEmulationVersion();
                Response.Write("browserEmulationVersion=" + browserEmulationVersion.ToString() + "<br />");

                //if (!IsBrowserEmulationSet())
                //{
                //    SetBrowserEmulationVersion();
                //}

                if (HttpContext.Current.Request.Cookies["bwjsCookie20180106"] != null)
                {
                    Utils.DelCoookie("bwjsCookie20180106");
                }
                else
                {
                    Utils.WriteCookie("bwjsCookie20180106", "token", "1000", 2);
                    Utils.WriteCookie("bwjsCookie20180106", "consultId", "b938b7e4-d50e-49b7-af98-08a090322189", 2);
                }

                string consultId = Utils.GetCookie("bwjsCookie20180106", "token");
                string token = Utils.GetCookie("bwjsCookie20180106", "consultId");
            }
        }

        private const string InternetExplorerRootKey = @"Software\Microsoft\Internet Explorer";

        public int GetInternetExplorerMajorVersion()
        {
            int result;

            result = 0;

            try
            {
                RegistryKey key;

                key = Registry.LocalMachine.OpenSubKey(InternetExplorerRootKey);

                if (key != null)
                {
                    object value;

                    value = key.GetValue("svcVersion", null) ?? key.GetValue("Version", null);
                    Response.Write("value=" + value + "<br />");

                    if (value != null)
                    {
                        string version;
                        int separator;

                        version = value.ToString();
                        separator = version.IndexOf('.');
                        if (separator != -1)
                        {
                            int.TryParse(version.Substring(0, separator), out result);
                        }
                    }
                }
            }
            catch (SecurityException)
            {
                // The user does not have the permissions required to read from the registry key.
            }
            catch (UnauthorizedAccessException)
            {
                // The user does not have the necessary registry rights.
            }

            return result;
        }

        private const string BrowserEmulationKey = InternetExplorerRootKey + @"\Main\FeatureControl\FEATURE_BROWSER_EMULATION";

        public BrowserEmulationVersion GetBrowserEmulationVersion()
        {
            BrowserEmulationVersion result;

            result = BrowserEmulationVersion.Default;

            try
            {
                RegistryKey key;

                key = Registry.CurrentUser.OpenSubKey(BrowserEmulationKey, true);
                if (key != null)
                {
                    string programName;
                    object value;

                    programName = Path.GetFileName(Environment.GetCommandLineArgs()[0]);
                    value = key.GetValue(programName, null);
                    Response.Write("value1=" + value + "<br />");

                    if (value != null)
                    {
                        result = (BrowserEmulationVersion)Convert.ToInt32(value);
                    }
                }
            }
            catch (SecurityException)
            {
                // The user does not have the permissions required to read from the registry key.
            }
            catch (UnauthorizedAccessException)
            {
                // The user does not have the necessary registry rights.
            }

            return result;
        }

        public bool IsBrowserEmulationSet()
        {
            return GetBrowserEmulationVersion() != BrowserEmulationVersion.Default;
        }

        #region set
        public bool SetBrowserEmulationVersion(BrowserEmulationVersion browserEmulationVersion)
        {
            bool result;

            result = false;

            try
            {
                RegistryKey key;

                key = Registry.CurrentUser.OpenSubKey(BrowserEmulationKey, true);

                if (key != null)
                {
                    string programName;

                    programName = Path.GetFileName(Environment.GetCommandLineArgs()[0]);

                    if (browserEmulationVersion != BrowserEmulationVersion.Default)
                    {
                        // if it's a valid value, update or create the value
                        key.SetValue(programName, (int)browserEmulationVersion, RegistryValueKind.DWord);
                    }
                    else
                    {
                        // otherwise, remove the existing value
                        key.DeleteValue(programName, false);
                    }

                    result = true;
                }
            }
            catch (SecurityException)
            {
                // The user does not have the permissions required to read from the registry key.
            }
            catch (UnauthorizedAccessException)
            {
                // The user does not have the necessary registry rights.
            }

            return result;
        }

        public bool SetBrowserEmulationVersion()
        {
            int ieVersion;
            BrowserEmulationVersion emulationCode;

            ieVersion = GetInternetExplorerMajorVersion();

            if (ieVersion >= 11)
            {
                emulationCode = BrowserEmulationVersion.Version11;
            }
            else
            {
                switch (ieVersion)
                {
                    case 10:
                        emulationCode = BrowserEmulationVersion.Version10;
                        break;
                    case 9:
                        emulationCode = BrowserEmulationVersion.Version9;
                        break;
                    case 8:
                        emulationCode = BrowserEmulationVersion.Version8;
                        break;
                    default:
                        emulationCode = BrowserEmulationVersion.Version7;
                        break;
                }
            }

            return SetBrowserEmulationVersion(emulationCode);
        }
        #endregion

        protected void btnUploadImg_Click(object sender, EventArgs e)
        {
            string base64Code = "/9j/4AAQSkZJRgABAQAAAQABAAD/2wCEABALDA4MChAODQ4SERATGCgaGBYWGDEjJR0oOjM9PDkzODdASFxOQERXRTc4UG1RV19iZ2hnPk1xeXBkeFxlZ2MBERISGBUYLxoaL2NCOEJjY2NjY2NjY2NjY2NjY2NjY2NjY2NjY2NjY2NjY2NjY2NjY2NjY2NjY2NjY2NjY2NjY//AABEIAXkB9AMBEQACEQEDEQH/xAGiAAABBQEBAQEBAQAAAAAAAAAAAQIDBAUGBwgJCgsQAAIBAwMCBAMFBQQEAAABfQECAwAEEQUSITFBBhNRYQcicRQygZGhCCNCscEVUtHwJDNicoIJChYXGBkaJSYnKCkqNDU2Nzg5OkNERUZHSElKU1RVVldYWVpjZGVmZ2hpanN0dXZ3eHl6g4SFhoeIiYqSk5SVlpeYmZqio6Slpqeoqaqys7S1tre4ubrCw8TFxsfIycrS09TV1tfY2drh4uPk5ebn6Onq8fLz9PX29/j5 gEAAwEBAQEBAQEBAQAAAAAAAAECAwQFBgcICQoLEQACAQIEBAMEBwUEBAABAncAAQIDEQQFITEGEkFRB2FxEyIygQgUQpGhscEJIzNS8BVictEKFiQ04SXxFxgZGiYnKCkqNTY3ODk6Q0RFRkdISUpTVFVWV1hZWmNkZWZnaGlqc3R1dnd4eXqCg4SFhoeIiYqSk5SVlpeYmZqio6Slpqeoqaqys7S1tre4ubrCw8TFxsfIycrS09TV1tfY2dri4 Tl5ufo6ery8/T19vf4 fr/2gAMAwEAAhEDEQA/ANg1pYwGkgD1PpRcLDWjDHOMH1FAxSrcYxj3ouIQy7eHRl9 ooAkUhhlSCPagaQtCYxRQ9QFpIBKdhXFxSBij0pjFxSEOFIocDQA7caYAM tINxTCr/eUH370A0HlOn3JCR6PSQMNxUjzEK 4GRTAlVdwyKBi7aSAQrVCDFGwBjFINgxQMQ0AMZ0XgsM meaSQhodm 7Gcep4FMYbZTnc4UeiCkIcsCsRuBYjuaLjsZnibV10qx8qEAzy8RqB v0qWXscFI0hDM7l5HOXb1NO1gRVpgREHNAgGelADzwKB2GseKVwGkmgBuaAEoAkAwM0AHLGmBMPlFAXHdgKQXF5xQhbgTgVVwsN5NIolhU7yx9MVIbEkkgQHFNITIA Tk0wHg560gEcgUJgQ96dxDicCmCHBsc0XAlilOaNANC1lCAguY1J5w3WloSzUju4pQP WadCH6tRtoBKtz5tyi4QI3DfN91fSqWgdSrqNqi SEYBVdsqeevakmG7IZYibZlCcAZDD1oAw9XUqYgff8ApRIpHoxBNWjEXbQMXFSwsFCEwxnrQxoYYIm527W9V4pphZAVlTHlsH/36ADzsf6yNk9 opbDaHqysOCDRcQ/FMBRSYw700AtJjHCkFgpiHAUhj1Azz9aALMULPjjikDLS2wA5oKsO8kYxjii4WZDJaxnnG0 q0XFYhaKVeQQ49xg0WAZu5wylfrTJAsoyM8im7DG YhyB8xxnigQHecbQB9RmkMQRHuxNAxFiVOFQAeoouJIdjFG4CUDBnCqWZtqqMknoBU3Gkecapff2nqUt2SfLBKRL7Dv NAyhI5xheKLAQdKYxhPNAmID3pBYXPc02AxjUjGk0wBVzQA8KAM0wDljSAlVQq 9IdhVPPNMLEuOM0risNZvSncEhpPFIY NSe1DZSQ92CcDrSjuJkLZbrV3FYVcUrisPyAKCiB3y1BIqgnk0xMf160mwA4phYQPt6Uh2J0mwc0xE4lLIUQ4LZyS3Sk3YLE9qLcfKzq 3naOcn8KfmJlyP/AEiT7rE9RntSdwSHtcJLIbWBstGu92XoPbPrT0Q7GLrv3bYd8Nk vShu4I9DrQxCkAUDuFFgYYNAri4pDCmCADmgBrQK3PKn1U4pAAWdB8pWVR2PB/OgYolCj94rIfcZH5igRKuGGV5 lFxigUrggAoGLQA9RTEWIlAxnr3paFF LGKQIkpFi0AISAMsQB70AVZrhRxFC8rf7IwPzpkuxTf 0rk7A0duh4IQZYD607W1EnfQ0La1itogka9OpPJNK5Y94Y3HzIKQEBs9p/dtx6GncVkMNvIvO38qdxcowLmkSNIoGMIoYIwPGGom10g28Q/e3J2Z9B3qbXKOI2hFAHYYrS1gI26cUCIjRYYwgk1IAeKAGsaQxlAChcmnYVx QowKWoxAC1AD8baAFDZ60AKpycmgLiu RihIQgb0oZRKkZY1JRMf3a4HWkkJsrucnmrSJuMLUBcVCByaBiSSE0JCbI1wTTESZ20ihC5PSnYQmTQAZosK5NGobkmhaA2TqyRpnax9cc02CuSJM2cKu33zzRYGO3XEuYvN2xk/NtHJ9s0tQNKzhS1i2xxDJ6cdT/WmmhXZmeIypW26bvm3Y6dqgav1O/JxncMfWtjJijpntSEFO1xBQMMUrjFpDDFMQ4CkAtAxRiiwgIyMdqBsjaFCwbBBHocUNgL  Q8bXX/aOCKLDATKpxJ 7/3ulKwrkowTwQR7GmBItIdiRWPagAOoww/K0gLf3VG40WC5LHqEs5xBbEf7Urbf0pWKuWMyLj7RMFz2QYH50WHfuTqBjjn3pALQMKACgBaACgAoAjkhSQ5Yc oOKAsV5LRxkxPn2amKxVyRJ5brsf0PekwOA8TXn23XXQcx252g9ie/6/y/JoV9TKeqGQPxSAjPNACdBSGMJzQITFCGAXmiwh5wBxSGR4yaBDhgCgaE3c0wDNIQbzikCQgyTTGixEveoZRN52wYAGadrgQyTMx5NO1hMizmmgFxQIXigBuwk0wF2YpIY7imAhYAdKLCG8mnYBQKQWHZIHFAWJI52XsDn1pCsT/aQF 5g0XCw9LshduFH4DP50XBoebp2RlRipIxkGjUdilqT7ordcklQQSe/SgDqLTxVCcLcpJB6l/3i/mOapMixsW99bXa5hYP/tQsGx9R1p2JaLSfOMxur wPNO4rClwpw2R9RSYND1G5cryPan6i1ChgmLjNCGBp2AWkwuFMBRUlIWiwhaYC47daAGeUoOV4 lFguLiUfcZR/vLnFFguPS1hnbbNdyM39xjtU/lS0A0bbT7e3O5I1zjjjgUmy4x7lnav90flU3KALjp09KBWFAA6DFAwoAKAFoAjZWzlWx9aAELSJ95dw9V60wFWeJ/uuM maQElABQBHNDHOm2Rcj9RQB5Zrmkz6Tr0lucyxXOZIm4yfr75NNCehmyoVJDDBFUBWegBlAIQntUsY3FJgJimAuQKBDRkmgAxigYhNIBAaAAZNADwvFAD1AoGP3EDipCwz5jyadwEPb3pjGAZ6GgQuCOtAMA2KLCF3HsKBh83egYlO4rDgRSYCg56UagPAoQMCvFMACnFK4Bg0AJzmlYRKtVcRDfA4jJHBz/SkCNGTS7xOhhlJ/hjJz tUkxNlVreW3dWeCaBx/EAVI/Km0wuieHXbyFhuuBOBxiUHP8A311/Wp2CxuWfi6LaqzLInYlsSIP607oVjYtr6yuzm3kU98wv/NeoqiXGxcRixxFIkvfaThqBMfu2ffBX60MNh45GRyPWlcYUCCncBRg9KAHbTihDFoAUCgBQKLhYXFIBdoI5AoGKgaM/u5GX8cj8qLAWY72Vf9YgYeq1LRSkWI7uGTo4B9G4pDTRNQMMZ60AIR9RQAwtIh 7vHqKYDvMHG7K59aLAOpAQvaxOxYggnrg4oAjeOeAFoWLj 63P5UwuMj1JG 8hH05pBdDp9TtLeB5pZQqopYg9eKAPNNX1aTW9UN8y XDGpjhQ9cdyfc1SuK9zMkbcabAhakK4zFDGI1IBhosAYFFwG4JoAUcUgGsaYxmKQEirQBKqjsKB2JBEWpXCxJHau7AKOTSbGkalpohlJZ3wOgFZuRaVzYj8JWzqHLds4z1qOYvlQ7/AIRuOAEIFx2AFS22x8umxn6jojrAzxpHkdMGrUyJR0ujBGw5WRdrDhlPUVor9CFYTyYtwwR/KndgrDjFGvpQPQhk29qaTE2QYq7E3HBc0gJUiNK40iZYeKTY7C X2pXBIVkG2lfULEJHPFaE2GsMUIQoYKPmIH1p3Boj1BSoiz3z/SloB0qyqxwrDcOx61SfYzumXVuZJk2Sn8DwKafcHceUh2hnhXHbCA5/OmxJkTWFi/3rOHJ67RikK5HJomm5DRQyRNnO9ZCCPpQolN3JraBo38tbya7H/POVd5H0YU15Eto0o471B 6kZPRbgb1/x/WkO5YhSV1PnwpCw6NFIcGmIfl0OBIknsRyKLAL5jAZZCPxpIdyRJFYcHNMQ/rQwQUMdxwouMXFABSFcdmgoAaQh26gA4PUZosMcjyR58uQ4PY8gUWHzEyXrr/rU3D1WkCZaSeKT7rqfbNIokoAQjPWgCEwMrEwvt9jyKYWGS3EkAzLHlf7y0CegsV7DLwrc lFhcxFepayITKrKeu5eCPehpiumc74oWW28NXEysjqygDIIYZOP0p20Hc4tvkjVD2ABq7aAiuxyaVh3GYqbghGGKQ7DNuaLiGMKYABxUjChgIaVwGUxCgAUrjHqCaY0WI0oGXIUB7VDHY07KAZHGSallpG3bBUccA9uDWLfc0sasOAMbcDtUN3KtYsABuTRcCGa2V0I2fe6im0Byut HUm/ewSFXB7jnFaRnYzlC5y1zaTQMVYNIvYgZrZTTM3CxW344JIx2NVuQKDu5Bpod7kixMe1AWJ44vUVLKSLKRgVLHaxL5fGQRj3NK4EbOgHAzRZg2MYepwKdhLUibgcVSFIiKnqaoktWVuJJRJIoKpyoPc1LuNEOt8tEcY 9/ShBI9Bms4blcXMMUh/vAbSPxFa7HP6mdcaFbshEc7IOyS/Ouf509QGpaX8CeU1qJV3cPHIMAfjQGpaj0 5PLtFHnsAWNPQWpYXTYF5mV5D1w7HH5Um wW7k6lYlKRp0/hQUtWxjgJGGSoX6nNUAvl5 8SfakA9UUDCqB9BQCQ7FMYhiVuooaEJ5ZUfI35ikNB 8H3lB/3TSCw4SIeOQfQ0DHj25piCkAUDFHSk2AtABTAUE tDYWF3Uhi8E9OaQDkeSM5jc/RuRT0Hdk63rAfPET/ALppWKurEqXcLEDeFJ7NxSAe8kQRt7Ltxzk9qA6GHItv55WJvMj5Iwp X2zTVyNx6h1GACQf7x6VVxWOZ8a3Msj2FkZAEG59gHHHQ /epuyuU5uXniquFiHHNDY7ARUjSGNSQDe1OwhhFIpABxSuFhMUxCYqQG7aq4EioTU3HYlRcU7gTL1qWyrFu3BJGBz71DZcTTiRgAJNpJ7KcilzaDsaVorKAET6AVnJlq7NeFmKgOBn61m12LLSnI5qVdAOI4x0q7gMEQ5ySc0wIprK3lxviU46HHNFybFS50eyn5a1iZvUrk0uZrYfLczZ/Dtu AYVbHTPaqU2tgcEyo/h9EHyqF9MDFHtGhckRn9ikfxA/wDjpo9qw5F0GHTIQwDxO5HuTinzhydxJdMGdywkH VNSbDlSZSl0y4ySmFUf3u9WqnczcH0KkiMjbHU578HFVcVrCqmRwKpMTVx6W 4/MvFHNYXKW1CouARmpu2FjK1tstCApCjPJ7njNXEhnpoQn3rYwQyaaC2GbieKIf7bDmhtAUW1OBzttLW6uyTjdDHhfzNFgv2E3eJ5ebext4l9JWJY/jSaGm xahOoEsLvSpFII5jfeD9P896duw7E/mqjGOSN4fQOpGfpS2DlHeYmcbhTRI8AHkc0wuOC0rjDbQAmOaBXFxRcYYoGNK5pCuNEQU5Xii4xSWByOaBChhjkEGmMUEeopALmgYUxBmkxi8/h60g1GNPEmd0yDHUZ5pWC4gulb7iO3vjH86NR3HCSVj9xVHqTk0WEKRnqxpgM zxZzt/U0DFy6YCqjL6dDRYQLMgYBgUJ7HmlYaWpxXi2TzPECrn5YoflP1pofUwpGwcswH1NO4DfMjGP3i8 9S2UPAzyCD9KQ0BQmlsDI2U1VxWGbT3qQA8DigBuKbAMUhjlAoESquaQ7Eqxk9qRaRZgtyx4rNyS3LjG5eitGLDBwB14qb3HsaVpZlcAABam9ilqasahQMDkd6zk9SyePg0kDLCnHShgO3EDgc/WhMBVfI54P502gsOzUhYaSCCMCgY1uaLhYjZN3UjPoaYWIZLfnIANO4tgCgDGMfhQ9AGFBjFCbAb9mQnJ4ovcNjK1PTww3IOV9KpOxDVzHeCSJ UJX 8K1TIkhpl2nG39adidtyvLPjBLKM 9NITZnalP5oiXrtz2 lapWIk7no09jcg/wCmzXjL/dgXav0yOa2sc2vUZaxaJDNzbleeXk Y5 ppXHoarQwzp/oWotEemP8A63ah3fQFbuJ9m1e1P7m6W4XHKv1H5/hU37j16CjV7qE4u7N191U8/wCcU7D5mXU1OzlGDKq z8VNmXzItBY3GQqMPXFF2MryafAzblBTPXb3pa3vcNHuiN9PI/1cv4MM007CcUyBklQ7XiOfUdKammLkkMDqT1/OruZ21HYpDuFFguJQIKBoQ0AGPakBDcz2tnt 1TJDv6FuM1KZdtAWSNlzFMrj2OetO/YkHlnGPLgR/q2KLdxibblvvTqg/wCmac/rmiwhv2ON2zM0kv8Avucfl0oAlS3hjGEhRfoMU7sCSkMWgLC0DEzQhBQMUcnpSY0ef KPMk19YbaMySuvyqBkkk//AFqEwtd6Gtpfhiwso1l1fF1dMc7C3yJ7Y71jUqW0R0RpdzX/ALP0ZxgabaD38lax55GnIjL1Twrbv/pGn/uX/ugfKfbFUqjW5DpLoc2Y3jkaKZNkinBHY/StE7mdu5DIoBq0xELCqEN4xSATbQApXjpQAKhJ6UPQLFqJMkDFQ2WkaVvaAjnrWTbNUjUtbVVAAXis7lKxeS3AH3ce1S3Z3G9SdUwKe4IcOAODU2KHZ20gJUbjqTTAlVsimyRaEULmpYCmjYYUWC4U7kjDQAhFICPaM9KoAK5FCQNjJI/lzjIoCxSms45UJA49qaYmjJudMXcfmOK0TsS4plZNOiibcELkdz2rTm5lqRy2M3xJBLFHaPLtAfftCjoBt/xqqbvczqKx6THLcJwspK46MM10nJdirPIkKwyW0csS9h1qXHW476WIJLTTmQ W0sLehJxVJMNLlhLK8hQvZ3yynsGXIx dRfuVZ7oH1C8gIS6tQeeqd/1/z/JqN9iZTt8QpvtMuubgKjercfqKnks9EVzRZLDYw7w1rdyDHOFfIp38hpa7krG hbgJOnoBhv5/SloU2wXUQDieCWHtlhx/n/Gnyi5lcnW5hfGJF56c9aVh3QskMUykOoIPfvRcd9LFFrC5T/VTxsMnCupHHbnPXp/npXMiXFFQ3JhB 1wS25HVmG5fzFC1I8iZXjkGUdXHsaLjsFAgpjAikhNFTULVrpIEAztlVm/3RyaGle5RZCKPuqAPYUhC4phcTFAAQexoGHOKQMM0ALmhhcBQMOgpAGaYDW 6cnAx1pMaMCOJLa uNQZMykeVAD/Ag6n6k5rGc7I6KUOrKFxcSyvy2WPJY81lGPc1bEhuLqJs7g6joCMGm4Iakb2naiJ4xg8jgg1D0GUdasEuF3kHrkMO1EZWdyJQuc8dNeYsYJ1JzgIy45 tdS2uc pm3UNxbE fEyjnnqKpNMnVbjIirjIOalspWJcZoAcBnikMeiZPApAaVjbliCykc8VnJmiRsx2wXgdKyuaWLkUezAxUvUpFkDFK1xi4otYLARRcLDdtLYBwJHAFNK4Eqk9qLASCjYGIWCkZPJ6CgWou6iw2KCDRcGhcUrhYQigLjHVgAcZHqKdg0GZFOwC5pWYCg4INAEUqKCXAwfamIqFQ5Oeaq9hNDRbjOaaZLuc546Xath6/vP8A2WtqXUxqdDuRXXc4xQaEFh3WmCGrHsOY2ZD/ALJxSY9iXzbgEESKxU8bhSsCuOaVJhi7tw/ 0vb tK1h37kSWdi7kJK8S44AfB/Oh6ArMfJHqNsd0M6zR9fmHNJajd0Rpq8//LS13L0JTpmjlFzkk0llKm3gOeRt45/pVKInJEaQlEyl2yyH Hrih9hpvqPD3fRpQV6ENSSHclM820D5Bj0Gf50WE2Vjaws/mNEm/wDvAc00Id5ZHRvwIpgLyMAr tIaDI//AF0DuLikMTtSEJRdghtUAtSykJQIQ80AAAHTigaQZoAM tIGKDRuMR2AUsegGaluyHGN2c5qEhJxgjdmuTmu7naloQwWjsNxXIIzk1fNcVh8kG0dKlXElYrrI1rL5q5H97FNq4J2ZtrMJYycggjmoLMHU7CVbn7RazeXJjjjIP1FaRnymMoXd0VV1K4gIW hEyKc5XrWqlfVGTTWjJ/7L0vV1LafMILjGSBx Yqrisuhj3ljfaY2LuEmP/novIpbhtuQrMrfdINOw7lq3BYjHU1DKijobOP5Q1YORvFWNGJTjmk9UNkoz2qbjSJlOaSdh2FoYahg0hh0oEKDVIB2TjgUASDpQAgkUnGQSPeloApNFwsKKTGPzSAUDNMQEGmIYV44AqrgMKADgY lTcdhCrqARg tADc5GRTQmiN4lY5Hyt6iiQDWjdT8wDL6rSuw0OV8esGFhySR5nUc/wANdNF7nPV6HY YR2rrRxDlkGPmOPrTYx4b3zQSP3etMYu6kFw8xRyWA/GkMaXV iFqBXFCvzsG0fUkflTCw MSRjCy7cnJ2jrSeo0rBtC87Q3v3oQWHZVevFMB3FDGFFxBiiwBikxiYoAQigBhTnOT FIYnNAkITigaG7hQxgTikMTNDAM0AJmgALqDjIzSACw9CaBjSXJ4wKEIiuS6pguTu7VhWdkdFGN3czIbc3V1vYYReB71ijoZoMEiHbGOc0m2JIoTru6GhXQ2UJVJNapohhayvENhOR2pSVxpk8jeYtZ7FWM65i3HgVomZSRmTWwbEkbGN quvBrSLMpI0bHxDNCPI1SIXEOMGUDnHuK0Ju1uT3vhyz1OL7XpEyoT1C8qfbHaktBW7GKsdzYXSw30RjPZj0PuDUyRUZ23OnsiDEuOnWuWS1OqL0NBPapuAoByfc5pbjHrwAKYx4NAx eKAuJjjNAriiqsDHCkAo5OcZoESjGOFA lFhoCo9KTQwCUrgLtoAcq/LzSuIXYT0JFMTYbG9QapBcYwB46GpKuN5U8UxDHQkEpgHrj1o2FciU59qbYyRaBWOR IRJ/s/P/TT/ANlroo9TCt0OuKius4mATNAIQpz3ouDEYOFwkjKfXrSuCAGQY3sWpoByyIpxhlJ9qLsCVXGOo goJHBxigpDgwpsBQ1ADg1ABkUh3DPvQG4bj7Y tFwDeO/H1ouITeMdRRuMQuKGITcfSkMQ7yeAAPegaGtCW/5auB/s4FAEM0Ij2gM53Z6tk0mNFeRLkD9zcbT6Ou4VKG7jfMvFXlI2PqM07hqHnSE/M2PoKm4yQMp/iB9s0wHg0CsOzRcY4HmgdirdsWcqD NctR3Z101ZEiIIo89 5qL6FmbPc7mIBFIfqVZLgKCT0qkh6FSa jXqjn1x2qkjNj4WEsMcwBCuMjPWhuwXJ0PNSxiSxBgxPpQmS1cy7gFQFAxt4wK2iZSRFHGNuMZzVNisVbe4vNNvGlsJCu48p1DfhTvpqQ422OptNWsdag x6lEIZm4G7oT6g9jTv2E2pKzMywuWtA0Mn3YnKZ9geDUSgmrlQm4qzNyCdJFDI2Qa5nFo6YyT2LKnNQUOpgOFADxjFADx04oGM bNO4mLzmhBYeh5FO4MmWjoJEhXI96QwAFSAYFMB1Ahcd6Yg4zSQCOoYYPNVYEQupT3X171LLumN4IBByKBEbxBnHZsYzQlcLgiSDO/Bx3HemtBM5H4hdNP/wC2n/stdFHqYVeh2ArrOMWgAoaFcKVh3DFAxCvFADGjz9aYkhMMOjnHpSGL5rg9Af0pAH2kKfmV8eo5p3ABeQk7ROpb 6Tg/lQGjJBPk4zn6CgB29iOAPzo2AVdx6gA xpiHbc0irCLEgOQoz60xEgWkAoWmNDsUAxdtFhJla6GJlX/AGc1DepRFilcrcSkA0oG4IzSFuMMCZztGRwKaGNMbqPlYfiM0AIHlUfMm7/doGPjnRm5JGDyCMUtRrUib5mPbLZ tcknqdsdEN1CUpCMHluBUjMhxhapaCepTlJar0EVpIywYYzxVEsvgLHBFGOAiAVElqNEkB3nI6VLGWxHlaQMy76Ly5QeSGHPsa2iZsoSuIU9MnAq0myG0S6Va dK0rk7V6AdzSk7aBFX3NiXTI7mLG0A1lza3KcUzJmhe2faynb/AHj1/Gto1E9GZyjyhDK0bBo3K98djWnKmjNNp6GtZ6qpbZcfKezdjWMqPVG8avRmoHz05Fc8lbc3TuAepsDHBu9UImjbNBQ84oQgNAxyDjJ4p3IbJlZRj5h FAXH7hjOc09B3DcPXA9amwAGVuhBosFxc0NBuHfNIB2cUXCwZzTASiwETx90wD1IPelYY0kFsEbT6GhBYcFqhXON IwwNN4A/wBb0/4BW9HqYVeh2Kpu5Qhv905rruclgKEHkYoQhMUxWDFKwBikMMZoACKYxpFIBrLRYCN04qWgKjWga9jnzjYjKR6kkc/pTRTL0S4FU9TMnApFJjwKAsOApgO20WC45UyaLBckCexoFcd5ft NFxsd5dFxpIzrv/j dc/dRRWbH1Ij1pDExTAMUigxQIMUguGKLjQ3yQ5 7zjrRLYqO5Ukk2ojKc81yPc7Fohl/GXWN19OlKxSZnEA8HiqQMr XnOaTJIz5cYLOQFAySaab6Esm0u0fVt0wVltgcBiMbqlp31Dc1RYpGQEUBR0p3HdkjRbccVL3FczbuLEZY9Oa0TE0Yd7bl1hA52kAY71pGVjNwubmnWhiiC7cADis5vqaKNtDTjj9OlZodipf2m8bhnI7djVITMaa0KZMYx7Vop2M5QTICpxhhWymmYyg0TWl1NapsV2ZB/CTRKCkOM5R2Ne1vYpwADh/wC6a55UmtjeNRSLJccYNYmyHxyYPNMRKJv85oGKZQRkEVaJuRG6weF3Z9DV2RLGNd4b5RtPThuKQWEa8kGCAvHXPWhBYie RTucsOOuTRy2HdCx6zbqf9YFbtuOKXKyeZGrDqEMyAk7W6UhosBx0J59aRQu70osMcDUgJvwwB6HvRcLDqdxDSoPBGaQx4RG4ZSfxosS7nE/EkAf2aBnH73r/wAArpodTCr0N0W0QzsXYT3Xg1scth4a6j/1d0xHo6hqfMGpIL64QYkt45PUq2000wdxy6najiVZYie5QkfmKdw0J4ri1m5iuYm9t3NO4WJdhxkDj2pphZjSKCRpFAxCKBjGHFSwGAfNTQXsTqPzoAkVaYEirQFyVY800DJVjpXESBQKVxi7eKVx2Fx7Uh2FxQNIxp8Nf3JHqB QpDEpCDHFBQlDELQO4YpAJimA MfOKlvQqO5khC9ngcHmuVvU7Qs7ovEkEmOoA4qUwRDf2xgmBx8r96pBcoyKegp7gV1smvryC1xlS4aQf7I6072IauzsMpHGI4lCIowqgdKydyrEYXJqhMZMuEP4U9xMzdQjD27p0yw/Kq6i3K0dkrsjOpIU5FJuw7WNFVC9utJu40SheeOlTsMVhkYouDRUubUHkAVV7it3MySDBwRzTTBxIXsdwLQkKcfdrSNRp6mMqXYpE7ZArgo4PTvXQmmc7VmX7bUmiws43x/3h1Ws5U0zWNRrc0FmV13IwZfUVzuLR0KSY/zODSsMgkY7sgkfSmhEW5jwWzn2qkJgJCoxjpQ0mJFead eSfxoBlKWd8Dk1aIZELraeeabQr2LtpqKqCrIQvbacVLRadzasdUWXCq28j 9wanluVc1Ypt65qLFIf5jdyD FFihyyZBB5zUgOU4FFwY4nigQ9TzTVhM4v4lf8w3/tr/AOyV0Uupz1eh0PStkjmuFFhDSaB3GMM0DIJLeJ8bkUn1xTQmhqpLFzBcTRH2fI/I8UNhbsSDUdShHLQ3P/XRdp/MUkw1Jk1rA/0iydD3MThgPzxVXDTqWIL6C6jklgLGOIgOzLjaTQInYcUWARFpoZMi0CJVWnYCZU46UbCJlQY70rjHgelTcaQoFBSQuKQ7BQMKAMPrcXB9ZDg tBI4UAGKQxOtAC4pXGGKEAUAOThhSGmUbZCrSowxiRgPpniuaW52Qegw26RTbgCDnI5qLjbLt1BHdWmCTxgg0 guplQWaTYJ5yfpzVRdhO5ZgSGz8zaqrIfvHvRK26HFCQzmSQgnJP8AKs9S20XkxjmqRmxkwyu31NVYOhXeINyQKVx2G7QDSQIXbQxi1N7jDNMBCMigGU7qI/eA tNNXDYqhcGm9QHXFrFcRbZUB7hu4NEZNPQzlFSMi6tJrYEgmWPrkcMPaumM09znlCSJIgjQrPpkkhbPzxOefyrTlTQk7aomg1COdtjEJJ0IPHNZOBoqpYOTwetYNG19BhQ00IVYy3A609AI5Icfe4paCKMlsyMTnKk8Z7VSkBWntm25WrUjNopEsH9xVIRbt7tkIJOCO9S0Umze03U9/wApY 47Vm4miZsrdAjPFQyiWOTPNKw7ku gY4ttXII mKNxCozHvzSdkM5D4inI07nJ/ef yVvQ6nNW6HS10XOQMfWgY0igLDCKAGkUwuNIqeo7EbCgBjDimtRMtaTHjw7fOfvy3BxnvyMDn8ap9BrY0kTCge1MQ5Ux700ImRaaQmTogNDETKMCoZQ4CkUkOpFhQAtABQAlAGFB80efVj/OgRJSAKTATBprUQtKxQUbALRcANA0V9uL2U9nw36Y/pXNNHXB3RJPGCmCOlZF2uR20uQI3PJpp20D0I2jaGVmQdeeKLWApXkokuEkRfmOQ5/rTTTEPsx  5H40CNEcUJgNLZNMBp9e1IBjDJpNDAHBxQMQn1qQDHFMLCjpincLjWQkY9aNAZRuYSpzjimCFhO4YPOKmQmhs0QwSv5GmmFmYt3bFJfNjDRvnO5e5raE7GE6d3dFeaea4K cFZweZAMEj0roVjJxJob94CFf95H0OeoqZQTHGbRYXXNM3bftG3tyhI/PFY yka 0iWotQsJSAl1Bk9t4FS4SDnTLYAblGV/oQaHForQR4AyjcvHalcdinc2ZUHavPpSch2RlXEALHjBFXzE2KrREdqtSJcSW3Zo24OKTY1c2bO7LAc5PvWbNEasMnFTewWLAfmgscX4oJHKwxRa4HJfEBt39n 3mf8AstdFFWuc9XodYRWxyiEUxDSKOgxrCpQ3YYRVCG4pDGsKBEcvyRsxIGATkmhDbsaNquzw7ZL0aR9x9 Sc/wAqp7h0LaCmImVfamiWyVF/Om2LcmVcCpbHYkAqS0haRYtABQAUAFAEc7bYJG9FJ/SgDHgG2FMDqM0hEmKQBigYlAgoGFAIXFAwIpBYilKxyRE9WytZzOikSEg8HmsGbGZfW7xN5sQJTrgHkVLXULi212 ASNw7ildrYe5HeMks0bRoy5BzkUJ6isS2q85JxzVaiLJYAYosIYDzQNAWoBiZ5o2GL1oASkMXrxQK4oXbwRigELigBs0RKHjNMCgIzG5H40mFyUJ5gxxSWgyGa2BXaTmnzWCxkXVgEYspIyelaRmzKULmbeRSRwsyqTj0rojO 5hKHKZPnJsLA5x2q2Rc2l0GytbWOfXLmSOWZd0dtbgb8e aly7FKKtqSppWmx4a3bU0LdNsqA/yq1FtE3SJ0huoQfs2rzBBzsuIg fqaTpeRaqO25Ot1raD95ZWt2vrDJtP6/4Vk6SuUqj7GfdalD5m24gmtJDj5ZUOPzqHSktilUixY2jnH7plf12nNTZrcvRiNCe2R702wLFsrKepqbpjNWByAO1JootK/NACPcY79KT1AhOoqpwZFyOwPNNIm5y/i69ju2tgjbim/P47f8K6KSsjCq7ne4rVnKBX8KEMaRVCGkVIDStMY0rQAwrSAguxi1kx/dNNbiNqZNsNhCR9yME/kKfUp7E0YqyLk6LmnsBMqjFQ2A8UikOqTQWgAoAKACgAoAr3zbbOU/7OKBMoKu1FHoMUMApAFABQAYoGFSMKA3CgCrqikWazDP7ltxx6dDWc43RtSdmSW7eagI6HvWDR0tk5UEYxSIKj24VjgdfSkUmVJMbyoHIoBjouKq5JIxyCPWjcoaGxSYhdwpIBN1UFw3ZpMYoPamAuamwDhmmBIlCAmADDBoEU7uHcTs6j0otcaK8Jwdp7VPqMnMYZT603sIpXMOVIxUoDIvFLKtuDte4byw3pW0Lt6GVVpR1L s HLex12zu47VI9NghXzNuBucE4yO fl tdLko7nPFXZjXNvNeX8tzeMHkk7joo7KB2ArPnNOSwl2k2nQqx53nCg1rTqMxnAS11eRnG9ArL754ro5k9zK0katrdxXTgZVW68VKj1Ropaakz3EqgoSCh6BhmiUNLlx1KUmnWFwu57YRP2eD92f04rOxduxCdNu4yPslylyP eUvyv9AehNZyih 8PtblFn z3SNa3Q6xy8Z h71jKDtoaxmnoaqJtqLvqWR3VwtsgzkseigU0rg2jJmvpScBDjuc0KNiGzPmluJRxnaeoxzWkbGbuzM1AOPL3KyjnGRj0rZMykerYqzATFMBCKQ9hpFUhCFaTGNIpAMK0rAV7pA6pGeruFA9TVR3Bm9dfPfYHREA/OkhyHItWtDNlhFobGiQDFSMcKRaFpFC0AFACUAFAADnpQBV1I/6Lt/vsFoEyrikAUxhikAmKASA0kwYUAGKdwDvUjFKh1KNyrDBFIqLszKs5haztZucPEePde1czVnY64NSRpbwRkHIpWHYDg0rhYzrlQk5XPUZpbsBinFAh249B3qgIn5GAaRQ5CcUmIC1MBAaQWJFagB2aYhfMCnrSY0TKwwKdwJ1YEA0gsOIUk8cYqrgZ91DsfeM4qGO9x0UgIxTQgljDruFILFbSbIXOtfaHB8i1XJJHBf098df88dFLuzlqO7shPEV79s1CO1wfIg ds9C/b8v8 ylPmZcIWM65jDg4/P0qbo2sVdSja5sYkYAyQncv 1VxlYxnAzBY3dw6CG35bgseAta8yI5WzSawtrKCOOJi8qHLyDua0pNtkTihwYsRmtJu5UFYsRjIrO5rYmjjBPPbmspajbNMWttqED2 oIssXHLdVJ9D1FEU2zKXZnPEtoGqHTbi4MtsyeZbyN1C5Pyn9amUb6oqEmvdZXluvNkLsSWPf2rNpm10yLzFLherEZwBRYTaJoQjuQpDFeuCOKqMX0IcktzK8QvC32cRSIzKXDBTnHTrWtNNXuZ1Gnax6WQK1OVsQimAhFK4DTTBCEVIxpFMQ0igY2NN1/aKM5Eobj2oQ pqt813M3 0B QqoCluTKO9UyGiZeBUsocKkaHCkWhaBhQAlAAO1AhGYKuScCgYkWfLGetAkVtQOfKX1bP5UAyvimwQYpAFIdwxQAhFIAoAKQxAKGIftIG5iFA7k4pIqzMPUYhPcyyI21tvyupzzzWdSN9TaEmiCHVGj ScHcOrDp9axaZupXLkWoxydHGPWkO5FLMJJSRzwBmlbUV9BvmDoTTaJHFvSgaGZpNDHBuKWoBupgAbnmi1h3HA0CH5AouAYB 9TY0T8MnXBFLcRJG2F9aYEgb/wDVRYGMkwRilYCqRhhgYApsCZTtjLdxSBs0IYltLQIeuTI/uTWifu2MEru5z0sLEOX/ANYxLN9aaNLlfGCB1ocShssWVypx7VKEVypxjkfQ01uJsQxjFd0HZGEkMUZcgEcU20Fmadvbkrk8KvWol5FLTcksJrW5dliZgwPRhgn3FRKLQuZPYt39r/o32aMlZbh1ZznBCj/6wpq6M9zkPEHmXt59phj22sA yxs5x5hUnJHt1pcyRSTbuihb2d5Gu4Qt5fXcrg0NphqiyvnzXctlFOYIsZupMfcUe9HKtyE79S3aXGk28ebO0Rwh/wBdLGWf XFaRjfqDlFGRr9za3BgFrDFHt3btibc9Ov5UmmnqDaex6eRTsYCUAgIphuNIobHYQikA0iiwxpFAIdp67tYixg7ELH2zxTtoC3L8fzM7/3mJqoikWEHFDES96kY4UikLSLFoAKAEoARVC9KAFIB60AFAFO9 aeIf3QTQJkVMAxUjExQIKAA0rDEp2C4YJ6UrD3MLV/EsVoGh08CaYcGTGVT/E1aj3KS7HEaleXerXaiaV5XkcKi54HPp/n/AAHZEvc7po0t7dIYxhUUKMewxXNNnRFGVcD5jiovYsrDO/IyD6ijQRoW 4J8xye1Q0VclzTsA5TUjQuaGNDhQFxBnnNJjYE0xbCg4pMSHoQTQgJRjimMepwevFKwDg4Bo3GShuKHcBM5oEyJx6UWYC4JQAjOCD Rp7oGXri5WSNGQj943IPbFWncyiuhUuI0lT0bswouXYzXQr94DPtVJ3ERFaLXKvZETxntQlYTBLJpjmTp6U3MXL3LCWSoVUKRngVLmwsiprpuwgt7cmOEjDlPvE n f8A642gzGaZ0Om2SW1qt1dRKpjXCRqPu 38qpNt3ZnJ2Vhn7ySd5pmDSuPujog9BSqS5S6cepnatZpeKtttwI0Z0I7H0rCLuay0OVsbhY2huXU/Zx8zgHOMdsVra225DatqiZ7eSHSnkYg3epDz3Ufwx5yPzya1Ubsx6aFa0he4fyrQEMwweMAduaq9hNX2Idc002FlZSbg4maT5s9cbefpzUrULWPT8c1SMRDTGIaBCGiwXExSHcaRTuA0ikMm0sEXlxJyQseP8/lR0Gi3APkFWtiCyopMB4FIaQ4VJohaBhQAUAFABQAUAFAFK4 a5/3VxQJkZFMQYoGGKQCYpABoGJjnFAHPeJtYMZOm2j4c4891PKg9qqKNErnJXMgjj2KMAVRb0RL4TtRd60bh/uWq7vqx6f1rKbsRBXdzrrlixya53qbIzJ tSVsQKPmq0hNl2PlahqzGh2cUDHCpYwBOaVxj1NJgBNIQ0ntTGC4XA7UILkq4FFhCktQO5KjHuTQA7PemA4SetCAdvHc0rahcNwPTPHtVDsG4DFIBwlVeHBKE8kdV96E7aMlrqglWTaHhxNGe69R9RTTFcqsDKxAx9PSmPQRLZ8c4/CrvZCHCDaeRUOTY7EigChITQ7HRumKNtwJ9PsvtU/msD5aHOT3NawjzamEpdh r3K25QuQRnEMIP3j/AHj7VrOSiiIwcmU4ncoWLAueSa5d9WdKVildzXSX9sY13xfN5uB0GOtVCxE2zjI7CacWdovmKk0qRlihGCev1xz VdCepi72Oou9s p3DqBsQiGMAdFUYx eaSNFEngWYfIiKS3AI4obuNoyvHdr9i07RoC2Sqyg8/7lOBjJWZ25rVHOJQFxKAEpgIakY0imA00gJtLP jXkvUFtufpxTa2HF6F NdqgVRBKtSykOFIpDqRYtABQAUAFABQAUAFAFF/muJD7gU0SJiiwBikAYoATFAAFLHAoGjA1zxALUvaabiS56PLjKxf4mmotlpdjkuIVPJd2OWc8lj65rS1jVKy0M 9f5SaTImzqvClsLbRlkP352Ln6dq5Zu5cFZGjKcnPpWLNChODk 9CQyFfvYq0Sy2h WokUthakYuaQ0Lmi49xQcVLAGamMTOTQIRge1NCJEbjmiwyXOaaJF3UWGOXjpSC4EjNFxomTBHb60XEKBn6UwsKFFKw2xwAxxT0C4ioFfcvDeooshEpkBA86JZPdRhqfM onHsJiFh8lx5ZP8Mo/rVJpivJdBHt7nGUiEo9Y3B/nily9g50RLFOfvW0y/Vf8KqwXRZhgdvLyhCqQcEHJp8t2ZTk7E19rNtaR XBGZJsf6teMfWrc1FWREYuWphxpLcXDXFw3mTP1PZR/dHtXPKV3qdMVZWNKGMDgikMZPFt YDqCPzFNOxLRlaNpEaRz6tO8plsGkWKMEbAAvp J/StVJ9DGW5X0 JzaQs4/eOoYjuSeablqa9DesbXyE3kZkxxn1ouS9Ec58S4hGmlsCSW80knj 5W0VZHO79Tr60sYWCmMSkAUCEIpDGkVQDTUgWLEbdNJA4klJ/X/AOtTe5XQuqKozJBUlIcBSKSFpFi0AFABQAUAFABQAUAUl Ys3qxNNEi4pgBqQExTTAZPLDawNPcyLFEoyWY4pblJHI614jlvlNtY77e2P3pOjyew9B tWolqNzDLLGmyMbR1PvVGvkiCR8ihsHoUbw/uyR1qWZSO709Vi021QdPLB/SuKb1N4rQdIahllKahCZCg aquJIsBqktCg0rjAmgA3VKQIA9MY/ORQAA0AOzzikSKCOlNMdiVelNkoD7UhjQ/OKGA8nPPQgYzSGiZG UYA9Dg00Kw4SA5API61QahuJPU49KQx4aiwhwkUHnpSAGcdadhkTvxjipZSKzxxk5A2k/3Tt/lRqLQFmli VLuYfV8/wA6Tv3Jsh  VlIkuZnB7F6NX1FZCQ2 77gC571SVh3LccQQACgaJoxg470WuDJJU3REHoOTTsSRQoPs15atwJwSrdicYxVRk7NGbjaVyJbVYGGVCd9tJaLU00LsGZZUxwEYMzf0rSCuzKbOI I96Lq to0YNHDvAwO/y5roRzncVaMQpjENKwCUxAaQxppiIpjtjYjsDSQzQt1KWVqhxyN39f60dSm9CytNmY4UikPFSaIWgYUAFABQAUAFABQAhOASe1AFOIfu1/OqIJNhxnoPU0h2MS98VaTZzGFXku5QcFYBkD6npTUWwbSM5fHcEzFbbSrhmA/jYKBT9mylrsc9e3d3qlwbjUZi2D 7hU4RPoP6/wCRXLbc1jHuQM4HAouaETNmmBG1SxFe6G6Jh7VJnI7XTJPN0qzf1hUH8BXDNe8bxeiJmNSyiu65oGQ45poQE4piHI1S0ULnmhAGaLhcCO9BSHryKTC48ClYVxaLAAw2RQDZInyjA6VQDs0mhDSOaENMctNIkchIpWsxseOh7Z64qrgIH2sF65pMB6vnsaAHbgOTRcBskoApbjK0k1DHcg3vJ0OKqIrkgjfGdufpQ0K4sSM3zPkKO1HL3BmjCf4R6UNAWABUtCHDrxTGShcjB78GmhFCJyNyZyyHHNIbRdErCJjuUgDOHGRVpsyY GwjubdZZA0LNziFioxWsKa J7mEpXOM JNpDZxaXHAm0HziT3J TrWqJOyqzFhQMSgQlFhiGgBpoJIbj/Ut78U7FGsVKtEn9xMUluVIlAoIHCkUhwpFoWgYUAFABQA1mVFLMwVQMkk4AFAHO3XjTTYZSkCy3ODgtGBt/M/5/WrUGyHNI19L1O11W28 1fIBwynhlPoR2qWrOxSdy1MwWF2ZgoCnJJwBSBnE6x428pjb6LEsu3Km5f7v4Dv9auMXIluxyV7qV9eHdeX08rem4hR A4rTlUSdyolw0a7FO1fbimpW2HY0YXKWygE5bkmmzogtBCxqHqabDCahhcYWppiuIXFIGyGUhlIoMpO51HhuXzNGhBPMZZSPxrkqaM6KbvE0zzXO2WRScCmBXPFXsDIyaQArc0wJN1TYYMfSlYBQcimMmQACpbBki4piuKV9KBpjduG3Dv1oJY4UholHSmIYwxQtQDkU0gHA0MaHUkAgByKoRIeOaBDC5AO7HtgUmiivK9BRVlkI7807CuWbJCw57nihiZrwW8aryQfU55pkj5Yw4x2x3pMaIIkKcZyRxTVrAywvTNIY5etIGTKaYmZU2YtUuVP3WKuPxH/1qT0COxLJJhFQE5kYCmmZ1NEdGFAUKOgGK7LaHMef/FT/AJhf/bX/ANkoQHXMpU81Zk0JTAQ0JCuIaAA0hjSKAsQSrvaNP77haaDqa7c3DewApLYJbj6BDhSLQ6kWLQAUAFADXdY0LuwVVGSScACgDznxV4lbWJTYae7LYof3ko480 n 7/OtIQ5mRKVjDBRQFRRwMCupK2iMi9pGsXWgXMs8EfnxSrh4mfbz2b lZVYt7FRkluRax4j1LWk2XUq29r3hi43fU96zVPuXcyjJhQqDCjpWqdkTYick1L1BaDAvzfNmpaaNEaKyKEAFO hstBjTAVNgc7ERmNFiOYYzk96Ym2xA1IWoE0AbXhibYZ4j/eDc 9ctZG9LY6QNxXKbjHIK9KAKsh5qkIgLYNArihhxSK0JAaYDgaQrjxigY8DNSMnC9KYiTjFJgNqhMUUhjqBCnIQkAn2FFhoMZp3EHltnJyDTuFx33eDU7jDGTmnsJiGi4EUp4607lJEOzPPagCjcnDY7HimkDNKycBQaWwjSWYY60gHeZkZxRcaQ0t82e1FxD0kzxQOxKrAmiwh4YUBuY qyMNaQKePs4OP BGqerF0JrT99L5mMrDj8ycCrhHUwqO6OpJwK6TE8/wDimc/2Xxj/AFv/ALJSTuBR8LeK3tpUsNSk8y2b5Y5m6x x9v5VadyWjvCMdOh6VSM2JSAQ8UAJSGNYUAxiLvvbdf8Ab3flTuOJqLzI7H1xSWwpbj6AHipNELQMKAILm7trRN9zPFCvXLsBTtcLmBf NtNt8paLJdyf7A2r JNUoNkuRyWq6rqWtnF5II7bORBEcKfqe9axp9yOZvYobEjXaAAK3SSRLTK81xtBVFGT3PaplJLYFBvcqNKxPLVm5NlctiPec4HNQ5FpXHhWbqcUOVylAQxnHWpuPlG8ihS7k8pJuOKsV7CFiaQ73DNAITNILiinYLi0mBf0iXyrvGeGHSsK0bo1pS1OpilDID61xbHUOY5FAFaXiqEVXNJCY1Sex5qmSTxucc9allpkgNAxwpXFYsRnAoZROpyKLXEPCjGMnNAk2KVoAFWhK4xxQg9eKdiQHHBpFBjmgBQSKTYCE5qkIF57UMbYGkwSE8vceRmiwxWj4IouBQurEzRkDqOQarmGzPt7t4JTHOrKwOOOQabRFzSjv4toJlQZ9WxU2KRMt/B1EqfUNSsDZL9siZcrKjfQ5qrAmOS4z0JqXoMlS465bFIXqTpMDjmnuFkjMmgu7rUpZhEqxhQiHf2H/wCs/wCelEamtaQrbWix5DPvDvjvz0q4ySMpwZpyXSyKAqv1z0xWjqJkcjRwvxNcuNM4x/rf/ZKqDvcmSa3MKawsZA23ejnng8A/4VtYlnUeH/EttFYxWWqTGKaL5FkKnayjpz9O9MzaOoheO4j8yCVJU6ZRgabEkKRSsIbihgIRSHuJaJnUlP8AdQt/Sh7DjuaEQJXJ7nNAWuYeseL9O0x/IiP2u4zgpGRhfqe1Ci2Votjm7jxlrM5/cm2tVzgfLuJ/P/P9NFT7he5Tk8R68SD/AGkDnj5I1q/ZoV2MbW9ckOJNRm2/7GFP6UezQrsq7Xd90haZzzvkbd hrRKKE0x APvAYH5U20K1yCe8G7ap5rJs0SSKssxPU0X7jsio8mTxWTYDMk96QDlYCmUtB/mikyk0O3gigdyNiM0CYoPFUZhmgLBmgEJnFIQA07jHVNx2JLeQxzK45wameqKhozqLSXK8HiuBrU6kW93FBRBKaBMquaaRJHuwaYEivUtDROrZHWgZIppDRMjUAWIzSYWJlNMB/Wp3HYdjFWtBCcg9eKaZI1jSuUIG9aQ7C7gRiiwhpODTWgh4JouOw4CkMkXAFAIDikMZjmpEZ2o2gkUSqMMDzjuK1TJZkS2ynnaD9RWlyWVpIY1yRGufpQmKyK3mJE2VUKfUcVW4r2NW01aAoN06A/7RxWcostSTJZdZiUZDK eAF7mp5ehSkupr6fHf3UQfyPKU8jef6Ur9EFzXisZON0ij2xTsQ2XUhwBlh VGxLkTLESODgUbkORwnxOTZ/ZnzZz5vb/crekrXIlK5zEcjMea6Sbk3m4PGM 4p2J3JILh7NxPb3X2Rx2BwD H f5U7W3Fym3B49mSMJJZC8kH8akpn8MGk7dAUWxT8QJlPz6Qqj/fP FIfL5E8fjyFhmXTsf7so/wqlFPqK1hP E8gjlMsFhJuZNuGb7vPX3p8lxN2Zn6l4qvtRh8tbpYom Vo4flOPcnn/P5NQXURhKRGMDB9T61olbYYokzgdqaC5IrHPQn6VSYXJgTjJVh FIlh55QZUgH3NDaGkVZGeViXlwPxFQ4jTIWdE7ip0QFZ5C59qhu7KEFFhXEzUsYA0gAmgYoNACGgB6mqTEKelPcbAZoEkHWlYY5Vp2AdtJotYLiAEHjrSauhcxvafL 7U tcVSNmdUXdGmrZFZN2NEMk6UhlRyc1aJZGWpiANzSsBMsmKXKO5Mr0gTJg3ShOxRZjbAoYFgNn0pCHqwPShIbY/f6miwkg3UMLDTSGhpFFxiZqkJijGeaTAcGFIB4bjJxRYYeZx1ptCuMMnvRYAE/HODRYLkE0gPLYGfyqkgSM cDdx NAmZt0 0E1cSGzGmk3PtHJrZGTYqQ/LlgCOvNFx20Oi8M6WqsbydFL/8ALJB/D7/Ws5y6FwjbVncWpLRgt1rDzNGWwRjiqMh6EDrT0IaZLvFVzWJscD8Ujn y/wDtr/7JWtOV7ktHLxRsxwoya6IpsW5djtFQbnbLfyrZQS3NFEkzCvPlRFh0YqCRT3G4oVrtsfeNJpFrQje6ZgQzEj3oSQmU5IY5OgAPtSa6kuKZVYywHnJX1pczRi4WHCYOOatSTJ1GmVcc03JBYZ9pC9Fyfeo57bByjWnc gqedsdkhhdj1Y/nSuwAdc7j dO1xXHde5/OnYLjTSAQ0mhgBmiwriFaVhjaljCkMWmAUASRgEVcUmTcl2iqtYdw UUtAE3LT0EJvFK6HYPMouDQ0vzSuKxp6XNu3IT93pXNV7nRSd1Y3Im4rle5umOYUWArTLzQhFZqtANHWmIkU0mxkqvipSETI/rSa1GmTLKdwxTGXIGzQFywMdqkBDnOaewwNIYKSOCSfrSEIT2qku4xDQAEgUMTRGZMGqXmSwaTOCTSC41pM96AuJvNMYZyMGkBDcRiWPYemQePaqTFd3IXyFwBUsdjK1DIQ4q4kSKVpalzvYda0kyIo07exEsiKRxntUXuUdTboqRqEACgcYrNmiZo20mEA79Km1gbuWkcmhCaJVJ65qiGh/mD60E8rOE JrBv7Mx283/2StqPUiasZoVIhhOnqe9ehFWKSsMd uabdx7FdzzmkBEz0gvoML0XsTcN BUjEMmaCStNt6gc1N9SZIh61RkBFJoExKLDEpAGaEwDdTbCwqtzzQpA0OYimShN1HMOwm6k5DsIal6jQmakYUAANADlbFNOwDtxptgNzSuMKBC0AFMAoEWLObyLlHxx91vpUzV0VB2Z0sLdvSuFppnUix1FK5RDIM0EsqSKATjvVgR0MBA1Ax6tQImVuakCzEwoZSZajbApAWVkpDHhwaBCZ5oGFADGJ3cUxis3FAFdpu54pktlaW7VM9WPoKqwiidahDlZoZk9SOapQ7EXXUmh1Wwdgi3GD6FCKfLIFKPQuieEDmValotNC/arcj5ZMke1TZlXuQyahaqMCQlvTaaErku1yjPqH91fzpqDByM4NLe3AQcKOWI/lWijZGd22bMNuFUAL9BWbKNK2gCAcAH2qbjNCIFRjFG4bE3miNSx4A5JoaGhYL6W4bbaQPLjq MKPxrO/RFXXUnFtqzn5pLaJSfUsRTcZNEOpEmTTbo/e1DP0iFJU5dZCdVdEcb8R7Z7f zt85l3ebjK4x9yuqjHlvqYzlzGMbtW4Br0BqSYwyZ70hjS9DC4wnNSg3Gk4oYrDGcCkJsheX0oJk xEzE9aRI0HmhMloeelVcSG1JQlIQlIYUAA60IBxqxCCkAUmMSpAMUDCgBKAFBoAfVAJQAUAFAC5oAUkYpAxAaYjoNNuPMiUk/MOGrjqqzOqDujUU1maCPUNjKsq56VUSWV24NXcBtAh1AxVJpCLET80NAXEfIqUUTK4xSGh6yc8VQWJA47mpHYA aBWFJouBG78VQFWQFjRYGQmHNO4WK89h5gyuA3uKpMVijNZOuVZKvmJ5UQOkyqcTSqOuN3FUrE8uuhCzXSniVx AoTXYTT7iC5uh1kB qinp2FaXcb5s8ziMEc9SB0p6WFrexuWECwxAKPxrFtmiVjUtk3HJ7VDZVjThTAosIn4C5PakD1KjlbqUBzmFTyB/Ef8KHsFjXtLpQVjUKoA6L0qU7DauXvMyM9qsz5RytkZFAmjhvieeNM/7a/wDslbUupnI4zdiu  hkL5pFJFczHLN60MakSbxiodzVMiebHFIhyIWcmmRcbmgQUgENAD15WqSuiXuNNTYYlKwwpAJQAooQDjV2EJSAQ1LGJSGANAD KoQhFDBDR1pDH9qdhBSGFMApAFACGgABpiNDS59kxjPRun1rGpG6Nacuh0ET5Fc2x0IkPNTYZC44oJZVcVaAjzzTAcDSsJi0xj42waTGWoyCQe9SO5YBoGKrEHFG4mxxY0kCY9W4p2He48vxSsAzOetAXF2jFCC4mzFMB20Y6UWBFeaHPIqr2HZFKROckDPvzVLUViBokPUCqt2EVLmFFQt6c0ESCwtxuLY5NKT6CStqbkSbVAHWoGi7CuABSGX4zheaQiC4lLuIkJyf0FDuUPiQKgA4xQIsW5 bn8KllF9Z8cZ4pXfQdkSpLVEtI4v4ktu/s3/tr/7JW9HqYVDjK7TAKYCZpXANxpXHdiE5oAKkApgFACUgHwvtJB6Gqi9SZK4r4zxVOwlcbilYdxCKlodxtSMUU0A41VyRtSUFIBtIYUgFzTAM0wCkA4dKaAKACgAoAKAFoATFMRJGxR1cdVOaLXQJ2Z0ltIGUMvQjNcE1ZnXFlsHiosXcY1CQMgdaokrsMVaBobnFAh46UhoUUATRtzQBZQmkxj8nPFIdh6knrSY7EoFNCFwcUMa1AClcLDxQOwuKGAZxQIRiCMUahcqyxA1YXKEyFDjn61cWJoz7lS6kZ60XIZdtPlxUtgzRiO9/pQNI0IhxUXGxZphFETyT2FMVh1rE0aEv99 W9vagNh5bZ1PBocRj0JHI60rCdydG55NNaDTLCOB3qXqByPxDk3/2eM5I8zv/ALtb0epjV6HImu05xCalsY0mpASmAuaLgGaQwoAXNACU7isJSAXNO4Bmi4WFzTuKwdaQCY5oSHck2nHSrcdCbjMVFhiGkMbSGFIBaYBQAUASxgEc1SQDygxTSGN2inYQu0CpaGJxTQg4ouA0kUEgGxSuFjW0mcMpToV7e1c9aPU6KWqsbKHIrmN7CtSERSCmgK7LTvYCFlNNMVhAxqrAPBouIkU4NK40WUekw6kynNSWTJ1pNgTAUIVrikZFJlLQaBg0CZIKYCmkMidsGmmBC0lUgIJLkL1qiGU5rvcpwMDPSmkIo7jLcKuM/wBKtInqaCxmNQR261Ml1H5Fu2cbvpUu4zSVwBzU3Ait3NxOzHGxCQPrQyi Dk0IloGUEYIyKdxWBQFHXGKT0KQ5m4pAZ17q6WwwWJPYCnbsNuxyev6g188O/GU3cD3x/hW9JWuYVXexlk11NmA01IBQAUDCi4BQIKAFoAKBhikAlMQUAFABQAobFNMTRL5ny1tzKxHLqRk1k2XYaTU3GJSGFIApgLQAUAKpxTTAduNFxibjRcAyaLiDNACZpAFABTAntJzb3CyjtwfcVMldDi VnTROCAykFW5UiuOSsdaZJnA5pXENNIZGwp6ARsuaLiIHUjpV3Cw0NjrTESK1IZMjUrhYsRtxSHcnV8GosO5ZjOafQaJcVIAFoC4YxTGFAkNZMihoZBJF3oQWKssAYGqFYpSW4HXNVzMnYLW3XzC2OelNyCxqeV8h46VaYmiiCY5iM9amSQtiaS5by8D7x4FQhpl 1TyYETvjLH1NSyi8jAiqJFage5BLcLGOtFrgjGv9XYApE4U/3vSmo3JcihYabe65c5iJWLOHnboB7eprTSJnZyJPF mWmlwafDarz 83yH7zn5etVTbd7iqJK1jmq3MQoAKYBSGFABQAUCFFADgtWohcU8UARnrUMApDCgApiCgB2eKoQ2pGJSGFABQAUALQAlACjrQA6mAUAJSAWmAlAxDSEFMQ4GgDU0m5wfIZsDqtYVY9TenLobCtkc1z6GohOKYCE0h3G5pk2GsuRQFiuyEn3pphYYMqeasRMr1NhplhHGKQyRZKQFqGUdM0miky2kgPBNKwXJRg0AIeaAGCjQYu4YoAidgRTasMgkouBWkANNEMS2XcX28lDyBTYky8z7YGJGARjJ7VS1QjFZw8pZDuAGM1o46CunsWIsF4y2SAwNZeQbGqpJ75qC73LEZwOadxDJ59g60DOd1TUvvYOAOM/wB6rjG5EpJFjRfD019tudRHlW ciLoz/X2qm1HREqLe52CCOCMRwqqRqMBVGAKy3LOO8dNuNl/20/8AZa3pmVQ5UiumxiJUjCgBKACgAoAWgBRTQh 7itObQQwtmobGNqBi0AFACUwFoAXtVdCRDUsoSpAKACmAuKdgFxQAbaLANpAPHSmAlIApgGaADNAAaQCUwCgB6MVYMOo5FG4J2Nu1ufNiDZ5rklCzOiLui0HyKhooQtzQNAG5oGPHNIQm0U0IjeIGmgIHRl6VSYmhUkI4NNpCTJkkqLFXJ45OetFguWklIxSG2WBOcDBosFxTKx6HB9aOVDuBlNKwXED8UWC40sOlOw7kbtxTSE2VmOTgU7CuYlxqM1vqBltJdjJ8u4AEH8O9dEYaanM5a3Q9tYvL4eXdTBk/uhAK0hFIynJstWrKy4AAA7DtRVVkb0noWGyi7h25rndjU0reYSRhgQQaykUTNLikhGVqN2VRiTirSuJuyF0DSRPML69UMB/qouoHuaqUraIUVf3mdYz/ACjpj2rItkZfNMRyXjY5Nn/wP/2WtaXUyqHM9a69zAQikxjakYUAFABQAoFMQUAGaQBQMSkAUAFABQAChAO7VRI2pZQUgCgAoAKdwFzTAXNFwENJgKKAFxTsAlABikAUwCgBMUAFAhRQBZs5vKkwxwrfzqJq6LhKzsawYrwetcu50C76aQXHA5osMkU1LGSCgQpFICNgKoZE0YNFySGV1hUszAAVS1E2kLDcLINyNkU5J9QTuW45feosMnEoI60bEscJsd6YwMue9AB5/NFkFx3mcUBcjZ8gnsKY2ZOo6kqo0MB3O3DOP4R6D3rWMO5jKV9EYtamZJETuFVElo17B185EZtpk4BPTPpTqq8SqbszaSA7zG6kN0we9cSZ0XuUrGcAugYEByB6dabiNMtySELxU2G2Yt6XuZ1hVsZIJHt61pFWId2dRZMEXavQVk5alKNjQMoKCi5ViLdTuBzHjM5 x/8AA/8A2WtKXUyq9Dm66UYC9aoQhFS0O42kMWgAApiFNADaTGFIApgFIAoAKACkAopgOPSq6EjKgoKACmAUgCmAUALQAlADloAdtNMdh2w0DsJsNMOUNhosKwbKTHYaRigkMUAGKQC44piL1rcF0Ebn5kGB7isJws7m0ZXViyGqLFEqPScS0yRWpWC9x 7ApDF8zFAXGmQU7AQSThR1osQzIu7gzSY/hFbwjYxk7kUcrxPujbBqmriTsXItVkXHmRo49uKh00UptFpNVtz1WRD BFLkZXOhx1K3/vuf A0lTY dB/aUWCVLH/gNP2chOohBq6D/AJZMffOKPYsFUGvrLFcJD Lt0/KmqQnPyKdxeTTjDOQv91TxWigkQ5NlU0xDaAHp1qokst5zDhulbNXRC3L8GuaqIfs63YMeMZZAWx9cVh7FN3NXJ2CyTagVTyves6i5TWGxpAsydOax6lorxWUwE0z43gfKPaquUW7OclRis5JDRoCUkCpsFyRXyKLD2Oa8WyxyNaqkiuy79205x0/wrakrXMKjvY5 ugyAGmId1qhCEVNhhRYBM0MBKm4woAKACmAUgChALQAlADlGapITHMOKbQIjqGMKQBTAKQBQAUwFoASgBydaBomFDNELTTAXFFwClcdgp7iIn60GbG5p3EGaQBmlcBY3KSBh2pPUE7GkjrIoZe9YWszfdXJVbFJjTHh6QxTJSsO40yUxXI2lwKaC5SuZzjAPJq4q5nKRTrUyCgAoAKAFFMCRelUmKw0mlcYoNNMANDEMNSAlIY9TirTsJon3fu6u5KWpLbYJ61UdRsuWzNa3KeYB5UvRvesq0bo0pu2hvLESOFPHXiuK5uEeWXp9RVXHYqwxeS5RQQo6UPUV7F4MqJudgq pNSrjbtqZN1rkRuREibrccO eTnuPpVqGhjKaZlavFaRCEWd0JlO7K45Tp/n8K0iQZtaiCgBQaaESoAetWiGNcAUmNEdQWFIAoAKACgAoAUUAFABTAetUhMRjQ2AysxhQAUwCkAUAFMBaAA0AC9aQ0Sg0yx2aGMM0guGaBibqdyRjHJoIYwmgQmaQBQAoNAE9vL5ZwehpSjcqLsXFfIrHY2F3UABekAwvTQiGWXaKaVyXKxUYljk1qlYzYlMQUAFABQAopgSr92mtgGGgAAoAXBp6gMak0AlSAopoRIT8tWwRJE20ZoiwZct5lZDFINyN1Fa3uRsS3Ml20AjW5klgTkIcfr61nKklqVzssWetrHCBLBJI/TKng/WsnT5jRVX1J49ajkLGW2MOBnIO7NQ6TSH7UyiLvWNQhhU/PcPtRXbCiiKsQ5NvU2ZPAmuwLmNbWY/3Ukwf1AptXAzfEGhTaLbWRulYXE5cvlgRxtwBj600BiVQC0ALirsIXOKL2FYQnNJsYlIYlIAoAKACkAUAFMAoAKAJF6VaEMbrUtjEqQCgBRTACKQ7CUCCmAuKAA0AJSAkBpli5pDbDdigVxpagLiFqCbjaBBQAUAFAF 1soryALBIxuuT5Zx83oAOpP8AjT0tdlct9ijyDg8EUJkk8UhHB6VElcuMrE2 s7GlxC1FhXGl6dhXK8hya0RDGUyQoAKACgAoAUUASryKsQhAoGGcU0IN1PmAYxyazbuMbSAUUwHg/LVE9RQcLTQyWBhnGatMmRbSUgjB5Fa3RI6WHcnmIef4hioaFcrqcVDWhWxrjT5IhDLbzAPGRKrMOhHP f8AJrkbsx6rU1det5Jp7bU7Wa5UXq7SsMhBSXg4/Q/TH5ac3Quz6GD4msNWsRa/2rcSTBwxiDzGTb0z16dRQpXCzW5hUwCgAzTuAUgCgAoAKACgAoAKACgAoAKACgAyfWgAoAKACgAoAKACgAoAMmgAoAKADNABk tABQAUAFABQAUAFABQA6OR4pFkidkdTkMpwR NAbA7tI7O7FnY5ZmOST6mgBuaAF3N/eP50rDuw3N/eP50WQXYbj6mnYLiUCCgAoAKACgAoAKAFyfU0AJk tABmgAzQAUAFABQAZPrQAZPrRcBQSOhIp3AXzH/AL7fnRzPuKyF82TGPMf/AL6NPmfcLITzH/vt dK7HYk 2XW3b9pmwBjG81NkBONY1MIqDUbsKvRRO2B tFkO7Irq u73b9rup7jZnb5shbbnrjP0piP/2Q==";
            base64Code = base64Code.Replace(" ", "+");
            //Base64StringToImage(base64Code);
            string fileDir = string.Empty;
            string filePath = string.Empty;
            DNTRequest.Base64StringToImage(base64Code, ref fileDir, ref filePath);
        }

        #region MyRegion
        //图片转为base64编码的字符串
        protected string ImgToBase64String(string Imagefilename)
        {
            try
            {
                Bitmap bmp = new Bitmap(Imagefilename);

                MemoryStream ms = new MemoryStream();
                bmp.Save(ms, System.Drawing.Imaging.ImageFormat.Jpeg);
                byte[] arr = new byte[ms.Length];
                ms.Position = 0;
                ms.Read(arr, 0, (int)ms.Length);
                ms.Close();
                return Convert.ToBase64String(arr);
            }
            catch (Exception ex)
            {
                return null;
            }
        }

        //threeebase64编码的字符串转为图片
        protected Bitmap Base64StringToImage(string base64Code)
        {
            try
            {
                string sPath = AppDomain.CurrentDomain.SetupInformation.ApplicationBase;
                if (sPath.Substring(sPath.Length - 1, 1) != "\\")
                {
                    sPath += "\\";
                }
                if (!Directory.Exists(sPath + "Temp"))
                {
                    Directory.CreateDirectory(sPath + "Temp");
                }

                string sFileName = sPath + "Temp\\" + DateTime.Now.ToString("yyyyMMddHHmmssffff");

                byte[] arr = Convert.FromBase64String(base64Code);
                MemoryStream ms = new MemoryStream(arr);
                Bitmap bmp = new Bitmap(ms);

                string f1 = sFileName + ".jpg";
                string f2 = sFileName + ".bmp";
                string f3 = sFileName + ".gif";
                string f4 = sFileName + ".png";

                bmp.Save(sFileName + ".jpg", ImageFormat.Jpeg);
                bmp.Save(sFileName + ".bmp", ImageFormat.Bmp);
                bmp.Save(sFileName + ".gif", ImageFormat.Gif);
                bmp.Save(sFileName + ".png", ImageFormat.Png);
                ms.Close();

                #region 读取本地文件

                FileStream fs = new FileStream(f1, FileMode.Open, FileAccess.Read);
                BinaryReader br = new BinaryReader(fs);
                byte[] photo = br.ReadBytes((int)fs.Length);
                br.Close();
                fs.Close();

                Copy(photo);

                #endregion

                return bmp;
            }
            catch (Exception ex)
            {
                Response.Write(ex.Message);
                return null;
            }
        }

        protected Bitmap Copy(byte[] arr)
        {
            try
            {
                string sPath = AppDomain.CurrentDomain.SetupInformation.ApplicationBase;
                if (sPath.Substring(sPath.Length - 1, 1) != "\\")
                {
                    sPath += "\\";
                }
                if (!Directory.Exists(sPath + "Temp\\Temp"))
                {
                    Directory.CreateDirectory(sPath + "Temp\\Temp");
                }

                string sFileName = sPath + "Temp\\Temp\\" + DateTime.Now.ToString("yyyyMMddHHmmssffff");

                MemoryStream ms = new MemoryStream(arr);
                Bitmap bmp = new Bitmap(ms);

                string f1 = sFileName + ".jpg";
                string f2 = sFileName + ".bmp";
                string f3 = sFileName + ".gif";
                string f4 = sFileName + ".png";

                bmp.Save(sFileName + ".jpg", ImageFormat.Jpeg);
                bmp.Save(sFileName + ".bmp", ImageFormat.Bmp);
                bmp.Save(sFileName + ".gif", ImageFormat.Gif);
                bmp.Save(sFileName + ".png", ImageFormat.Png);
                ms.Close();

                return bmp;
            }
            catch (Exception ex)
            {
                Response.Write(ex.Message);
                return null;
            }
        }
        #endregion
    }
}