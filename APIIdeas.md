# Contacts Client Side

## Send

- addContact#username
- removeContact#username

## Receive

- updateOnlineContacts#username1`...

# Account Client Side

## Send

- login#username`password
    - server will respond with a login event true/false.
    - see Receive login event
    - server sends updateOnlineContacts with username
- logout#username
- createAccount#username`password

## Receive

- login#true/"error message"
- createAccount#true/"error message"


# Chatting

## Send

- initChat#username
    - username is the username of the person to chat with 
    - server will respond with initChat and chatroom ID
- sendMessage#chatroomID`username`time`message
- leaveChat#chatroomID,username

## Receive

- receiveMessages#message1`message2
- clientLeftChat#username

# Should we do proxies? Who knows, we don't


# Use Case Realizations

## Add a New Contact

 - The client will get the username to send from the applicable text box. That will then be sent to another class that will correctly format the string to send to the server. The client will then send the built string to the server and wait for a response. On the server side, the server will receive the formatted string and use the portion of the string up to the # symbol and run that portion through the state transition machine. Once the state transition machine directs the server to the correct method, in this case the method to add a contact to a client's list, the server then executes that method, adding the username, the portion of the formatted string after the # symbol, to the client's list of contacts, if the username is one that exists. IF it does, the server sends back a string to the client saying the process is completed. If the username does not exist, an applicable error message will be sent to the client. Back on the client side, the client will present a message box with information applicable to the string received from the server.

## Logout
 - The client that is being logged out will send a string containing its own username to the server that is built by a class that formats strings to be sent to the server. The server will then use the formatted string it got from the client as input for the state transition machine. Once the server realizes that a client is being logged out, it will then take the username and find all other clients that have that username in its contact list. It will then broadcast an event to all applicable contacts that the client is now offline. The server then sets the online status of that client to be offline.