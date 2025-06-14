<!DOCTYPE html>

<html lang="en">
<head>
<meta charset="utf-8">


<title>Credit Card Form</title>
<link rel='stylesheet' href='css/creditcard.css' type='text/css'/>
</head>

<body onload='document.creditcard.credcard.focus()'>


<div class = "header">

<h1> Payment Options
<br>
_________________________________________________________________________________________________________________________________ </h1>

<h1> Debit/Credit Card <img src="image/mastercard.png" alt="mastercard"></h1>

</div>

<div class="mail">
<form name="creditcard" action="#" method="post">
<ul>
<h4> Card Number </h4>
<li><input type='text' name='credcard'/></li>
<li>&nbsp;</li>
<br>

<h4> Expiration Date </h4>

<select id="Years" name = 'Years'>
  <option value="2020">2020</option>
  <option value="2021">2021</option>
  <option value="2022">2022</option>
</select>

<select id="Months" name = 'Months'>
  <option value="01">01</option>
  <option value="02">02</option>
  <option value="03">03</option>
  <option value="04">04</option>
  <option value="05">05</option>
  <option value="06">06</option>
  <option value="07">07</option>
  <option value="08">08</option>
  <option value="09">09</option>
  <option value="10">10</option>
  <option value="11">11</option>
  <option value="12">12</option>
</select>

<h4> Security Code </h4>
<h6> (3-4 digit code normally on the back of your card) </h6>
<li><input type='text' name='CVV' style="margin-top: 50px; float: left;"></li>

<br>

<li class="submit"> <input type="submit" name="submit" value="Submit" id="ButtonSubmit" style="background-color: darkred; color: white; font-style: bold;"
onclick="cardnumber(document.creditcard.credcard)"
onclick="seccode(document.creditcard.CVV)"
onclick="sortcode(document.creditcard.Months)"
onclick="sortcode(document.creditcard.Years)">
</li>
<li>&nbsp;</li>

</ul>
</form>
</div>
<script src="js/creditcard.js"></script>
</body>
</html>


<?php

$servername = "localhost";
$username = "root";
$password = "";
$dbname = "creditcard";

$connect = mysqli_connect($servername, $username, $password, $dbname);

if (!$connect)
{
	die ("connnection failed: " .  mysqli_connect_error());
	exit();
}

$mysqli = new mysqli("localhost", "root", "", "creditcard");

if ($mysqli->connect_errno) {
 
   echo "Connection failed: ".$mysqli->connect_error;
   exit();
}

?>

<?php
 if (isset($_POST['submit']))
    {
      $Years = $_POST['Years'];
      $Months= $_POST['Months'];
      $expdate = "$Years-$Months-01";
      $seccode = $_POST['CVV'];
      $cardnumber =$_POST['credcard'];
      $sql = mysqli_query($connect, "SELECT * FROM `card` ORDER BY `card`.`#` DESC Limit 1");

     if($sql === false) 
      {
  		echo "error while executing mysql: " . mysqli_error($connect);
	  } 	

	 else 
	 {
       $getdata = mysqli_fetch_row($sql);
       $num = $getdata[0] + 1;
       $query = "INSERT INTO card VALUES ('$num','$cardnumber','$expdate','$seccode')";

     if($connect -> query($query) === TRUE)
     {
      header("Location: secondpage.php");
      exit();
     }

     else
     {
       echo "Error";
     }
     $connect -> close();
    }
  }
?>