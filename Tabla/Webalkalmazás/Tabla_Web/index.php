<?php include('server.php');
if (empty($_SESSION['username'])) {
    header('location: login.php');
}

?>


<!DOCTYPE html>
<html lang="hu">

<head>
    <meta charset="UTF-8">
    <meta name="viewport" content="width=device-width, initial-scale=1.0">
    <title>Tábla napló</title>
    <!-- Bootsrap beszúrása -->
    <link rel="stylesheet" href="https://maxcdn.bootstrapcdn.com/bootstrap/3.4.1/css/bootstrap.min.css">
    <!-- Jquery beszúrása -->
    <script src="https://ajax.googleapis.com/ajax/libs/jquery/3.5.1/jquery.min.js"></script>
    <script src="https://maxcdn.bootstrapcdn.com/bootstrap/3.4.1/js/bootstrap.min.js"></script>
    <!-- A CSS-ek beszúrása -->
    <link rel="stylesheet" href="CSS/header.css">
    <link rel="stylesheet" href="CSS/navbar.css">
    <link rel="stylesheet" href="CSS/sidenav.css">
    <!-- Az indexScript beszúrása -->
    <script src="/Js/IndexScript.js"></script>
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
        <div class="content">
            <?php if (isset($_SESSION['succes'])) : ?>
                <div class="error succes">
                    <h3>
                        <?php
                        echo $_SESSION['succes'];
                        unset($_SESSION['succes']);

                        ?>
                    </h3>
                </div>
            <?php endif ?>

            <?php if (isset($_SESSION["username"])) : ?>
                <p>Üdvözlöm <strong><?php echo $_SESSION['username'];?></strong></p>
                <p> <a href="index.php?logout='1'">Kijelentkezés</a> </p>
            <?php endif ?>
        </div>
    </div>























</body>

</html>