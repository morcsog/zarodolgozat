<?php include('server.php') ?>
<!DOCTYPE html>
<html lang="hu">
<head>
    <meta charset="UTF-8">
    <meta name="viewport" content="width=device-width, initial-scale=1.0">
    <title>Tábla napló</title>
    <link rel="stylesheet" href="https://maxcdn.bootstrapcdn.com/bootstrap/3.4.1/css/bootstrap.min.css">
  <script src="https://ajax.googleapis.com/ajax/libs/jquery/3.5.1/jquery.min.js"></script>
  <script src="https://maxcdn.bootstrapcdn.com/bootstrap/3.4.1/js/bootstrap.min.js"></script>
  <link rel="stylesheet" href="CSS/login.css">
  <link rel="stylesheet" href="CSS/header.css">
  <link rel="stylesheet" href="CSS/sidenav.css">
  <script src="/Js/loginScript.js"></script>    
</head>
<body>
<div class="header">
    <div class="jumbotron text-center">                        
          <h1>Tábla e-napló</h1>        
    </div>
  </div>
    
      

<div class="sidenav">
        <br><br><br><br><br><br><br><br>
        <a href="index.php">Kezdőlap</a>
        <a href="jegyek.php">Jegyek</a>
        <a href="hianyzasok.php">Hiányzások</a>
        <a href="uzenofal.php">Üzenőfal</a>        
    </div>

 
    <div class="main">
    <form method="post">
        <?php include('errors.php');?>
        <div class="input-group">
            <label>Felhasználónév</label>
            <input type="text" name="username">
        
        </div>
       
        <div class="input-group">
            <label>Jelszó</label>
            <input type="password" name="password">        
        </div>
       
        <div class="input-group">
            <button  type="submit" name="login" class="btn">Bejelentkezés</button>        
        </div>
    </form>
    </div>

      
</body>
</html>