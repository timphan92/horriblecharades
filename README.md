# horriblecharades

HorribleCharades with .NETCore, signalR, React-native

#Setup backend for dev
unix

* dotnet run, listening on localhost:5000.
* mongodb service should be on. Make sure you have created a user admin with password abc123!. Or change the mongo connectionstring.
* ngrok http 5000 (setup secure tunnel to localhost for API-tests with signalR)

#Setup frontend for dev
unix

* Expo on mobilephone
* yarn start
