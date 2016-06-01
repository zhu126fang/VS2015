<?php
   class MyDB extends SQLite3
   {
      function __construct()
      {
         $this->open('dir.db');
      }
   }
   $db = new MyDB();
   if(!$db){
      echo $db->lastErrorMsg();
   } else {
      echo "Opened database successfully\n<br/>";
   }

   $sql =<<<EOF
      SELECT * from dir;
EOF;

   $ret = $db->query($sql);
   while($row = $ret->fetchArray(SQLITE3_ASSOC) ){
      echo  $row['Name'] ."<br/>\n";
   }
   echo "Operation done successfully\n";
   $db->close();
?>
