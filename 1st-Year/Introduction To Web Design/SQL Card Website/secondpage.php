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
$sql = mysqli_query($connect, "SELECT * FROM `card` ORDER BY `card`.`#` DESC Limit 1");
$getdata = mysqli_fetch_row($sql);
$num = $getdata[1]; 
?>

<!DOCTYPE html>
<html lang="en">
<head>
<meta charset="utf-8">
<title>JavaScript form validation - checking non-empty</title>
<link rel='stylesheet' href='css/creditcard.css' type='text/css'/>
<script src="js/creditcard.js"></script>
</head>

<body onload='document.creditcard.cardnumber.focus()'>
<div class = "header">

<h1> You have sucessfully entred your credit card details
<br>
_________________________________________________________________________________________________________________________________ </h1>

<h1> Debit/Credit Card <img src="image/mastercard.png" alt="mastercard"></h1>

</div>

<h4> Your credit card is <?php echo $num ?> </h4>

<div class="mail">

</ul>
</form>
</div>
</body>
</html>
