import { useState, SyntheticEvent} from 'react';
import './Register.css';

const Register = () => {
   const [login, setLogin] = useState('');
   const [email, setEmail] = useState(''); 
   const [password, setPassword] = useState('');  

   const submit = async (e:SyntheticEvent) => {
        e.preventDefault();
        await fetch('https://localhost:44365/api/Identity/register', {
            method: 'POST',
            headers: {'Content-Type': 'application/json'},
            body: JSON.stringify({
                login,
                email,
                password
            })
        });

        // const content = await response.json();
        // console.log(content);
        // console.log({
        //     login,
        //     email,
        //     password
        // })
        
   };

    return(
        <div className="center">
            <h1>Register</h1>
            <form onSubmit={submit}>
                <div className="txt_field">
                    <input type="text" required onChange={e => setLogin(e.target.value)}/>
                    <span></span>
                    <label>Login</label>
                </div>
                <div className="txt_field">
                    <input type="text" required onChange={e => setEmail(e.target.value)}/>
                    <span></span>
                    <label>Email</label>
                </div>
                <div className="txt_field">
                    <input type="password" required onChange={e => setPassword(e.target.value)}/>
                    <span></span>
                    <label>Password</label>
                </div>
                <input type="submit" value="Register"/>
            </form>
        </div>
    );
}

export default Register