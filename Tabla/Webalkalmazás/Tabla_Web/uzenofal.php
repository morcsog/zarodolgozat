<?php include('server.php');
if (empty($_SESSION['username'])) {
    header('location: login.php');
}
?>
<!DOCTYPE html>
<html lang="hu">

<head>
    <meta charset="UTF-8">
    <meta http-equiv="X-UA-Compatible" content="IE=edge">
    <meta name="viewport" content="width=device-width, initial-scale=1.0">
    <title>Tábla napló</title>
    <link rel="stylesheet" href="https://maxcdn.bootstrapcdn.com/bootstrap/3.4.1/css/bootstrap.min.css">
    <script src="https://ajax.googleapis.com/ajax/libs/jquery/3.5.1/jquery.min.js"></script>
    <script src="https://maxcdn.bootstrapcdn.com/bootstrap/3.4.1/js/bootstrap.min.js"></script>
    <link rel="stylesheet" href="CSS/navbar.css">
    <link rel="stylesheet" href="CSS/header.css">
    <link rel="stylesheet" href="CSS/sidenav.css">
    <link rel="stylesheet" href="CSS/uzenofal.css">    
</head>

<body>
    <div class="header">
        <div class="jumbotron text-center">
            <h1>Tábla e-napló</h1>
        </div>
    </div>

    <div class="sidenav">
        <br><br><br><br><br><br><br>
        <a href="index.php">Kezdőlap</a>
        <a href="jegyek.php">Jegyek</a>
        <a href="hianyzasok.php">Hiányzások</a>
        <a href="uzenofal.php">Üzenőfal</a>        
    </div>


    <div class="main">
        <div class="form">
            <form method="POST" action="uzenofal_action.php">
                <?php
                $sql = "SELECT tanarok.Nev FROM tanarok";
                $result = $db->query($sql);
                echo "<select name='item'>";
                echo "<option> -- Tanárok -- </option>";
                while (($row = mysqli_fetch_array($result))) {
                    echo "<option>$row[Nev]</option>";
                }
                echo "</select>";
                ?>
                <br><br>
                <textarea name="comment" placeholder="Ide írja üzenetét (max 500 karakter)"></textarea>
                <br><br>
                <button type="submit" name="submit" value="submit" class="btn">Elküldés</button>
            </form>
        </div>
    </div>



</body>

</html>