import './Login.css';
import { useState, SyntheticEvent} from 'react';

const Login = () => {
    const [email, setEmail] = useState(''); 
    const [password, setPassword] = useState('');
    
    const submit = async (e:SyntheticEvent) => {
        e.preventDefault();
        const response = await fetch('https://localhost:44365/api/Identity/login', {
            method: 'POST',
            headers: {'Content-Type': 'application/json'},
            body: JSON.stringify({
                email,
                password
            })
        });

        const content = await response.json();
        console.log(content);
        // console.log({
        //     login,
        //     email,
        //     password
        // })
        
   };

    return(
        <div className="center">
            <h1>Login</h1>
            <form onSubmit={submit}>
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
                <input type="submit" value="Login"/>
            </form>
        </div>
    );
}

export default Login