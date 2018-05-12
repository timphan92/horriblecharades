import React from 'react';
import { StyleSheet, Text, View } from 'react-native';
// import * as signalR from '@aspnet/signalr';

const signalR = require('@aspnet/signalr');

export default class App extends React.Component {

componentWillMount () {
    let connection = new signalR.HubConnectionBuilder().withUrl("https://89f4f9c1.ngrok.io/gamehub").configureLogging(signalR.LogLevel.Information).build();
    
    // let connection = new signalR.HubConnection('/gamehub', { logger: signalR.LogLevel.Trance });
    // let connection = new signalR.HubConnectionBuilder().withUrl("http://localhost:5000/gamehub").configureLogging(signalR.LogLevel.Information).build();
    // connection.on("ReceiveMessage", (user, message) => { 
    //   console.log("receivemessage!");
    // });

    fetch('http://89f4f9c1.ngrok.io/gamehub/negotiate', { method: 'post' })
 .then(resp => resp.json())
 .then(data => console.log('test', data))
 .catch((err) => console.log('fail', err) );

 
    console.log("connection");
    console.log(connection);

    let val = 'http://89f4f9c1.ngrok.io/api/values';
    console.log(val);

    // let value = 'http://www.omdbapi.com/?t=hej';
    // console.log(value);

    // console.log("fetching omdb");
    // fetch(value)
    // .then(resp => console.log('success omdb', resp.json()))
    // .catch((err) => console.log('fail', err) );


    // console.log("fetching api");

    // fetch(val)
    // .then(resp => console.log('success api', resp.json()))
    // .catch((err) => console.log('fail', err) );


  // let x = "tim";
  // let u = "testuser";

  // connection.invoke("SendMessage", u, x).catch(err => console.error(err.toString()));

  connection.on("ReceiveMessage", (user, message) => { 
    console.log("WE INVOKED RECEIVEMESSAGE");
});
  connection.start().then(()=> connection.invoke("SendMessage", "hello", "tim") );
  }

  
  

  render() {

    return (
      <View style={styles.container}>
        <Text>Open up App.js to start working on your app!</Text>
        <Text>Tim</Text>
      </View>
    );
  }
}

const styles = StyleSheet.create({
  container: {
    flex: 1,
    backgroundColor: '#fff',
    alignItems: 'center',
    justifyContent: 'center',
  },
});
