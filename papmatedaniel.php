<?php
    // A fájl elérési útja
    $fajl = "szavazatok.txt";
    
    // Ellenőrizd, hogy létezik-e a fájl
    if (!file_exists($fajl)) {
        // Ha nem létezik, hozz létre egy alapértelmezett fájlt
        file_put_contents($fajl, "0||0||0||0");
    }

    // Beolvassuk a fájl tartalmát
    $content = file($fajl);
    $array = explode("||", trim($content[0])); // Az adatokat || alapján bontjuk

    // A változók inicializálása
    $bab = (int)$array[0];
    $gulyas = (int)$array[1];
    $para = (int)$array[2];
    $tojas = (int)$array[3];

    // Ha van szavazat, növeljük a megfelelő értéket
    if (isset($_POST['vote'])) {
        $vote = (int)$_POST['vote'];
        if ($vote == 0) {
            $bab++;
        } elseif ($vote == 1) {
            $gulyas++;
        } elseif ($vote == 2) {
            $para++;
        } elseif ($vote == 3) {
            $tojas++;
        }

        // Az új szavazatokat összefűzzük és elmentjük
        $insertvote = $bab . "||" . $gulyas . "||" . $para . "||" . $tojas;

        // A fájlba írás
        file_put_contents($fajl, $insertvote);

        if(!isset($_SESSION['ittjártam']))
        {
            print'<form action="" method="post" class="szavazodoboz">
            <h3>Mit választasz?</h3>
        
            <input type="radio" name="vote" value="0">Bableves <br>
            <input type="radio" name="vote" value="1">Gulyásleves <br>
            <input type="radio" name="vote" value="2">Paradicsomleves <br>
            <input type="radio" name="vote" value="3">Tojásleves <br>
        
            <input type="submit" value="szavazok" style="margin: 24px 0 0 24px;">
            </form>';
        } else {
            
        }
    }
?>
