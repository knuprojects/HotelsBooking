import './Login.css';

const Login = () => {
    return(
        <div className="center">
            <h1>Login</h1>
            <form method="post">
                <div className="txt_field">
                    <input type="text" required/>
                    <span></span>
                    <label>Email</label>
                </div>
                <div className="txt_field">
                    <input type="password" required/>
                    <span></span>
                    <label>Password</label>
                </div>
                <input type="submit" value="Login"/>
            </form>
        </div>
    );
}

export default Login