<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="Kit.aspx.cs" Inherits="BWJS.WebApp.Test.cfs.Kit" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
<meta http-equiv="Content-Type" content="text/html; charset=utf-8"/>
    <title></title>
      <script type="text/javascript">
   

      function GetStr() {
         var a=document.getElementById("ucBrowser").GetStr();
         alert(a);
      }
       function  SetUrl(strUrl)
       { 
           document.getElementById("ucBrowser").SetUrl(strUrl);
       }
    </script>
    <style type="text/css">
       
        #ucBrowser {
            height: 480px;
            width: 1024px;
        }
       
    </style>
</head>
<body>
    <form id="form1" runat="server">
    <div>
     <object classid="clsid:6a501d33-a734-4568-b8b0-4bc507400a81" id="ucBrowser"></object>

        
        <br />
         <input id="Button0" type="button" value="GetStr" onclick="GetStr()"/>
        <br />
      
                    <input id="Button1" type="button" value="社保" class="btn btn-default" onclick="SetUrl('https://tianji.rong360.com/tianjiwapreport/login?data=nD%2BRaNTUBXKJrM1QPpIetHZv%2BlmDDqYSmqTy5PE3BgFDznpmN3UeqFv17guxejLG4nNRU1bQkyF8o0jOrRz9IA3%2B5NwxBCbLfK1iG97uaRIyPt7CpUgYKNCUkpAID7Bp6KaKsyyQhc7o0j%2Bt9z%2FEf2ndmxl3dSZ7L4AEkGyS7BtFIJuipVZ1X6S5gxwJjCgDxILcIUlHYuN%2FFuj%2FksOZMA%2B%2BDBCQ2QshpCFTOkb%2F%2FUERCTEDhKbvx88yTDWU4zgz')" />
                    <input id="Button2" type="button" value="京东" class="btn btn-default" onclick="SetUrl('https://tianji.rong360.com/tianjiwapreport/login?data=nD%2BRaNTUBXKJrM1QPpIetGZIAU%2Bz5fjQWsSkUFo9nsbI2n7Utz4sDrlYyOKdFNPkdwvIkKnkU0XteCKRDrxJa91D4wqhLf40EYQZ7ldqYYzGxGv9AT9XijOhUfZuriHghW98fdMHhRQuUsM8DS2%2F9UtLMA7RPb%2Fo1lEoaCuKILknoF9RFhYJXBzeMeYRwrIWKea%2ByuMaeVqT64Wr9CXljnZ0a4PezF7tcHiolJXccYbdxQR4OGUQvtcImP%2BO0Shh')" />
                    <input id="Button3" type="button" value="手机运营商" class="btn btn-default" onclick="SetUrl('https://tianji.rong360.com/tianjiwapreport/login?data=nD%2BRaNTUBXKJrM1QPpIetGaDepM8KaHwRbDWkHGkJo%2BYKSWSmFWbMOEIsdnQ8oDaj9d%2Fq7s7q%2F%2FtjAFQAac6edpKFGVEvBaLVmx5q8my47GhEjwZuepl5mRHMxdnmp8d1Ghy69I1al%2FVPJoeZKzauJx52SH0LH68l0L1M70sqTjL5R%2FemyoI%2F5nP4Dud0AiDSu%2F%2FQ3qhLXsw3S9iie5HPlaH%2Fa92fO%2FufdjQUSh6QVb92Rw9PorrdSAPUQdXo9xF')" />
                    <input id="Button4" type="button" value="支付宝" class="btn btn-default" onclick="SetUrl('https://tianji.rong360.com/tianjiwapreport/login?data=nD%2BRaNTUBXKJrM1QPpIetDbUGbN5%2F2Ln9QhEpHgn1SBe9eY8qzDk9tOmT8vDQIqPARXOIDLbML3E7ZEhcjIqzZSJ4hsyGrdnSckemOsQixxcw8NA5iSa7AhNSUHPMsoQ1%2BdGnll8HR2FRhczyBg9%2FWw3WfIjzdCJP2UfTztTiHE9311RIjDefEVzIaFBy%2B%2FCinKh387BQUgYEcOcfzBn9K%2FlDmOmUACxam1jxz9f4WtG6j9Gxnh71tCMTiimbdfA')" />
                    <input id="Button5" type="button" value="信用卡" class="btn btn-default" onclick="SetUrl('https://tianji.rong360.com/tianjiwapreport/login?data=nD%2BRaNTUBXKJrM1QPpIetAuaSbW%2BZQQ0KjYKygpaOGK%2Bak3uGPitfldiyOoJAetYe9DHyoLKeV0Dh360R5LYLmtnqsIFxnshW0OORCzBRiinRl0%2FPQTUzdRH71MeWgubPcQfdUsKoeH4QTFelcVd4lmxIb%2FO88%2FIM8mCGKK76mtWYYuXzsPKk5YHyQewK1avlM05iswuLnjWRtq82iX%2FcanQ128Oe5kjumUy%2FknElxa%2BkQaxemmR1z3lxGe%2B19tA')" />
                    <input id="Button6" type="button" value="网银" class="btn btn-default" onclick="SetUrl('https://tianji.rong360.com/tianjiwapreport/login?data=nD%2BRaNTUBXKJrM1QPpIetKz4SWRBI%2BwxU0sZmQLIqualmn2v6P6mUvWIyWbNKGn5W9CNpia%2Bs18ZwdkrPDjeDzEQPSDviG126%2FLaSwodcXBou1TM8nDwHFxJYNHb0%2FMSuHtQpZJ4FTo%2FhCk2L2Ek0Y5Te56Sb1uhOM8Htbt%2BEZkr4cGwEkk1wDacL%2FRfjLPZ%2FH%2FubYFjJ4E%2FzFhft5LZrlb%2Bh94HYu7LappPBNyeGDj%2BbSvh4M2KSVDWxz%2FiMjXK')" />
                    <input id="Button7" type="button" value="学信网" class="btn btn-default" onclick="SetUrl('https://tianji.rong360.com/tianjiwapreport/login?data=nD%2BRaNTUBXKJrM1QPpIetKJk6b5pFeoct0qasOOaxSESS1ATwwqozeyRoZNufcH1BGwJxTrs3YDsB%2FRPdRzQZY7hA7lJq4OrrfJxufm%2FnMEeYXug0HfN%2FnDFYVVR7Q%2BCBWIYWI9nWpSH9XI%2F7nZDAjvuSBpHiY%2FP7gOyBwjAE6qJjmeqqHULqQX3ptRaNrbots0BBFSgAXnoDvFVO2NYEbVabsnMNzegJDWy4P%2BvyV9%2FbymG%2Bq23h%2BjECDkSjKCL')" />
                    <input id="Button8" type="button" value="人行征信" class="btn btn-default" onclick="SetUrl('https://tianji.rong360.com/tianjiwapreport/login?data=nD%2BRaNTUBXKJrM1QPpIetGSxQwQL05O1Pp6Hb3Sb2y0Qs0RZuq1trn8W0%2Fsi7x1hktCO0l6TzgKVCkqWeN7a5B37cxYTiIbt52cHqyPjoOOlFLCXLwz7I3KQd9GvN754xEK2ZdxGPMg0LnbYYXwvvYqfwmYn65UaQXxG592Mb%2B4iBQ%2FlwBY3sQRZhlvf%2B8QACzcCTyPh3BSMxwBeY5OENzUZ1%2BY7OX2b4G9sEUPdEHaKgHdu0%2Fhe559w3aw3imLM')" />
                    <input id="Button9" type="button" value="公积金" class="btn btn-default" onclick="SetUrl('https://tianji.rong360.com/tianjiwapreport/login?data=nD%2BRaNTUBXKJrM1QPpIetOGA0fBjnmjTWwoaYHj8WGfdaPDaDW4WTADxgtXHIKHpYkVItx1FHbp%2B7xxlMloBPTvY37Y6lexOhI62Uc4A4rZmcw6We%2BEtzV0D%2BZnd6moGOx5rLVjq0gk9xpKPq40cLICivXDnPbXGU1OuKwSnfCq8gvea%2Fq1ke6c6hf%2FugpCSqY7j65Gu1wdJhT8Isa3Vm6T7%2FnlMqVfK%2F7olaYSVqndLwX9lQheFKJv1N9jJiEN4')" />

    </div>
    </form>
</body>
</html>
