import logo from './logo.svg';
import './App.css';
import { useState } from 'react';

const apiUrl = 'http://localhost:59191/api/students';

function App() {
  const [email, setEmail] = useState('asd');
  const [pass, setPass] = useState('asd');
  const [loggedIn, setShowLoggedIn] = useState(false);

  const btnLogin = () => {

    const partlyStudentDetailsLogin = { //pay attention case sensitive!!!! should be exactly as the prop in C#!
      Email: email,
      Password: pass,
    };

    fetch(apiUrl, {
      method: 'POST',
      body: JSON.stringify(partlyStudentDetailsLogin),
      headers: new Headers({
        'Content-type': 'application/json; charset=UTF-8', //very important to add the 'charset=UTF-8'!!!!
        'Accept': 'application/json; charset=UTF-8'
      })
    })
      .then(res => {
        console.log('res=', res);
        console.log('res.status ', res.status);
        console.log('res.ok ', res.ok);
        if (res.ok) {
          return res.json()
        }
        else
          return null;

      })
      .then(
        (result) => {
          console.log("fetch POST= ", result);
          if (result != null) {
            setShowLoggedIn(true);
          }
          else {
            setShowLoggedIn(false);
          }
        },
        (error) => {
          console.log("err post=", error);
        });
  }

  return (
    <div className="App">
      <header className="App-header">
        <img src={logo} className="App-logo" alt="logo" />
        Email: <input type="text" onChange={(text) => setEmail(text.target.value)} /> <br />
        Pass:<input type="password" onChange={(text) => setPass(text.target.value)} /> <br />
        <button onClick={btnLogin}>Login</button> <br />
        <div>u r {(loggedIn ? "" : "not")} logged in:)</div>
      </header>
    </div>
  );
}

export default App;
