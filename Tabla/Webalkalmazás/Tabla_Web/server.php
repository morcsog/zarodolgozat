<?php 
session_start();

$username = "";

$errors = array();

$db = new mysqli('127.0.0.1', 'root', '', 'tablaenaplo');
if($db->connect_errno){
    echo "Hiba az adatbázis betöltése közben";
    echo $db->connect_error;
    die();
}


if (isset($_POST['login'])) {
    $username =  $_POST['username'];
    
    $password =  $_POST['password'];

    if(empty($username)){
        array_push($errors, "Felhasználónév hiányzik");
    }
    if(empty($password)){
        array_push($errors, "Jelszó hiányzik");
    }
    if (count($errors)==0) {
        $base64 = base64_encode(sha1($password, true));
        $query = "SELECT * FROM login WHERE username='$username' AND password = '$base64'";
        $getDiakIDQuery = "SELECT login.DiakID, login.username, login.password FROM login WHERE login.username ='$username' AND login.password = '$base64'";
        $getDiakID=mysqli_query($db, $getDiakIDQuery);
        $DiakID = 0;
        while($rows=mysqli_fetch_array($getDiakID)){
            $DiakID =$rows['DiakID'];
        }
        
        $loginedQuery = "UPDATE diakok SET logined=1 WHERE ID='$DiakID'";
        $result = mysqli_query($db, $query);
        mysqli_query($db, $loginedQuery);
       
        if(mysqli_num_rows($result)==1){
            $_SESSION['username'] = $username;
            $_SESSION['succes'];
            header('location: index.php');
        }else{
            array_push($errors, "A felhasználónév/jelszó párosítás nem megfelelő");
            
        }
    }
}


if(isset($_GET['logout'])){
    $username =  $_SESSION['username'];
    $getDiakIDQuery = "SELECT login.DiakID, login.username FROM login WHERE login.username ='$username'";
    $getDiakID=mysqli_query($db, $getDiakIDQuery);
    $DiakID = 0;
    while($rows=mysqli_fetch_array($getDiakID)){
        $DiakID =$rows['DiakID'];
    }
        
    $loginedQuery = "UPDATE diakok SET logined=null WHERE ID='$DiakID'";
    mysqli_query($db, $loginedQuery);
    session_destroy();
    unset($_SESSION['username']);
    header('location: login.php');
}


?>