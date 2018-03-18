<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="home.aspx.cs" Inherits="BWJS.WebPad.Product.NewSSKD.home" %>

<!DOCTYPE html>
<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
<meta http-equiv="Content-Type" content="text/html; charset=utf-8"/>
     <meta content="width=device-width,initial-scale=1.0,maximum-scale=1.0,user-scalable=no" id="viewport" name="viewport">
    <script src="/Scripts/jquery.min.js"></script>
    <link rel="stylesheet" href="../../Content/css/bootstrap.min.css" />
    <link rel="stylesheet" href="../../Content/css/NewSSKD/main.css" />
     <script src="/Scripts/pagecommon.js"></script>
    <title></title>
     <style>
        body,html{
            margin: 0;
            padding: 0;
            width: 100%;
            height: 100%;
            overflow-x: hidden;
        }
    </style>
    <script>
        $(document).ready(function () {
            $(".no2").click(function () {
                $(this).css("background", "url(../../../Content/img/NewSSKD/over2.png)");
                $(this).css("background-size", "100% 100%;");

            });
            $(".no4").click(function () {
                $(this).css("background", "url(../../../Content/img/NewSSKD/over4.png)");
                $(this).css("background-size", "100% 100%;");

            });
        });
    </script>

  
</head>
<body >
<div class="home">
    <div class="container-fluid">
       <div class="da-time text-center">
            <p id="shi"></p>
            <p id="show" class="data-time"></p>
        </div>
        <div class="col-lg-12 text-center">
            <div class="btn-box">
                <ul>
                   <a href="ToApplyForALoan.aspx">  <li class="no2" >工薪贷<span class="lb-dot"><img src="../../Content/img/NewSSKD/home-dot2.png" /></span></li></a>
                   <a href="housingLoan.aspx"><li class="no4">房 贷<span class="lb-dot"><img src="../../Content/img/NewSSKD/home-dot4.png" /></span></li></a> 
                </ul>
            </div>

        </div>
    </div>
</div>
</body>
</html>
   
