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
    <link rel="stylesheet" href="CSS/hianyzasok.css">
    <style>        

    
    </style>
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
        <table>
            <tr>
                <th>Dátum</th>
                <th>Tanár</th>
            </tr>

            <?php
            $sql = "SELECT hianyzasok.Datum, tanarok.Nev FROM hianyzasok INNER JOIN tanarok ON hianyzasok.TanarID = tanarok.ID INNER JOIN diakok ON hianyzasok.DiakID = hianyzasok.DiakID = diakok.ID WHERE diakok.logined=1 ORDER BY hianyzasok.Datum";
            $result = $db->query($sql);
            if ($result->num_rows > 0) {
                while ($row = $result->fetch_assoc()) {
                    echo "<tr><td>" . $row["Datum"] . "</td><td>" . $row["Nev"] . "</td></tr>";
                }
                echo "</table>";
            } else {
                echo "nincs eredmény";
            }
            $db->close();
            ?>
        </table>
    </div>



</body>

</html>