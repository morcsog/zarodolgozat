<?php
include("server.php");
$uzenet = $_POST['comment'];
$selectedTanar = $_POST['item'];
$loginedQuery="SELECT ID FROM diakok WHERE logined=1";
$result=mysqli_query($db, $loginedQuery);
$id=0;
while($rows=mysqli_fetch_array($result)){
    $id=$rows['ID'];
}
if(isset($_POST['submit'])){
    $query = "INSERT INTO uzenetek (DiakID, TanarNev, uzenet) VALUES('".$id."','".$selectedTanar."','".$uzenet."')";
    mysqli_query($db, $query);
}
header('Location: uzenofal.php');



?>